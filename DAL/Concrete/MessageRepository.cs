using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.Interface.Repository;
using DAL.Interface.DTO;
using DAL.Mappers;
using ORM;
using ORM.Entities;

namespace DAL.Concrete
{
    /// <summary>
    /// Message repository class implemets IMessageRepository
    /// </summary>
    public class MessageRepository : IMessageRepository
    {
        private readonly SocialNetworkContext context;
        private readonly DbSet<Profile> profiles;
        private readonly DbSet<Message> messages;
        private readonly DbSet<Post> posts;

        /// <summary>
        /// Create instance of MessageRepository 
        /// </summary>
        /// <param name="socialNetworkContext"></param>
        public MessageRepository(SocialNetworkContext socialNetworkContext)
        {
            context = socialNetworkContext;
            profiles = socialNetworkContext.Profiles;
            messages = socialNetworkContext.Messages;
            posts = socialNetworkContext.Posts;
        }

        /// <summary>
        /// Method for adding new message
        /// </summary>
        /// <param name="dalMessage"></param>
        public void Add(DalMessage dalMessage)
        {
            var message = dalMessage.ToMessage();
            var profileFrom = profiles.FirstOrDefault(p => p.Id == dalMessage.ProfileIdFrom);
            var profileTo = profiles.FirstOrDefault(p => p.Id == dalMessage.ProfileIdTo);
            var postTo = posts.FirstOrDefault(p => p.Id == dalMessage.PostId);
            message.ProfileFrom = profileFrom;
            message.ProfileTo = profileTo;
            message.PostTo = postTo;
            messages.Add(message);
        }

        /// <summary>
        /// Delete exist message by Id
        /// </summary>
        /// <param name="id">id of exist message</param>
        public void DeleteById(int id)
        {
            var message = messages.FirstOrDefault(m => m.Id == id);
            if (!ReferenceEquals(message, null))
            {
                messages.Remove(message);
            }
            else
            {
                throw new ArgumentNullException(nameof(message));
            }
        }

        /// <summary>
        /// Get message by Id
        /// </summary>
        /// <param name="id">Id of exist message</param>
        /// <returns>DalMessage entity</returns>
        public DalMessage GetById(int id)
        {
            return messages.FirstOrDefault(m => m.Id == id).ToDalMessage();
        }

        /// <summary>
        /// get All messages
        /// </summary>
        /// <returns>Collection of DalMessages</returns>
        public IEnumerable<DalMessage> GetAll()
        {
            return messages.Include(m => m.ProfileFrom).Include(m => m.ProfileTo).Select(m => m).Map();
        }

        /// <summary>
        /// Update exist message
        /// </summary>
        /// <param name="entity">exist DalMessage entity</param>
        public void Update(DalMessage entity)
        {
            var message = messages.FirstOrDefault(m => m.Id == entity.Id);
            if (!ReferenceEquals(message, null))
            {
                message.Id = entity.Id;
                message.Date = entity.Date;
                message.PostTo = posts.FirstOrDefault(p => p.Id == entity.PostId);
                message.ProfileFrom = profiles.FirstOrDefault(p => p.Id == entity.ProfileIdFrom);
                message.ProfileTo = profiles.FirstOrDefault(p => p.Id == entity.ProfileIdTo);
            }
            else
            {
                throw new ArgumentNullException(nameof(message));
            }
            context.Entry(message).State = EntityState.Modified;
        }

        /// <summary>
        /// Get Concrete messages with sender Id and destination Id
        /// </summary>
        /// <param name="profileFrom">sender Id</param>
        /// <param name="profileTo">destination Id</param>
        /// <returns>Collection of concrete messages</returns>
        public List<DalMessage> GetMessages(int profileFrom, int profileTo)
        {
            return
                messages.Where((m => (((m.ProfileFrom.Id == profileFrom && m.ProfileTo.Id == profileTo) 
                || (m.ProfileFrom.Id == profileTo && m.ProfileTo.Id == profileFrom))
                && (m.PostTo == null))))
                    .Select(m=>m)
                    .OrderBy(m => m.Date)
                    .Map().ToList();
        }

        /// <summary>
        /// Read mesage with Id
        /// </summary>
        /// <param name="id">Id of exist message</param>
        public void ReadMessage(int id)
        {
            var temp = messages.FirstOrDefault(m => m.Id == id);
            if (!ReferenceEquals(temp, null))
            {
                temp.IsRead = true;
            }
            else
            {
                throw new ArgumentNullException(nameof(temp));
            }           
            context.Entry(temp).State = EntityState.Modified;
        }

        /// <summary>
        /// Method for getting nums of all unread mesages by profile Id
        /// </summary>
        /// <param name="idProfile">Id of exist profile</param>
        /// <returns>nums of unread messages</returns>
        public int NumberOfUnreadMessage(int idProfile)
        {
            return messages.Count(m => (m.ProfileTo.Id==idProfile)&&(m.PostTo == null) && (m.IsRead == false));
        }
    }
}
