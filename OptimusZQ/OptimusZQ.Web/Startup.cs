using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OptimusZQ.Common.Models;
using OptimusZQ.Dependencies;
using OptimusZQ.Web.AppStart;

namespace OptimusZQ.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.MapSettings(Configuration);

            var settings = services.BuildServiceProvider().GetService<IOptions<AppSettings>>();

            services.RegisterDAL(settings.Value.ConnectionString);

            services.RegisterAuth(settings.Value.ValidIssuer,
                settings.Value.ValidAudience,
                settings.Value.SecretKey);

            services.RegisterServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IOptions<AppSettings> settings)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                new RoutesConfigurator(routes, settings.Value.RoutesTemplatesPath).BuildRoutesUsingTemplates();
            });
        }
    }
}
