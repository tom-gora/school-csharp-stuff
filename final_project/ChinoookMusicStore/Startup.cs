using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;

namespace ChinoookMusicStore {
  public class Startup {
    public void ConfigureServices(IServiceCollection services) {
      services.AddSession(
          options => {
            options.IdleTimeout = TimeSpan.FromMinutes(30);
            options.Cookie.HttpOnly = true;
            options.Cookie.IsEssential = true;
          }
          );
      services.AddRazorPages();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
      app.UseSession();
      if (env.IsDevelopment()) {
        app.UseDeveloperExceptionPage();
      }

      app.UseRouting();
      app.UseDefaultFiles();
      app.UseStaticFiles();
      app.UseStaticFiles(new StaticFileOptions {
        FileProvider = new PhysicalFileProvider(
                 Path.Combine(env.ContentRootPath, "Resources")),
        RequestPath = "/Resources"
      });
      app.UseEndpoints(endpoints => {
        endpoints.MapRazorPages();
      });
    }
  }
}