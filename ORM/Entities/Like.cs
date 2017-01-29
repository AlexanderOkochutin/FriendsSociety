namespace ORM.Entities
{
    /// <summary>
    /// ORM layout class
    /// </summary>
    public class Like
    {
        /// <summary>
        /// like Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Who make like (profile). It needs for database creation
        /// </summary>
        public virtual Profile ProfileFrom { get; set; }

        /// <summary>
        /// Destination post of like. It needs for database creation
        /// </summary>
        public virtual Post Post { get; set; }
    }
}
