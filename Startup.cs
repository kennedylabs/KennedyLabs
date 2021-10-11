using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Extensions;

namespace KennedyLabs
{
    public class Startup
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _config;

        public Startup(IWebHostEnvironment webHostEnvironment, IConfiguration config)
        {
            _env = webHostEnvironment ??
                throw new ArgumentNullException(nameof(webHostEnvironment));
            _config = config ??
                throw new ArgumentNullException(nameof(config));
        }

        public void ConfigureServices(IServiceCollection services) =>
            services.AddUmbraco(_env, _config)
                .AddBackOffice()
                .AddWebsite()
                .AddComposers()
                .Build();

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseUmbraco()
                .WithMiddleware(
                    m => m.UseBackOffice().UseWebsite())
                .WithEndpoints(
                    e => e.UseInstallerEndpoints().UseBackOfficeEndpoints().UseWebsiteEndpoints());
        }
    }
}
