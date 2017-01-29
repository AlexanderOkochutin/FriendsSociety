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
    public class MessageService:IMessageService
    {
        private readonly IUnitOfWork unitOfWork;

        public MessageService(IUnitOfWork uow)
        {
            unitOfWork = uow;
        }

        public void AddMessage(BllMessage message)
        {
            unitOfWork.Messages.Add(message.ToDalMessage());
            unitOfWork.Commit();
        }

        public List<BllMessage> GetMessages(int UserFrom, int UserTo)
        {
            var temp = unitOfWork.Messages.GetMessages(UserFrom, UserTo);
            return temp.Map().ToList();
        }

        public int NumsOfUnreadMessage(int idProfile)
        {
           return unitOfWork.Messages.NumberOfUnreadMessage(idProfile);
        }

        public void ReadMessage(int id)
        {
            unitOfWork.Messages.ReadMessage(id);
            unitOfWork.Commit();
        }

        
    }
}
