using System;
using System.Collections.Generic;

namespace DAL.Interface.DTO
{
    /// <summary>
    /// DAL layout Profile class
    /// </summary>
    public class DalProfile : IEntity
    {
        /// <summary>
        /// Default constructor of DalProfile
        /// </summary>
        public DalProfile()
        {
            Friends = new List<int>();
        }

        /// <summary>
        /// DalProfile Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// DalProfile First name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// DalProfile Last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// DalProfile gender
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// DalProfile Birth date
        /// </summary>
        public DateTime? BirthDay { get; set; }

        /// <summary>
        /// DalProfile relationship status
        /// </summary>
        public string RelationStatus { get; set; }

        /// <summary>
        /// DalPRofile address
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// DalProfile list of friends Id
        /// </summary>
        public IList<int> Friends { get; set; }
    }
}

