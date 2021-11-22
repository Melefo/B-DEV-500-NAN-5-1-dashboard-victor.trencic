using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Doshboard.Backend
{
    /// <summary>
    /// Configuration webapp
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// List of configuration
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Startup constructor
        /// </summary>
        /// <param name="configuration">Base configuration</param>
        public Startup(IConfiguration configuration) =>
            Configuration = configuration;

        /// <summary>
        /// Configure and add list services
        /// </summary>
        /// <param name="services">Where to register services</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(new Mongo(Configuration));
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Doshboard", Version = "v1" });
            });
            services.AddEndpointsApiExplorer();
        }

        /// <summary>
        /// Enable services
        /// </summary>
        /// <param name="app">Our application</param>
        /// <param name="env">Environment</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseRouting();

            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}