using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Simposium2023.Helpers;
using Simposium2023.Models.BussinessLogic;
using Simposium2023.Models.Responses;
using Simposium2023.Repositories.BusinessLogic.User;

namespace Simposium2023.Controllers.BusinessLogic
{
    [ApiController]
    [Route("simposium-api/users")]
    [ApiExplorerSettings(GroupName = "Users")]

    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly GenericResponse<JObject> _error = new();

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        public async Task<IActionResult> UserRegistration([FromBody] UserRegistration user)
        {
            try
            {
                var result = await _userRepository.UserRegistrationAsync(user);
                return StatusCode(result.StatusCode, result);
            }
            catch (Exception ex)
            {
                _error.StatusCode = 500;
                _error.Message = MessageErrorBuilder.GenerateError(ex.Message);
                return StatusCode(_error.StatusCode, _error);
            }
        }

        [HttpPost("logIn")]
        public async Task<IActionResult> UserLogIn([FromBody] UserValidation user)
        {
            try
            {
                var result = await _userRepository.UserValidationAsync(user);
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
