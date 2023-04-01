using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NLog.Extensions.Logging;
using NLog.Web;
using NTNP.API.Middlewares;
using NTNP.API.Migrations;
using NTNP.AppServices;
using NTNP.EFCore.Context;
using NTNP.EFCore.Models.AppSettings;
using NTNP.Infratructure;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

const string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

IConfiguration configuration = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                            .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
                            .Build();
// Add services to the container.


NLog.LogManager.Configuration = new NLogLoggingConfiguration(configuration.GetSection("NLog"));


builder.Services.AddControllers()
                .AddFluentValidation(configuration =>
                {
                    configuration.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
                });

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


var appSettingsSection = configuration.GetSection("AppSettings");
builder.Services.Configure<AppSetting>(appSettingsSection);
var appSettings = appSettingsSection.Get<AppSetting>();
var key = Encoding.ASCII.GetBytes(appSettings.Secret);
var x = configuration.GetValue<string>("Issuer");
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opt =>
    {
        opt.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = true,
            ValidateAudience = false,
            ValidIssuer = configuration.GetValue<string>("Issuer"),
        };
    });

//
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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
