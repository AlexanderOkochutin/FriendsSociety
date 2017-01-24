using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.Interface.DTO;
using ORM.Entities;

namespace DAL.Mappers
{
    /// <summary>
    /// Service class for mapping DalUser and ORM User entities
    /// </summary>
    public static class FileMapper

{

/// <summary>
        /// Map User
        /// </summary>
        /// <param name="user"></param>
        /// <returns>new ORM User entity same as user</returns>
        public static File ToFile(this DalFile file)
        {
            if (ReferenceEquals(file, null)) return null;
            File result = new File()
            {
                Id = file.Id,
                Data = file.Data,
                Date = file.Date,
                MimeType = file.MimeType,
                Name = file.Name
            };

            return result;
        }

        /// <summary>
        /// Map User
        /// </summary>
        /// <param name="user"></param>
        /// <returns>new DalUser entity same as user</returns>
        public static DalFile ToDalFile(this File file)
        {
            if (ReferenceEquals(file, null)) return null;
            DalFile result = new DalFile()
            {
                Id = file.Id,
                Date = file.Date,
                Data = file.Data,
                MimeType = file.MimeType,
                Name = file.Name,
                ProfileId = file.Profile.Id,
                PostId = file.Post.Id
            };
            return result;
        }

        /// <summary>
        /// Map users
        /// </summary>
        /// <param name="users"></param>
        /// <returns>new DalUser collection same as users</returns>
        public static IEnumerable<DalFile> Map(this IQueryable<File> Files)
        {
            var dalFiles = new List<DalFile>();
            foreach (var item in Files)
            {
                dalFiles.Add(item.ToDalFile());
            }
            return dalFiles;
        }
    }
}
