using LoginSystemManagement.Database;
using LoginSystemManagement.Entity;
using LoginSystemManagement.IRepository;
using Microsoft.EntityFrameworkCore;

namespace LoginSystemManagement.Repository
{
    public class UserTaskRepository : IUserTaskRepository
    {
        private readonly AppDbContext _context;

        public UserTaskRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UserTask> AddTask(UserTask task)
        {
            // Check if the UserId exists in the Users table
            var userExists = await _context.Users.AnyAsync(u => u.Id == task.UserId);
            if (!userExists)
            {
                throw new Exception("UserId does not exist.");
            }

            var data = await _context.UserTasks.AddAsync(task);
            await _context.SaveChangesAsync();
            return data.Entity;
        }

        public async Task<IEnumerable<UserTask>> GetAllTasks()
        {
            return await _context.UserTasks.Include(t => t.User).ToListAsync();
        }

        public async Task<UserTask> GetTaskById(Guid id)
        {
            return await _context.UserTasks.Include(t => t.User).FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<UserTask> UpdateTask(UserTask task)
        {
            var existingTask = await _context.UserTasks.FindAsync(task.Id);
            if (existingTask == null)
            {
                throw new Exception("Task not found.");
            }

            existingTask.Name = task.Name;

            _context.UserTasks.Update(existingTask);
            await _context.SaveChangesAsync();
            return existingTask;
        }

        public async Task<bool> DeleteTask(Guid id)
        {
            var task = await _context.UserTasks.FindAsync(id);
            if (task == null)
            {
                return false;
            }

            _context.UserTasks.Remove(task);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
