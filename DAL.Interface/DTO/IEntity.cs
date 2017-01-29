namespace DAL.Interface.DTO
{
    /// <summary>
    /// DAL layout entity interface. Each entity must have Id
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// Entity Id
        /// </summary>
        int Id { get; set; }
    }
}
