using Ege.Net;
using AdaMedicine.MobileApi.Infrastructure;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AdaMedicine.MobileApi
{
    public class Startup : ModularStartup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        public new void ConfigureServices(IServiceCollection services) { }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseEgeNet(new AppHost
            {
                AppSettings = new NetCoreAppSettings(Configuration)
            });

            app.Run(context =>
            {
                context.Response.Redirect("api/metadata");
                return Task.FromResult(0);
            });
        }
    }
}
