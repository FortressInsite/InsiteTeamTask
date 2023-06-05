
using InsiteTeamTask.API.Extentions;
using InsiteTeamTask.Data.Providers;
using InsiteTeamTask.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
namespace InsiteTeamTask
{
    public class Startup
    {
        string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(options =>{
                options.Filters.Add(typeof(ExceptionFilter));
            });
            // Configure services and dependencies here
            services.AddTransient<IDataService, DataService>();
            services.AddTransient<IDataProvider, DataProvider>();


            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyHeader()
                           .AllowAnyMethod()
                           .WithOrigins("http://localhost:4200");
                });
                //options.AddPolicy(name: MyAllowSpecificOrigins,
                //                  builder =>
                //                  {
                //                      builder.WithOrigins("http://localhost:4200").AllowAnyHeader().WithExposedHeaders("mycustomheader"); ;
                //                  });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
