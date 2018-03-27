using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Cart.Data;
using Cart.Models;
using Cart.Components;
using Cart.API.Filters;
using FluentValidation.AspNetCore;

namespace Cart.API
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
            services.AddMvc(options => {
                options.Filters.Add(new RequiredActionFilter());
            });

            services.AddMvc(options => {
                options.Filters.Add(new CustomExceptionFilter());
            });
             

            services.AddTransient<IOrderRepository, MockOrderRepository>();
            services.AddTransient<IProductRepository, MockProductRepository>();
            services.AddTransient<ICustomerRepository, MockCustomerRepository>();
            services.AddTransient<OrderComponent, OrderComponent>();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
