using System.Collections.Generic;
using BLL.Interface.Entities;

namespace BLL.Interface.Services
{
    /// <summary>
    /// Interface for work with isers
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// method for adding new user
        /// </summary>
        /// <param name="user">new BllUser</param>
        void AddUser(BllUser user);

        /// <summary>
        /// Delete exist user
        /// </summary>
        /// <param name="user">exist BllUser</param>
        void DeleteUser(BllUser user);

        /// <summary>
        /// Method for updating exist user
        /// </summary>
        /// <param name="user">exist BllUser</param>
        void UpdateUser(BllUser user);

        /// <summary>
        /// Get All users
        /// </summary>
        /// <returns>Collection of BllUsers</returns>
        List<BllUser> GetAll();

        /// <summary>
        /// Get exist user by Id
        /// </summary>
        /// <param name="id">Id of exist user</param>
        /// <returns>concrete Blluser</returns>
        BllUser GetUser(int id);

        /// <summary>
        /// get exist user By Email
        /// </summary>
        /// <param name="email">contact email of exist user</param>
        /// <returns>concrete BllUser</returns>
        BllUser GetUserByEmail(string email);

        /// <summary>
        /// Mail confirmation of user with Email
        /// </summary>
        /// <param name="email">Email of exist user</param>
        void MailConfirm(string email);
    }
}
