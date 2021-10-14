using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace BlaAndCamping.Security
{
    public class BAEncryption
    {
        private int HashInterations = 10000;
        private int HashSize = 128;

        private int AuthTokenSize = 128;

        public string HashPassword(string password, byte[] salt)
        {

            using (var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, salt, HashInterations))
            {
                return Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(HashSize));
            }
        }

        public string HashAccessToken(string token)
        {
            using (HashAlgorithm algorithm = SHA256.Create())
                return Convert.ToBase64String(algorithm.ComputeHash(Encoding.UTF8.GetBytes(token)));
        }

        public string GenerateEmailActivationString()
        {
            Random random = new Random();
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            return new string(Enumerable.Repeat(chars, 64)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public string GenerateBase64Accesstoken()
        {
            var tokenBytes = new byte[AuthTokenSize];

            using (var provider = new RNGCryptoServiceProvider())
            {
                provider.GetNonZeroBytes(tokenBytes);
            }

            return Convert.ToBase64String(tokenBytes);
        }

        public byte[] GenerateSalt()
        {
            /*
             RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create();
             byte[] salt = new byte[128];
             randomNumberGenerator.GetBytes(salt);
            */

            var saltBytes = new byte[HashSize];

            using (var provider = new RNGCryptoServiceProvider())
            {
                provider.GetNonZeroBytes(saltBytes);
            }

            return saltBytes;
        }
    }
}