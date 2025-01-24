using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using SalesEscord.Context;
using SalesEscord.Handlers;
using SalesEscord.Interfaces;
using SalesEscord.Services;

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

            services
                .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Login";
                    options.ExpireTimeSpan = TimeSpan.FromDays(1);
                    options.Cookie.Name = "auth-cookie";
                });
            services.AddAuthorization();

            services.AddScoped<IBtoaHandler, BtoaHandler>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }

        public static IApplicationBuilder UseServices(this IApplicationBuilder app)
        {
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();

            return app;
        }
    }
}
