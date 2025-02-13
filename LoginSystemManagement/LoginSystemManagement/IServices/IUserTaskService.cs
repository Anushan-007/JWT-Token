using LoginSystemManagement.DTOs.Request;
using LoginSystemManagement.DTOs.Response;

namespace LoginSystemManagement.IServices
{
    public interface IUserTaskService
    {
        Task<UserTaskResponse> AddTask(UserTaskRequest taskRequest);
        Task<IEnumerable<UserTaskResponse>> GetAllTasks();
        Task<UserTaskResponse> GetTaskById(Guid id);
        Task<UserTaskResponse> UpdateTask(Guid UserTaskId, UserTaskRequest taskRequest);
        Task<bool> DeleteTask(Guid id);
    }

}
