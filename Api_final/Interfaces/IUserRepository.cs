using Api_final.Models;

namespace Api_final.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByUserNameAsync(string userName);
        Task<User> RegisterAsync(User user);
    }
}
