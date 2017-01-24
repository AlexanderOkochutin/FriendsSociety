using System;

namespace DAL.Interface.Repository
{
    public interface IUnitOfWork:IDisposable
    {
        IUserRepository Users { get; set; }
        IProfileRepository Profiles { get; set; }
        IFileRepository Files { get; set; }
        IMessageRepository Messages { get; set; }
        IInviteRepository Invites { get; set; }
        IPostRepository Posts { get; set; }
        ILikeRepository Likes { get; set; }
        void Commit();
    }
}
