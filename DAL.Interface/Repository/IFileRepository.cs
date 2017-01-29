using System.Collections.Generic;
using DAL.Interface.DTO;

namespace DAL.Interface.Repository
{
    /// <summary>
    /// Expand of IRepository interface for  operations with DalUsers
    /// </summary>
    public interface IFileRepository:IRepository<DalFile>
    {
        /// <summary>
        /// Method for gettin File by name
        /// </summary>
        /// <param name="name">name of file</param>
        DalFile GetByName(string name);

        /// <summary>
        /// Method for getting all gallery files
        /// </summary>
        /// <param name="id">profile Id</param>
        IEnumerable<DalFile> GetAllGalleryFiles(int id);
    }
}
