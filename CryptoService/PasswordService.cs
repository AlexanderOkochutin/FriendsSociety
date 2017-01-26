using System;
using System.Security.Cryptography;
using System.Text;
using ICryptoService;

namespace CryptoService
{
    /// <summary>
    /// Custom realization of Password service
    /// </summary>
    public class PasswordService : IPasswordService
    {
        /// <summary>
        /// BYte length of salt
        /// </summary>
        private int SaltLength = 128;

        /// <summary>
        /// Method for getting random salt
        /// </summary>
        /// <returns></returns>
        public string GetSalt()
        {
            var cryptoService = new RNGCryptoServiceProvider();
            var saltBytes = new byte[SaltLength];
            cryptoService.GetNonZeroBytes(saltBytes);
            return Encoding.Unicode.GetString(saltBytes);
        }

        /// <summary>
        /// Get hash of pass and salt concatanation
        /// </summary>
        /// <param name="password"> string of user pass</param>
        /// <param name="salt">string of user salt</param>
        /// <returns>hash of pass and salt concatanation</returns>
        public string GetHash(string password, string salt)
        {
            var bytes = Encoding.Unicode.GetBytes(password + salt);
            var hashed = MD5.Create().ComputeHash(bytes);
            return Encoding.Unicode.GetString(hashed);
        }

        /// <summary>
        /// Verify user's password
        /// </summary>
        /// <param name="password">input password from authentication form</param>
        /// <param name="salt">salt from database for this user</param>
        /// <param name="hash">hash from database for this user</param>
        /// <returns></returns>
        public bool VerifyPassword(string password, string salt, string hash)
        {
            return hash == GetHash(password, salt);
        }
    }
}
