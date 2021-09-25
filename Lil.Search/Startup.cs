using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lil.Custumers.Interfaces;
using Lil.Custumers.Services;
using Lil.Search.Interfaces;
using Lil.Search.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace Lil.Search
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient("customerService", C =>
            {
                C.BaseAddress = new Uri(Configuration["Services:Customers"]);
            });

            services.AddHttpClient("productService", C =>
            {
                C.BaseAddress = new Uri(Configuration["Services:Products"]);
            });

            services.AddHttpClient("salesService", C =>
            {
                C.BaseAddress = new Uri(Configuration["Services:Sales"]);
            });

            services.AddSingleton<ICustomerService, CustomerService>();
            services.AddSingleton<IProductsService, ProductsService>();
            services.AddSingleton<ISalesService, SalesService>();

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Lil.Search", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Lil.Search v1"));
            }

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
