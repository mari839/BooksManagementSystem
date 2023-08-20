using Microsoft.EntityFrameworkCore;
using BooksManagementSystem.Entities;
using Microsoft.Extensions.Configuration;

namespace BooksManagementSystem.DbContexts
{
    public class BookDbContext : DbContext
    {
        protected readonly IConfiguration _configuration;


        public BookDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(_configuration.GetConnectionString("DefaultConnection"));
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(
                    new Author
                    {
                        Id = 1,
                        Age = 1,
                        Country ="asda",
                        FirstName = "asf",
                        LastName = "gf",
                        
                    }
                );
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    AuthorId = 1,
                    ISBN = "978-3-16-148410-0",
                    Description = "Description",
                    PublicationYear = 1245,
                    Rating = 9,
                    Title = "Title",
                    Id =1,
                }
            );
        }

    }
}
