using System.Data.Entity;
using ICryptoService;
using ORM.Entities;
using ORM.Mappers;

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

        public DbSet<Invite> Invites { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Like> Likes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserMapper());
            modelBuilder.Configurations.Add(new ProfileMapper());
            modelBuilder.Configurations.Add(new PostMapper());
        }
    }
}
