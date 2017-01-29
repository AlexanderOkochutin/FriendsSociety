using System.Collections.Generic;
using BLL.Interface.Entities;

namespace BLL.Interface.Services
{
    /// <summary>
    /// Interface for work with Profiles
    /// </summary>
    public interface IProfileService
    {
        /// <summary>
        /// Method for getting concrete profile by Id
        /// </summary>
        /// <param name="id">Id of exist profile</param>
        /// <returns>concrete BllProfile</returns>
        BllProfile Get(int id);

        /// <summary>
        /// Method for Update exist profile
        /// </summary>
        /// <param name="profile">exist BllProfile</param>
        void Update(BllProfile profile);

        /// <summary>
        /// Method for getting concrete BllProfile by Email
        /// </summary>
        /// <param name="email">Email of exist BllPRofile</param>
        /// <returns>concrete BLLProfile</returns>
        BllProfile GetByUserEmail(string email);

        /// <summary>
        /// Method for searching profile by Name and address
        /// </summary>
        /// <param name="stringKey"> name string </param>
        /// <param name="city">address </param>
        /// <returns>Collection of Profiles</returns>
        IEnumerable<BllProfile> Find(string stringKey = "", string city = null);

        /// <summary>
        /// Method to check profile is your friend or not
        /// </summary>
        bool IsYourFriend(int idYour,int id);

        /// <summary>
        /// Get all friends profiles of exist profile
        /// </summary>
        /// <param name="id">Id of exist profile</param>
        /// <returns>Collection of BllProfiles</returns>
        IEnumerable<BllProfile> GetAllFriendsOfId(int id);
    }
}
