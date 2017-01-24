using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.DTO;
using DAL.Interface.Repository;
using DAL.Mappers;
using ORM;
using ORM.Entities;

namespace DAL.Concrete
{
    public class LikeRepository : ILikeRepository
    {
        private readonly SocialNetworkContext context;
        private readonly DbSet<Profile> profiles;
        private readonly DbSet<Post> posts;
        private readonly DbSet<Like> likes;

        public LikeRepository(SocialNetworkContext context)
        {
            this.context = context;
            profiles = context.Set<Profile>();
            posts = context.Set<Post>();
            likes = context.Set<Like>();
        }

        public void Add(DalLike entity)
        {
            var like = new Like()
            {
                Id = entity.Id,
                Post = posts.FirstOrDefault(p => p.Id == entity.PostId),
                ProfileFrom = profiles.FirstOrDefault(p => p.Id == entity.ProfileFromId)
            };
            likes.Add(like);
        }

        public void DeleteById(int id)
        {
            likes.Remove(likes.FirstOrDefault(l => l.Id == id));
        }

        public IEnumerable<DalLike> GetAll()
        {
            return likes.Select(l => l).Map();
        }

        public DalLike GetById(int id)
        {
            return likes.FirstOrDefault(l => l.Id == id).ToDalLike();
        }

        public DalLike GetByPredicate(Expression<Func<DalLike, bool>> f)
        {
            throw new NotImplementedException();
        }

        public void Update(DalLike entity)
        {
            var like = likes.FirstOrDefault(l => l.Id == entity.Id);
            like.Id = entity.Id;
            like.Post = posts.FirstOrDefault(p => p.Id == entity.PostId);
            like.ProfileFrom = profiles.FirstOrDefault(p => p.Id == entity.ProfileFromId);
            context.Entry(like).State = EntityState.Modified;
        }
    }
}
