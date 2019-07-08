using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using OptimusZQ.DAL;
using OptimusZQ.DAL.Abstract;
using OptimusZQ.DAL.Repositories;
using OptimusZQ.Services;
using OptimusZQ.Services.Abstract;
using OptimusZQ.Services.Concrete;
using System.Text;
#if DEBUG
using Microsoft.IdentityModel.Logging;
#endif

namespace OptimusZQ.Dependencies
{
    public static class Registrator
    {
        public static void RegisterDAL(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<OptimusDbContext>(options =>
            options.UseSqlServer(connectionString));
            services.AddTransient<IUserRepository, UserRepository>();
        }

        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<IAuthenticationService, AuthenticationService>();
        }

        public static void RegisterAuth(this IServiceCollection services, 
            string validIssuer, string validAudience, string secretKey)
        {
#if DEBUG
            IdentityModelEventSource.ShowPII = true;
#endif
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = validIssuer,
                ValidAudience = validAudience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))};
            });
        }

        public static void MapSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AppSettings>( (settings) =>
            {
                settings.ConnectionString = configuration.GetSection("AppSettings").GetSection("connectionString").Value;
                settings.SecretKey = configuration.GetSection("AppSettings").GetSection("secretKey").Value;
                settings.ValidIssuer = configuration.GetSection("AppSettings").GetSection("validIssuer").Value;
                settings.ValidAudience = configuration.GetSection("AppSettings").GetSection("validAudience").Value;
            });
        }
    }
}
