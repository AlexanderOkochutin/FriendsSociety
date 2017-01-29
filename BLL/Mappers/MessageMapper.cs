using System.Collections.Generic;
using BLL.Interface.Entities;
using DAL.Interface.DTO;

namespace BLL.Mappers
{
    /// <summary>
    /// Service class for mapping DalMessage and BllMessage Entities
    /// </summary>
    public static class MessageMapper
    {
        /// <summary>
        /// Method map To BllMessage
        /// </summary>
        /// <returns>new BllMessage the same as DalMessage</returns>
        public static BllMessage ToBllMessage(this DalMessage dalMessage)
        {
            if (ReferenceEquals(dalMessage, null)) return null;
            var bllMessage = new BllMessage()
            {
                Id = dalMessage.Id,
                Date = dalMessage.Date,
                PostId = dalMessage.PostId,
                IsRead = dalMessage.IsRead,
                Text = dalMessage.Text,
                ProfileIdFrom = dalMessage.ProfileIdFrom,
                ProfileIdTo = dalMessage.ProfileIdTo
            };
            return bllMessage;
        }

        /// <summary>
        /// Method map to DalMessage
        /// </summary>
        /// <returns>new DalMessage the same as BllMessage</returns>
        public static DalMessage ToDalMessage(this BllMessage bllMessage)
        {
            if (ReferenceEquals(bllMessage, null)) return null;
            var dalMessage = new DalMessage()
            {
                Id = bllMessage.Id,
                Date = bllMessage.Date,
                PostId = bllMessage.PostId,
                IsRead = bllMessage.IsRead,
                Text = bllMessage.Text,
                ProfileIdFrom = bllMessage.ProfileIdFrom,
                ProfileIdTo = bllMessage.ProfileIdTo
            };
            return dalMessage;
        }

        /// <summary>
        /// Method map To BllMessages
        /// </summary>
        /// <returns>new BllMessages collection same as DalMessages collection</returns>
        public static IEnumerable<BllMessage> Map(this IEnumerable<DalMessage> dalMessages)
        {
            var bllMessages = new List<BllMessage>();
            foreach (var dalMessage in dalMessages)
            {
                bllMessages.Add(dalMessage.ToBllMessage());
            }
            return bllMessages;
        }
    }
}
