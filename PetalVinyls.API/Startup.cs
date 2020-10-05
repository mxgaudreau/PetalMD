using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PetalVinyls.API.Data;
using PetalVinyls.API.Services;

namespace PetalVinyls.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IPetalVinylsContext, PetalVinylsContext>();
            services.AddScoped<IVinylService, VinylService>();
            services.AddControllers()
                .ConfigureApiBehaviorOptions(options =>
                {
                    options.ClientErrorMapping[StatusCodes.Status400BadRequest].Link = 
                        "[Chemin invalide] Cet API n'a aucun chemin correspondant à votre requête.";
                    options.ClientErrorMapping[StatusCodes.Status404NotFound].Link =
                        "[Requête invalide] Aucune ressource trouvée.";
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //app.UseExceptionHandler(appBuilder =>
                //{
                //    appBuilder.Run(async context =>
                //    {
                //        context.Response.StatusCode = 500;
                //        await context.Response.WriteAsync("Une faute inattendue s'est produite. Réessayez plus tard.");
                //    });
                //});
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Vinyl}/{action=GetCollection}/{id?}");
            });
        }
    }
}
