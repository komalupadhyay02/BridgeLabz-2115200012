using BusinessLayer.Services;
using RepositoryLayer.Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<UserRegistrationBL>();
builder.Services.AddSingleton<UserRegistrationRL>();
var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

