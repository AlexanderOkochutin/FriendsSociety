using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.DTO;
using ORM.Entities;

namespace DAL.Mappers
{
    /// <summary>
    /// Service class for mapping DalLike and ORM Like entities
    /// </summary>
    public static class LikeMapper
    {
        /// <summary>
        /// Map To Like
        /// </summary>
        /// <returns>new ORM Like entity same as dalLike</returns>
        public static Like ToLike(this DalLike dalLike)
        {
            if (ReferenceEquals(dalLike, null)) return null;
            var like = new Like()
            {
                Id = dalLike.Id
            };
            return like;
        }

        /// <summary>
        /// Map To DalLike
        /// </summary>
        /// <returns>new ORM Like entity same as dalLike</returns>
        public static DalLike ToDalLike(this Like like)
        {
            if (ReferenceEquals(like, null)) return null;
            var dalLike = new DalLike()
            {
                Id = like.Id,
                PostId = like.Post.Id,
                ProfileFromId = like.ProfileFrom.Id
            };
            return dalLike;
        }

        /// <summary>
        /// Map To DalLikes
        /// </summary>
        /// <returns>new ORM Like collection same as ORM likes</returns>
        public static IEnumerable<DalLike> Map(this IQueryable<Like> likes)
        {
            var dalLikes = new List<DalLike>();
            foreach (var like in likes)
            {
                dalLikes.Add(like.ToDalLike());
            }
            return dalLikes;
        }
    }
}
