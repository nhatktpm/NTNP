using Microsoft.Extensions.DependencyInjection;
using NTNP.EFCore.Context;
using NTNP.Infratructure.Interfaces;
using NTNP.Infratructure.Repositories.User;
using NTNP.Infratructure.Repositories.Vocabularies;

namespace NTNP.Infratructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<Func<NTNPContext>>((provider) => provider.GetService<NTNPContext>);
            services.AddScoped<DbFactory>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IVocabularyRepository, VocabularyRepository>();

            return services;
        }
    }
}
