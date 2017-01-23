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
    public class DbInitializer:CreateDatabaseIfNotExists<SocialNetworkContext>
    {
        private readonly IPasswordService passwordService;

        public DbInitializer(IPasswordService passwordService)
        {
            this.passwordService = passwordService;
        }

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
                Login = "Admin",
                Email = "okochutinwork@gmail.com",
                IsEmailConfirmed = true,
                PasswordSalt = passwordService.GetSalt()
            };

            adminUser.PasswordHash = passwordService.GetHash("123456", adminUser.PasswordSalt);

            var adminRoles = context.Set<Role>().Select(r => r);
            foreach (var role in adminRoles)
            {
                adminUser.Roles.Add(role);
            }

            context.Set<User>().Add(adminUser);
            context.SaveChanges();

            for (int i = 2; i < 7; i++)
            {
                User user = new User()
                {
                    Id = i,
                    Login =  $"User{i-1}",
                    Email = $"user{i-1}@gmail.com",
                    IsEmailConfirmed = true,
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
