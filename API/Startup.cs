using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.OpenApi.Models;

namespace DAL
{
    public class Startup
    {
        readonly string MiCors = "MiCors";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            //services.AddControllers();
            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
            //});

            services.AddCors(options =>
            {
                options.AddPolicy(name: MiCors,
                builder =>
                {
                    builder.WithOrigins("*");
                }
              );

            });

            services.AddControllers();
            AddSwagger(services);
        }


        public void AddSwagger(IServiceCollection services)
            {
                services.AddSwaggerGen(options =>
                {
                    var groupName = "v1";

                    options.SwaggerDoc(groupName, new OpenApiInfo
                    {
                        Title = $"Proyecto Trabajo Final de Ingenieria {groupName}",
                        Version = groupName,
                        Description = "TFI 2021",
                        Contact = new OpenApiContact
                        {
                            Name = "Gabriel Taglioretti",
                            Email = string.Empty,
                            Url = new Uri("https://localhost:44362/"),
                        }
                    });
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

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Proyecto Trabajo Final de Ingenieria");
            });


            app.UseRouting();

            app.UseCors(MiCors);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


        }
    }
}
