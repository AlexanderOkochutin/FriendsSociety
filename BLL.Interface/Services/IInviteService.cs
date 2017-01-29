using System.Collections.Generic;
using BLL.Interface.Entities;

namespace BLL.Interface.Services
{
    /// <summary>
    /// Interface for work with Invites
    /// </summary>
    public interface IInviteService
    {
        /// <summary>
        /// Method to check Is invite sended or not
        /// </summary>
        /// <param name="idFrom">sender Id</param>
        /// <param name="idTo">Destination Id</param>
        bool IsInviteSend(int idFrom, int idTo);

        /// <summary>
        /// Method for sending new invite 
        /// </summary>
        /// <param name="idFrom">sender Id</param>
        /// <param name="idTo">destination Id</param>
        void SendInvite(int idFrom, int idTo);

        /// <summary>
        /// Method make profile1 friend of profile2 
        /// </summary>
        /// <param name="idFrom">Id of exist profile1</param>
        /// <param name="idTo">Id of exist profile2</param>
        void AddFriend(int idFrom, int idTo);

        /// <summary>
        /// Delete friendship of two profiles
        /// </summary>
        /// <param name="id1">Id of exist profile1</param>
        /// <param name="id2">Id of exist profiel2</param>
        void DeleteFriend(int id1, int id2);

        /// <summary>
        /// Method to refuse friend invite
        /// </summary>
        /// <param name="idFrom">sender Id of profile</param>
        /// <param name="idTo">destination Id of profile</param>
        void RefuseInvite(int idFrom, int idTo);
        
        /// <summary>
        /// Method for getting all invites to concrete profile
        /// </summary>
        /// <param name="idTo">Id of exist profile</param>
        /// <returns>Collection of BllProfiles</returns>
        IEnumerable<BllProfile> GetAllInviteProfiles(int idTo);
    }
}
