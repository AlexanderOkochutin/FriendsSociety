using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.DTO
{
    public class DalInvite : IEntity
    {
        public int Id { get; set; }
        public int IdFrom { get; set; }
        public int IdTo { get; set; }
        public string Response { get; set; }
    }
}
