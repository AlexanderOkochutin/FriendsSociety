using System.Collections.Generic;

namespace DAL.Interface.DTO
{
    public class DalUser : IEntity
    {
        public DalUser()
        {
            Roles = new List<string>();
        }

        public int Id { get; set; }

        public string Email { get; set; }

        public bool IsEmailConfirmed { get; set; }

        public string MailSalt { get; set; }

        public string Password { get; set; }

        public string PasswordSalt { get; set; }

        public ICollection<string> Roles { get; set; }
    }
}
