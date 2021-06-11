using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sentry.AspNetCore;
using ToSoftware.Shop.Catalog.Api.Data;
using ToSoftware.Shop.Catalog.Api.Domain.Repositories.Contracts;
using ToSoftware.Shop.Catalog.Api.Filters;

namespace ToSoftware.Shop.Catalog.Api
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddTransient<IProductRepository, ProductRepository>();

            services.AddCors();

            services.AddScoped<CodeQueryFilter>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true)
                .AllowCredentials());

            app.UseRouting();

            app.UseSentryTracing();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}