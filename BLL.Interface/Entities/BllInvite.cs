using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Entities
{
    public class BllInvite
    {
        public int Id { get; set; }
        public int ProfileFrom { get; set; }
        public int ProfileTo { get; set; }
        public string Response { get; set; }
    }
}
