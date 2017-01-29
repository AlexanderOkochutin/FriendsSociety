using System.Collections.Generic;
using System.Linq;
using DAL.Interface.DTO;
using ORM.Entities;

namespace DAL.Mappers
{
    /// <summary>
    /// Service class for mapping DalFile and ORM File entities
    /// </summary>
    public static class FileMapper
    {
        /// <summary>
        /// Map To File
        /// </summary>
        /// <returns>new ORM File entity same as DalFile</returns>
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
        /// Map To DAlFile
        /// </summary>
        /// <returns>new DalFile entity same as File</returns>
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
                PostId = file.Post?.Id
            };
            return result;
        }

        /// <summary>
        /// Map To DalFiles
        /// </summary>
        /// <returns>new DalFile collection same as ORM files collection</returns>
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
