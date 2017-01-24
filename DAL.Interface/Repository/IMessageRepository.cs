using System.Collections.Generic;
using DAL.Interface.DTO;

namespace DAL.Interface.Repository
{
    public interface IMessageRepository:IRepository<DalMessage>
    {
        List<DalMessage> GetMessages(int profileIdFrom, int profileIdTo);
    }
}
