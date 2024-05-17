using DotNetCoreWebAPIWithAngular_BE.Application.Commands.UserFeatures;
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

namespace DotNetCoreWebAPIWithAngular_BE.Application.Commands.CommandHandlers.UserFeatures
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
                ApiResult<string> apiResult = request.Valid();

                // Validation
                if (apiResult.IsSuccessed == false)
                    return apiResult;

                // kiểm tra người dùng tồn tại
                //...

                // tạo người dùng
                var user = new User
                {
                    Email = request.Email,
                    Password = request.Password,
                    FullName = request.FullName,
                };

                apiResult = await _entities.UserService.Create(user);

                if (apiResult.IsSuccessed == false)
                    return apiResult;

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
