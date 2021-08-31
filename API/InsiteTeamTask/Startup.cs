using InsiteTeamTask.Data.Providers;
using InsiteTeamTask.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InsiteTeamTask
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddCors(options =>
            {
                options.AddPolicy(
                    name: "AllowOrigin",
                    builder => {
                        builder.AllowAnyOrigin()
                                .AllowAnyMethod()
                                .AllowAnyHeader();
                    });
            });
            services.AddScoped<IDataService, DataService>();
            services.AddScoped<IDataProvider, DataProvider>();

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseCors("AllowOrigin");
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
