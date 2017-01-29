using System.Collections.Generic;
using System.Linq;
using DAL.Interface.DTO;
using ORM.Entities;

namespace DAL.Mappers
{
    public static class MessageMapper
    {
        /// <summary>
        /// Map User
        /// </summary>
        /// <param name="user"></param>
        /// <returns>new ORM User entity same as user</returns>
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
        /// Map User
        /// </summary>
        /// <param name="user"></param>
        /// <returns>new DalUser entity same as user</returns>
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
        /// Map users
        /// </summary>
        /// <param name="users"></param>
        /// <returns>new DalUser collection same as users</returns>
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
