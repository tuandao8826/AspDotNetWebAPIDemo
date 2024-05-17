using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCoreWebAPIWithAngular_BE.Infrastructure.Common.ResponseNotifications
{
    public class ApiSuccessResult<T> : ApiResult<T>
    {
        public ApiSuccessResult()
        {
            IsSuccessed = true;
        }

        public ApiSuccessResult(string message)
        {
            IsSuccessed = true;
            Message = message;
        }

        public ApiSuccessResult(T obj)
        {
            IsSuccessed = true;
            Obj = obj;
        }

        public ApiSuccessResult(string message, T obj)
        {
            IsSuccessed = true;
            Message = message;
            Obj = obj;
        }
    }
}
