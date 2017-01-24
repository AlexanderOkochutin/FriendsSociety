using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;
using DAL.Interface.DTO;

namespace BLL.Mappers
{
    public static class LikeMapper
    {
        public static BllLike ToBllLike(this DalLike dalLike)
        {
            if (ReferenceEquals(dalLike, null)) return null;
            var bllLike = new BllLike()
            {
                Id = dalLike.Id,
                PostId = dalLike.Id,
                ProfileFromId = dalLike.ProfileFromId
            };
            return bllLike;
        }

        public static DalLike ToDalLike(this BllLike bllLike)
        {
            if (ReferenceEquals(bllLike, null)) return null;
            var dalLike = new DalLike()
            {
                Id = bllLike.Id,
                PostId = bllLike.Id,
                ProfileFromId = bllLike.ProfileFromId
            };
            return dalLike;
        }

        public static IEnumerable<BllLike> Map(this IEnumerable<DalLike> dalLikes)
        {
            var bllLikes = new List<BllLike>();
            foreach (var dalLike in dalLikes)
            {
                bllLikes.Add(dalLike.ToBllLike());
            }
            return bllLikes;
        }

        public static IEnumerable<DalLike> Map(this IEnumerable<BllLike> bllLikes)
        {
            var dalLikes = new List<DalLike>();
            foreach (var bllLike in bllLikes)
            {
                dalLikes.Add(bllLike.ToDalLike());
            }
            return dalLikes;
        }
    }
}
