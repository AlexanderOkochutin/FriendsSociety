using System;
using System.Collections.Generic;

namespace ORM.Entities
{
    /// <summary>
    /// ORM layout Profile class
    /// </summary>
    public class Profile
    {
        /// <summary>
        /// Default constructor of profile entity
        /// </summary>
        public Profile()
        {
            Messages = new HashSet<Message>();
            Friends = new HashSet<Profile>();
            InFriends = new HashSet<Profile>();
            Posts = new HashSet<Post>();
            Files = new HashSet<File>();
        }

        /// <summary>
        /// profile Id (the same as user Id)
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// profile first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// profile last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// profile gender
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// profile address
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// profile birth date
        /// </summary>
        public DateTime? BirthDay { get; set; }

        /// <summary>
        /// profile relationship status
        /// </summary>
        public string RelationStatus { get; set; }

        /// <summary>
        /// Profile user/ It needs for DataBase creation
        /// </summary>
        public virtual User User { get; set; }

        /// <summary>
        /// Profile friends. It Nedds for Database creation
        /// </summary>
        public virtual ICollection<Profile> Friends { get; set; }

        /// <summary>
        /// this profile in friends. It needs for Database creation
        /// </summary>
        public virtual ICollection<Profile> InFriends { get; set; }

        /// <summary>
        /// Profile Messages. It need for database creation
        /// </summary>
        public virtual ICollection<Message> Messages { get; set; }

        /// <summary>
        /// profile posts. It needs for database creation
        /// </summary>
        public virtual ICollection<Post> Posts { get; set; }

        /// <summary>
        /// profile files.  It needs for database creation
        /// </summary>
        public virtual ICollection<File> Files { get; set; }
    }
}
