namespace BLL.Interface.Entities
{
    /// <summary>
    /// BLL layout class of Invite
    /// </summary>
    public class BllInvite
    {
        /// <summary>
        /// BllInvite Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// BllInvite sender Id
        /// </summary>
        public int ProfileFrom { get; set; }

        /// <summary>
        /// BllInvite destination profile Id
        /// </summary>
        public int ProfileTo { get; set; }

        /// <summary>
        /// BllInvite response
        /// </summary>
        public string Response { get; set; }
    }
}
