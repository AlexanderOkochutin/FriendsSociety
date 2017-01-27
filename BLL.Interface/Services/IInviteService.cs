using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;

namespace BLL.Interface.Services
{
    public interface IInviteService
    {
        bool IsInviteSend(int idFrom, int idTo);
        void SendInvite(int idFrom, int idTo);
        void AddFriend(int idFrom, int idTo);
        IEnumerable<BllProfile> GetAllInviteProfiles(int idTo);
    }
}
