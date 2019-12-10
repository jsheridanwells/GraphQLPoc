using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GQL.UserService.Utilities
{
    public static class PasswordManager
    {
        public static void EncryptPassword(string password, out byte[] hash, out byte[] salt)
        {
            if (password == null || string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Password cannot be blank.");

            using (var hmac = new HMACSHA512())
            {
                var encodedPassword = Encoding.UTF8.GetBytes(password);
                hash = hmac.ComputeHash(encodedPassword);
                salt = hmac.Key;
            }
        }

        public static bool VerifyPassword(string password, byte[] hash, byte[] salt)
        {
            if (password == null || string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Password cannot be blank");

            using (var hmac = new HMACSHA512(salt))
            {
                byte[] passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < passwordHash.Length; i++)
                {
                    if (hash[i] != passwordHash[i])
                        return false;
                }
            }
            return true;
        }
    }
}
