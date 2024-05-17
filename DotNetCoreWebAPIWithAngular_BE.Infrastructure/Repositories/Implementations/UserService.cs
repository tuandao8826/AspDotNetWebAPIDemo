using DotNetCoreWebAPIWithAngular_BE.Entities.Entities;
using DotNetCoreWebAPIWithAngular_BE.Infrastructure.Common.ResponseNotifications;
using DotNetCoreWebAPIWithAngular_BE.Infrastructure.DBContext;
using DotNetCoreWebAPIWithAngular_BE.Infrastructure.Repositories.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCoreWebAPIWithAngular_BE.Infrastructure.Repositories.Implementations
{
    public class UserService : GenericService<User>, IUserService
    {
        private IConfiguration _configuration;
        private readonly WebAPIWithAngularDemoContext _context;

        public UserService(WebAPIWithAngularDemoContext context, IConfiguration configuration) : base(context) 
        {
            this._configuration = configuration;
            this._context = context;
        }

        public async Task<User?> Login(string email, string password)
        {
            return _context.Users.Where(u => u.Email == email && u.Password == password).FirstOrDefault();
        }

        public JwtSecurityToken CreateToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
            _ = int.TryParse(_configuration["JWT:TokenValidityInMinutes"], out int tokenValidityInMinutes);

            var token = new JwtSecurityToken
            (
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddMinutes(tokenValidityInMinutes),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            return token;
        }
    }
}
