using PermissionSystem.Business.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PermissionSystem.Business.Models
{
    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class LoginResponseModel
    {
        public string Token { get; set; }
        public StatutResponseLogin Statut { get; set; }
    }
}
