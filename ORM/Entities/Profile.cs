using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.Entities
{
    public class Profile
    {
        public Profile()
        {
            Files = new HashSet<File>();
            Messages = new HashSet<Message>();
            Friends = new HashSet<Profile>();
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public string City { get; set; }

        public DateTime? BirthDay { get; set; }

        public string RelationStatus { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<File> Files { get; set; }

        public virtual ICollection<Profile> Friends { get; set; }

        public virtual ICollection<Message> Messages { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
