using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExportManagementAPI.Application.Services;
using ExportManagementAPI.Domain.Repositories;
using ExportManagementAPI.Domain.Services;
using ExportManagementAPI.Infrastructure.Repositories;
using ExportManagementAPI.Web.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace ExportManagementAPI.Web
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
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "ExportManagementAPI.Web", Version = "v1"});
            });

            //region Repository Dependency Injections

            services.AddTransient<IUserRepositoryAsync, UserRepositoryAsync>();
            services.AddTransient<IUserTokenRepositoryAsync, UserTokenRepositoryAsync>();

            //endregion

            //region Service Dependency Injections

            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddTransient<IPasswordService, PasswordService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUserTokenService, UserTokenService>();

            //endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ExportManagementAPI.Web v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseMiddleware<ErrorHandlerMiddleware>();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}