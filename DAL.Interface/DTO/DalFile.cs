using System;

namespace DAL.Interface.DTO
{
    /// <summary>
    /// DAL layout File class
    /// </summary>
    public class DalFile:IEntity
    {
        /// <summary>
        /// Default constructor of DalFile entity
        /// </summary>
        public DalFile()
        {
            Date = DateTime.Now;
        }

        /// <summary>
        /// DalFile Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// DalFile Data
        /// </summary>
        public byte[] Data { get; set; }
        
        /// <summary>
        /// DalFile Mime Type
        /// </summary>
        public string MimeType { get; set; }

        /// <summary>
        /// DalFile Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// DalFile upload date
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// owner profile Id
        /// </summary>
        public int ProfileId { get; set; }

        /// <summary>
        /// Post ID which file belongs to
        /// </summary>
        public int? PostId { get; set; }
    }
}
