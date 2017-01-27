using System.Collections.Generic;
using DAL.Interface.DTO;

namespace DAL.Interface.Repository
{
    public interface IProfileRepository:IRepository<DalProfile>
    {
        DalProfile GetByUserEmail(string email);
        IEnumerable<DalProfile> GetAllFriendsOfId(int id);
    }
}
