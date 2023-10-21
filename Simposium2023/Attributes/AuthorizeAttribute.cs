using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Simposium2023.Helpers;
using Simposium2023.Models.Responses;
using Newtonsoft.Json.Linq;

namespace Simposium2023.Attributes
{
    public class AuthorizeAttribute : Attribute, IAsyncAuthorizationFilter
    {
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            GenericResponse<JObject> response = new();
            try
            {
                var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().FirstOrDefault();
                if (allowAnonymous != null) return;

                var hasError = bool.Parse(context.HttpContext.Items["HasError"].ToString());
                if (hasError)
                {
                    response.StatusCode = 401;
                    context.Result = new UnauthorizedObjectResult(response);
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                var message = MessageErrorBuilder.GenerateError(ex.Message);
                response.StatusCode = 500;
                response.Message = message;
                context.Result = new BadRequestObjectResult(response);
                return;
            }

        }
    }
}