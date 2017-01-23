using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.Entities
{
    public class Post
    {

        public Post()
        {
            RepostProfiles = new HashSet<Profile>();
            Files = new HashSet<File>();
            Comments = new HashSet<Message>();
        }

        public int Id { get; set; }

        public virtual Profile AuthorProfile { get; set; }

        public virtual ICollection<Profile> RepostProfiles { get; set; }

        public virtual ICollection<File> Files { get; set; }

        public virtual ICollection<Message> Comments { get; set; }

        public string Text { get; set; }

        public DateTime Date { get; set; }

        public int Likes { get; set; }
    }
}
