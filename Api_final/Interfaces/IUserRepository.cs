using Api_final.Models;

namespace Api_final.Interfaces
{
    public interface IUserRepository
    {
        Task<Users?> GetByUserNameAsync(string userName);
        Task<Users> RegisterAsync(Users user);
    }
}
