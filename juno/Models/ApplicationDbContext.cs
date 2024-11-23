using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace juno.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("db_truhamConnection")
        {
        }

        public DbSet<User> Users { get; set; }

        // Add a DbSet for the Events entity
        public DbSet<Events> Events { get; set; }

        // This method is used to configure the model (such as the primary key)
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Configure the primary key for Events
            modelBuilder.Entity<Events>()
                .HasKey(e => e.EventId); // Specify the primary key

            base.OnModelCreating(modelBuilder); // Always call this at the end of the method
        }
    }
}