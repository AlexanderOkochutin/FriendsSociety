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
    /// User repository class implements IUserRepository
    /// </summary>
    public class UserRepository : IUserRepository
    {
        private readonly SocialNetworkContext context;
        private readonly DbSet<User> users;
        private readonly DbSet<Role> roles;

        /// <summary>
        /// Create new User Repositiry instance
        /// </summary>
        /// <param name="socialNetworkContext">context</param>
        public UserRepository(SocialNetworkContext socialNetworkContext)
        {
            context = socialNetworkContext;
            users = context.Set<User>();
            roles = context.Set<Role>();
        }

        /// <summary>
        /// Method for adding new user entity in collection
        /// </summary>
        public void Add(DalUser dalUser)
        {
            var user = dalUser.ToUser();

            foreach (var role in dalUser.Roles)
            {
                var userRole = roles.FirstOrDefault(r => r.Name == role);
                user.Roles.Add(userRole);
            }

            users.Add(user);
        }

        /// <summary>
        /// Method for update exist user
        /// </summary>
        /// <param name="dalUser">exist user</param>
        public void Update(DalUser dalUser)
        {
            var user = users.FirstOrDefault(u => u.Id == dalUser.Id);
            if (!ReferenceEquals(user, null))
            {
                user.Email = dalUser.Email;
                user.IsEmailConfirmed = dalUser.IsEmailConfirmed;
                user.MailSalt = dalUser.MailSalt;
                user.Roles.Clear();
                foreach (var item in dalUser.Roles)
                {
                    var userRole = roles.FirstOrDefault(r => r.Name == item);
                    user.Roles.Add(userRole);
                }
               // context.Entry(user).State = EntityState.Modified;
            }
            else
            {
                throw new ArgumentNullException(nameof(user));
            }
        }

        /// <summary>
        /// Delete by Id exist user
        /// </summary>
        /// <param name="id">Id of exist user</param>
        public void DeleteById(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            if (!ReferenceEquals(user, null))
            {
                users.Remove(user);
            }
            else
            {
                throw new ArgumentNullException(nameof(user));
            }
        }

        /// <summary>
        /// Get by Id exist user
        /// </summary>
        /// <param name="id"></param>
        /// <returns>DAlUser entity</returns>
        public DalUser GetById(int id)
        {
            return users.FirstOrDefault(u => u.Id == id).ToDalUser();
        }

        /// <summary>
        /// get all users 
        /// </summary>
        /// <returns>Dal user collection</returns>
        public IEnumerable<DalUser> GetAll()
        {
            return users.Include(u => u.Roles).Select(u => u).Map();
        }

        /// <summary>
        /// Get user by contact email
        /// </summary>
        /// <returns>Dal user entity</returns>
        public DalUser GetByEmail(string email)
        {
            return users.FirstOrDefault(u => u.Email == email).ToDalUser();
        }
    }
}
