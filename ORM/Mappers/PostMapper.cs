using System.Data.Entity.ModelConfiguration;
using ORM.Entities;

namespace ORM.Mappers
{
    /// <summary>
    /// Service class for configuration Post table
    /// </summary>
    public class PostMapper:EntityTypeConfiguration<Post>
    {
        public PostMapper()
        {
            ToTable("Posts");
            HasKey(p => p.Id);
            HasMany(p => p.Files).WithOptional(f => f.Post);
            HasMany(p => p.Comments).WithOptional(m => m.PostTo);
            HasMany(p => p.Likes).WithRequired(l => l.Post);
            HasMany(p => p.RepostProfiles).WithMany(p => p.Posts);
        }
    }
}
