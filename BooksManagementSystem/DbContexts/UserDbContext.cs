﻿using BooksManagementSystem.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BooksManagementSystem.DbContexts
{
    public class UserDbContext : IdentityDbContext<IdentityUser>
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            SeedRoles(builder);
        }

        private void SeedRoles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "Admin" },
                new IdentityRole() { Name = "User", ConcurrencyStamp = "2", NormalizedName = "User" }
                );
        }

    }
}
