﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCoreWebAPIWithAngular_BE.Infrastructure.Common.ResponseNotifications
{
    public class ApiResult<T>
    {
        public bool IsSuccessed { get; set; }

        public string Message { get; set; } = string.Empty;

        public T? Obj { get; set; }
    }
}
