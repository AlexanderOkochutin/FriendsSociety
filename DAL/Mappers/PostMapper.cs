using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.DTO;
using ORM.Entities;

namespace DAL.Mappers
{
    public static class PostMapper
    {
        public static Post ToPost(this DalPost dalPost)
        {
            if (ReferenceEquals(dalPost, null)) return null;
            var post = new Post()
            {
                Id = dalPost.Id,
                Date = dalPost.Date,
                IsOnTheWall = dalPost.IsOnTheWall,
                Likes = 
            };
        }
    }
}
