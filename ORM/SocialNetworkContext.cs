using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICryptoService;
using ORM.Entities;

namespace ORM
{
    public class SocialNetworkContext:DbContext
    {
        public SocialNetworkContext(IPasswordService passwordService) : base("SocialNetworkContext")
        {
            Database.SetInitializer(new DbInitializer(passwordService));
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Profile> Profiles { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Message> Messages { get; set; }

        public DbSet<File> Files { get; set; }

        public DbSet<FriendInvite> Invites { get; set; }

        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Profile>().HasRequired(t => t.User).WithOptional(u => u.Profile);
            modelBuilder.Entity<Profile>()
                .HasMany(c => c.Friends)
                .WithMany(p => p.InFriends)
                .Map(m =>
                {
                    m.ToTable("Friends");
                    m.MapLeftKey("UserId");
                    m.MapRightKey("User2Id");
                });
        }
    }
}
