using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.Repository;
using DAL.Interface.DTO;
using DAL.Mappers;
using ORM;
using ORM.Entities;

namespace DAL.Concrete
{
    public class FileRepository : IFileRepository
    {
        private readonly SocialNetworkContext context;
        private readonly DbSet<File> files;
        private readonly DbSet<Profile> profiles;
        private readonly DbSet<Post> posts;

        public FileRepository(SocialNetworkContext context)
        {
            this.context = context;
            files = context.Set<File>();
            posts = context.Set<Post>();
            profiles = context.Set<Profile>();
        }


        public void Add(DalFile entity)
        {
            var file = entity.ToFile();
            file.Profile = profiles.FirstOrDefault(p => p.Id == entity.ProfileId);
            file.Post = posts.FirstOrDefault(p => p.Id == entity.PostId);
            files.Add(file);
        }

        public void DeleteById(int id)
        {
            files.Remove(files.FirstOrDefault(f => f.Id == id));
        }

        public IEnumerable<DalFile> GetAll()
        {
            return files.Select(f => f).Map();
        }

        public DalFile GetById(int id)
        {
            return files.FirstOrDefault(f => f.Id == id).ToDalFile();
        }

        public DalFile GetByPredicate(Expression<Func<DalFile, bool>> f)
        {
            throw new NotImplementedException();
        }

        public void Update(DalFile entity)
        {
            var file = files.FirstOrDefault(f => f.Id == entity.Id);
            if (!ReferenceEquals(file, null))
            {
                file.Id = entity.Id;
                file.Profile = profiles.FirstOrDefault(p => p.Id == entity.ProfileId);
                file.Post = posts.FirstOrDefault(p => p.Id == entity.PostId);
                file.Data = entity.Data;
                file.Date = entity.Date;
                file.Name = entity.Name;
                file.MimeType = entity.MimeType;
                context.Entry(file).State = EntityState.Modified;
            }
        }

        public DalFile GetByName(string name)
        {
            return files.FirstOrDefault(f => f.Name == name).ToDalFile();
        }

        public IEnumerable<DalFile> GetAllGalleryFiles(int id)
        {
            return files.Where(f => f.Profile.Id == id && f.Name == "galery").Map();
        }
    }
}
