using Simposium2023.Models.BussinessLogic;
using Simposium2023.Models.Responses;

namespace Simposium2023.Repositories.BusinessLogic.Task
{
    public interface ITaskRepository
    {
        Task<GenericResponse<GenericCrud>> TaskRegistrationAsync(TaskRegistration task);
        Task<GenericResponse<TaskResponseGet>> GetSpecificTaskAsync(string taskId);
        Task<GenericResponse<List<TaskResponseGet>>> GetAllTasksAsync();
        Task<GenericResponse<List<TaskResponseGet>>> GetCompletedTasksAsync();
        Task<GenericResponse<GenericCrud>> UpdateTaskAsync(TaskUpdated task);
        Task<GenericResponse<GenericCrud>> DeleteTaskAsync(string taskId);
    }
}
