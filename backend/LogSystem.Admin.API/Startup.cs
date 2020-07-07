using System.Net;
using System.Threading.Tasks;
using LogSystem.IoC.AdminIoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LogSystem.Admin.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            RegisterServices(services);     
        }

        private void RegisterServices(IServiceCollection services)
        {
            DependencyContainer dependency = new DependencyContainer(Configuration);
            dependency.RegisterServices(services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "LogSystemAPI V1");
                });

                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseStatusCodePages(context =>
            {
                var response = context.HttpContext.Response;

                if (response.StatusCode == (int)HttpStatusCode.Unauthorized)
                {
                    response.Redirect("/api/Error/unAuthorized");
                }
                else if (response.StatusCode == (int)HttpStatusCode.Forbidden)
                {
                    response.Redirect("/api/Error/forbidden");
                }
                else if (response.StatusCode == (int)HttpStatusCode.MethodNotAllowed)
                {
                    response.Redirect("/api/Error/methodNotAllowed");
                }
                else if (response.StatusCode == (int)HttpStatusCode.NotFound)
                {
                    response.Redirect("/api/Error/rootNotFound");
                }
                return Task.CompletedTask;
            });

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()); 

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
