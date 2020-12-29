using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using CoreStart.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CoreStart
{
    public class Startup
    {
        private string _connection = null;
        public Startup(IConfiguration configuration)
        {
            /* Configuration is injected and we can use it to
             * read config data such as connection strings. */
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            //var builder = new SqlConnectionStringBuilder(
            //    Configuration.GetConnectionString("BlogPostContext"));
            //builder.Clear();
            //builder.Add("BlogContext", Configuration["BlogContextConnectionString"]);
            //_connection = builder.ConnectionString;

            /*Enables injection of DbContext into the constructor. I pass a lambda expression
             that creates a DbContextOptions object. In turn, this object is passed to DbContext's
             constructor to provide info about the database. The framework automatically creates
             and passes a DbContext object to any controller that has a DbContext parameter.*/
            services.AddDbContext<BlogContext>(options => options.UseSqlServer(
                Configuration.GetConnectionString("BlogContextConnectionString")));

            services.AddRouting(options =>
            {
                options.LowercaseUrls = true;
                options.AppendTrailingSlash = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //Allows the right currency symbol during development on a local Linux container.
                //Investigate how to localize in production.
                //CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("sv-SE");

                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}/{slug?}");
            });
        }
    }
}
