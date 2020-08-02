using AutoMapper;
using HexadLMServices.Interfaces;
using HexadLMServices.Logics;
using HexadLMServices.Repositories.Interfaces;
using HexadLMServices.Repositories.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

namespace HexadLMServices
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddAutoMapper(typeof(Startup));

            services.AddScoped<IBooksLogic, BooksLogic>();
            services.AddScoped<IBooksRepository, BooksRepository>();
            services.AddScoped<ILibraryLogic, LibraryLogic>();
            services.AddScoped<ILibraryRepository, LibraryRepository>();
            services.AddScoped<IUserLogic, UserLogic>();
            services.AddScoped<IUserRepository, UserRepository>();

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "HexadLMServices",
                    Description = "HexadLMServices",
                    Contact = new OpenApiContact
                    {
                        Name = "Dhiraj Bairagi",
                        Email = "dhiraj.bairagi@yahoo.com",
                        Url = new Uri("https://www.linkedin.com/in/dhirajbairagi/"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "HexadLMServices"
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
            app.UseRouting();
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
