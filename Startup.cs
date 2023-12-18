﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using Vecto.Services;

namespace Vecto
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
            services.AddSingleton<ResizeEffect>();
            services.AddSingleton<BlurEffect>();
            services.AddSingleton<GrayscaleEffect>();

            services.AddSingleton<IImageProcessingService, ImageProcessingService>(provider =>
            {
                var effects = new List<IImageEffect>
        {
            provider.GetRequiredService<ResizeEffect>(),
            provider.GetRequiredService<BlurEffect>(),
            provider.GetRequiredService<GrayscaleEffect>()
        };
                return new ImageProcessingService(effects);
            });

            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Image}/{action=Index}/{id?}");
            });
        }
    }
}
