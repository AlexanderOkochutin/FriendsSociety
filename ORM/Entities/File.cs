using System;

namespace ORM.Entities
{
    /// <summary>
    /// ORM layout file class
    /// </summary>
    public class File
    {
        /// <summary>
        /// default constructor of file entity
        /// </summary>
        public File()
        {
            Date = DateTime.Now;
        }

        /// <summary>
        /// file Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// file data
        /// </summary>
        public byte[] Data { get; set; }

        /// <summary>
        /// file Mime type
        /// </summary>
        public string MimeType { get; set; }

        /// <summary>
        /// file name in database
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// file upload date
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// profile of owner of file. It needs for database creation
        /// </summary>
        public virtual Profile Profile { get; set; }

        /// <summary>
        /// post for wich file belong to. It needs for database creation
        /// </summary>
        public virtual Post Post { get; set; }
    }
}
