using System.Collections.Generic;
using System.Linq;
using DAL.Interface.DTO;
using ORM.Entities;

namespace DAL.Mappers
{
    /// <summary>
    /// Service for mapping DalInvite and ORM invite entities
    /// </summary>
    public static class InviteMapper
    {
        /// <summary>
        /// Map To Invite
        /// </summary>
        /// <returns>new ORM inite entity same as dalInvite</returns>
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

        /// <summary>
        /// Map To DalInvite
        /// </summary>
        /// <returns>new DalInvite entity same as ORM Invite entity</returns>
        public static DalInvite ToDalInvite(this Invite invite)
        {
            if (ReferenceEquals(invite, null)) return null;
            DalInvite dalInvite = new DalInvite()
            {
                Id = invite.Id,
                ProfileFrom = invite.ProfileFrom.Id,
                ProfileTo = invite.ProfielTo.Id,
                Response = invite.Response
            };
            return dalInvite;
        }

        /// <summary>
        /// Map To DalInvites
        /// </summary>
        /// <returns>new DalInvite Collection same as ORM Invite collection</returns>
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
