using System.Reflection;
using Microsoft.OpenApi.Models;
using stone_21.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
builder.Services.AddSwaggerGen(swaggerGenOptions =>
{
    swaggerGenOptions.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
    swaggerGenOptions.SwaggerDoc("v1", new OpenApiInfo { Title = "stone_21", Version = "v1" });
});

builder.Services.AddSingleton<HRDepartmentService>();

var app = builder.Build();

app.UseSwagger(swaggerOptions => { swaggerOptions.RouteTemplate = $"swagger/" + "{documentName}/swagger.json"; });
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint($"/swagger/v1/swagger.json", "dtsignalsapi v1");
    c.RoutePrefix = $"swagger";
    c.DocumentTitle = "stone_21 Swagger";
});

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
