using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using PermissionSystem.Business.Context;
using PermissionSystem.Business.Outils.Password;
using PermissionSystem.Business.Repositories.RepositoryWrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermissionSystem.Extensions
{
    public static class ServiceExtensions
    {

        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });
        }

        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options =>
            {

            });
        }
        
        public static void ConfigurePasswordCrypt(this IServiceCollection services)
        {
            services.AddSingleton<IPasswordCrypt, PasswordCrypt>();
        }

        public static void ConfigureJWT(this IServiceCollection services, IConfiguration config)
        {
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.GetSection("securityKey").Value));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        //what to validate
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateIssuerSigningKey = true,
                        //setup validate data
                        ValidIssuer = "smesk.in",
                        ValidAudience = "readers",
                        IssuerSigningKey = symmetricSecurityKey
                    };
                });
        }

        public static void ConfigureMySqlContext(this IServiceCollection services, IConfiguration config)
        {

            services.AddDbContext<AppInoContext>(opt => opt.UseMySQL(config.GetConnectionString("DefaultConnection")));
        }

        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }

    }
}
