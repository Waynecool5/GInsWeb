using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
//using Blazor.FileReader;

namespace GIns.Client
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddFileReaderService();
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}

