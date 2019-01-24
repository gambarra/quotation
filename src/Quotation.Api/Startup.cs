using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Quotation.Infra.Ioc;
using Newtonsoft.Json.Serialization;
using Quotation.Api.Swagger;

namespace Quotation.Api {
    public partial class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {

            ConfigureSwaggerService(services);

            services
               .AddHealthChecks();
            

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(p => {
                    p.SerializerSettings.ContractResolver = new DefaultContractResolver() {
                        NamingStrategy = new SnakeCaseNamingStrategy()
                    };
                    p.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                });
            ;
            services.AddDependencies();



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }
            else {
                app.UseHsts();
            }
           
            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseHealthChecks("/hc");
            ConfigureSwagger(app, env);
        }
    }
}
