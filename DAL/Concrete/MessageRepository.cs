﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using DAL.Interface.Repository;
using DAL.Interface.DTO;
using DAL.Mappers;
using ORM;
using ORM.Entities;

namespace DAL.Concrete
{
    public class MessageRepository : IMessageRepository
    {
        private readonly SocialNetworkContext context;
        private readonly DbSet<Profile> profiles;
        private readonly DbSet<Message> messages;
        private readonly DbSet<Post> posts;

        public MessageRepository(SocialNetworkContext socialNetworkContext)
        {
            context = socialNetworkContext;
            profiles = socialNetworkContext.Profiles;
            messages = socialNetworkContext.Messages;
            posts = socialNetworkContext.Posts;
        }

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

        public void DeleteById(int id)
        {
            messages.Remove(messages.FirstOrDefault(m => m.Id == id));
        }

        public DalMessage GetById(int id)
        {
            return messages.FirstOrDefault(m => m.Id == id).ToDalMessage();
        }

        public IEnumerable<DalMessage> GetAll()
        {
            return messages.Include(m => m.ProfileFrom).Include(m => m.ProfileTo).Select(m => m).Map();
        }

        public DalMessage GetByPredicate(Expression<Func<DalMessage, bool>> f)
        {
            throw new NotImplementedException();
        }

        public void Update(DalMessage entity)
        {
            throw new NotImplementedException();
        }

        public List<DalMessage> GetMessages(int ProfileFrom, int ProfileTo)
        {
            return
                messages.Where(m => (m.ProfileFrom.Id == ProfileFrom && m.ProfileTo.Id == ProfileTo) || (m.ProfileFrom.Id == ProfileTo && m.ProfileTo.Id == ProfileFrom))
                    .OrderBy(m => m.Date)
                    .Map().ToList();
        }
    }
}