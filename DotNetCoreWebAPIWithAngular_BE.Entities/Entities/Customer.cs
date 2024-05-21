﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCoreWebAPIWithAngular_BE.Entities.Entities
{
    public class Customer : IdentityUser<Guid>
    {
        public string FullName { get; set; }
    }
}
