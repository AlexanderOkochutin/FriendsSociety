using System;
using System.Collections.Generic;

namespace ORM.Entities
{
    public class File
    {
        public File()
        {
            Date = DateTime.Now;
        }

        public int Id { get; set; }

        public byte[] Data { get; set; }

        public string MimeType { get; set; }

        public string Name { get; set; }

        public DateTime Date { get; set; }

        public virtual Profile Profile { get; set; }

        public virtual Post Post { get; set; }
    }
}
