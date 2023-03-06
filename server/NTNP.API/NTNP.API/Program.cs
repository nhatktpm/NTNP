using Microsoft.EntityFrameworkCore;
using NLog.Extensions.Logging;
using NLog.Web;
using NTNP.API.Middlewares;
using NTNP.API.Migrations;
using NTNP.AppServices;
using NTNP.EFCore.Context;
using NTNP.Infratructure;

var builder = WebApplication.CreateBuilder(args);

const string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

IConfiguration configuration = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                            .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
                            .Build();
// Add services to the container.


NLog.LogManager.Configuration = new NLogLoggingConfiguration(configuration.GetSection("NLog"));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Cors
builder.Services.AddCors(options =>
{
    options.AddPolicy(MyAllowSpecificOrigins, corsBuilder =>
    {
        var origins = configuration
            .GetSection("AllowedHosts").GetChildren()
            .Select(o => o.Value)
            .ToArray();
        corsBuilder
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials()
            .WithOrigins(origins);
    });
});



builder.Services.AddDbContext<NTNPContext>(
            options => options.UseNpgsql(configuration.GetConnectionString("NTNP"), b => b.MigrationsAssembly("NTNP.API")));

// Add app services from NTNP
builder.Services.AddAppService();
builder.Services.AddInfrastructureServices();

builder.Host.UseNLog();

var app = builder.Build();

//Only apply swagger authentication for DEV and Production environment
if (builder.Environment.EnvironmentName != "Development")
{
    app.UseMiddleware<SwaggerAuthMiddleware>();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//
app.Migrate();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
