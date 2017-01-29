using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;

namespace BLL.Interface.Services
{
    public interface IFileService
    {
        void AddFile(BllFile file);
        Task AddFileAsync(BllFile file);
        void AddAvatarToUser(BllFile file, string email);
        void DeleteFile(BllFile file);
        void UpdateFile(BllFile file);
        List<BllFile> GetAllFiles(int userId);
        BllFile GetFile(int key);
        BllFile GetByName(string name);
        List<BllFile> GetAllGalleryFiles(int id);
    }
}
