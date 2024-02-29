using ClimaTempoWebAPI.Authentication;
using ClimaTempoWebAPI.Data;
using ClimaTempoWebAPI.Data.Repositories;
using ClimaTempoWebAPI.Entities.Customers;
using ClimaTempoWebAPI.Entities.User;
using ClimaTempoWebAPI.Services;
using ClimaTempoWebAPI.Services.External;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddJwtAuthentication();
builder.Services.AddSwagger();

// Configuração para HttpClient
builder.Services.AddHttpClient();

builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IWeatherService, WeatherService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<CustomExceptionHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
