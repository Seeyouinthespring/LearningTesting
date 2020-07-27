using System;
using System.Reflection;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using WebAPITest.Models;
using WebAPITest.Repository;
using System.Data.Entity;
using WebAPITest.Interfaces;
using WebAPITest.Services;
using Microsoft.OpenApi.Models;

namespace WebAPITest
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
            services.AddDbContext<WebAPIContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<ICityService,CityService>();
            services.AddScoped<ISightseenService, SightseenService>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped(typeof(CommonRepositoryInclude<>));
            services.AddScoped(typeof(CommonRepository<>));
            services.AddSwaggerGen();
            services.AddMvc();
            services.AddControllers().AddNewtonsoftJson(options =>options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "beta",
                    Title = "GEOOO",
                    Description = "A geoinformation repository API",
                    TermsOfService = new Uri("https://vk.com/id118971987"),
                    Contact = new OpenApiContact
                    {
                        Name = "Nick Zhuravlyov",
                        Email = "colya.juravlyov2011@ya.ru",
                        Url = new Uri("https://vk.com/id118971987"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under LICX",
                        Url = new Uri("https://vk.com/id118971987"),
                    }
                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger(c =>
            {
                c.RouteTemplate = "api-docs/{documentName}/swagger.json";
            });

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/api-docs/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });
        }
    }
}
