using Application.Repositories;
using Application.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories;
using Persistence.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            #region Connection String
            services.AddDbContext<BlogDbContext>(options => options.UseNpgsql(Configuration.ConnectionString));
            #endregion

            #region Repository Registration
            services.AddScoped<IUserWriteRepository, UserWriteRepository>();
            services.AddScoped<IUserReadRepository, UserReadRepository>();
            #endregion

            #region Service Registration
            services.AddScoped<IUserService, UserService>();
            #endregion
        }
    }
}
