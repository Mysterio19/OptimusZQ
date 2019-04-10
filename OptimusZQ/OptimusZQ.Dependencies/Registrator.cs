using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using OptimusZQ.DAL;
using OptimusZQ.Services.Abstract;
using OptimusZQ.Services.Concrete;
using System.Configuration;
using System.Text;

namespace OptimusZQ.Dependencies
{
    public static class Registrator
    {
        public static void RegisterDAL(this IServiceCollection services)
        {
            services.AddDbContext<OptimusDbContext>(options =>
            options.UseSqlServer(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString));
        }

        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<IAuthenticationService, AuthenticationService>();
        }

        public static void RegisterAuth(this IServiceCollection services)
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
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ConfigurationManager.AppSettings["secretKey"]))};
            });
        }
    }
}
