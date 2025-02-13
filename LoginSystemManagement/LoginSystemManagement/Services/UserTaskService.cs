using LoginSystemManagement.DTOs.Request;
using LoginSystemManagement.DTOs.Response;
using LoginSystemManagement.Entity;
using LoginSystemManagement.IRepository;
using LoginSystemManagement.IServices;

namespace LoginSystemManagement.Services
{
    public class UserTaskService : IUserTaskService
    {
        private readonly IUserTaskRepository _userTaskRepository;

        public UserTaskService(IUserTaskRepository userTaskRepository)
        {
            _userTaskRepository = userTaskRepository;
        }

        public async Task<UserTaskResponse> AddTask(UserTaskRequest taskRequest)
        {
            var task = new UserTask
            {
                Id = Guid.NewGuid(),
                Name = taskRequest.Name,
                UserId = taskRequest.UserId
            };

            var addedTask = await _userTaskRepository.AddTask(task);
            return new UserTaskResponse
            {
                Id = addedTask.Id,
                Name = addedTask.Name,
                UserId = addedTask.UserId
            };
        }

        public async Task<IEnumerable<UserTaskResponse>> GetAllTasks()
        {
            var tasks = await _userTaskRepository.GetAllTasks();
            return tasks.Select(t => new UserTaskResponse
            {
                Id = t.Id,
                Name = t.Name,
                UserId = t.UserId
            });
        }

        public async Task<UserTaskResponse> GetTaskById(Guid id)
        {
            var task = await _userTaskRepository.GetTaskById(id);
            if (task == null)
            {
                return null;
            }

            return new UserTaskResponse
            {
                Id = task.Id,
                Name = task.Name,
                UserId = task.UserId
            };
        }

        public async Task<UserTaskResponse> UpdateTask(Guid UserTaskId ,UserTaskRequest taskRequest)
        {
            var get = await _userTaskRepository.GetTaskById(UserTaskId);
            get.Name = taskRequest.Name;
            get.UserId = taskRequest.UserId;

            var updatedTask = await _userTaskRepository.UpdateTask(get);


            //var task = new UserTask
            //{
            //    //Id = taskRequest.UserTaskId,
            //    Name = taskRequest.Name
            //};

            return new UserTaskResponse
            {
                Id = updatedTask.Id,
                Name = updatedTask.Name,
                UserId = updatedTask.UserId
            };
        }

        public async Task<bool> DeleteTask(Guid id)
        {
            return await _userTaskRepository.DeleteTask(id);
        }
    }
}
