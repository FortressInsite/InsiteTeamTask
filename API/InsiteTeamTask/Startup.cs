using InsiteTeamTask.Data.Providers;
using InsiteTeamTask.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Net;
using System.Threading.Tasks;

namespace InsiteTeamTask
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                               policy =>
                               {
                                   policy.WithOrigins("http://localhost:4200"
                                                       ).AllowAnyHeader().AllowAnyMethod();
                               });
            });
            services
                .AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            
            // Adding Dependency Injection
            services.AddSingleton<IDataService, DataService>();
            services.AddSingleton<IDataProvider, DataProvider>();
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
            app.UseCors(MyAllowSpecificOrigins);
            app.UseMiddleware<AuthorizedMiddleware>();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
    public class AuthorizedMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthorizedMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            string jwt = context.Request.Headers["token"];
            if (string.IsNullOrEmpty(jwt))
            {
                // no jwt in headers so i want to return Unauthorized to user:
                await ReturnErrorResponse(context);
            }
            await _next(context);
            
        }

        private Task ReturnErrorResponse(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;

            return Task.CompletedTask;
        }

    }
}
