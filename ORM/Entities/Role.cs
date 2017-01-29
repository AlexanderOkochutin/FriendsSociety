using System.Collections.Generic;

namespace ORM.Entities
{
    /// <summary>
    /// ORM layout Role class
    /// </summary>
    public class Role
    {
        /// <summary>
        /// Default constructor for role entity
        /// </summary>
        public Role()
        {
            Users = new List<User>();
        }

        /// <summary>
        /// role Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// role name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// roles users. It need for database creation
        /// </summary>
        public virtual ICollection<User> Users { get; set; }
    }
}
