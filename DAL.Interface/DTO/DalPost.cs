using System;
using System.Collections.Generic;

namespace DAL.Interface.DTO
{
    /// <summary>
    /// DAL layout Post class
    /// </summary>
    public class DalPost:IEntity
    {
        /// <summary>
        /// default constructor of DalPost entity
        /// </summary>
        public DalPost()
        {
            Date = DateTime.Now;
            Likes = new HashSet<DalLike>();
            RepostProfiles = new HashSet<int>();
            Files = new HashSet<int>();
            Comments = new HashSet<int>();
        }

        /// <summary>
        /// DalPost Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// DalPost author profile Id
        /// </summary>
        public int AuthorId { get; set; }

        /// <summary>
        /// Main text of DalPost
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Date of DalPost
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// DalLike collection belong to this DalPost
        /// </summary>
        public ICollection<DalLike> Likes { get; set; }

        /// <summary>
        /// Is DalPost on the wall or in the gallery
        /// </summary>
        public bool IsOnTheWall { get; set; }

        /// <summary>
        /// Collection of Id's of profiles who make repost
        /// </summary>
        public ICollection<int> RepostProfiles { get; set; }

        /// <summary>
        /// Collection of files Id belongs to this profile
        /// </summary>
        public ICollection<int> Files { get; set; }

        /// <summary>
        /// Collection of comments Id belongs to this post
        /// </summary>
        public ICollection<int> Comments { get; set; }
    }
}
