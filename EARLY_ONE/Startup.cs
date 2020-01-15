using System;
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
using Microsoft.OpenApi.Models;
using Microsoft.DotNet.PlatformAbstractions;
using System.IO;

namespace EARLY_ONE
{
    /// <summary>
    /// Api启动类
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 全局变量-API名
        /// </summary>
        public string apiName { get; set; } = "EARLY_ONE";

        /// <summary>
        /// 启动方法
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// 
        /// </summary>
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            var basePath = ApplicationEnvironment.ApplicationBasePath;

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("V1", new OpenApiInfo { 
                    Version = "V1",
                    Title = $"{apiName} 接口文档--.Net Core 3.1",
                    Description = $"{apiName} HTTP API V1",
                    Contact = new OpenApiContact { Name = apiName, Email = "Early@gmail.com", Url = new Uri("https://www.early.com") },
                    License = new OpenApiLicense { Name = apiName, Url = new Uri("https://www.early.com") }
                });
                c.OrderActionsBy(o => o.RelativePath);
                var xmlPath = Path.Combine(basePath, "EARLY_ONE.xml");
                c.IncludeXmlComments(xmlPath,true);
            });

                    
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c => 
            {
                c.SwaggerEndpoint($"/swagger/V1/swagger.json", $"{apiName} V1");
                c.RoutePrefix = "swagger";
            });

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
