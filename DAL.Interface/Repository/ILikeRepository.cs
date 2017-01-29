using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.DTO;

namespace DAL.Interface.Repository
{
    /// <summary>
    /// Expand of IRepository interface for  operations with DalLikes
    /// </summary>
    public interface ILikeRepository:IRepository<DalLike>
    {
    }
}
