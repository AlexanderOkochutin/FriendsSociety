using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;
using DAL.Interface.DTO;

namespace BLL.Mappers
{
    public static class UserMapper
    {
        public static BllUser ToBllUser(this DalUser dalUser)
        {
            if (ReferenceEquals(dalUser, null)) return null;
            var bllUser = new BllUser()
            {
                Id = dalUser.Id,
                Roles = dalUser.Roles,
                PasswordSalt = dalUser.PasswordSalt,
                Email = dalUser.Email,
                IsEmailConfirmed = dalUser.IsEmailConfirmed,
                Password = dalUser.Password,
                MailSalt = dalUser.MailSalt
            };
            return bllUser;
        }

        public static DalUser ToDalUser(this BllUser bllUser)
        {
            if (ReferenceEquals(bllUser, null)) return null;
            var dalUser = new DalUser()
            {
                Id = bllUser.Id,
                Roles = bllUser.Roles,
                PasswordSalt = bllUser.PasswordSalt,
                Email = bllUser.Email,
                IsEmailConfirmed = bllUser.IsEmailConfirmed,
                Password = bllUser.Password,
                MailSalt = bllUser.MailSalt
            };
            return dalUser;
        }

        public static IEnumerable<BllUser> Map(this IEnumerable<DalUser> dalUsers)
        {
            var bllUsers = new List<BllUser>();
            foreach (var dalUser in dalUsers)
            {
                bllUsers.Add(dalUser.ToBllUser());
            }
            return bllUsers;
        }
    }
}
