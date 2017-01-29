using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.Interface.Entities;
using MvcPL.ViewModels;

namespace MvcPL.Infrastructure.Mappers
{
    /// <summary>
    /// Class for mapping  BllFile and FileViewModel
    /// </summary>
    public static class FileMapper
    {
        
        /// <summary>
        /// Map To FileView model
        /// </summary>
        /// <returns> FileViewModel same as BllFil</returns>
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
        /// Map To BllFile
        /// </summary>
        /// <returns>BllFile Same as FileViewModel</returns>
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
        /// Map to FileViewModels
        /// </summary>
        /// <returns>Collection of FileViewModel same as collection of BllFiles</returns>
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