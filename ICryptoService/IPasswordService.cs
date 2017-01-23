namespace ICryptoService
{
    /// <summary>
    /// Interface for classes with crypto functionality
    /// </summary>
    public interface IPasswordService
    {
        /// <summary>
        /// Hashing key
        /// </summary>
        string GetSalt();

        /// <summary>
        /// Get hashed password
        /// </summary>
        /// <param name="password"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        string GetHash(string password, string salt);

        /// <summary>
        /// Check input password
        /// </summary>
        /// <param name="password"></param>
        /// <param name="key"></param>
        /// <param name="hash"></param>
        /// <returns></returns>
        bool VerifyPassword(string password, string salt, string hash);
    }
}
