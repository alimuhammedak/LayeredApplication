using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            // HMACSHA512 is a type of algorithm
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                // passwordSalt is a random key
                passwordSalt = hmac.Key;
                // passwordHash is the hashed password
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            // HMACSHA512 is a type of algorithm
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                // passwordHash is the hashed password
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                // If the computedHash is equal to the passwordHash, return true
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
