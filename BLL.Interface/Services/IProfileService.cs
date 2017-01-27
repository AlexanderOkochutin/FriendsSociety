using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;

namespace BLL.Interface.Services
{
    public interface IProfileService
    {
        BllProfile Get(int id);
        void Update(BllProfile profile);
        BllProfile GetByUserEmail(string email);
        IEnumerable<BllProfile> Find(string stringKey = "", string city = null);
    }
}
