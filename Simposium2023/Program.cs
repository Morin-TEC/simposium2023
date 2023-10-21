using Microsoft.OpenApi.Models;
using Simposium2023.Attributes;
using Simposium2023.Data;
using Simposium2023.Middlewares;
using Simposium2023.Repositories.BusinessLogic.User;
using Simposium2023.Services;
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddControllers().ConfigureApiBehaviorOptions(options => options.InvalidModelStateResponseFactory = ModelStateValidator.ValidModelState);
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "WebSitesPolicy", policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});
builder.Services.AddControllers();
builder.Services.AddScoped<DapperContext>();
builder.Services.AddScoped<IJwtService, JwtService>();
builder.Services.AddScoped<IDapperService, DapperService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    


    c.SwaggerDoc("Users", new OpenApiInfo
    {
        Title = "Users",
        Version = "v1",
        Description = "Documento para la administracion de los usuarios",
        Contact = new OpenApiContact
        {
            Name = "Jaime Tenorio",
            Email = "test@test.com",
        },
        License = new OpenApiLicense
        {
            Name = "Use inder license ###"
        }
    });

    c.SwaggerDoc("Tasks", new OpenApiInfo
    {
        Title = "Tasks",
        Version = "v1",
        Description = "Documento para la administracion de las tareas de los usuarios",
        Contact = new OpenApiContact
        {
            Name = "Jaime Tenorio",
            Email = "test@test.com",
        },
        License = new OpenApiLicense
        {
            Name = "Use inder license ###"
        }
    });

});

builder.Services.AddHttpContextAccessor();
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(c => c.RouteTemplate = "/swagger/{documentname}/swagger.json");

    app.UseSwaggerUI(c =>
    {
        c.ConfigObject = new ConfigObject
        {
            ShowCommonExtensions = true
        };

        c.RoutePrefix = "swagger";
        c.InjectStylesheet("/swagger-ui/custom.css");
        c.InjectJavascript("/swagger-ui/custom.js");
        c.SwaggerEndpoint("Users/swagger.json", "Users");
        c.SwaggerEndpoint("Tasks/swagger.json", "Tasks");
    });
}
else
{
    app.UseSwagger(c => c.RouteTemplate = "/apiDocumentation/{documentname}/swagger.json");

    app.UseSwaggerUI(c =>
    {
        c.ConfigObject = new ConfigObject
        {
            ShowCommonExtensions = true
        };

        c.RoutePrefix = "apiDocumentation";
        c.InjectStylesheet("/swagger-ui/custom.css");
        c.InjectJavascript("/swagger-ui/custom.js");
        c.SwaggerEndpoint("Users/swagger.json", "Users");
        c.SwaggerEndpoint("Tasks/swagger.json", "Tasks");
    });
}

app.UseHttpsRedirection();

app.UseCors("WebSitesPolicy");

app.UseAuthorization();

app.UseStaticFiles();

app.UseMiddleware<JwtMiddleware>();

app.MapControllers();

app.Run();
