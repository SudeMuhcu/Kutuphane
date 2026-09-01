using Kutuphane.Models;
using Kutuphane.Models.Kutuphane.Models;
using Microsoft.EntityFrameworkCore;

namespace Kutuphane.Context
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options)
        {


        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Loan>()
                .HasOne(x => x.Student)
                .WithMany(x => x.Loans)
                .HasForeignKey(x => x.StudentId);

            modelBuilder.Entity<Loan>()
                .HasOne(x => x.Book)
                .WithMany(x => x.Loans)
                .HasForeignKey(x => x.BookId);

            modelBuilder.Entity<Student>()
                .HasOne(x => x.AppUser)
                .WithOne(x => x.Student)
                .HasForeignKey<Student>(x => x.AppUserId);
        }
    }
}