using AutoMapper;
using InsiteTeamTask.Configuration;
using InsiteTeamTask.Data.Configuration;
using InsiteTeamTask.Logic.Configuration;
using InsiteTeamTask.Services;
using InsiteTeamTask.Services.List;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace InsiteTeamTask
{
    public class Startup
    {
        private readonly IServicesConfigurationForLogic _servicesConfigurationForLogic;
        private readonly IServiceCollectionForData _serviceCollectionForData;

        public Startup(IConfiguration configuration)
        {
            _servicesConfigurationForLogic = new ServicesConfigurationForLogic();
            _serviceCollectionForData = new ServiceCollectionForData();
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            services.AddScoped<IAttendenceViewService, AttendenceViewService>();
            services.AddScoped<IListViewService, ListViewService>();
            services.AddAutoMapper(typeof(ViewModelMappingProfile));

            AddProjectServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }

        //Having each project handle its own DI, allows for proper separation of concerns and internal implementations.
        private IServiceCollection AddProjectServices(IServiceCollection serviceCollection)
        {
            serviceCollection = _servicesConfigurationForLogic.ConfigureServices(serviceCollection);
            serviceCollection = _serviceCollectionForData.ConfigurServiceCollection(serviceCollection);
            return serviceCollection;
        }
    }
}
