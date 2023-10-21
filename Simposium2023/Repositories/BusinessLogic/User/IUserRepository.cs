using Simposium2023.Models.BussinessLogic;
using Simposium2023.Models.Responses;

namespace Simposium2023.Repositories.BusinessLogic.User
{
    public interface IUserRepository
    {
        Task<GenericResponse<GenericCrud>> UserRegistrationAsync(UserRegistration user);
        Task<GenericResponse<UserLoginResponse>> UserValidationAsync(UserValidation user);
    }
}
