using Microsoft.EntityFrameworkCore;
using NTNP.EFCore.Context;
using NTNP.Infratructure;

var builder = WebApplication.CreateBuilder(args);

const string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

IConfiguration configuration = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                            .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
                            .Build();
// Add services to the container.

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
builder.Services.AddInfrastructureServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
