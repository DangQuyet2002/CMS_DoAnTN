using Autofac;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Repositories;
using System;
using System.Collections.Generic;

namespace APIIdentityServer
{
    public static class ConfigurationHelper
    {
        public static readonly IConfiguration settings = GetConfig();

        public static IConfiguration GetConfig()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json",
                optional: true,
                reloadOnChange: true);

            return builder.Build();
        }

        public static void ServicesConfig(IServiceCollection services)
        {
            #region Common

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Api Category",
                    Description = "Api Category",
                    TermsOfService = new Uri("https://namvietjsc.edu.vn/"),
                    Contact = new OpenApiContact
                    {
                        Name = "Nam Viet JSC",
                        Email = "nmduc@namvietjsc.edu.vn",
                        Url = new Uri("https://namvietjsc.edu.vn/"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Essoft 6.5",
                        Url = new Uri("https://namvietjsc.edu.vn/"),
                    }
                });
                c.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = JwtBearerDefaults.AuthenticationScheme
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement() {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = JwtBearerDefaults.AuthenticationScheme
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header
                        }
                        ,new List<string>()
                    }
                });
                c.TagActionsBy(api =>
                {
                    if (api.GroupName != null)
                    {
                        return new[] { api.GroupName };
                    }

                    var controllerActionDescriptor = api.ActionDescriptor as ControllerActionDescriptor;
                    if (controllerActionDescriptor != null)
                    {
                        return new[] { controllerActionDescriptor.ControllerName };
                    }

                    throw new InvalidOperationException("Unable to determine tag for endpoint.");
                });
                c.DocInclusionPredicate((name, api) => true);
            });
            services.AddControllersWithViews();
            services.AddLocalization(options => options.ResourcesPath = "Resources");
            services.AddMvc().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix).AddDataAnnotationsLocalization();

            #endregion Common
        }

        // Khai báo đăng ký IRepository
        public static void AutofacDependencyConfig(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(BaseRepository).Assembly).Where(t => t.Name.EndsWith("Repository")).AsImplementedInterfaces();
            // Với các trường hợp ngoại lệ
            builder.RegisterType<AppConfiguration>().As<IAppConfiguration>();
        }
    }
}