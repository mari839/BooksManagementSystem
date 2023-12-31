using Microsoft.EntityFrameworkCore;
using BooksManagementSystem.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace BooksManagementSystem.DbContexts
{
    public class BookDbContext : DbContext
    {

        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options) 
        {

        }
        //protected readonly IConfiguration _configuration;


        //public BookDbContext(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //}


        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //    options.UseNpgsql(_configuration.GetConnectionString("DefaultConnection"));
        //}

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(
                new Author
                {
                    Id = 1,
                    Age = 10,
                    Country = "asda",
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
                    Id = 1,
                }
            );

            modelBuilder.Entity<Author>().HasData(
                new Author
                {
                    Id = 2,
                    Age = 22,
                    Country = "mari",
                    FirstName = "tandashvili",
                    LastName = "gsadasff",

                }
            );

            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    AuthorId = 2,
                    ISBN = "222-3-16-148410-10",
                    Description = "new description",
                    PublicationYear = 1995,
                    Rating = 9,
                    Title = "newTitle",
                    Id = 2,
                }
            );
        }

    }
}
