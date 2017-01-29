using System;

namespace ORM.Entities
{
    /// <summary>
    /// ORM layout message class
    /// </summary>
    public class Message
    {
        /// <summary>
        /// Default constructor of message entity
        /// </summary>
        public Message()
        {
            Date = DateTime.Now;
        }

        /// <summary>
        /// message Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// profile who send message. It needs for database creation
        /// </summary>
        public virtual Profile ProfileFrom { get; set; }

        /// <summary>
        /// destination profile of message 
        /// </summary>
        public virtual Profile ProfileTo { get; set; }

        /// <summary>
        /// destination post of message(if null it's message to profile, if notnull it's comment)
        /// </summary>
        public virtual Post PostTo { get; set; }
        
        /// <summary>
        /// main text of message
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// date of message sending
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// message is read or not
        /// </summary>
        public bool IsRead { get; set; }
    }
}
