using DotNetCoreWebAPIWithAngular_BE.Infrastructure.Repositories.Implementations;
using DotNetCoreWebAPIWithAngular_BE.Infrastructure.Repositories.Services;
using DotNetCoreWebAPIWithAngular_BE.Infrastructure.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCoreWebAPIWithAngular_BE.Infrastructure.Extensions
{
    public static class AddRepositoriesExtensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IMyEntities, MyEntities>();
            services.AddTransient<IUserService, UserService>();
        }
    }
}
