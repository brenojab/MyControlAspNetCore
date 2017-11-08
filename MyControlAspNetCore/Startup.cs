using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using MyControlAspNetCore.Models;
using Microsoft.AspNetCore.Identity;

namespace MyControlAspNetCore
{
  public class Startup
  {
    public IConfiguration Configuration { get; }

    public Startup(IHostingEnvironment env)
    {
      var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile("dbconfig.json", optional: true)
                .AddEnvironmentVariables();
      Configuration = builder.Build();
    }

    //public Startup(IConfiguration configuration)
    //{
    //  Configuration = configuration;
    //}


    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddMvc();

      services.AddDbContext<MyControlAspNetCoreContext>(options =>
              options.UseSqlServer(Configuration.GetConnectionString("connStr")));

      services.AddIdentity<Usuario, IdentityRole>()
        .AddEntityFrameworkStores<MyControlAspNetCoreContext>()
        .AddDefaultTokenProviders();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseBrowserLink();
      }
      else
      {
        app.UseExceptionHandler("/Home/Error");
      }

      app.UseStaticFiles();

      app.UseMvc(routes =>
      {
        routes.MapRoute(
                  name: "default",
                  template: "{controller=Account}/{action=Login}/{id?}");
      });
    }
  }
}
