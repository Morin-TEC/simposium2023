using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Simposium2023.Models.Responses;

namespace Simposium2023.Attributes
{
    public static class ModelStateValidator
    {
        public static ActionResult ValidModelState(ActionContext context)
        {
            var modelStateEntries = context.ModelState.Where(x => x.Value?.Errors.Count > 0);

            string errorSerialized = "";

            if (modelStateEntries.Count() > 0)
            {
                errorSerialized = string.Join(" | ", modelStateEntries.Select(x => x.Value?.Errors.First().ErrorMessage).ToList());
            }

            GenericResponse<JObject> response = new();
            response.StatusCode = 400;
            response.Message = new GenericResponseData
            {
                Type = "warning",
                Title = "Error",
                Message = "Verifique la captura de sus datos",
                InnerException = errorSerialized
            };
            return new BadRequestObjectResult(response);
        }
    }
}

