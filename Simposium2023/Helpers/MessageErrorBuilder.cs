using Simposium2023.Models.Responses;

namespace Simposium2023.Helpers
{
    public class MessageErrorBuilder
    {
        public static GenericResponseData GenerateError(string innerException)
        {
            return new GenericResponseData
            {
                Type = "danger",
                Title = "Error",
                Message = "Oye papu te equivocaste asi no es prro :v",
                InnerException = innerException
            };
        }
    }
}
