using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;
using DAL.Interface.DTO;

namespace BLL.Mappers
{
    public static class InviteMapper
    {
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
