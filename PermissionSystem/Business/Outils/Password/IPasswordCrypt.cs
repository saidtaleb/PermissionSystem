using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PermissionSystem.Business.Outils.Password
{
    public interface IPasswordCrypt
    {
        string HashPassword(string password);
        bool VerifyPassword(string hash, string password);
    }
}
