using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using BLL.Mappers;
using DAL.Interface.Repository;

namespace BLL.Services
{
    /// <summary>
    /// Service for work with Messages, implements IMessagesService
    /// </summary>
    public class MessageService:IMessageService
    {
        private readonly IUnitOfWork unitOfWork;

        /// <summary>
        /// Create MessageService instance
        /// </summary>
        /// <param name="uow">class which implements IUnitOfWork</param>
        public MessageService(IUnitOfWork uow)
        {
            unitOfWork = uow;
        }

        /// <summary>
        /// method to add new message
        /// </summary>
        /// <param name="message">new BllMessage</param>
        public void AddMessage(BllMessage message)
        {
            unitOfWork.Messages.Add(message.ToDalMessage());
            unitOfWork.Commit();
        }

        /// <summary>
        /// Method to get all messaages by Sender ID and destination Id
        /// </summary>
        /// <param name="UserFrom">Id of sender</param>
        /// <param name="UserTo">Id of destination</param>
        /// <returns>List of BllMessages</returns>
        public List<BllMessage> GetMessages(int UserFrom, int UserTo)
        {
            var temp = unitOfWork.Messages.GetMessages(UserFrom, UserTo);
            return temp.Map().ToList();
        }

        public bool IsUnreadMessageFromProfile(int id)
        {
            return unitOfWork.Messages.IsUnreadMessageFromProfile(id);
        }

        /// <summary>
        /// Method to get number of unread messages of concrete profile
        /// </summary>
        /// <param name="idProfile">Id of exist profile</param>
        /// <returns>number of unread message</returns>
        public int NumsOfUnreadMessage(int idProfile)
        {
           return unitOfWork.Messages.NumberOfUnreadMessage(idProfile);
        }

        /// <summary>
        /// Method to check message as IsRead
        /// </summary>
        /// <param name="id">Id of exist message</param>
        public void ReadMessage(int id)
        {
            unitOfWork.Messages.ReadMessage(id);
            unitOfWork.Commit();
        }      
    }
}
