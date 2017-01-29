using System;
using System.Collections.Generic;

namespace DAL.Interface.DTO
{
    public class DalProfile : IEntity
    {
        public DalProfile()
        {
            Friends = new List<int>();
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public DateTime? BirthDay { get; set; }

        public string RelationStatus { get; set; }

        public string City { get; set; }

        public IList<int> Friends { get; set; }
    }

}

