﻿using Application.DataTransferObject;
using Application.Repositories;
using Application.Services.Token;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Services.Token
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly IUserReadRepository _userReadRepository;

        public TokenService(IConfiguration configuration, IUserReadRepository userReadRepository)
        {
            _configuration = configuration;
            _userReadRepository = userReadRepository;
        }
        public async Task<JWTToken> generateToken(User user)
        {
            JWTToken jwtToken = new();

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Role , user.role),
                new Claim(ClaimTypes.Name , user.firstName),
            };
            
               
            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));
            
            var creds = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);

            JwtSecurityToken securityToken = new(
                claims: claims,
                expires: DateTime.UtcNow.AddDays(7),
                signingCredentials: creds
            );

            JwtSecurityTokenHandler tokenHandler = new();
            jwtToken.AccessToken = tokenHandler.WriteToken(securityToken);
            return jwtToken;
        }
    }
}
