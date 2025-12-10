using Api_final.Data;
using Api_final.Interfaces;
using Api_final.Models;
using Microsoft.EntityFrameworkCore;

namespace Api_final.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApiContext _context;

        public UserRepository(ApiContext context) { 
            _context = context;        
        }


        public async Task<Users?> GetByUserNameAsync(string userName)
        {
            return await _context.User.FirstOrDefaultAsync(x  => x.UserName == userName);
        }

        public async Task<Users> RegisterAsync(Users user)
        {
            _context.User.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
