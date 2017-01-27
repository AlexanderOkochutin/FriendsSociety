using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.DTO;
using DAL.Interface.Repository;
using DAL.Mappers;
using ORM;
using ORM.Entities;

namespace DAL.Concrete
{
    public class InviteRepository : IInviteRepository
    {
        private readonly SocialNetworkContext context;
        private readonly DbSet<Invite> invites;
        private readonly DbSet<Profile> profiles;

        public InviteRepository(SocialNetworkContext context)
        {
            this.context = context;
            invites = context.Set<Invite>();
            profiles = context.Set<Profile>();
        }

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

        public void DeleteById(int id)
        {
            invites.Remove(invites.FirstOrDefault(i => i.Id == id));
        }

        public IEnumerable<DalInvite> GetAll()
        {
            return invites.Select(i => i).Map();
        }

        public DalInvite GetById(int id)
        {
            return invites.FirstOrDefault(i => i.Id == id).ToDalInvite();
        }

        public DalInvite GetByPredicate(Expression<Func<DalInvite, bool>> f)
        {
            throw new NotImplementedException();
        }

        public void Update(DalInvite entity)
        {
            var invite = invites.FirstOrDefault(i => i.Id == entity.Id);
            invite.Id = entity.Id;
            invite.ProfileFrom = profiles.FirstOrDefault(p => p.Id == entity.ProfileFrom);
            invite.Response = entity.Response;
            invite.ProfielTo = profiles.FirstOrDefault(p => p.Id == entity.ProfileTo);
            context.Entry(invite).State = EntityState.Modified;
        }

        public DalInvite GetByFromToId(int idFrom,int idTo)
        {
            return invites.FirstOrDefault(i => i.ProfileFrom.Id == idFrom && i.ProfielTo.Id == idTo).ToDalInvite();
        }

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
