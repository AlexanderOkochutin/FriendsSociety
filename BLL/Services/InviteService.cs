using System.Collections.Generic;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using BLL.Mappers;
using DAL.Interface.Repository;

namespace BLL.Services
{
    /// <summary>
    /// Service for work with Invites, implements IInviteService
    /// </summary>
    public class InviteService:IInviteService
    {

        private readonly IUnitOfWork unitOfWork;

        /// <summary>
        /// Create inviteSrvice instance
        /// </summary>
        /// <param name="uow">class which implements IUnitOfWork</param>
        public InviteService(IUnitOfWork uow)
        {
            unitOfWork = uow;
        }

        /// <summary>
        /// Method to check IsInvite send to this profile
        /// </summary>
        /// <param name="idFrom">Id of sender</param>
        /// <param name="idTo">Id of destination</param>
        public bool IsInviteSend(int idFrom, int idTo)
        {
            var invite = unitOfWork.Invites.GetByFromToId(idFrom, idTo);
            return invite != null;
        }

        /// <summary>
        /// Method to send invite by sender Id and destination Id
        /// </summary>
        /// <param name="idFrom">sender Id</param>
        /// <param name="idTo">destination Id</param>
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

        /// <summary>
        /// Method to add friendship between to profiles
        /// </summary>
        /// <param name="idFrom">Id of profile1</param>
        /// <param name="idTo">Id of profile2</param>
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

        /// <summary>
        /// Method to get all invites for concrete profile
        /// </summary>
        /// <param name="idTo">Id of exist profile</param>
        /// <returns>Collection of BllProfiles</returns>
        public IEnumerable<BllProfile> GetAllInviteProfiles(int idTo)
        {
            return unitOfWork.Invites.GetAllInviteProfiles(idTo).Map();
        }
        
        /// <summary>
        /// Method to refuse concrete friend invite
        /// </summary>
        /// <param name="idFrom">Id of sender</param>
        /// <param name="idTo">Id of destination</param>
        public void RefuseInvite(int idFrom, int idTo)
        {
            var inviteId = unitOfWork.Invites.GetByFromToId(idFrom, idTo).Id;
            unitOfWork.Invites.DeleteById(inviteId);
            unitOfWork.Commit();
        }

        /// <summary>
        /// Delete friendship between to profiels
        /// </summary>
        /// <param name="id1">Id of profile1</param>
        /// <param name="id2">Id of profile2</param>
        public void DeleteFriend(int id1, int id2)
        {
            var profile1 = unitOfWork.Profiles.GetById(id1);
            var profile2 = unitOfWork.Profiles.GetById(id2);
            profile1.Friends.Remove(id2);
            profile2.Friends.Remove(id1);
            unitOfWork.Profiles.Update(profile1);
            unitOfWork.Profiles.Update(profile2);
            unitOfWork.Commit();
        } 
    }
}
