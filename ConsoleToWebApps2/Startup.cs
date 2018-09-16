using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleToWebApps2
{
    public class Startup
    {
        //We can use this inside the Startup But to use it inside the view 
        //We need to add @inject directive
        public IConfiguration Configuration { get; set; }
        public Startup(IConfiguration config)
        {
            this.Configuration = config;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddMvc(); //Adding MVC Services
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc(); // Use the Mvc service but it will not show any effect till we add pages

            string Message = Configuration["Message"];
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("<b>Hello World!</b>"+Message);
            });
        }
    }
}
