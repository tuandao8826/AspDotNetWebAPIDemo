using DotNetCoreWebAPIWithAngular_BE.Application.DTOs.UserFeatures.Reponses;
using DotNetCoreWebAPIWithAngular_BE.Application.Features.UserFeatures.Models;
using DotNetCoreWebAPIWithAngular_BE.Entities.Entities;
using DotNetCoreWebAPIWithAngular_BE.Infrastructure.Common.ResponseNotifications;
using DotNetCoreWebAPIWithAngular_BE.Infrastructure.UnitOfWork;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCoreWebAPIWithAngular_BE.Application.Features.UserFeatures.Handlers
{
    internal class LoginRequestHandler : IRequestHandler<LoginRequest, ApiResult<LoginReponse>>
    {
        private readonly IMyEntities _entities;
        private readonly IConfiguration _configuration;

        public LoginRequestHandler(IMyEntities entities, IConfiguration configuration)
        {
            this._configuration = configuration;
            this._entities = entities;
        }

        public async Task<ApiResult<LoginReponse>> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            try
            {
                // Bước 1: Login
                var user = await _entities.UserService.Login(request.Email, request.Password);

                if (user == null)
                    return new ApiErrorResult<LoginReponse>("Thông tin tài khoản hoặc mật khẩu không chính xác.");

                // Bước 2: Tạo claim
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.PrimarySid, user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Name, user.FullName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                // Bước 3: Tạo Token
                var newAccessToken = CreateToken(authClaims);
                var token = new JwtSecurityTokenHandler().WriteToken(newAccessToken);

                // Bước 4: Tạo refesh token 
                var refreshToken = GenerateRefreshToken();

                // Bước 5: Cập nhật RefeshToken vào Database
                var expired = _configuration["JWT:RefreshTokenValidityInDays"] ?? "";
                user.RefeshToken = refreshToken;
                user.RefeshTokenExpired = DateTime.Now.AddDays(Convert.ToInt32(expired));
                _entities.UserService.Update(user);

                // Trả kết quả
                var reponse = new LoginReponse
                {
                    Email = user.Email,
                    FullName = user.FullName,
                    Token = token,
                    RefeshToken = refreshToken,
                };

                // Save Database
                _entities.SaveChange();

                return new ApiSuccessResult<LoginReponse>("Đăng nhập thành công", reponse);
            }
            catch
            {
                return new ApiErrorResult<LoginReponse>("Lỗi hệ thống");
            }
        }

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
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
