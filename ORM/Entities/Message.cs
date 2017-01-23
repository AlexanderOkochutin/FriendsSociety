using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.Entities
{
    public class Message
    {
        public Message()
        {
            Date = DateTime.Now;
        }

        public int Id { get; set; }

        public virtual Profile ProfileFrom { get; set; }

        public virtual Profile ProfileTo { get; set; }

        public virtual Post PostTo { get; set; }

        public string Text { get; set; }

        public DateTime Date { get; set; }

        public bool IsRead { get; set; }
    }
}
