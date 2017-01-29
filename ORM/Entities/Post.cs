using System;
using System.Collections.Generic;

namespace ORM.Entities
{
    /// <summary>
    /// ORM layout Post class
    /// </summary>
    public class Post
    {
        /// <summary>
        /// Default constructor of post entity
        /// </summary>
        public Post()
        {
            Date = DateTime.Now;
            RepostProfiles = new HashSet<Profile>();
            Files = new HashSet<File>();
            Comments = new HashSet<Message>();
            Likes = new HashSet<Like>();
        }

        /// <summary>
        /// post Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// post author Id
        /// </summary>
        public int AuthorId { get; set; }

        /// <summary>
        /// who make repost. It needs for database creation
        /// </summary>
        public virtual ICollection<Profile> RepostProfiles { get; set; }

        /// <summary>
        /// files in posts. It needs for Database creation
        /// </summary>
        public virtual ICollection<File> Files { get; set; }

        /// <summary>
        /// comments to posts. It needs for database creation
        /// </summary>
        public virtual ICollection<Message> Comments { get; set; }

        /// <summary>
        /// main post text
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// post date
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// post likes. It needs for creation database
        /// </summary>
        public ICollection<Like> Likes { get; set; }

        /// <summary>
        /// is on the wall post, or gallery
        /// </summary>
        public bool IsOnTheWall { get; set; }
    }
}
