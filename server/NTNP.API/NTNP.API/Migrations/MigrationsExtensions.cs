using Microsoft.EntityFrameworkCore;
using NTNP.EFCore.Context;

namespace NTNP.API.Migrations
{
    public static class MigrationsExtensions
    {
        public static void Migrate(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<NTNPContext>();

                context.Database.Migrate();
            }
        }
    }
}
