using System;
using System.Collections.Generic;

namespace ORM.Entities
{
    public class Post
    {

        public Post()
        {
            RepostProfiles = new HashSet<Profile>();
            Files = new HashSet<File>();
            Comments = new HashSet<Message>();
            Likes = new HashSet<Like>();
        }

        public int Id { get; set; }

        public int AuthorId { get; set; }

        public virtual ICollection<Profile> RepostProfiles { get; set; }

        public virtual ICollection<File> Files { get; set; }

        public virtual ICollection<Message> Comments { get; set; }

        public string Text { get; set; }

        public DateTime Date { get; set; }

        public ICollection<Like> Likes { get; set; }

        public bool IsOnTheWall { get; set; }
    }
}
