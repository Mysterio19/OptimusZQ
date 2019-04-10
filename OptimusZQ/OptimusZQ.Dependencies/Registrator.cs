using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OptimusZQ.DAL;
using System;
using System.Configuration;

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

        }
    }
}
