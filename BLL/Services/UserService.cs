using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using BLL.Mappers;
using DAL.Interface.DTO;
using DAL.Interface.Repository;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork unitOfWork;

        public UserService(IUnitOfWork uow)
        {
            unitOfWork = uow;
        }

        public void AddUser(BllUser user)
        {
            unitOfWork.Users.Add(user.ToDalUser());
            unitOfWork.Profiles.Add(new DalProfile() {Id = user.Id});
            unitOfWork.Commit();
        }

        public void DeleteUser(BllUser user)
        {
            unitOfWork.Users.DeleteById(user.Id);
            unitOfWork.Profiles.DeleteById(user.Id);
            unitOfWork.Commit();
        }

        public List<BllUser> GetAll()
        {
            return unitOfWork.Users.GetAll().Map().ToList();
        }

        public BllUser GetUser(int id)
        {
            return unitOfWork.Users.GetById(id).ToBllUser();
        }

        public BllUser GetUserByEmail(string email)
        {
            return unitOfWork.Users.GetByEmail(email).ToBllUser();
        }

        public void MailConfirm(string email)
        {
            var user = unitOfWork.Users.GetByEmail(email);
            user.IsEmailConfirmed = true;
            UpdateUser(user.ToBllUser());
        }

        public void UpdateUser(BllUser user)
        {
            unitOfWork.Users.Update(user.ToDalUser()); 
            unitOfWork.Commit();
        }
    }
}
