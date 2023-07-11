using Ozone.Application;
using Ozone.Infrastructure.Persistence;
//using Ozone.Infrastructure.Persistence.Contexts;
using Ozone.Infrastructure.Shared;
using Ozone.WebApi.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Server;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore.SqlServer;
using Ozone.Infrastructure.Persistence.Models;
using Sieve.Services;

namespace Ozone.WebApi
{
    public class Startup
    {
        public IConfiguration _config { get; }
        public Startup(IConfiguration configuration)
        {
            _config = configuration;

        }
        public void ConfigureServices(IServiceCollection services)
        {
            var jwtTokenConfig = _config.GetSection("JWTSettings").Get<JwtTokenConfig>();
            services.AddDbContext<OzoneContext>(options => options.UseSqlServer(_config.GetConnectionString("DefaultConnection")));

            //services.AddDbContext<OzoneDataModelContext>(options => options.UseSqlServer(_config.GetConnectionString("DefaultConnection")));

            services.AddSingleton(jwtTokenConfig);
            services.AddSingleton<IJwtAuthManager, JwtAuthManager>();

           services.AddScoped<CustomJwtBearerEvents>();

            services.AddApplicationLayer();
            services.AddPersistenceInfrastructure(_config);
            //services.AddSeedData(_config);
            services.AddSharedInfrastructure(_config);
            services.AddSwaggerExtension();
            services.AddControllersExtension();
            services.AddAutoMapper(typeof(Startup));
            services.AddControllersWithViews();
            services.AddScoped<SieveProcessor>();

            // Authentication
            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options => _config.Bind("JWTSettings", options));
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = true;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = jwtTokenConfig.Issuer,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtTokenConfig.Key)),
                    ValidAudience = jwtTokenConfig.Audience,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromMinutes(1)
                };

                x.EventsType = typeof(CustomJwtBearerEvents);                
            });

            // CORS
            services.AddCorsExtension();
            services.AddHealthChecks();
            // API version
            services.AddApiVersioningExtension();
            // API explorer
            services.AddMvcCore()
                .AddApiExplorer();
            // API explorer version
            services.AddVersionedApiExplorerExtension();
      }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory, OzoneContext dbContext)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            //else
            //{
            //    app.UseExceptionHandler("/Error");
            //    app.UseHsts();
            //}

            // Add this line; you'll need `using Serilog;` up the top, too


            //loggerFactory.AddSerilog();

            //app.UseDeveloperExceptionPage();
            app.UseSerilogRequestLogging();

            app.UseExceptionHandler(c => c.Run(async context =>
            {
                
                var exception = context.Features
                    .Get<IExceptionHandlerPathFeature>()
                    .Error;
                //Log.Error(exception.Message);
                var response = new { error = exception.Message };
                await context.Response.WriteAsJsonAsync(response);
            }));

            dbContext.Database.EnsureCreated();

            
            app.UseHttpsRedirection();
            app.UseRouting();
            //Enable CORS
            app.UseCors("AllowAll");
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSwaggerExtension();
            //app.UseErrorHandlingMiddleware();
            //app.UseHealthChecks("/health");

            app.UseEndpoints(endpoints =>
             {
                 endpoints.MapControllers();
             });
        }
    }
}
