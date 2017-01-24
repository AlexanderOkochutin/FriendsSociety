using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.Repository;
using ORM;

namespace DAL.Concrete
{
    class UnitOfWork : IUnitOfWork
    {
        public DbContext Context { get; private set; }
        public IUserRepository Users { get; set; }
        public IProfileRepository Profiles { get; set; }
        public IFileRepository Files { get; set; }
        public IMessageRepository Messages { get; set; }
        public IInviteRepository Invites { get; set; }
        public IPostRepository Posts { get; set; }
        public ILikeRepository Likes { get; set; }

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

        public void Commit()
        {
            Context?.SaveChanges();
        }

        public void Dispose()
        {
            Context?.Dispose();
        }
    }
}
