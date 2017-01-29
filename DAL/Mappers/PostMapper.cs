using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using DAL.Interface.DTO;
using ORM.Entities;

namespace DAL.Mappers
{
    public static class PostMapper
    {
        public static Post ToPost(this DalPost dalPost)
        {
            if (ReferenceEquals(dalPost, null)) return null;
            var post = new Post()
            {
                Id = dalPost.Id,
                Date = dalPost.Date,
                IsOnTheWall = dalPost.IsOnTheWall,
                AuthorId = dalPost.AuthorId,
                Text = dalPost.Text
            };
            return post;
        }

        public static DalPost ToDalPost(this Post post)
        {
            if (ReferenceEquals(post, null)) return null;
            var dalPost = new DalPost()
            {
                Id = post.Id,
                Date = post.Date,
                AuthorId = post.AuthorId,
                IsOnTheWall = post.IsOnTheWall,
                Text = post.Text,
            };
            dalPost.Files = post.Files.Select(f => f.Id).ToList();
            dalPost.Comments = post.Comments.Select(c => c.Id).ToList();
            dalPost.RepostProfiles = post.RepostProfiles.Select(p => p.Id).ToList();
            foreach (var like in post.Likes)
            {
                dalPost.Likes.Add(like.ToDalLike());
            }
            return dalPost;
        }

        public static IEnumerable<DalPost> Map(this IQueryable<Post> posts)
        {
            var dalPosts = new List<DalPost>();
            foreach (var post in posts)
            {
                dalPosts.Add(post.ToDalPost());
            }
            return dalPosts;
        }
    }
}
