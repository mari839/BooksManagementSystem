using BooksManagementSystem.Entities;

namespace BooksManagementSystem.Repositories
{
    public interface IUserRepository
    {
        Task<User> addUser(User user);
    }
}
