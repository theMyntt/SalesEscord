using Microsoft.EntityFrameworkCore;
using SalesEscord.Context;

namespace SalesEscord
{
    public static class Startup
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["MsSql:ConnectionString"] ?? throw new Exception("MsSql:ConnectionString Is Null");

            services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseSqlServer(connectionString, m =>
                {
                    m.MigrationsAssembly(typeof(DatabaseContext).Assembly.FullName);
                });
            });

            return services;
        }
    }
}
