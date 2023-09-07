using BooksManagementSystem.DbContexts;
using BooksManagementSystem.DTOs;
using BooksManagementSystem.Entities;
using BooksManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;

namespace BooksManagementSystem.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext _userDbContext;
        public UserRepository(UserDbContext userDbContext)
        {
            _userDbContext = userDbContext;   
        }

        public Task<User> addUser(User user)
        {
            throw new NotImplementedException();
        }
        //public async Task<User> addUser(User user)
        //{
        //    var res = _userDbContext.Users.Add(user);
        //    await _userDbContext.SaveChangesAsync();
        //    return res.Entity;
        //}
    }
}
