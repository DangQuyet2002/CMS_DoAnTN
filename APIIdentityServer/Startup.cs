using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Models;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.Globalization;
using System.IO;
using System.Text;

namespace APIIdentityServer
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            ConfigurationHelper.ServicesConfig(services);
            // Add AutofacDependencyConfig
            var containerBuilder = new ContainerBuilder();
            ConfigurationHelper.AutofacDependencyConfig(containerBuilder);
            containerBuilder.Populate(services);
            return new AutofacServiceProvider(containerBuilder.Build());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.Use(async (context, next) =>
            //{
            //    //var url1 = context.Request.GetDisplayUrl();
            //    //var url2 = context.Request.GetEncodedUrl();
            //    context.Request.EnableBuffering();
            //    using (var reader = new StreamReader(context.Request.Body, Encoding.UTF8, false, 1024, true))
            //    {
            //        var body = await reader.ReadToEndAsync();
            //        if (!string.IsNullOrEmpty(body))
            //        {
            //            UserClaims baseModel = JsonConvert.DeserializeObject<UserClaims>(body);
            //            if (baseModel != null && !string.IsNullOrEmpty(baseModel.IP))
            //            {
            //                log4net.GlobalContext.Properties["IP"] = baseModel.IP;
            //            }
            //        }
            //    }
            //    context.Request.Body.Seek(0, SeekOrigin.Begin);
            //    await next.Invoke();
            //});

            app.Use(async (context, next) =>
            {
                //var url1 = context.Request.GetDisplayUrl();
                //var url2 = context.Request.GetEncodedUrl();
                context.Request.EnableBuffering();
                using (var reader = new StreamReader(context.Request.Body, Encoding.UTF8, false, 1024, true))
                {
                    var body = await reader.ReadToEndAsync();
                    if (!string.IsNullOrEmpty(body))
                    {
                        UserClaims baseModel = JsonConvert.DeserializeObject<UserClaims>(body);
                        if (baseModel != null && !string.IsNullOrEmpty(baseModel.UserId))
                        {
                            log4net.GlobalContext.Properties["IP"] = baseModel.IP;
                            log4net.GlobalContext.Properties["UserId"] = baseModel.UserId;
                        }
                    }
                }
                context.Request.Body.Seek(0, SeekOrigin.Begin);
                await next.Invoke();
            });

            app.UseSwagger(options =>
            {
                options.SerializeAsV2 = true; //Suppport Swagger JSON in version 2.0 of the specification-officially called the OpenAPI Specification.
            });
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(ConfigurationHelper.settings["SwaggerEndpoint:Url"], ConfigurationHelper.settings["SwaggerEndpoint:Name"]);
                c.RoutePrefix = string.Empty;
                c.DocExpansion(DocExpansion.None);
                c.EnableFilter();
            });
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCookiePolicy();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("en-US"),
                // Formatting numbers, dates, etc.
                SupportedCultures = new[] { new CultureInfo("en-US") },
                // UI strings that we have localized.
                SupportedUICultures = new[] { new CultureInfo("en-US") }
            });
        }
    }
}