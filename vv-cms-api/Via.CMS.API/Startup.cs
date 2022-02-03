using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Serilog;
using Via.CMS.Business;
using Via.CMS.Business.Business;
using Via.CMS.Infra.Repository;
using Via.CMS.Infra.Repository.Interface;
using Via.CMS.Service;
using Via.CMS.Service.Interface;

namespace Via.CMS.API
{
    public class Startup
    {

        private const string HEALTH_CHECK_PATH = "/health";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();

            #region Repository
            services.AddScoped<IFaqRepository, FaqRepository>();
            #endregion Repository

            #region Service
            services.AddScoped<IFaqService,FaqService>();
            #endregion Service

            #region Business
            services.AddScoped<IFaqBusiness, FaqBusiness>();
            #endregion

            #region Singletons
            services.AddSingleton(typeof(ILogger<>), typeof(Logger<>));
            #endregion

            #region Decorator
            #endregion

            services.AddControllers()
                    .AddFluentValidation(fvc => fvc.RegisterValidatorsFromAssemblyContaining<Startup>());

            services
               .AddSwaggerGen(c =>
               {
                   c.SwaggerDoc("v1", new OpenApiInfo { Title = "vv.cms.api", Version = "v1" });
               })
            .AddHealthChecks();

            services.Configure<KestrelServerOptions>(options =>
            {
                options.Limits.MaxRequestBodySize = null;
                options.AllowSynchronousIO = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment() || !env.IsEnvironment("prd"))
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "vv.cms.api v1"));
                    c.RoutePrefix = string.Empty;
                });
            }

            loggerFactory.AddSerilog();

            //Midleware
            //app.UseCorrelationId();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true)
                .AllowCredentials());

            app.UseAuthorization();
            // app.UseViaVarejoLogging();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseHealthChecks(HEALTH_CHECK_PATH);
        }
    }
}
