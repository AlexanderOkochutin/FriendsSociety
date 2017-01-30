using System.Collections.Generic;
using BLL.Interface.Entities;

namespace BLL.Interface.Services
{
    /// <summary>
    /// Interface for work with messages
    /// </summary>
    public interface IMessageService
    {
        /// <summary>
        /// method for adding new message
        /// </summary>
        /// <param name="message">new BllMessage</param>
        void AddMessage(BllMessage message);

        /// <summary>
        /// Method to check message as IsRead
        /// </summary>
        /// <param name="id">Id of exist message</param>
        void ReadMessage(int id);

        /// <summary>
        /// Get All messages by sender Id and Destination Id
        /// </summary>
        /// <param name="UserFrom">Sender Id</param>
        /// <param name="UserTo">Destination Id</param>
        /// <returns>Collection of BllMessages</returns>
        List<BllMessage> GetMessages(int UserFrom, int UserTo);

        /// <summary>
        /// Method for get number of unread messages by profile ID
        /// </summary>
        /// <param name="idProfile">Id of exist Profile</param>
        /// <returns>number of unread message</returns>
        int NumsOfUnreadMessage(int idProfile);

        bool IsUnreadMessageFromProfile(int id);
    }
}
