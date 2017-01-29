using System;

namespace BLL.Interface.Entities
{
    /// <summary>
    /// BLL layout File class 
    /// </summary>
    public class BllFile
    {
        /// <summary>
        /// Default constructor of BllFile entity
        /// </summary>
        public BllFile()
        {
            Date = DateTime.Now;
        }

        /// <summary>
        /// BLlFile Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// BllFile Data
        /// </summary>
        public byte[] Data { get; set; }

        /// <summary>
        /// BllFile MimeType
        /// </summary>
        public string MimeType { get; set; }

        /// <summary>
        /// BllFile Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// BllFile upload date
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// BllFile owner Id
        /// </summary>
        public int ProfileId { get; set; }

        /// <summary>
        /// Post Id which file belongs to
        /// </summary>
        public int? PostId { get; set; }
    }
}
