using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Fiver.Lib.MongoDB.Client.OtherLayers;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Extensions.Configuration;

namespace Fiver.Lib.MongoDB.Client
{
    public class Startup
    {
        public static IConfiguration Configuration;

        public Startup(
            IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(
            IServiceCollection services)
        {
            services.AddScoped<IMongoRepository<Movie>>(factory =>
            {
                return new MongoRepository<Movie>(
                    new MongoSettings(
                        connectionString: Configuration["Mongo_ConnectionString"],
                        databaseName: Configuration["Mongo_DatabaseName"],
                        collectionName: Configuration["Mongo_CollectionName"]));
            });
            services.AddScoped<IMovieService, MovieService>();

            services.AddMvc();
        }

        public void Configure(
            IApplicationBuilder app, 
            IHostingEnvironment env)
        {
            //app.UseDeveloperExceptionPage();

            app.UseExceptionHandler(configure =>
            {
                configure.Run(async context =>
                {
                    var ex = context.Features
                                    .Get<IExceptionHandlerFeature>()
                                    .Error;

                    await context.Response.WriteAsync($"Unexpected error: {ex.Message}");
                });
            });

            app.UseMvcWithDefaultRoute();
        }
    }
}
