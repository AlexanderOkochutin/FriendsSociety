using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.Interface.Repository;
using DAL.Interface.DTO;
using DAL.Mappers;
using ORM;
using ORM.Entities;

namespace DAL.Concrete
{
    /// <summary>
    /// Class FileRepository implements IFileRepository
    /// </summary>
    public class FileRepository : IFileRepository
    {
        private readonly SocialNetworkContext context;
        private readonly DbSet<File> files;
        private readonly DbSet<Profile> profiles;
        private readonly DbSet<Post> posts;

        /// <summary>
        /// Create FileRepository instance
        /// </summary>
        /// <param name="context"></param>
        public FileRepository(SocialNetworkContext context)
        {
            this.context = context;
            files = context.Set<File>();
            posts = context.Set<Post>();
            profiles = context.Set<Profile>();
        }

        /// <summary>
        /// Method for adding new file
        /// </summary>
        public void Add(DalFile entity)
        {
            var file = entity.ToFile();
            file.Profile = profiles.FirstOrDefault(p => p.Id == entity.ProfileId);
            file.Post = posts.FirstOrDefault(p => p.Id == entity.PostId);
            files.Add(file);
        }

        /// <summary>
        /// Delete By Id exist file
        /// </summary>
        /// <param name="id">exist file Id</param>
        public void DeleteById(int id)
        {
            var file = files.FirstOrDefault(f => f.Id == id);
            if (!ReferenceEquals(file, null))
            {
                files.Remove(file);
            }
            else
            {
                throw new ArgumentNullException(nameof(file));
            }
        }

        /// <summary>
        /// Get All files
        /// </summary>
        /// <returns>collection of all files</returns>
        public IEnumerable<DalFile> GetAll()
        {
            return files.Select(f => f).Map();
        }

        /// <summary>
        /// Get exist file by Id
        /// </summary>
        /// <param name="id">Id of exist file</param>
        /// <returns>Dal file entity</returns>
        public DalFile GetById(int id)
        {
            return files.FirstOrDefault(f => f.Id == id).ToDalFile();
        }

        /// <summary>
        /// Method for updating exist file
        /// </summary>
        /// <param name="entity">exist file entity</param>
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
            else
            {
                throw new ArgumentNullException(nameof(file));
            }
        }

        /// <summary>
        /// Method for get file by name
        /// </summary>
        /// <param name="name">name of file</param>
        /// <returns>dalfile entity</returns>
        public DalFile GetByName(string name)
        {
            return files.FirstOrDefault(f => f.Name == name).ToDalFile();
        }

        /// <summary>
        /// Get AllGallery files method
        /// </summary>
        /// <param name="id">id of exist profile</param>
        /// <returns>collection of gallery images of exist profile</returns>
        public IEnumerable<DalFile> GetAllGalleryFiles(int id)
        {
            return files.Where(f => f.Profile.Id == id && f.Name == "galery").Map();
        }
    }
}
