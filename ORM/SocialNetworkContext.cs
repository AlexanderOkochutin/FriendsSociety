using System.Data.Entity;
using ICryptoService;
using ORM.Entities;
using ORM.Mappers;

namespace ORM
{
    /// <summary>
    /// Service ORM layout class, DbContext inheritor
    /// </summary>
    public class SocialNetworkContext:DbContext
    {
        /// <summary>
        /// Creates context and start initializer
        /// </summary>
        /// <param name="passwordService">class which implements IPasswordService</param>
        public SocialNetworkContext(IPasswordService passwordService) : base("SocialNetworkContext")
        {
            Database.SetInitializer(new DbInitializer(passwordService));
        }

        /// <summary>
        /// Users collection
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Profiles collection
        /// </summary>
        public DbSet<Profile> Profiles { get; set; }
        
        /// <summary>
        /// Roles collection
        /// </summary>
        public DbSet<Role> Roles { get; set; }

        /// <summary>
        /// Message collection
        /// </summary>
        public DbSet<Message> Messages { get; set; }

        /// <summary>
        /// Files collection
        /// </summary>
        public DbSet<File> Files { get; set; }

        /// <summary>
        /// Invites collection
        /// </summary>
        public DbSet<Invite> Invites { get; set; }

        /// <summary>
        /// Posts collection
        /// </summary>
        public DbSet<Post> Posts { get; set; }

        /// <summary>
        /// Likes collection
        /// </summary>
        public DbSet<Like> Likes { get; set; }

        /// <summary>
        /// Method needs to matching objects and tables
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserMapper());
            modelBuilder.Configurations.Add(new ProfileMapper());
            modelBuilder.Configurations.Add(new PostMapper());
        }
    }
}
