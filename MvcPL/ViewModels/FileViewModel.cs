using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcPL.ViewModels
{
    public class FileViewModel
    {
        public FileViewModel()
        {
            Date = DateTime.Now;
        }

        public int Id { get; set; }
        public byte[] Data { get; set; }
        public string MimeType { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int ProfileId { get; set; }
        public int? PostId { get; set; }
    }
}