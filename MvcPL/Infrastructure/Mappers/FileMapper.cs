using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.Interface.Entities;
using MvcPL.ViewModels;

namespace MvcPL.Infrastructure.Mappers
{
    public static class FileMapper
    {
        /// <summary>
        /// Map User
        /// </summary>
        /// <param name="user"></param>
        /// <returns>new BllUser same as user</returns>
        public static FileViewModel ToFileViewModel(this BllFile File)
        {
            if (ReferenceEquals(File, null)) return null;
            FileViewModel result = new FileViewModel()
            {
                Id = File.Id,
                Date = File.Date,
                ProfileId = File.ProfileId,
                MimeType = File.MimeType,
                Data = File.Data,
                PostId = File?.PostId,
                Name = File.Name
            };
            return result;
        }

        /// <summary>
        /// Map User
        /// </summary>
        /// <param name="user"></param>
        /// <returns>new DalUser same as user</returns>
        public static BllFile ToBllFile(this FileViewModel File)
        {
            if (ReferenceEquals(File, null)) return null;
            BllFile result = new BllFile()
            {
                Id = File.Id,
                Date = File.Date,
                ProfileId = File.ProfileId,
                MimeType = File.MimeType,
                Data = File.Data,
                PostId = File?.PostId,
                Name = File.Name
            };
            return result;
        }

        /// <summary>
        /// Map Users
        /// </summary>
        /// <param name="users"></param>
        /// <returns>new BllUsers collection same as users</returns>
        public static IEnumerable<FileViewModel> Map(IEnumerable<BllFile> Files)
        {
            var bllFiles = new List<FileViewModel>();
            foreach (var item in Files)
            {
                bllFiles.Add(item.ToFileViewModel());
            }
            return bllFiles;
        }
    }
}