using LoginSystemManagement.Entity;

namespace LoginSystemManagement.IRepository
{
    public interface IUserTaskRepository
    {
        Task<UserTask> AddTask(UserTask task);
        Task<IEnumerable<UserTask>> GetAllTasks();
        Task<UserTask> GetTaskById(Guid id);
        Task<UserTask> UpdateTask(UserTask task);
        Task<bool> DeleteTask(Guid id);
    }
}
