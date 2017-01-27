using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using BLL.Mappers;
using DAL.Interface.DTO;
using DAL.Interface.Repository;

namespace BLL.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IUnitOfWork unitOfWork;

        public ProfileService(IUnitOfWork uow)
        {
            unitOfWork = uow;
        }

        public BllProfile Get(int id)
        {
            return unitOfWork.Profiles.GetById(id).ToBllProfile();
        }

        public void Update(BllProfile profile)
        {
            unitOfWork.Profiles.Update(profile.ToDalProfile());
            unitOfWork.Commit();
        }

        public BllProfile GetByUserEmail(string email)
        {
            return unitOfWork.Profiles.GetByUserEmail(email).ToBllProfile();
        }

        public IEnumerable<BllProfile> Find(string stringKey = "", string city = null)
        {
            var profiles = unitOfWork.Profiles.GetAll();
            if (!ReferenceEquals(stringKey, null)) profiles = profiles.Where(p => (p.FirstName + " " + p.LastName).ToLower().Contains(stringKey.ToLower()));
            if (!ReferenceEquals(city, null)) profiles = profiles.Where(p => p.City != null && p.City.ToLower().Contains(city.ToLower()));
            return profiles.Map();
        }

        public bool IsYourFriend(int idYour,int id)
        {
            var profile = unitOfWork.Profiles.GetById(id);
            return profile.Friends.Contains(idYour);
        }
    }
}
