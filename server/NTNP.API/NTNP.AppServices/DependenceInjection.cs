using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using NTNP.AppServices.AuthServices;
using NTNP.AppServices.BaseAppServices;
using NTNP.AppServices.VocabularyAppServices;
using System.Reflection;

namespace NTNP.AppServices
{
    public static class DependenceInjection
    {
        public static IServiceCollection AddAppService(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(typeof(Profile).Assembly);

            // dependency injection
            services.AddScoped<IBaseAppService, BaseAppService>();
            services.AddScoped<IVocabularyAppService, VocabularyAppService>();
            services.AddScoped<IAuthAppService, AuthAppService>();

            return services;
        }
    }
}
