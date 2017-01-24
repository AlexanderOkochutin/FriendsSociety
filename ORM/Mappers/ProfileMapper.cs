using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORM.Entities;

namespace ORM.Mappers
{
    public class ProfileMapper:EntityTypeConfiguration<Profile>
    {
        public ProfileMapper()
        {
            ToTable("Profiles");
            HasKey(p => p.Id);
            Property(p => p.FirstName).HasMaxLength(128);
            Property(p => p.LastName).HasMaxLength(128);
            Property(p => p.City).HasMaxLength(128);
            Property(p => p.BirthDay);
            Property(p => p.Gender).HasMaxLength(16);
            Property(p => p.RelationStatus).HasMaxLength(16);
            HasRequired(p => p.User).WithOptional(u => u.Profile);
            HasMany(p => p.Messages)
                .WithRequired(m => m.ProfileFrom);
            HasMany(p => p.Files)
                .WithRequired(f => f.Profile);
            HasMany(p => p.Posts)
                .WithMany(p => p.RepostProfiles)
                .Map(m => m.ToTable("ProfilesReposts")
                .MapLeftKey("ProfileId")
                .MapRightKey("PostId"));
            HasMany(p => p.Friends)
                .WithMany(p => p.InFriends)
                .Map(m => m.ToTable("Friends")
                .MapLeftKey("UserId")
                .MapLeftKey("FriendId"));
        }
    }
}
