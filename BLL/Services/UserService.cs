using System.Collections.Generic;
using System.Linq;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using BLL.Mappers;
using DAL.Interface.DTO;
using DAL.Interface.Repository;

namespace BLL.Services
{
    /// <summary>
    /// Service for work with users, implements IUserService
    /// </summary>
    public class UserService : IUserService
    {
        private readonly IUnitOfWork unitOfWork;

        /// <summary>
        /// Create instance of UserService
        /// </summary>
        /// <param name="uow">class which implement IUnitOfWork</param>
        public UserService(IUnitOfWork uow)
        {
            unitOfWork = uow;
        }

        /// <summary>
        /// Method for adding new user
        /// </summary>
        public void AddUser(BllUser user)
        {
            unitOfWork.Users.Add(user.ToDalUser());
            unitOfWork.Profiles.Add(new DalProfile() {Id = user.Id});
            unitOfWork.Commit();
        }

        /// <summary>
        /// Method for delete exiting user
        /// </summary>
        /// <param name="user">exist BllUser</param>
        public void DeleteUser(BllUser user)
        {
            unitOfWork.Profiles.DeleteById(user.Id);
            unitOfWork.Users.DeleteById(user.Id); 
            unitOfWork.Commit();
        }

        /// <summary>
        /// Get All users
        /// </summary>
        /// <returns>List of BllUsers</returns>
        public List<BllUser> GetAll()
        {
            return unitOfWork.Users.GetAll().Map().ToList();
        }

        /// <summary>
        /// get concrete user by Id
        /// </summary>
        /// <param name="id">Id of exist user</param>
        /// <returns>concrete BllUser</returns>
        public BllUser GetUser(int id)
        {
            return unitOfWork.Users.GetById(id).ToBllUser();
        }

        /// <summary>
        /// Get concrete user by email
        /// </summary>
        /// <param name="email">email of exist user</param>
        /// <returns>concrete BllUser</returns>
        public BllUser GetUserByEmail(string email)
        {
            return unitOfWork.Users.GetByEmail(email).ToBllUser();
        }

        /// <summary>
        /// Method for confirming mail
        /// </summary>
        /// <param name="email">email of exist user</param>
        public void MailConfirm(string email)
        {
            var user = unitOfWork.Users.GetByEmail(email);
            user.IsEmailConfirmed = true;
            UpdateUser(user.ToBllUser());
        }

        /// <summary>
        /// Method for updating exist user
        /// </summary>
        /// <param name="user">exist BllUser</param>
        public void UpdateUser(BllUser user)
        {
            unitOfWork.Users.Update(user.ToDalUser()); 
            unitOfWork.Commit();
        }
    }
}
