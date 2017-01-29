namespace DAL.Interface.DTO
{
    /// <summary>
    /// DAL layout Invite class
    /// </summary>
    public class DalInvite : IEntity
    {
        /// <summary>
        /// DalInvite Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// DalInvite profile sender Id
        /// </summary>
        public int ProfileFrom { get; set; }

        /// <summary>
        /// Destination profile Id
        /// </summary>
        public int ProfileTo { get; set; }

        /// <summary>
        /// DalInvite Response
        /// </summary>
        public string Response { get; set; }
    }
}
