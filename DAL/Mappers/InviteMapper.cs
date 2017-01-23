using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.DTO;
using ORM.Entities;

namespace DAL.Mappers
{
    public static class InviteMapper
    {
        public static Invite ToInvite(this DalInvite dalInvite)
        {
            if (ReferenceEquals(dalInvite,null)) return null;
            Invite invite = new Invite()
            {
                Id = dalInvite.Id,
                Response = dalInvite.Response
            };
            return invite;
        }

        public static DalInvite ToDalInvite(this Invite invite)
        {
            if (ReferenceEquals(invite, null)) return null;
            DalInvite dalInvite = new DalInvite()
            {
                Id = invite.Id,
                IdFrom = invite.ProfileFrom.Id,
                IdTo = invite.ProfielTo.Id,
                Response = invite.Response
            };
            return dalInvite;
        }

        public static IEnumerable<DalInvite> Map(this IQueryable<Invite> invites)
        {
            var dalInvites = new List<DalInvite>();
            foreach (var invite in invites)
            {
                dalInvites.Add(invite.ToDalInvite());
            }
            return dalInvites;
        }
    }
}
