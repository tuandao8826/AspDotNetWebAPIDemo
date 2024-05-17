using DotNetCoreWebAPIWithAngular_BE.Infrastructure.Repositories.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCoreWebAPIWithAngular_BE.Infrastructure.UnitOfWork
{
    public interface IMyEntities
    {
        public IUserService UserService { get; set; }
        int SaveChange();
    }
}
