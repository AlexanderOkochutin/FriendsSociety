using System.Collections.Generic;
using BLL.Interface.Entities;
using DAL.Interface.DTO;

namespace BLL.Mappers
{
    /// <summary>
    /// Service class for mapping DalLike and BllLike Entities
    /// </summary>
    public static class LikeMapper
    {
        /// <summary>
        /// Method map To BllLike
        /// </summary>
        /// <returns>new BllLike the same as DalLike</returns>
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

        /// <summary>
        /// Method map to DalLike
        /// </summary>
        /// <returns>new DalLike the same as BllLike</returns>
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

        /// <summary>
        /// Method map To BllLikes
        /// </summary>
        /// <returns>new BllLikes collection same as DalLikes collection</returns>
        public static IEnumerable<BllLike> Map(this IEnumerable<DalLike> dalLikes)
        {
            var bllLikes = new List<BllLike>();
            foreach (var dalLike in dalLikes)
            {
                bllLikes.Add(dalLike.ToBllLike());
            }
            return bllLikes;
        }

        /// <summary>
        /// Method map To DalLikes
        /// </summary>
        /// <returns>new DalLikes collection same as BllLikes collection</returns>
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
