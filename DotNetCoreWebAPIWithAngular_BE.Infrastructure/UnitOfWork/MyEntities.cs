using DotNetCoreWebAPIWithAngular_BE.Infrastructure.DBContext;
using DotNetCoreWebAPIWithAngular_BE.Infrastructure.Repositories.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCoreWebAPIWithAngular_BE.Infrastructure.UnitOfWork
{
    internal class MyEntities : IMyEntities
    {
        private WebAPIWithAngularDemoContext _context;
        public IUserService UserService { get; set; }

        public MyEntities(WebAPIWithAngularDemoContext context, IUserService userService)
        {
            this._context = context;
            this.UserService = userService;
        }

        public int SaveChange()
        {
            return _context.SaveChanges();
        }
    }
}
