using System.Collections.Generic;
using DAL.Interface.DTO;

namespace DAL.Interface.Repository
{
    /// <summary>
    /// Expand of IRepository interface for  operations with DalProfiles
    /// </summary>
    public interface IProfileRepository:IRepository<DalProfile>
    {
        /// <summary>
        /// Get DAlProfile by contact email
        /// </summary>
        /// <param name="email">contact name of DalUser</param>
        DalProfile GetByUserEmail(string email);

        /// <summary>
        /// Get all friends of profile with Id
        /// </summary>
        /// <param name="id">profile Id</param>
        IEnumerable<DalProfile> GetAllFriendsOfId(int id);

        IEnumerable<DalProfile> GetAllDialogProfiles(int id);
    }
}
