using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.Entities
{
    public class Invite
    {
        public int Id { get; set; }

        public virtual Profile ProfileFrom { get; set; }

        public virtual Profile ProfielTo { get; set; }

        public string Response { get; set; }
    }
}
