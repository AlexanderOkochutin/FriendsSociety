using System;
using System.Collections.Generic;

namespace DAL.Interface.DTO
{
    public class DalPost:IEntity
    {
        public int Id { get; set; }

        public int AuthorId { get; set; }

        public string Text { get; set; }

        public DateTime Date { get; set; }

        public ICollection<DalLike> Likes { get; set; }

        public bool IsOnTheWall { get; set; }

        public ICollection<int> RepostProfiles { get; set; }

        public ICollection<int> Files { get; set; }

        public ICollection<int> Comments { get; set; }
    }
}
