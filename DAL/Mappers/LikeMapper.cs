using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.DTO;
using ORM.Entities;

namespace DAL.Mappers
{
    public static class LikeMapper
    {
        public static Like ToLike(this DalLike dalLike)
        {
            if (ReferenceEquals(dalLike, null)) return null;
            var like = new Like()
            {
                Id = dalLike.Id
            };
            return like;
        }

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
