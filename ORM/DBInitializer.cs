using System.Data.Entity;
using System.Linq;
using ICryptoService;
using ORM.Entities;

namespace ORM
{
    /// <summary>
    /// Service class for database initializing
    /// </summary>
    public class DbInitializer:CreateDatabaseIfNotExists<SocialNetworkContext>
    {
        private readonly IPasswordService passwordService;

        /// <summary>
        /// constructor for initializer
        /// </summary>
        /// <param name="passwordService">service which implements IPassword service</param>
        public DbInitializer(IPasswordService passwordService)
        {
            this.passwordService = passwordService;
        }

        /// <summary>
        /// Method which creates all Roles, Administrator and test users.
        /// </summary>
        /// <param name="context"> context name </param>
        protected override void Seed(SocialNetworkContext context)
        {
            context.Roles.AddRange(new Role[]
            {
                new Role() {Id = 1, Name = "Administrator"},
                new Role() {Id = 2, Name = "User"}
            });
            context.SaveChanges();

            User adminUser = new User()
            {
                Id = 1,
                Email = "okochutinwork@gmail.com",
                IsEmailConfirmed = true,
                MailSalt = passwordService.GetSalt(),
                PasswordSalt = passwordService.GetSalt()
            };

            adminUser.PasswordHash = passwordService.GetHash("123456", adminUser.PasswordSalt);

            var adminRoles = context.Set<Role>().Select(r => r);
            foreach (var role in adminRoles)
            {
                adminUser.Roles.Add(role);
            }
            var adminProfile = new Profile()
            {
                Id = 1
            };
            context.Set<Profile>().Add(adminProfile);
           context.Set<User>().Add(adminUser);
            context.SaveChanges();

            for (int i = 2; i < 15; i++)
            {
                User user = new User()
                {
                    Id = i,
                    Email = $"user{i-1}@gmail.com",
                    IsEmailConfirmed = true,
                    MailSalt =  passwordService.GetSalt(),
                    PasswordSalt = passwordService.GetSalt()
                };
                user.PasswordHash = passwordService.GetHash("123456", user.PasswordSalt);
                user.Roles.Add(context.Set<Role>().FirstOrDefault(r=>r.Name=="User"));
                context.Set<User>().Add(user);
                var profile = new Profile()
                {
                    Id = user.Id
                };
                context.Set<Profile>().Add(profile);
                context.SaveChanges();
            }
        }
    }
}
