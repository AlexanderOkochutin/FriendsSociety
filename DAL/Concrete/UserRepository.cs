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
    /// <summary>
    /// User repository class implements Repository pattern for user collection
    /// </summary>
    public class UserRepository : IUserRepository
    {
        private readonly SocialNetworkContext context;
        private readonly DbSet<User> users;
        private readonly DbSet<Role> roles;

        public UserRepository(SocialNetworkContext socialNetworkContext)
        {
            context = socialNetworkContext;
            users = context.Set<User>();
            roles = context.Set<Role>();
        }

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
                context.Entry(user).State = EntityState.Modified;
            }
        }

        public void DeleteById(int id)
        {
            users.Remove(users.FirstOrDefault(u => u.Id == id));
        }

        public DalUser GetById(int id)
        {
            return users.FirstOrDefault(u => u.Id == id).ToDalUser();
        }

        public IEnumerable<DalUser> GetAll()
        {
            return users.Include(u => u.Roles).Select(u => u).Map();
        }

        public DalUser GetByPredicate(Expression<Func<DalUser, bool>> f)
        {
            throw new NotImplementedException();
        }

        public DalUser GetByEmail(string email)
        {
            return users.FirstOrDefault(u => u.Email == email).ToDalUser();
        }
    }
}
