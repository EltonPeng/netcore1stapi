using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using netcore1stapi.Interfaces;
using netcore1stapi.Models;
using netcore1stapi.Services;

namespace netcore1stapi
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
            services.AddDbContext<Models.WallContext>(opt => opt.UseInMemoryDatabase("WallPanel"));
            services.AddSession();
            services.AddMvc();

            services.AddTransient<IOperationTransient, Operation>();
            services.AddScoped<IOperationScoped, Operation>();
            services.AddSingleton<IOperationSingleton, Operation>();
            services.AddSingleton<IOperationSingletonInstance>(new Operation(Guid.Empty));
            services.AddTransient<OperationCenter, OperationCenter>();

            //services.AddTransient<IBookingRepositoryService, BookingRepositoryService>();

            // container will create the instance(s) of these types and will dispose them            
            //services.AddSingleton<IOperationScoped>(sp => new Operation());

            // container did not create instance so it will NOT dispose it
            //services.AddSingleton<Operation>(new Operation());

            ///In version 1.0, the container called dispose on all IDisposable objects, including those it did not create.
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSession();

            app.UseMvc();
        }
    }
}
