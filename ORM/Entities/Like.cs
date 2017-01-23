using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.Entities
{
    public class Like
    {
        public int Id { get; set; }
        public virtual Profile ProfileFrom { get; set; }
        public virtual Post Post { get; set; }
    }
}
