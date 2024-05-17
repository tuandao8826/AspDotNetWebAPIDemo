using DotNetCoreWebAPIWithAngular_BE.Application.Queries.UserFeatures.Models;
using DotNetCoreWebAPIWithAngular_BE.Entities.Entities;
using DotNetCoreWebAPIWithAngular_BE.Infrastructure.Common.ResponseNotifications;
using DotNetCoreWebAPIWithAngular_BE.Infrastructure.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCoreWebAPIWithAngular_BE.Application.Queries.UserFeatures.Handlers
{
    internal class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, ApiResult<User>>
    {
        private readonly IMyEntities _entities;

        public GetUserByIdQueryHandler(IMyEntities entities)
        {
            this._entities = entities;
        }

        public async Task<ApiResult<User>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _entities.UserService.GetById(request.Id);

            if (user == null)
                return new ApiSuccessResult<User>("Người dùng không tồn tại.");
            else
                return new ApiSuccessResult<User>(user);
        }
    }
}
