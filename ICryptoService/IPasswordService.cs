namespace ICryptoService
{
    /// <summary>
    /// Interface for classes with crypto functionality
    /// </summary>
    public interface IPasswordService
    {
        /// <summary>
        /// Get random salt
        /// </summary>
        string GetSalt();

        /// <summary>
        /// Get hashed password
        /// </summary>
        /// <param name="password">user password</param>
        /// <param name="key">user password salt</param>
        /// <returns></returns>
        string GetHash(string password, string salt);

        /// <summary>
        /// Check input password
        /// </summary>
        /// <param name="password">input password</param>
        /// <param name="salt">user salt</param>
        /// <param name="hash">user password hash</param>
        /// <returns></returns>
        bool VerifyPassword(string password, string salt, string hash);
    }
}
