﻿using System.Data.Entity;
using DAL.Interface.Repository;
using ORM;

namespace DAL.Concrete
{
    /// <summary>
    /// Service class implements IUnitOfWork
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        public DbContext Context { get; private set; }
        public IUserRepository Users { get; set; }
        public IProfileRepository Profiles { get; set; }
        public IFileRepository Files { get; set; }
        public IMessageRepository Messages { get; set; }
        public IInviteRepository Invites { get; set; }
        public IPostRepository Posts { get; set; }
        public ILikeRepository Likes { get; set; }

        /// <summary>
        /// Create UnitOfWork Instance
        /// </summary>
        /// <param name="context">Db context</param>
        public UnitOfWork(DbContext context)
        {
            Context = context;
            Users = new UserRepository((SocialNetworkContext) context);
            Profiles = new ProfileRepository((SocialNetworkContext) context);
            Files = new FileRepository((SocialNetworkContext) context);
            Messages = new MessageRepository((SocialNetworkContext) context);
            Invites = new InviteRepository((SocialNetworkContext) context);
            Posts = new PostRepository((SocialNetworkContext) context);
            Likes = new LikeRepository((SocialNetworkContext) context);
        }

        /// <summary>
        /// Method for saving changes in db
        /// </summary>
        public void  Commit()
        {
            Context?.SaveChanges();
        }

        /// <summary>
        /// Dispose context
        /// </summary>
        public void Dispose()
        {
            Context?.Dispose();
        }
    }
}
