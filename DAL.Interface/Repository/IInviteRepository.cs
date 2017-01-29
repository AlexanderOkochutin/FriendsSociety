using System.Collections.Generic;
using DAL.Interface.DTO;

namespace DAL.Interface.Repository
{
    /// <summary>
    /// Expand of IRepository interface for  operations with DalInvites
    /// </summary>
    public interface IInviteRepository:IRepository<DalInvite>
    {
        /// <summary>
        /// Get concrete invite with sender Id and destination Id
        /// </summary>
        /// <param name="idFrom">sender Id</param>
        /// <param name="idTo">destination Id</param>
        DalInvite GetByFromToId(int idFrom,int idTo);

        /// <summary>
        /// Get All invites for profile with Id
        /// </summary>
        /// <param name="idTo">profile Id</param>
        IEnumerable<DalProfile> GetAllInviteProfiles(int idTo);
    }
}
