using System.Collections.Generic;
using ORM.Entities;

namespace ORM
{
    public class User
    {
        public User()
        {
            Roles = new List<Role>();
        }

        public int Id { get; set; }

        public string Login { get; set; }

        public string Email { get; set; }

        public bool IsEmailConfirmed { get; set; }

        public string PasswordHash { get; set; }

        public string PasswordSalt { get; set; }

        public virtual ICollection<Role> Roles { get; set; }

        public virtual Profile Profile { get; set; }
    }
}
