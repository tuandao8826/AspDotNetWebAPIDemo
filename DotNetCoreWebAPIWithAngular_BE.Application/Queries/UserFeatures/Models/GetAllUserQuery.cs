using DotNetCoreWebAPIWithAngular_BE.Entities.Entities;
using DotNetCoreWebAPIWithAngular_BE.Infrastructure.Common.ResponseNotifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCoreWebAPIWithAngular_BE.Application.Queries.UserFeatures.Models
{
    public class GetAllUserQuery : IRequest<ApiResult<List<User>>>
    {
    }
}
