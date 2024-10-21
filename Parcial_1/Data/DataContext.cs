using Microsoft.EntityFrameworkCore;
using Parcial_1.Entities;

namespace Parcial_1.API.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Loan> Loans { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.Entity<Book>().HasIndex(b => b.ISBN).IsUnique();
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
            modelBuilder.Entity<Category>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<Publisher>().HasIndex(p => p.Name).IsUnique();
            modelBuilder.Entity<Loan>().HasIndex(l => new { l.UserId, l.BookId }).IsUnique(); 
            modelBuilder.Entity<Reservation>().HasIndex(r => new { r.UserId, r.BookId }).IsUnique(); 
        }
    }
}
