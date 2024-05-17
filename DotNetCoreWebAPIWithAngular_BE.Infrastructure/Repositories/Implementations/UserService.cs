using DotNetCoreWebAPIWithAngular_BE.Entities.Entities;
using DotNetCoreWebAPIWithAngular_BE.Infrastructure.Common.ResponseNotifications;
using DotNetCoreWebAPIWithAngular_BE.Infrastructure.DBContext;
using DotNetCoreWebAPIWithAngular_BE.Infrastructure.Repositories.Services;

namespace DotNetCoreWebAPIWithAngular_BE.Infrastructure.Repositories.Implementations
{
    public class UserService : GenericService<User>, IUserService
    {
        private readonly WebAPIWithAngularDemoContext _context;

        public UserService(WebAPIWithAngularDemoContext context) : base(context) 
        {
            this._context = context;
        }

        public async Task<User?> Login(string email, string password)
        {
            return _context.Users.Where(u => u.Email == email && u.Password == password).FirstOrDefault();
        }
    }
}
