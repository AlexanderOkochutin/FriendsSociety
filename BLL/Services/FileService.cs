using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using BLL.Mappers;
using DAL.Interface.Repository;

namespace BLL.Services
{
    /// <summary>
    /// Service for work with Files, implements IFileService
    /// </summary>
    public class FileService : IFileService
    {
        private readonly IUnitOfWork unitOfWork;

        /// <summary>
        /// Create FileService instance
        /// </summary>
        /// <param name="uow">class which implements IUnitOfWork</param>
        public FileService(IUnitOfWork uow)
        {
            unitOfWork = uow;
        }

        /// <summary>
        /// Method to adding new file
        /// </summary>
        /// <param name="file">new BllFile</param>
        public void AddFile(BllFile file)
        {
            unitOfWork.Files.Add(file.ToDalFile());
            unitOfWork.Commit();
        }

        /// <summary>
        /// Method for delete exist File
        /// </summary>
        /// <param name="file">exist BllFile</param>
        public void DeleteFile(BllFile file)
        {
            unitOfWork.Files.DeleteById(file.Id);
            unitOfWork.Commit();
        }

        /// <summary>
        /// Method for getting all files belong to concrete profile
        /// </summary>
        /// <param name="userId">Id of exist profile</param>
        /// <returns>List of BllFiles</returns>
        public List<BllFile> GetAllFiles(int userId)
        {
            return unitOfWork.Files.GetAll().Where(f => f.ProfileId == userId).Map().ToList();
        }

        /// <summary>
        /// Method for getting concrete file by Id
        /// </summary>
        /// <param name="key">Id of exist file</param>
        /// <returns>concrete BllFile</returns>
        public BllFile GetFile(int key)
        {
            return unitOfWork.Files.GetById(key).ToBllFile();
        }

        /// <summary>
        /// Method for updating exist file
        /// </summary>
        /// <param name="file">exist BllFile</param>
        public void UpdateFile(BllFile file)
        {
            unitOfWork.Files.Update(file.ToDalFile());
        }

        /// <summary>
        /// Method for getting concrete file by name
        /// </summary>
        /// <param name="name">Name of exist file</param>
        /// <returns>concrete BllFile</returns>
        public BllFile GetByName(string name)
        {
            return unitOfWork.Files.GetByName(name).ToBllFile();
        }

        /// <summary>
        /// Method for getting all gallery files of concrete profile
        /// </summary>
        /// <param name="id">Id of exist profile</param>
        /// <returns>List of BllFiles</returns>
        public List<BllFile> GetAllGalleryFiles(int id)
        {
            return unitOfWork.Files.GetAllGalleryFiles(id).Map().ToList();
        }
    }
}
