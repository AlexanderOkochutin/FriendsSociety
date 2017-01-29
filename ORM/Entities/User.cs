using System.Collections.Generic;

namespace ORM.Entities
{
    /// <summary>
    /// ORM layout user class
    /// </summary>
    public class User
    {
        /// <summary>
        /// Default constructor of ORM user entity
        /// </summary>
        public User()
        {
            Roles = new List<Role>();
        }

        /// <summary>
        /// user Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// user contact email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// user email is checked or not
        /// </summary>
        public bool IsEmailConfirmed { get; set; }

        /// <summary>
        /// user random string for mail confirming
        /// </summary>
        public string MailSalt { get; set; }

        /// <summary>
        /// user password hash
        /// </summary>
        public string PasswordHash { get; set; }

        /// <summary>
        /// user password salt
        /// </summary>
        public string PasswordSalt { get; set; }

        /// <summary>
        /// User roles. It needns for DataBase creating
        /// </summary>
        public virtual ICollection<Role> Roles { get; set; }

        /// <summary>
        /// User Profile/ It needs for DataBase creating
        /// </summary>
        public virtual Profile Profile { get; set; }
    }
}
