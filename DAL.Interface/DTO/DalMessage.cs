using System;

namespace DAL.Interface.DTO
{
    public class DalMessage:IEntity
    {
        public DalMessage()
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
