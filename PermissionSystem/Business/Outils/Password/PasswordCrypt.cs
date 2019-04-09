using CryptoHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PermissionSystem.Business.Outils.Password
{
    public class PasswordCrypt : IPasswordCrypt
    {
        // Method for hashing the password
        public string HashPassword(string password)
        {
            return Crypto.HashPassword(password);
        }

        // Method to verify the password hash against the given password
        public bool VerifyPassword(string hash, string password)
        {
            return Crypto.VerifyHashedPassword(hash, password);
        }
    }
}
