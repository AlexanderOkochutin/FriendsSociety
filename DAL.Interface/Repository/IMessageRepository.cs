using System.Collections.Generic;
using DAL.Interface.DTO;

namespace DAL.Interface.Repository
{
    /// <summary>
    /// Expand of IRepository interface for  operations with DalMessages
    /// </summary>
    public interface IMessageRepository:IRepository<DalMessage>
    {
        /// <summary>
        /// get all DalMessages with Sender ID and destination ID
        /// </summary>
        /// <param name="profileIdFrom">Sender Id</param>
        /// <param name="profileIdTo">Destination Id</param>
        List<DalMessage> GetMessages(int profileIdFrom, int profileIdTo);

        /// <summary>
        /// Return nums of unread message(needs for notifications on PL)
        /// </summary>
        /// <param name="idProfile">profile Id</param>
        int NumberOfUnreadMessage(int idProfile);

        /// <summary>
        /// Method for read message with Id
        /// </summary>
        /// <param name="id">Id of message</param>
        void ReadMessage(int id);
    }
}
