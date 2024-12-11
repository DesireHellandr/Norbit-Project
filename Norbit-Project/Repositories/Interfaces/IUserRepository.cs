using Norbit_Project.Models;

namespace Norbit_Project.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserByIdAsync(int id);
        Task<User> GetUserByEmailAsync(string email);
        Task AddUserAsync(User user);
        Task SaveChangesAsync();
    }
}
