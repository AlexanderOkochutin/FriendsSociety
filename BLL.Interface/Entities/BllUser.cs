using System.Collections.Generic;

namespace BLL.Interface.Entities
{
    /// <summary>
    /// BLL layout user class
    /// </summary>
    public class BllUser
    {
        /// <summary>
        /// default constructor of BllUser entity
        /// </summary>
        public BllUser()
        {
            Roles = new List<string>();
        }

        /// <summary>
        /// BllUser Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// BllUser Contact email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Is Email of BllUser confirmed or not
        /// </summary>
        public bool IsEmailConfirmed { get; set; }

        /// <summary>
        /// BllUser mailsalt for mail confirmation
        /// </summary>
        public string MailSalt { get; set; }

        /// <summary>
        /// BllUser Password hash
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// BllUser Password salt
        /// </summary>
        public string PasswordSalt { get; set; }

        /// <summary>
        /// BllUser Roles
        /// </summary>
        public ICollection<string> Roles { get; set; }
    }
}
