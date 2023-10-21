using Simposium2023.Services;

namespace Simposium2023.Middlewares
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IJwtService jWtService)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token is not null)
            {
                var validateTokenResult = jWtService.ValidateToken(token, "tallerApiKey");
                context.Items["HasError"] = validateTokenResult.HasError;
                context.Items["RefreshToken"] = validateTokenResult.RefreshToken;
                context.Items["UserId"] = validateTokenResult.UserId;
                context.Items["InnerException"] = validateTokenResult.InnerException;
            }
            else
            {
                context.Items["HasError"] = true;
                context.Items["RefreshToken"] = "";
                context.Items["InnerException"] = "Token is null";
            }
            await _next(context);
        }
    }
}

