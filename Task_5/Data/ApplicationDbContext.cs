using Microsoft.EntityFrameworkCore;
using Task_5.Models;

namespace Task_5.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Dropdown> Dropdowns { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Define the table name if needed
            modelBuilder.Entity<Dropdown>().ToTable("Dropdown");
        }
    }
}
