using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using OptimusZQ.DAL;
using OptimusZQ.DAL.Abstract;
using OptimusZQ.DAL.Models;
using OptimusZQ.DAL.Repositories;
using OptimusZQ.Services;
using OptimusZQ.Services.Abstract;
using OptimusZQ.Services.Concrete;
using System.Configuration;
using System.Text;

namespace OptimusZQ.Dependencies
{
    public static class Registrator
    {
        public static void RegisterDAL(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<OptimusDbContext>(options =>
            options.UseSqlServer(connectionString));
            services.AddTransient<IRepository<User>, UserRepository>();
            //services.AddTransient<IRepository<Folder>, BaseRepository<Folder>>();
            //services.AddTransient<IRepository<SharedFile>, BaseRepository<SharedFile>>();   //todo
            //services.AddTransient<IRepository<File>, BaseRepository<File>>();
        }

        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<IAuthenticationService, AuthenticationService>();
        }

        public static void RegisterAuth(this IServiceCollection services, string secretKey)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                
                ValidIssuer = "http://localhost:5000",
                ValidAudience = "http://localhost:5000",
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))};
            });
        }

        public static void MapSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AppSettings>( (settings) =>
            {
                settings.ConnectionString = configuration.GetSection("AppSettings").GetSection("connectionString").Value;
                settings.SecretKey = configuration.GetSection("AppSettings").GetSection("secretKey").Value;
            });
        }
    }
}
