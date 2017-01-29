using System.Collections.Generic;
using System.Linq;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using BLL.Mappers;
using DAL.Interface.Repository;

namespace BLL.Services
{
    /// <summary>
    /// Service for work with profiles? implements IProfileService
    /// </summary>
    public class ProfileService : IProfileService
    {
        private readonly IUnitOfWork unitOfWork;

        /// <summary>
        /// Creates an instance of ProfileService
        /// </summary>
        /// <param name="uow">class which implements IUnitOfWork</param>
        public ProfileService(IUnitOfWork uow)
        {
            unitOfWork = uow;
        }

        /// <summary>
        /// Get concrete BllProfile by Id
        /// </summary>
        /// <param name="id">Id of exist profile</param>
        /// <returns>concrete BllProfile</returns>
        public BllProfile Get(int id)
        {
            return unitOfWork.Profiles.GetById(id).ToBllProfile();
        }

        /// <summary>
        /// Method for updating exist profile
        /// </summary>
        /// <param name="profile">exist BllProfile</param>
        public void Update(BllProfile profile)
        {
            unitOfWork.Profiles.Update(profile.ToDalProfile());
            unitOfWork.Commit();
        }

        /// <summary>
        /// Method for getting concrete profile by email
        /// </summary>
        /// <param name="email">email of exist profile</param>
        /// <returns>concrete BllProfile</returns>
        public BllProfile GetByUserEmail(string email)
        {
            return unitOfWork.Profiles.GetByUserEmail(email).ToBllProfile();
        }

        /// <summary>
        /// Method to search profiles by name and address
        /// </summary>
        /// <param name="stringKey">name of profile</param>
        /// <param name="city">address of profile</param>
        /// <returns>collecction of BllProfiles</returns>
        public IEnumerable<BllProfile> Find(string stringKey = "", string city = null)
        {
            var profiles = unitOfWork.Profiles.GetAll();
            if (!ReferenceEquals(stringKey, null)) profiles = profiles.Where(p => (p.FirstName + " " + p.LastName).ToLower().Contains(stringKey.ToLower()));
            if (!ReferenceEquals(city, null)) profiles = profiles.Where(p => p.City != null && p.City.ToLower().Contains(city.ToLower()));
            return profiles.Map();
        }

        /// <summary>
        /// Method to check profiles are friend or not
        /// </summary>
        /// <param name="idYour">Id profile1</param>
        /// <param name="id">Id profile2</param>
        public bool IsYourFriend(int idYour,int id)
        {
            var profile = unitOfWork.Profiles.GetById(id);
            return profile.Friends.Contains(idYour);
        }

        /// <summary>
        /// Method to get all friends of concrete profile
        /// </summary>
        /// <param name="id">Id of exist profile</param>
        /// <returns>Collection of BllProfiles</returns>
        public IEnumerable<BllProfile> GetAllFriendsOfId(int id)
        {
            var friends = unitOfWork.Profiles.GetAllFriendsOfId(id);
            return friends.Map();
        }
    }
}
