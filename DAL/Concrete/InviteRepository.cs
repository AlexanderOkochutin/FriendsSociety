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
    /// <summary>
    /// InviteRepository class implements IInviteRepository
    /// </summary>
    public class InviteRepository : IInviteRepository
    {
        private readonly SocialNetworkContext context;
        private readonly DbSet<Invite> invites;
        private readonly DbSet<Profile> profiles;

        /// <summary>
        /// Creates InviteRepository instance
        /// </summary>
        public InviteRepository(SocialNetworkContext context)
        {
            this.context = context;
            invites = context.Set<Invite>();
            profiles = context.Set<Profile>();
        }

        /// <summary>
        /// Method for adding new invite entity
        /// </summary>
        public void Add(DalInvite entity)
        {
            var invite = new Invite()
            {
                Id = entity.Id,
                ProfileFrom = profiles.FirstOrDefault(p=>p.Id == entity.ProfileFrom),
                Response = entity.Response,
                ProfielTo = profiles.FirstOrDefault(p=>p.Id==entity.ProfileTo)
            };
            invites.Add(invite);
        }

        /// <summary>
        /// Delete exist invite by Id
        /// </summary>
        /// <param name="id">Id of exist invite</param>
        public void DeleteById(int id)
        {
            var invite = invites.FirstOrDefault(i => i.Id == id);
            if (!ReferenceEquals(invite, null))
            {
                invites.Remove(invite);
            }
            else
            {
                throw new ArgumentNullException(nameof(invite));
            }
        }

        /// <summary>
        /// Get All invites
        /// </summary>
        /// <returns>Collection of DalInvites</returns>
        public IEnumerable<DalInvite> GetAll()
        {
            return invites.Select(i => i).Map();
        }

        /// <summary>
        /// Get exist invite By Id
        /// </summary>
        /// <param name="id">exist invite Id</param>
        /// <returns>DalInvite Entity</returns>
        public DalInvite GetById(int id)
        {
            return invites.FirstOrDefault(i => i.Id == id).ToDalInvite();
        }

        /// <summary>
        /// Method for updating exist invite
        /// </summary>
        /// <param name="entity">exist invite</param>
        public void Update(DalInvite entity)
        {
            var invite = invites.FirstOrDefault(i => i.Id == entity.Id);
            if (!ReferenceEquals(invite, null))
            {
                invite.Id = entity.Id;
                invite.ProfileFrom = profiles.FirstOrDefault(p => p.Id == entity.ProfileFrom);
                invite.Response = entity.Response;
                invite.ProfielTo = profiles.FirstOrDefault(p => p.Id == entity.ProfileTo);
                //context.Entry(invite).State = EntityState.Modified;
            }
            else
            {
                throw new ArgumentNullException(nameof(invite));
            }
        }

        /// <summary>
        /// get concrete invite with sender Id and destination Id
        /// </summary>
        /// <param name="idFrom">sender Id</param>
        /// <param name="idTo">destination Id</param>
        /// <returns>concrete DalInvite </returns>
        public DalInvite GetByFromToId(int idFrom,int idTo)
        {
            return invites.FirstOrDefault(i => i.ProfileFrom.Id == idFrom && i.ProfielTo.Id == idTo).ToDalInvite();
        }

        /// <summary>
        /// Get all invite for concrete profile
        /// </summary>
        /// <param name="idTo">Id of exist profile</param>
        /// <returns>all invite to this profile</returns>
        public IEnumerable<DalProfile> GetAllInviteProfiles(int idTo)
        {
            var allInvites =  invites.Where(i => i.ProfielTo.Id == idTo);
            var allProfiles = new List<DalProfile>();
            foreach (var invite in allInvites)
            {
                allProfiles.Add(profiles.FirstOrDefault(p=>p.Id == invite.ProfileFrom.Id).ToDalProfile());
            }
            return allProfiles;
        }
    }
}
