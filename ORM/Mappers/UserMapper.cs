﻿using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.Mappers
{
    public class UserMapper:EntityTypeConfiguration<User>
    {
        public UserMapper()
        {
            ToTable("Users");
            HasKey(u => u.Id);
            Property(u => u.Email).IsRequired().HasMaxLength(64);
            Property(u => u.Login).IsRequired().HasMaxLength(64);
            Property(u => u.PasswordHash).IsRequired().HasMaxLength(128);
            Property(u => u.PasswordSalt).IsRequired().HasMaxLength(128);
            HasMany(u => u.Roles)
                .WithMany(r => r.Users)
                .Map(m => m.ToTable("UsersRoles")
                .MapLeftKey("UserId")
                .MapRightKey("RoleId"));
        }
    }
}
