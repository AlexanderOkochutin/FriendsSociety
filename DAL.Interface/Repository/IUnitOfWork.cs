using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.Repository
{
    interface IUnitOfWork
    {
        IUserRepository Users { get; set; }
        IProfileRepository Profiles { get; set; }
        IFileRepository Photos { get; set; }
        IMessageRepository Messages { get; set; }
        IInviteRepository Invites { get; set; }
        void Commit();
    }
}
