using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PruebaTecnica_Newshore.API.Model;
using PruebaTecnica_Newshore.Service.Server.Implementation;
using PruebaTecnica_Newshore.Service.Server.Interface;
using PruebaTecnica_Newshore.UnitOfWork.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using u = PruebaTecnica_Newshore.UnitOfWork.Implementation;

namespace PruebaTecnica_Newshore.API
{
    /// <summary>
    /// Clase Startup
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    var origins = Configuration.GetSection("AllowedOrigins").Get<string[]>();

                    builder.WithOrigins(origins)
                           .AllowAnyMethod()
                           .AllowAnyHeader()
                           .AllowCredentials();
                }
                );
            });
            services.AddControllers();
            services.AddControllersWithViews();
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Prueba Tecnica para la empresa Newshore API",
                    Version = "v1",
                    Description = "Prueba Tecnica para la empresa Newshore application API",
                    Contact = new OpenApiContact
                    {
                        Name = "Developer Gastón Cárdenas",
                        Email = "gacardenasch80@gmail.com",
                        Url = new Uri("https://github.com/gacardenasch80"),
                    },
                });
                string xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                string xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                s.IncludeXmlComments(xmlPath);

            });
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.AddScoped<IJourneyService, JourneyService>();
            services.AddSingleton<IUnitOfWork>(op => new u.UnitOfWork(
                Configuration.GetConnectionString("Newshore")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Prueba Tecnica para la empresa Newshore API V1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
