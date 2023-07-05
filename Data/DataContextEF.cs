using LibraryConsoleApp.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryConsoleApp.Data{

    public class DataContextEF:DbContext
    {
        private string _connectionString = "Server=localhost;Database=Library;Trusted_Connection=false;TrustServerCertificate=True;User Id=sa;Password=SQLConnect1;";

        public DbSet<Book> ? Book {set; get;}
        public DbSet<Customer> ? Customer {set;get;}
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)//connecting to database 
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString,
                optionsBuilder => optionsBuilder.EnableRetryOnFailure());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) //mapping each column to a property in the model
        {
            modelBuilder.Entity<Book>(entity => {
                //entity.HasNoKey();
                entity.ToTable("Book");

                entity.Property(e=> e.BookId)
                .HasColumnName("BookId");
                
                entity.Property(e => e.Title)
                .IsRequired()
                .HasColumnName("Title");

                entity.Property(e => e.Author)
                .IsRequired()
                .HasColumnName("Author");

                entity.Property(e => e.Genre)
                .IsRequired()
                .HasColumnName("Genre");

                entity.Property(e => e.Price)
                .IsRequired()
                .HasColumnName("Price");

                entity.Property(e => e.PublishedDate)
                .IsRequired()
                .HasColumnName("PublishedDate");
            });

            modelBuilder.Entity<Customer>(entity => {
                entity.ToTable("Customer");

                entity.Property(e=> e.CustomerId)
                .HasColumnName("CustomerId");

                entity.Property(e => e.FullName)
                .IsRequired()
                .HasColumnName("FullName");

                entity.Property(e=>e.PhoneNumber)
                .IsRequired()
                .HasColumnName("PhoneNumber");

                entity.Property(e => e.Email)
                .IsRequired()
                .HasColumnName("Email");

            });

        }


    }
}