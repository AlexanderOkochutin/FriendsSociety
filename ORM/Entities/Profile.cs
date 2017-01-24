using System;
using System.Collections.Generic;

namespace ORM.Entities
{
    public class Profile
    {
        public Profile()
        {
            Messages = new HashSet<Message>();
            Friends = new HashSet<Profile>();
            InFriends = new HashSet<Profile>();
            Posts = new HashSet<Post>();
            Files = new HashSet<File>();
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public string City { get; set; }

        public DateTime? BirthDay { get; set; }

        public string RelationStatus { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Profile> Friends { get; set; }

        public virtual ICollection<Profile> InFriends { get; set; }

        public virtual ICollection<Message> Messages { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

        public virtual ICollection<File> Files { get; set; }
    }
}
