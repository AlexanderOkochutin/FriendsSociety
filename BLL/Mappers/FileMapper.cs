using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;
using DAL.Interface.DTO;

namespace BLL.Mappers
{
    public static class FileMapper
    {
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
