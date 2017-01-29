using System.Collections.Generic;
using BLL.Interface.Entities;
using DAL.Interface.DTO;

namespace BLL.Mappers
{
    /// <summary>
    /// Service class for mapping DalInvite and BllInvite Entities
    /// </summary>
    public static class InviteMapper
    {
        /// <summary>
        /// Method map To BllInvite
        /// </summary>
        /// <returns>new BllInvite the same as DalInvite</returns>
        public static BllInvite ToBllInvite(this DalInvite dalInvite)
        {
            if (ReferenceEquals(dalInvite, null)) return null;
            var bllInvite = new BllInvite()
            {
                Id = dalInvite.Id,
                ProfileFrom = dalInvite.ProfileFrom,
                Response = dalInvite.Response,
                ProfileTo = dalInvite.ProfileTo
            };
            return bllInvite;
        }

        /// <summary>
        /// Method map to DalInvite
        /// </summary>
        /// <returns>new DalInvite the same as BllInvite</returns>
        public static DalInvite ToDalInvite(this BllInvite bllInvite)
        {
            if (ReferenceEquals(bllInvite, null)) return null;
            var dalInvite = new DalInvite()
            {
                Id = bllInvite.Id,
                ProfileFrom = bllInvite.ProfileFrom,
                Response = bllInvite.Response,
                ProfileTo = bllInvite.ProfileTo
            };
            return dalInvite;
        }

        /// <summary>
        /// Method map To BllInvites
        /// </summary>
        /// <returns>new BllInvites collection same as DalInvites collection</returns>
        public static IEnumerable<BllInvite> Map(this IEnumerable<DalInvite> dalInvites)
        {
            var bllInvites = new List<BllInvite>();
            foreach (var dalInvite in dalInvites)
            {
                bllInvites.Add(dalInvite.ToBllInvite());
            }
            return bllInvites;
        }
    }
}
