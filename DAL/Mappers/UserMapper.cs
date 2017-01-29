using System.Collections.Generic;
using System.Linq;
using DAL.Interface.DTO;
using ORM.Entities;

namespace DAL.Mappers
{
    /// <summary>
    /// Service class for mapping DalUser and ORM User entities
    /// </summary>
    public static class UserMapper
    {
        /// <summary>
        /// Mapr to User
        /// </summary>
        /// <returns>new ORM User entity same as user</returns>
        public static User ToUser(this DalUser user)
        {
            if (ReferenceEquals(user, null)) return null;
            User result = new User
            {
                Id = user.Id,
                Email = user.Email,
                PasswordHash = user.Password,
                PasswordSalt = user.PasswordSalt,
                IsEmailConfirmed = user.IsEmailConfirmed,
                MailSalt = user.MailSalt
            };
            return result;
        }

        /// <summary>
        /// Map To DAL User
        /// </summary>
        /// <returns>new DalUser entity same as user</returns>
        public static DalUser ToDalUser(this User user)
        {
            if (ReferenceEquals(user, null)) return null;
            DalUser result = new DalUser
            {
                Id = user.Id,
                Email = user.Email,
                Password = user.PasswordHash,
                PasswordSalt = user.PasswordSalt,
                IsEmailConfirmed = user.IsEmailConfirmed,
                MailSalt = user.MailSalt
            };
            foreach (var role in user.Roles)
            {
                result.Roles.Add(role.Name);
            }
            return result;
        }

        /// <summary>
        /// Map ot DalUsers
        /// </summary>
        /// <returns>new DalUser collection same as users</returns>
        public static IEnumerable<DalUser> Map(this IQueryable<User> users)
        {
            var dalUsers = new List<DalUser>();
            foreach (var item in users)
            {
                dalUsers.Add(item.ToDalUser());
            }
            return dalUsers;
        }
    }
}
