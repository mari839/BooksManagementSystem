using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BooksManagementSystem.DbContexts
{
    public class UserDbContext : IdentityDbContext
    {
        //protected readonly IConfiguration _configuration;


        //public UserDbContext(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //    options.UseNpgsql(_configuration.GetConnectionString("DefaultConnection"));
        //}

        public UserDbContext(DbContextOptions<BookDbContext> options) : base(options)
        {

        }
    }
}
