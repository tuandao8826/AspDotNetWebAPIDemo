using DotNetCoreWebAPIWithAngular_BE.Entities.Entities;
using DotNetCoreWebAPIWithAngular_BE.Infrastructure.Common.ResponseNotifications;
using DotNetCoreWebAPIWithAngular_BE.Infrastructure.DBContext;
using DotNetCoreWebAPIWithAngular_BE.Infrastructure.Repositories.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCoreWebAPIWithAngular_BE.Infrastructure.Repositories.Implementations
{
    public class UserService : GenericService<User>, IUserService
    {
        public UserService(WebAPIWithAngularDemoContext context) : base(context) { }
    }
}
