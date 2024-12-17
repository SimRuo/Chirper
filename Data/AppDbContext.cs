using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Chirper.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;



namespace Chirper.Data
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public DbSet<Chirp> Chirps { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuring a One-to-Many relationship
            modelBuilder.Entity<Chirp>()
                .HasOne(c => c.Author) // A Chirp has one Author
                .WithMany(u => u.Chirps) // A User has many Chirps
                .HasForeignKey(c => c.UserId); // UserId is the foreign key

            // Adding a unique constraint to the Username column
            modelBuilder.Entity<User>()
                .HasIndex(u => u.UserName) // UserName from IdentityUser
                .IsUnique();
        }
    }
}