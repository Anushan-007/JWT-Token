using LoginSystemManagement.DTOs.Request;
using LoginSystemManagement.DTOs.Response;
using LoginSystemManagement.IServices;
using Microsoft.AspNetCore.Mvc;

namespace LoginSystemManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTaskController : ControllerBase
    {
        private readonly IUserTaskService _userTaskService;

        public UserTaskController(IUserTaskService userTaskService)
        {
            _userTaskService = userTaskService;
        }

        [HttpPost("AddTask")]
        public async Task<IActionResult> AddTask(UserTaskRequest taskRequest)
        {
            try
            {
                var data = await _userTaskService.AddTask(taskRequest);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException?.Message ?? ex.Message);
            }
        }

        [HttpGet("GetAllTasks")]
        public async Task<IActionResult> GetAllTasks()
        {
            var data = await _userTaskService.GetAllTasks();
            return Ok(data);
        }

        [HttpGet("GetTaskById/{id}")]
        public async Task<IActionResult> GetTaskById(Guid id)
        {
            var data = await _userTaskService.GetTaskById(id);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpPut("UpdateTask")]
        public async Task<IActionResult> UpdateTask(Guid UserTaskId, UserTaskRequest taskRequest)
        {
            try
            {
                var get = await _userTaskService.GetTaskById(UserTaskId);
                var data = await _userTaskService.UpdateTask(get.Id, taskRequest);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException?.Message ?? ex.Message);
            }
        }

        [HttpDelete("DeleteTask/{id}")]
        public async Task<IActionResult> DeleteTask(Guid id)
        {
            var result = await _userTaskService.DeleteTask(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
