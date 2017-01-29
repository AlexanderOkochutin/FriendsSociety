using System.Collections.Generic;
using BLL.Interface.Entities;
using DAL.Interface.DTO;

namespace BLL.Mappers
{
    /// <summary>
    /// Service class for mapping DalFile and BllFile Entities
    /// </summary>
    public static class FileMapper
    {
        /// <summary>
        /// Method map To BllFile
        /// </summary>
        /// <returns>new BllFile the same as DalFile</returns>
        public static BllFile ToBllFile(this DalFile dalFile)
        {
            if (ReferenceEquals(dalFile, null)) return null;
            var bllFile = new BllFile()
            {
                Id = dalFile.Id,
                Date = dalFile.Date,
                Name = dalFile.Name,
                PostId = dalFile.PostId,
                ProfileId = dalFile.ProfileId,
                Data = dalFile.Data,
                MimeType = dalFile.MimeType
            };
            return bllFile;
        }

        /// <summary>
        /// Method map to DalFile
        /// </summary>
        /// <returns>new DalFile the same as BllFile</returns>
        public static DalFile ToDalFile(this BllFile bllFile)
        {
            if (ReferenceEquals(bllFile, null)) return null;
            var dalFile = new DalFile()
            {
                Id = bllFile.Id,
                Date = bllFile.Date,
                Name = bllFile.Name,
                PostId = bllFile.PostId,
                ProfileId = bllFile.ProfileId,
                Data = bllFile.Data,
                MimeType = bllFile.MimeType
            };
            return dalFile;
        }

        /// <summary>
        /// Method map To BllFiles
        /// </summary>
        /// <returns>new BllFiles collection same as DalFiles collection</returns>
        public static IEnumerable<BllFile> Map(this IEnumerable<DalFile> dalFiles)
        {
            var bllFiles = new List<BllFile>();
            foreach (var dalFile in dalFiles)
            {
                bllFiles.Add(dalFile.ToBllFile());
            }
            return bllFiles;
        }
    }
}
