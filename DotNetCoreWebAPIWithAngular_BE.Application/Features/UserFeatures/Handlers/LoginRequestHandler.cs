using DotNetCoreWebAPIWithAngular_BE.Application.Features.UserFeatures.Models;
using DotNetCoreWebAPIWithAngular_BE.Entities.Entities;
using DotNetCoreWebAPIWithAngular_BE.Infrastructure.Common.ResponseNotifications;
using DotNetCoreWebAPIWithAngular_BE.Infrastructure.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCoreWebAPIWithAngular_BE.Application.Features.UserFeatures.Handlers
{
    internal class LoginRequestHandler : IRequestHandler<LoginRequest, ApiResult<User>>
    {
        private readonly IMyEntities _entities;

        public LoginRequestHandler(IMyEntities entities)
        {
            this._entities = entities;
        }

        public async Task<ApiResult<User>> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            var user = await _entities.UserService.Login(request.Email, request.Password);

            if (user == null)
                return new ApiErrorResult<User>("Thông tin tài khoản hoặc mật khẩu không chính xác.");

            return new ApiSuccessResult<User>("Đăng nhập thành công", user);
        }
    }
}
