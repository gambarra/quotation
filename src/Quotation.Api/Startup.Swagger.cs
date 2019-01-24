using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Quotation.Api.Swagger;
using Swashbuckle.AspNetCore.Examples;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Quotation.Api {
    public partial class Startup {
        private void ConfigureSwaggerService(IServiceCollection services) {
            services.AddSwaggerGen(options => {
                string basePath = PlatformServices.Default.Application.ApplicationBasePath;
                string moduleName = GetType().GetTypeInfo().Module.Name.Replace(".dll", ".xml");
                string filePath = Path.Combine(basePath, moduleName);
                string readme = File.ReadAllText(Path.Combine(basePath, "Docs", "README.md"));

               

                Info info = Configuration.GetSection("Info").Get<Info>();
                info.Description = readme;
                options.SwaggerDoc(info.Version, info);

                options.IncludeXmlComments(Path.Combine(basePath, "Quotation.Api.xml"));
                options.IncludeXmlComments(Path.Combine(basePath, "Quotation.Application.xml"));
            
                options.DescribeAllEnumsAsStrings();
               // options.CustomSchemaIds(CustomSchemaIds.Format);
                options.OperationFilter<ExamplesOperationFilter>();
                options.DescribeStringEnumsInCamelCase();

            });
         
           
        }
      

        private void ConfigureSwagger(IApplicationBuilder app, IHostingEnvironment env) {
            app.UseStaticFiles();

            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "V1 Docs");
            });

            app.UseSwagger(c => {
                c.RouteTemplate = "/swagger/{documentName}/swagger.json";
            });
        }
    }
}
