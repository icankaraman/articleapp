﻿using System;
using System.Linq;
using articleApp.Api.Extension;
using articleApp.Business.Repository;
using articleApp.Business.Services;
using articleApp.Business.Validator;
using articleApp.Data.Models;
using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace articleApp.Api
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
            services.Configure<ConnectionSettings>(options =>
          {
              options.ConnectionString
                  = Configuration.GetSection("MongoConnection:ConnectionString").Value;
              options.Database
                  = Configuration.GetSection("MongoConnection:Database").Value;
          });
            services.AddTransient<ArticleDbContext>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2).AddFluentValidation(validationConfig => validationConfig.RegisterValidatorsFromAssemblyContaining<ArticleRequestModelValidator>());
            services.Configure<ApiBehaviorOptions>(options =>
                {
                    options.InvalidModelStateResponseFactory = (context) =>
                    {
                        var errors = context.ModelState.Values.SelectMany(x => x.Errors.Select(p => p.ErrorMessage)).ToList();
                        var result = new
                        {
                            Message = "Validation Error",
                            Errors = errors
                        };
                        return new BadRequestObjectResult(result);
                    };
                });

            services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                    {
                        Title = "Article API",
                        Version = "v1",
                        Description = "Article API Uygulaması",
                    });
                });

            services.AddAutoMapper();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IArticleService, ArticleService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors("AllowAll");
            app.UseErrorHandling();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Article API V1");
            });
            app.UseMvc();
        }
    }
}
