using System.Collections.Generic;
using System.Linq;
using BLL.Interface.Entities;
using DAL.Interface.DTO;

namespace BLL.Mappers
{
    /// <summary>
    /// Service class for mapping DalPost and BllPost Entities
    /// </summary>
    public static class PostMapper
    {
        /// <summary>
        /// Method map To BllPost
        /// </summary>
        /// <returns>new BllPost the same as DalPost</returns>
        public static BllPost ToBllPost(this DalPost dalPost)
        {
            if (ReferenceEquals(dalPost, null)) return null;
            var bllPost = new BllPost()
            {
                Id = dalPost.Id,
                Date = dalPost.Date,
                Files = dalPost.Files,
                Likes = dalPost.Likes.Map().ToList(),
                Text = dalPost.Text,
                RepostProfiles = dalPost.RepostProfiles,
                Comments = dalPost.Comments,
                AuthorId = dalPost.AuthorId,
                IsOnTheWall = dalPost.IsOnTheWall               
            };
            return bllPost;
        }

        /// <summary>
        /// Method map to DalPost
        /// </summary>
        /// <returns>new DalPost the same as BllPost</returns>
        public static DalPost ToDalPost(this BllPost bllPost)
        {
            if (ReferenceEquals(bllPost, null)) return null;
            var dalPost = new DalPost()
            {
                Id = bllPost.Id,
                Date = bllPost.Date,
                Files = bllPost.Files,
                Likes = bllPost.Likes.Map().ToList(),
                Text = bllPost.Text,
                RepostProfiles = bllPost.RepostProfiles,
                Comments = bllPost.Comments,
                AuthorId = bllPost.AuthorId,
                IsOnTheWall = bllPost.IsOnTheWall
            };
            return dalPost;
        }

        /// <summary>
        /// Method map To BllPosts
        /// </summary>
        /// <returns>new BllPosts collection same as DalPosts collection</returns>
        public static IEnumerable<BllPost> Map(this IEnumerable<DalPost> dalPosts)
        {
            var bllPosts = new List<BllPost>();
            foreach (var dalPost in dalPosts)
            {
                bllPosts.Add(dalPost.ToBllPost());
            }
            return bllPosts;
        }
    }
}
