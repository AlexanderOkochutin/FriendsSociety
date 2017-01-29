using System;
using System.Collections.Generic;

namespace BLL.Interface.Entities
{
    /// <summary>
    /// BLL layout Post class
    /// </summary>
    public class BllPost
    {
        /// <summary>
        /// default constructor of BllPost instance
        /// </summary>
        public BllPost()
        {
            Date = DateTime.Now;
            Likes = new HashSet<BllLike>();
            RepostProfiles = new HashSet<int>();
            Files = new HashSet<int>();
            Comments = new HashSet<int>();
        }

        /// <summary>
        /// BllPost Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// BllPost author Id
        /// </summary>
        public int AuthorId { get; set; }

        /// <summary>
        /// BllPost main text
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// BllPost date
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// BllPost collection of BllLikes
        /// </summary>
        public ICollection<BllLike> Likes { get; set; }

        /// <summary>
        /// Is post on the wall or in the gallery
        /// </summary>
        public bool IsOnTheWall { get; set; }

        /// <summary>
        /// collection of Id of profiles who make repost
        /// </summary>
        public ICollection<int> RepostProfiles { get; set; }

        /// <summary>
        /// Collection of Id files include in post
        /// </summary>
        public ICollection<int> Files { get; set; }

        /// <summary>
        /// collection of Comments to this post
        /// </summary>
        public ICollection<int> Comments { get; set; }
    }
}
