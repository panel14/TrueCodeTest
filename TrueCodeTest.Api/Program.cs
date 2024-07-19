using TrueCodeTest.Api.Extensions;
using TrueCodeTest.Api.Middlewares;
using TrueCodeTest.Infrastructure.DataBaseInitialization;
using TrueCodeTest.Infrastructure.Web.ToDoItems.Controllers;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("Configuration/appsettings.json");

builder.Configuration.AddEnvironmentVariables();

builder.Services.AddValidationServices();
builder.Services.AddMappingServices();
builder.Services.AddStorageServices(builder.Configuration);
builder.Services.AddMediatRServices();
builder.Services.AddControllers();

builder.Services.AddSwaggerGen(opt =>
{
    var xmlFile = $"{typeof(ToDoItemsController).Assembly.GetName().Name}.xml";
    opt.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFile));

    opt.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "TrueCodeTest API", Version = "v1" });
});


builder.Services.AddCorsServices();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    await DatabaseInitializator.InitAsync(scope.ServiceProvider);
}

app.UseMiddleware<ExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("DefaultPolicy");

app.MapControllers();

app.Run();
