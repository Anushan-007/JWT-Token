using LoginSystemManagement.Database;
using LoginSystemManagement.Entity;
using LoginSystemManagement.IRepository;
using Microsoft.EntityFrameworkCore;

namespace LoginSystemManagement.Repository
{
    public class userRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public userRepository(AppDbContext context)
        {
            _context = context; 
        }

        public async Task<User> UserRegister(User user)
        {
            var data = await _context.AddAsync(user);
            await _context.SaveChangesAsync();
            return data.Entity;
        }

        public async Task<User> GetUserName(string username)
        {
            var data = await _context.Users.FirstOrDefaultAsync(u => u.Name == username); 
            return data;
        }

        public async Task<List<User>> GetAllUsers()
        {
            var data = await _context.Users.ToListAsync();
            return data;
        }
    }
}
