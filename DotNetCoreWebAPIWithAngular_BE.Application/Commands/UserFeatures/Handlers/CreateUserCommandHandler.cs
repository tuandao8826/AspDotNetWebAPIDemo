using DotNetCoreWebAPIWithAngular_BE.Application.Commands.UserFeatures;
using DotNetCoreWebAPIWithAngular_BE.Application.Commands.UserFeatures.Models;
using DotNetCoreWebAPIWithAngular_BE.Entities.Entities;
using DotNetCoreWebAPIWithAngular_BE.Infrastructure.Common.ResponseNotifications;
using DotNetCoreWebAPIWithAngular_BE.Infrastructure.Repositories.Services;
using DotNetCoreWebAPIWithAngular_BE.Infrastructure.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCoreWebAPIWithAngular_BE.Application.Commands.UserFeatures.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ApiResult<string>>
    {
        private readonly IMyEntities _entities;

        public CreateUserCommandHandler(IMyEntities entities)
        {
            this._entities = entities;
        }

        public async Task<ApiResult<string>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Kiểm tra thông tin vào
                string message;
                if (request.Valid(out message) == false)
                    return new ApiSuccessResult<string>(message);

                // kiểm tra người dùng tồn tại
                //...

                // tạo người dùng
                var user = new User
                {
                    Email = request.Email,
                    Password = request.Password,
                    FullName = request.FullName,
                };

                _entities.UserService.Create(user);

                _entities.SaveChange();

                return new ApiSuccessResult<string>("Chúc mừng bạn đã đăng ký thành công.");
            }
            catch 
            {
                return new ApiErrorResult<string>("Lỗi hệ thống, vui lòng thử lại sau.");
            }
        }
    }
}
