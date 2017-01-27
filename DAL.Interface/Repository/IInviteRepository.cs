using System.Collections.Generic;
using DAL.Interface.DTO;

namespace DAL.Interface.Repository
{
    public interface IInviteRepository:IRepository<DalInvite>
    {
        DalInvite GetByFromToId(int idFrom,int idTo);
        IEnumerable<DalProfile> GetAllInviteProfiles(int idTo);
    }
}
