using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using SZMK.Domain;
using SZMK.Infrastructure.Cryptography;
using SZMK.Domain.Models;
using SZMK.Domain.Constants;

namespace SZMK.Infrastructure.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<RefreshSession> RefreshSessions { get; set; }
        public DbSet<UserChange> UserChanges { get; set; }
        public DbSet<Role> Roles { get; set; }
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>().HasKey(t => new { t.RoleId, t.UserId });

            modelBuilder.Entity<UserRole>()
                .HasOne(kp => kp.User)
                .WithMany(k => k.UserRoles)
                .HasForeignKey(kp => kp.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserRole>()
                .HasOne(kp => kp.Role)
                .WithMany(k => k.UserRoles)
                .HasForeignKey(kp => kp.RoleId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserChange>().HasKey(t => new { t.OwnerId, t.UserId });

            modelBuilder.Entity<UserChange>()
                .HasOne(kp => kp.User)
                .WithMany(k => k.UserChanges)
                .HasForeignKey(kp => kp.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<UserChange>()
                .HasOne(kp => kp.Owner)
                .WithMany(k => k.OwnerChanges)
                .HasForeignKey(kp => kp.OwnerId)
                .OnDelete(DeleteBehavior.NoAction);

            byte[] Salt = new Hasher().GetSalt();

            User[] Users =
            {
                new User
                {
                    Id = 1,
                    DateCreate = DateTime.Now,
                    SurName = "ROOT",
                    Name = "ROOT",
                    MiddleName = "ROOT",
                    Login = "ROOT",
                    Salt = Salt,
                    Password = new Hasher().GetHash("askede12AS!",Salt),
                    UpdatePassword = false,
                    Active = true,
                    CountFailEnter = 0
                }
            };

            RolesConstants rolesConstants = new RolesConstants();

            UserRole[] RolesAdmin =
            {
                new UserRole { UserId = Users[0].Id, RoleId = rolesConstants.Roles[0].Id },
                new UserRole { UserId = Users[0].Id, RoleId = rolesConstants.Roles[1].Id },
                new UserRole { UserId = Users[0].Id, RoleId = rolesConstants.Roles[2].Id },
                new UserRole { UserId = Users[0].Id, RoleId = rolesConstants.Roles[3].Id }
            };

            UserChangeTypeConstants userChangeTypeConstants = new UserChangeTypeConstants();

            UserChange[] UserChanges =
            {
                new UserChange 
                {
                    DateCreate = DateTime.Now,
                    SurName = Users[0].SurName,
                    Name = Users[0].Name,
                    MiddleName = Users[0].MiddleName,
                    Login = Users[0].Login,
                    Salt = Users[0].Salt,
                    Password = Users[0].Password,
                    UpdatePassword = Users[0].UpdatePassword,
                    Active = Users[0].Active,
                    TypeId = userChangeTypeConstants.UserChangeTypes[0].Id,
                    UserId = Users[0].Id, 
                    OwnerId = Users[0].Id 
                }
            };

            modelBuilder.Entity<User>().HasData(Users);

            modelBuilder.Entity<Role>().HasData(rolesConstants.Roles);

            modelBuilder.Entity<UserRole>().HasData(RolesAdmin);

            modelBuilder.Entity<UserChangeType>().HasData(userChangeTypeConstants.UserChangeTypes);

            modelBuilder.Entity<UserChange>().HasData(UserChanges);
        }
    }
}
