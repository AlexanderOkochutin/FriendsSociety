using System;

namespace DAL.Interface.Repository
{
    /// <summary>
    /// Interface Unit of Work pattern
    /// </summary>
    public interface IUnitOfWork:IDisposable
    {
        /// <summary>
        /// Users collection
        /// </summary>
        IUserRepository Users { get; set; }

        /// <summary>
        /// Profiles collection
        /// </summary>
        IProfileRepository Profiles { get; set; }

        /// <summary>
        /// Files collection
        /// </summary>
        IFileRepository Files { get; set; }

        /// <summary>
        /// Messages collection
        /// </summary>
        IMessageRepository Messages { get; set; }

        /// <summary>
        /// Invites collection
        /// </summary>
        IInviteRepository Invites { get; set; }

        /// <summary>
        /// Posts collection
        /// </summary>
        IPostRepository Posts { get; set; }

        /// <summary>
        /// Likes collection
        /// </summary>
        ILikeRepository Likes { get; set; }

        /// <summary>
        /// Method for saving changes in database
        /// </summary>
        void Commit();
    }
}
