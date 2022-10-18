﻿using Application.Repositories;
using Domain.Entities;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class UserReadRepository : ReadRepository<User> , IUserReadRepository
    {
        public UserReadRepository(BlogDbContext context) : base(context)
        {

        }
    }
}
