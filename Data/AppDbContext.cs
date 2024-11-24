using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Chirper.Models;



namespace Chirper.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Chirp> Chirps { get; set; }
        public DbSet<User> Users { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuring a One-to-Many relationship
            modelBuilder.Entity<Chirp>()
                .HasOne(c => c.Author) // A Chirp has one Author
                .WithMany(u => u.Chirps) // A User has many Chirps
                .HasForeignKey(c => c.UserId); // UserId is the foreign key
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=chirps.db");
        }
    }
}