using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.Interface.DTO;
using DAL.Interface.Repository;
using DAL.Mappers;
using ORM;
using ORM.Entities;

namespace DAL.Concrete
{ 
    #region Not use in current build

    /// <summary>
    /// Post Repository class implements IPostRepository
    /// </summary>
    public class PostRepository : IPostRepository
    {
        private readonly SocialNetworkContext context;
        private readonly DbSet<Post> posts;
        private readonly DbSet<Like> likes;
        private readonly DbSet<Profile> profiles;
        private readonly DbSet<File> files;
        private readonly DbSet<Message> messages;

        /// <summary>
        /// Create PostRepository Instance
        /// </summary>
        public PostRepository(SocialNetworkContext context)
        {
            this.context = context;
            likes = context.Set<Like>();
            profiles = context.Set<Profile>();
            files = context.Set<File>();
            messages = context.Set<Message>();
            posts = context.Set<Post>();
        }

        /// <summary>
        /// Method for adding new Post
        /// </summary>
        public void Add(DalPost entity)
        {
            var post = new Post()
            {
                Id = entity.Id,
                Date = entity.Date,
                AuthorId = entity.AuthorId,
                IsOnTheWall = entity.IsOnTheWall,
                Text = entity.Text
            };

            foreach (var comment in entity.Comments)
            {
                post.Comments.Add(messages.FirstOrDefault(m=>m.Id==comment));
            }

            foreach (var file in entity.Files)
            {
                post.Files.Add(files.FirstOrDefault(f=>f.Id==file));
            }

            foreach (var like in entity.Likes)
            {
                post.Likes.Add(likes.FirstOrDefault(l=>l.Id == like.Id));
            }

            foreach (var profile in entity.RepostProfiles)
            {
                post.RepostProfiles.Add(profiles.FirstOrDefault(p=>p.Id == profile));
            }

            posts.Add(post);
        }

        /// <summary>
        /// Delete exist post by Id
        /// </summary>
        /// <param name="id">Id of exist post</param>
        public void DeleteById(int id)
        {
            var post = posts.FirstOrDefault(p => p.Id == id);
            if (!ReferenceEquals(post, null))
            {
                posts.Remove(post);
            }
            else
            {
                throw new ArgumentNullException(nameof(post));
            }
        }

        /// <summary>
        /// get All posts
        /// </summary>
        /// <returns>collection of all posts</returns>
        public IEnumerable<DalPost> GetAll()
        {
            return posts.Select(p => p).Map();
        }

        /// <summary>
        /// Get convrete post by Id
        /// </summary>
        /// <param name="id">Id of Concrete post</param>
        /// <returns>concrete DalPost entity</returns>
        public DalPost GetById(int id)
        {
            return posts.FirstOrDefault(p => p.Id == id).ToDalPost();
        }

        /// <summary>
        /// Method for updating exist post
        /// </summary>
        /// <param name="entity">exist post entity</param>
        public void Update(DalPost entity)
        {
            var post = posts.FirstOrDefault(p => p.Id == entity.Id);
            if (!ReferenceEquals(post, null))
            {
                post.Id = entity.Id;
                post.Date = entity.Date;
                post.AuthorId = entity.AuthorId;
                post.IsOnTheWall = entity.IsOnTheWall;
                post.Text = entity.Text;
                post.Comments.Clear();
                post.Files.Clear();
                post.Likes.Clear();
                post.RepostProfiles.Clear();
                foreach (var comment in entity.Comments)
                {
                    post.Comments.Add(messages.FirstOrDefault(m => m.Id == comment));
                }
                foreach (var file in entity.Files)
                {
                    post.Files.Add(files.FirstOrDefault(f => f.Id == file));
                }
                foreach (var like in entity.Likes)
                {
                    post.Likes.Add(likes.FirstOrDefault(l => l.Id == like.Id));
                }
                foreach (var profile in entity.RepostProfiles)
                {
                    post.RepostProfiles.Add(profiles.FirstOrDefault(p => p.Id == profile));
                }
                context.Entry(post).State = EntityState.Modified;
            }
            else
            {
                throw new ArgumentNullException(nameof(post));
            }
        }
    }
    #endregion
}

