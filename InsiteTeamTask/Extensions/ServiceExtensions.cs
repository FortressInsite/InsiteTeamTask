using InsiteTeamTask.LoggerService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsiteTeamTask.Extensions
{
    public static class ServiceExtensions
    {
        //add logger service calling addscoped, service once per request when sending HTTP request, new instance is created.
        //configureservices in startup
        public static void ConfigureLoggerService(this IServiceCollection services) => services.AddScoped<ILoggerMessage, LoggerMessage>();

        public static void CorsConfigure(this IServiceCollection services) =>
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder =>
            builder.WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod()
            );
        });

        //extract jwtsettings from config
        //register jwt authentica middleware
        public static void JwtConfigure(this IServiceCollection services, IConfiguration configuration){
            var settings = configuration.GetSection("JsonWebTokenSettings");
            //create environment variable
            

            services.AddAuthentication(option =>{
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>{
                options.TokenValidationParameters = new TokenValidationParameters{
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    
                    ValidIssuer = settings.GetSection("validIssuer").Value,
                    ValidAudience = settings.GetSection("validAudience").Value,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("@12345"))
                    
                };
            });
        }
    }
}
