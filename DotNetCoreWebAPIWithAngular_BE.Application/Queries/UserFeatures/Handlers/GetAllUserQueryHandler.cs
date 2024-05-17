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
    public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, ApiResult<List<User>>>
    {
        private readonly IMyEntities _entities;

        public GetAllUserQueryHandler(IMyEntities entities)
        {
            this._entities = entities;
        } 

        public async Task<ApiResult<List<User>>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            var users = await _entities.UserService.GetAll();

            return new ApiSuccessResult<List<User>>(users);
        }
    }
}
