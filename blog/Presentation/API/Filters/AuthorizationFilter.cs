using Application.Services.Token;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;

namespace API.Filters
{
    public class AuthorizationFilter : IAsyncActionFilter
    {
        private readonly ITokenService _tokenService;
        public AuthorizationFilter(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }
    
        public Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var token = context.HttpContext.Request.Headers["Authorization"].ToString();
            return null;
        }
    }
}
