using System.Collections.Generic;

namespace DAL.Interface.DTO
{
    /// <summary>
    /// DAL layout user class
    /// </summary>
    public class DalUser : IEntity
    {
        /// <summary>
        /// Default constructor of DAlUser entity
        /// </summary>
        public DalUser()
        {
            Roles = new List<string>();
        }

        /// <summary>
        /// DalUser Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// DalUser contact email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// DalUser email is confirmed or not
        /// </summary>
        public bool IsEmailConfirmed { get; set; }

        /// <summary>
        /// DalUser mailsalt for mail confirm
        /// </summary>
        public string MailSalt { get; set; }

        /// <summary>
        /// DalUser password hash
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// DalUser password salt
        /// </summary>
        public string PasswordSalt { get; set; }

        /// <summary>
        /// DalUser Roles
        /// </summary>
        public ICollection<string> Roles { get; set; }
    }
}
