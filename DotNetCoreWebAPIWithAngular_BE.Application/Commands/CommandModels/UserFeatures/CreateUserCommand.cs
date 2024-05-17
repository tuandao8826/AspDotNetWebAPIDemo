using DotNetCoreWebAPIWithAngular_BE.Infrastructure.Common.ResponseNotifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCoreWebAPIWithAngular_BE.Application.Commands.UserFeatures
{
    public class CreateUserCommand : IRequest<ApiResult<string>>
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string ConfirmPassword { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        
        public ApiResult<string> Valid()
        {
            string message = string.Empty;

            if (String.IsNullOrEmpty(Email))
            {
                message = "Vui lòng nhập Email.";
            }
            else if (String.IsNullOrEmpty(Password))
            {
                message = "Vui lòng nhập mật khẩu.";
            }
            else if (String.IsNullOrEmpty(ConfirmPassword))
            {
                message = "Vui lòng nhập xác nhận mật khẩu.";
            }
            else if (String.IsNullOrEmpty(FullName))
            {
                message = "Vui lòng nhập họ và tên.";
            }
            else if (!Password.Equals(ConfirmPassword))
            {
                message = "Mật khẩu xác nhận không chính xác.";
            } 
            else
            {
                return new ApiSuccessResult<string>();
            }

            return new ApiErrorResult<string>(message);
        }
    }
}
