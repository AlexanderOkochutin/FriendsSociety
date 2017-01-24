using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Entities
{
    public class BllMessage
    {
        public BllMessage()
        {
            Date = DateTime.Now;
        }

        public int Id { get; set; }

        public int ProfileIdFrom { get; set; }

        public int ProfileIdTo { get; set; }

        public int PostId { get; set; }

        public DateTime Date;

        public string Text;

        public bool IsRead { get; set; }
    }
}
