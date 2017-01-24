using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Entities
{
    public class BllPost
    {
        public BllPost()
        {
            Date = DateTime.Now;
            Likes = new HashSet<BllLike>();
            RepostProfiles = new HashSet<int>();
            Files = new HashSet<int>();
            Comments = new HashSet<int>();
        }

        public int Id { get; set; }

        public int AuthorId { get; set; }

        public string Text { get; set; }

        public DateTime Date { get; set; }

        public ICollection<BllLike> Likes { get; set; }

        public bool IsOnTheWall { get; set; }

        public ICollection<int> RepostProfiles { get; set; }

        public ICollection<int> Files { get; set; }

        public ICollection<int> Comments { get; set; }
    }
}
