using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Entities
{
    public class BllProfile
    {
        public BllProfile()
        {
            Friends = new HashSet<int>();
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public DateTime? BirthDay { get; set; }

        public string RelationStatus { get; set; }

        public string City { get; set; }

        public ICollection<int> Friends { get; set; }
    }
}
