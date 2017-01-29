namespace BLL.Interface.Entities
{
    /// <summary>
    /// BLL layout class of Like
    /// </summary>
    public class BllLike
    {
        /// <summary>
        /// BllLike Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Sender Id
        /// </summary>
        public int ProfileFromId { get; set; }

        /// <summary>
        /// Destination post Id
        /// </summary>
        public int PostId { get; set; }
    }
}
