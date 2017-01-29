using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using BLL.Mappers;
using DAL.Interface.Repository;

namespace BLL.Services
{
    public class FileService : IFileService
    {
        private readonly IUnitOfWork unitOfWork;

        public FileService(IUnitOfWork uow)
        {
            unitOfWork = uow;
        }

        public void AddAvatarToUser(BllFile file, string email)
        {
            throw new NotImplementedException();
        }

        public async Task AddFileAsync(BllFile file)
        {
            unitOfWork.Files.Add(file.ToDalFile());
            await unitOfWork.CommitAsync();
        }

        public void AddFile(BllFile file)
        {
            unitOfWork.Files.Add(file.ToDalFile());
            unitOfWork.Commit();
        }

        public void DeleteFile(BllFile file)
        {
            unitOfWork.Files.DeleteById(file.Id);
            unitOfWork.Commit();
        }

        public List<BllFile> GetAllFiles(int userId)
        {
            return unitOfWork.Files.GetAll().Where(f => f.ProfileId == userId).Map().ToList();
        }

        public BllFile GetFile(int key)
        {
            return unitOfWork.Files.GetById(key).ToBllFile();
        }

        public void UpdateFile(BllFile file)
        {
            unitOfWork.Files.Update(file.ToDalFile());
        }

        public BllFile GetByName(string name)
        {
            return unitOfWork.Files.GetByName(name).ToBllFile();
        }

        public List<BllFile> GetAllGalleryFiles(int id)
        {
            return unitOfWork.Files.GetAllGalleryFiles(id).Map().ToList();
        }
    }
}
