using System;

namespace BLL.Interface.Entities
{
    /// <summary>
    /// BLL layout Message class 
    /// </summary>
    public class BllMessage
    {
        /// <summary>
        /// Default constructor of BllMessage instance
        /// </summary>
        public BllMessage()
        {
            Date = DateTime.Now;
        }

        /// <summary>
        /// BllMessage Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// BllMessage Sender Id
        /// </summary>
        public int ProfileIdFrom { get; set; }

        /// <summary>
        /// BllMessage Destination Id
        /// </summary>
        public int ProfileIdTo { get; set; }

        /// <summary>
        /// BllMessage Destination post Id
        /// </summary>
        public int PostId { get; set; }

        /// <summary>
        /// Bll Message  send date
        /// </summary>
        public DateTime Date;

        /// <summary>
        /// Bll Message main text
        /// </summary>
        public string Text;

        /// <summary>
        /// Is BlMessage
        /// </summary>
        public bool IsRead { get; set; }
    }
}
