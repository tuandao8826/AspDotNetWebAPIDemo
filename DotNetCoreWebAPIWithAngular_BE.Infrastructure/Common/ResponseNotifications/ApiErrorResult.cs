using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCoreWebAPIWithAngular_BE.Infrastructure.Common.ResponseNotifications
{
    public class ApiErrorResult<T> : ApiResult<T>
    {
        public ApiErrorResult()
        {
            IsSuccessed = false;
        }

        public ApiErrorResult(string message)
        {
            IsSuccessed = false;
            Message = message;
        }

        public ApiErrorResult(T obj)
        {
            IsSuccessed = false;
            Obj = obj;
        }

        public ApiErrorResult(string message, T obj)
        {
            IsSuccessed = false;
            Message = message;
            Obj = obj;
        }
    }
}
