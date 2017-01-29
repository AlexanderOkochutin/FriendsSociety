using System;

namespace DAL.Interface.DTO
{
    /// <summary>
    /// DAL layout message class
    /// </summary>
    public class DalMessage:IEntity
    {
        /// <summary>
        /// default constructor of DalMessage entity
        /// </summary>
        public DalMessage()
        {
            Date = DateTime.Now;
        }

        /// <summary>
        /// DalMessage Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Profile Id who send message
        /// </summary>
        public int ProfileIdFrom { get; set; }

        /// <summary>
        /// Destination profile Id
        /// </summary>
        public int ProfileIdTo { get; set; }

        /// <summary>
        /// Destination Post Id
        /// </summary>
        public int PostId { get; set; }

        /// <summary>
        /// Date of sending
        /// </summary>
        public DateTime Date;

        /// <summary>
        /// Main Text of DalMessage
        /// </summary>
        public string Text;

        /// <summary>
        /// Is DalMessage read or not
        /// </summary>
        public bool IsRead { get; set; }
    }
}
