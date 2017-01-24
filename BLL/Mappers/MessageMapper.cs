using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;
using DAL.Interface.DTO;

namespace BLL.Mappers
{
    public static class MessageMapper
    {
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
