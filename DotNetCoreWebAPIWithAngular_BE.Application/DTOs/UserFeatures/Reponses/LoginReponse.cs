using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCoreWebAPIWithAngular_BE.Application.DTOs.UserFeatures.Reponses
{
    public class LoginReponse
    {
        public string? Email { get; set; }
        public string? FullName { get; set; }
        public string? Token { get; set; }
        public string? RefeshToken { get; set; }
    }
}
