using DotNetCoreWebAPIWithAngular_BE.Entities.Entities;
using DotNetCoreWebAPIWithAngular_BE.Infrastructure.Common.ResponseNotifications;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCoreWebAPIWithAngular_BE.Infrastructure.Filters
{
    public class AuthorizeAttribute : TypeFilterAttribute
    {
        public AuthorizeAttribute() : base(typeof(DemoAuthorizeActionFilter))
        {
        }
    }

    public class DemoAuthorizeActionFilter : IAsyncAuthorizationFilter
    {
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var identity = context.HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var userClaims = identity.Claims;

                var user = new User
                {
                    Id = Guid.Parse(userClaims.FirstOrDefault(x => x.Type == ClaimTypes.PrimarySid)?.Value ?? Guid.Empty.ToString()),
                    Email = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value.ToString(),
                    FullName = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value.ToString(),
                };

                if (user.Id == Guid.Empty)
                {
                    context.HttpContext.Response.ContentType = "application/json";
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    context.Result = new JsonResult(new ApiErrorResult<string>("Bạn không có quyền truy cập vào chức năng này!"));

                    return;
                }
            }
        }
    }
}
