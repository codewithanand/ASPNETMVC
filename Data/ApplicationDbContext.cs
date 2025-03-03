﻿using BulkyMovie.Models.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace BulkyMovie.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, CategoryName = "Action", DisplayOrder = 1},
                new Category { Id = 2, CategoryName = "SciFi", DisplayOrder = 2 },
                new Category { Id = 3, CategoryName = "History", DisplayOrder = 3 }
            );
        }
    }
}
