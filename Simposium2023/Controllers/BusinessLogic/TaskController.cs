using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Simposium2023.Attributes;
using Simposium2023.Helpers;
using Simposium2023.Models.Responses;
using Simposium2023.Repositories.BusinessLogic.Task;
using Simposium2023.Models.BussinessLogic;

namespace Simposium2023.Controllers.BusinessLogic
{
    [TypeFilter(typeof(AuthorizeAttribute))]
    [ApiController]
    [Route("simposium-api/tasks")]
    [ApiExplorerSettings(GroupName = "Tasks")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;
        private readonly GenericResponse<JObject> _error = new();

        public TaskController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTasks()
        {
            try
            {
                var result = await _taskRepository.GetAllTasksAsync();
                return StatusCode(result.StatusCode, result);
            }
            catch (Exception ex)
            {
                _error.StatusCode = 500;
                _error.Message = MessageErrorBuilder.GenerateError(ex.Message);
                return StatusCode(_error.StatusCode, _error);
            }
        }

        [HttpGet("getCompletedTasks")]
        public async Task<IActionResult> GetCompletedTasksAsync()
        {
            try
            {
                var result = await _taskRepository.GetCompletedTasksAsync();
                return StatusCode(result.StatusCode, result);
            }
            catch (Exception ex)
            {
                _error.StatusCode = 500;
                _error.Message = MessageErrorBuilder.GenerateError(ex.Message);
                return StatusCode(_error.StatusCode, _error);
            }
        }

        [HttpGet("{taskId}")]
        public async Task<IActionResult> GetSpecificTaskAsync(string taskId)
        {
            try
            {
                var result = await _taskRepository.GetSpecificTaskAsync(taskId);
                return StatusCode(result.StatusCode, result);
            }
            catch (Exception ex)
            {
                _error.StatusCode = 500;
                _error.Message = MessageErrorBuilder.GenerateError(ex.Message);
                return StatusCode(_error.StatusCode, _error);
            }
        }

        [HttpPost]
        public async Task<IActionResult> TaskRegistrationAsync([FromBody] TaskRegistration task)
        {
            try
            {
                var result = await _taskRepository.TaskRegistrationAsync(task);
                return StatusCode(result.StatusCode, result);
            }
            catch (Exception ex)
            {
                _error.StatusCode = 500;
                _error.Message = MessageErrorBuilder.GenerateError(ex.Message);
                return StatusCode(_error.StatusCode, _error);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTaskAsync([FromBody] TaskUpdated task)
        {
            try
            {
                var result = await _taskRepository.UpdateTaskAsync(task);
                return StatusCode(result.StatusCode, result);
            }
            catch (Exception ex)
            {
                _error.StatusCode = 500;
                _error.Message = MessageErrorBuilder.GenerateError(ex.Message);
                return StatusCode(_error.StatusCode, _error);
            }
        }

        [HttpDelete("{taskId}")]
        public async Task<IActionResult> DeleteTaskAsync(string taskId)
        {
            try
            {
                var result = await _taskRepository.DeleteTaskAsync(taskId);
                return StatusCode(result.StatusCode, result);
            }
            catch (Exception ex)
            {
                _error.StatusCode = 500;
                _error.Message = MessageErrorBuilder.GenerateError(ex.Message);
                return StatusCode(_error.StatusCode, _error);
            }
        }
    }
}
