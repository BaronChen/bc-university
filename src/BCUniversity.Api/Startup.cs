using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BCUniversity.Api.Common;
using BCUniversity.Domain;
using BCUniversity.Infrastructure;
using BCUniversity.Infrastructure.Common;
using BCUniversity.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace BCUniversity.Api
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.Configure<DbSettings>(options =>
            {
                var envConnectionString = Environment.GetEnvironmentVariable("POSTGRES_CONNECTIONSTRING");
                options.ConnectionString = !string.IsNullOrWhiteSpace(envConnectionString)
                    ? envConnectionString
                    : Configuration.GetSection("Postgres:ConnectionString").Value;
            });
            
            services.RegisterDomainServices();
            services.RegisterService();
            services.RegisterInfrastructure();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseMiddleware<ErrorHandler>();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}