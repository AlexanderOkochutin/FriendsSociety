using System.Collections.Generic;
using System.Linq;
using DAL.Interface.DTO;
using ORM.Entities;

namespace DAL.Mappers
{
    /// <summary>
    /// Service class for mapping DalMessage and ORM message entities
    /// </summary>
    public static class MessageMapper
    {
        /// <summary>
        /// Map To Message
        /// </summary>
        /// <returns>new ORM Message entity same as dalMessage</returns>
        public static Message ToMessage(this DalMessage message)
        {
            if (ReferenceEquals(message, null)) return null;
            Message result = new Message()
            {
                Id = message.Id,
                Date = message.Date,
                Text = message.Text,
                IsRead = message.IsRead,
            };
            return result;
        }

        /// <summary>
        /// Map To DalMessage
        /// </summary>
        /// <returns>new DalMessage entity same as ORM message</returns>
        public static DalMessage ToDalMessage(this Message message)
        {
            if (ReferenceEquals(message, null)) return null;
            DalMessage result = new DalMessage()
            {
                Id = message.Id,
                Date = message.Date,
                Text = message.Text,
                ProfileIdFrom = message.ProfileFrom.Id,
                ProfileIdTo = message.ProfileTo.Id,
                PostId = message.PostTo?.Id??0,
                IsRead = message.IsRead
            };
            return result;
        }

        /// <summary>
        /// Map To DalMessages
        /// </summary>
        /// <returns>new DalMessage collection same as ORM messages</returns>
        public static IEnumerable<DalMessage> Map(this IQueryable<Message> messages)
        {
            var dalMessages = new List<DalMessage>();
            foreach (var item in messages)
            {
                dalMessages.Add(item.ToDalMessage());
            }
            return dalMessages;
        }
    }
}
