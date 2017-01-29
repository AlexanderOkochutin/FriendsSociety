using System;
using System.Collections.Generic;

namespace BLL.Interface.Entities
{
    /// <summary>
    /// BLL layout profile class
    /// </summary>
    public class BllProfile
    {
        /// <summary>
        /// Default constructor of BllProfile instance
        /// </summary>
        public BllProfile()
        {
            Friends = new List<int>();
        }

        /// <summary>
        /// BllProfile Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// BllProfile Foirst name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// BllProfile Last Name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// BllProfile gender
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// BllProfile birth date
        /// </summary>
        public DateTime? BirthDay { get; set; }

        /// <summary>
        /// BllProfile status of relationship
        /// </summary>
        public string RelationStatus { get; set; }

        /// <summary>
        /// BllProfile address
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// BllProfile friends
        /// </summary>
        public IList<int> Friends { get; set; }
    }
}
