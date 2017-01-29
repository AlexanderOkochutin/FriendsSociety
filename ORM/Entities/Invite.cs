namespace ORM.Entities
{
    /// <summary>
    /// ORM layout friend Invite classs
    /// </summary>
    public class Invite
    {
        /// <summary>
        /// Invite Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// profile who send Invite. It needs for database creation
        /// </summary>
        public virtual Profile ProfileFrom { get; set; }

        /// <summary>
        /// destination profile of invite. It needs for database creation
        /// </summary>
        public virtual Profile ProfielTo { get; set; }

        /// <summary>
        /// invite response
        /// </summary>
        public string Response { get; set; }
    }
}
