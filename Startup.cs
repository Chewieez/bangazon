using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Cors;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using BangazonAPI.Data;
using Microsoft.EntityFrameworkCore;

// CORS setup by Greg Lawrence

namespace BangazonAPI
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
            // Add CORS framework
            services.AddCors(options =>
            {
                // define a CORS policy to use
                // this policy will restrict api usage to just users on http://bangazon.com
                options.AddPolicy("AllowOnlyTheseOrigins",
                    builder => builder.WithOrigins("http://bangazon.com"));
            });

            services.AddMvc();
            // define path to database
            string path = System.Environment.GetEnvironmentVariable("BANGAZON_API_DB");
            var connection = $"Filename={path}";
            Console.WriteLine($"connection = {connection}");
            services.AddDbContext<BangazonAPIContext>(options => options.UseSqlite(connection));
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Use the CORS policy you created in ConfigureServices
            app.UseCors("AllowOnlyTheseOrigins");

            app.UseMvc();
        }
    }
}
