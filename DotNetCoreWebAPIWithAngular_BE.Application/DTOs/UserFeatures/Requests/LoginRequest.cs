using DotNetCoreWebAPIWithAngular_BE.Application.DTOs.UserFeatures.Reponses;
using DotNetCoreWebAPIWithAngular_BE.Infrastructure.Common.ResponseNotifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCoreWebAPIWithAngular_BE.Application.Features.UserFeatures.Models
{
    public class LoginRequest : IRequest<ApiResult<LoginReponse>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
