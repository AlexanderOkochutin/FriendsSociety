using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.Entities
{
    public class File
    {
        public File()
        {
            Date = DateTime.Now;
            Profiles = new HashSet<Profile>();
        }

        public int Id { get; set; }

        public byte[] Data { get; set; }

        public string MimeType { get; set; }

        public string Name { get; set; }

        public DateTime Date { get; set; }

        public virtual ICollection<Profile> Profiles { get; set; }
    }
}
