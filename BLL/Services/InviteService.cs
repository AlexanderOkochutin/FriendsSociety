using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using BLL.Mappers;
using DAL.Interface.Repository;

namespace BLL.Services
{
    public class InviteService:IInviteService
    {

        private readonly IUnitOfWork unitOfWork;

        public InviteService(IUnitOfWork uow)
        {
            unitOfWork = uow;
        }

        public bool IsInviteSend(int idFrom, int idTo)
        {
            var invite = unitOfWork.Invites.GetByFromToId(idFrom, idTo);
            return invite != null;
        }

        public void SendInvite(int idFrom, int idTo)
        {
            BllInvite invite = new BllInvite()
            {
               ProfileFrom = idFrom,
               ProfileTo = idTo,
               Response = null
            };
            unitOfWork.Invites.Add(invite.ToDalInvite());
            unitOfWork.Commit();
    }

        public void AddFriend(int idFrom, int idTo)
        {
            var invite = unitOfWork.Invites.GetByFromToId(idFrom, idTo);
            if (invite != null)
            {
                var user1 = unitOfWork.Profiles.GetById(idFrom);
                var user2 = unitOfWork.Profiles.GetById(idTo);
                unitOfWork.Invites.DeleteById(invite.Id);
                user1.Friends.Add(user2.Id);
                user2.Friends.Add(user1.Id);
                unitOfWork.Profiles.Update(user1);
                unitOfWork.Profiles.Update(user2);
                unitOfWork.Commit();
            }
        }

        public IEnumerable<BllProfile> GetAllInviteProfiles(int idTo)
        {
            return unitOfWork.Invites.GetAllInviteProfiles(idTo).Map();
        }
    }
}
