using System.Collections.Generic;
using BLL.Interface.Entities;

namespace BLL.Interface.Services
{
    /// <summary>
    /// Interface for work with Files
    /// </summary>
    public interface IFileService
    {
        /// <summary>
        /// Method for addding new file
        /// </summary>
        /// <param name="file">new BllFile</param>
        void AddFile(BllFile file);

        /// <summary>
        /// Delete exist file
        /// </summary>
        /// <param name="file">exist BllFile</param>
        void DeleteFile(BllFile file);

        /// <summary>
        /// Method for update exist file
        /// </summary>
        /// <param name="file">exist BllFile</param>
        void UpdateFile(BllFile file);

        /// <summary>
        /// Method for getting all files of concrete profile
        /// </summary>
        /// <param name="userId">Id of concrete user</param>
        /// <returns>List of BLlFIles</returns>
        List<BllFile> GetAllFiles(int userId);

        /// <summary>
        /// Get Concrete File by Id
        /// </summary>
        /// <param name="key">Id of exist BllFile</param>
        /// <returns>concrete BllFile</returns>
        BllFile GetFile(int key);

        /// <summary>
        /// Method for getting exist file by name
        /// </summary>
        /// <param name="name">name of exist file</param>
        /// <returns>concrete BllFile entity</returns>
        BllFile GetByName(string name);

        /// <summary>
        /// Method for getting all gallery files of concrete profile
        /// </summary>
        /// <param name="id">Id of exist profile</param>
        /// <returns>List of all Gallery files</returns>
        List<BllFile> GetAllGalleryFiles(int id);
    }
}
