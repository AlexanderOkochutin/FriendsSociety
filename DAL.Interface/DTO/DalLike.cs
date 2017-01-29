namespace DAL.Interface.DTO
{
    /// <summary>
    /// DAL layout Like class
    /// </summary>
    public class DalLike:IEntity
    {
        /// <summary>
        /// DalLike Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// DalLike profile sender Id
        /// </summary>
        public int ProfileFromId { get; set; }

        /// <summary>
        /// Destination post Id
        /// </summary>
        public int PostId { get; set; }
    }
}
