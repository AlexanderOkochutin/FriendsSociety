using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.Interface.DTO;
using DAL.Interface.Repository;
using DAL.Mappers;
using ORM;
using ORM.Entities;

namespace DAL.Concrete
{

    #region Not use in current build

    /// <summary>
    /// LikeRepository class implements ILikeRepositiry
    /// </summary>
    public class LikeRepository : ILikeRepository
    {
        private readonly SocialNetworkContext context;
        private readonly DbSet<Profile> profiles;
        private readonly DbSet<Post> posts;
        private readonly DbSet<Like> likes;

        /// <summary>
        /// Create LikeRepository instance
        /// </summary>
        public LikeRepository(SocialNetworkContext context)
        {
            this.context = context;
            profiles = context.Set<Profile>();
            posts = context.Set<Post>();
            likes = context.Set<Like>();
        }

        /// <summary>
        /// Method for adding new like
        /// </summary>
        public void Add(DalLike entity)
        {
            var like = new Like()
            {
                Id = entity.Id,
                Post = posts.FirstOrDefault(p => p.Id == entity.PostId),
                ProfileFrom = profiles.FirstOrDefault(p => p.Id == entity.ProfileFromId)
            };
            likes.Add(like);
        }

        /// <summary>
        /// Delete exist like by Id
        /// </summary>
        public void DeleteById(int id)
        {
            var like = likes.FirstOrDefault(l => l.Id == id);
            if (!ReferenceEquals(like, null))
            {
                likes.Remove(like);
            }
            else
            {
                throw new ArgumentNullException(nameof(like));
            }
        }

        /// <summary>
        /// Get all Likes
        /// </summary>
        /// <returns>collection of DalLikes</returns>
        public IEnumerable<DalLike> GetAll()
        {
            return likes.Select(l => l).Map();
        }

        /// <summary>
        /// Get exist like by Id
        /// </summary>
        /// <param name="id">Id of exist DalLike</param>
        /// <returns>exist dalLike entity</returns>
        public DalLike GetById(int id)
        {
            return likes.FirstOrDefault(l => l.Id == id).ToDalLike();
        }

        /// <summary>
        /// Method for updating exist like
        /// </summary>
        public void Update(DalLike entity)
        {
            var like = likes.FirstOrDefault(l => l.Id == entity.Id);
            if (!ReferenceEquals(like, null))
            {
                like.Id = entity.Id;
                like.Post = posts.FirstOrDefault(p => p.Id == entity.PostId);
                like.ProfileFrom = profiles.FirstOrDefault(p => p.Id == entity.ProfileFromId);
                context.Entry(like).State = EntityState.Modified;
            }
            else
            {
                throw new ArgumentNullException(nameof(like));
            }
        }
    }

    #endregion
}
