using Insight.Database;
using Insight.Database.Json;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using System.Linq;
using GIns.Server.Controllers.Customer;
using GIns.Server.Controllers.Policy;
using GIns.Server.Controllers.User;
using GIns.Server.Controllers.Excel;

namespace GIns.Server
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddNewtonsoftJson();
            services.AddResponseCompression(opts =>
            {
                opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
                    new[] { "application/octet-stream" });
            });

            //***Inject Repository to DataAcess Binders();
            services.AddTransient<ICustomerRepository, CustomerDataAccess>();
            services.AddTransient<IPolicyRepository, PolicyDataAccess>();
            services.AddTransient<IUserRepository,UserDataAccess> ();
            services.AddTransient<IExcelRepository, ExcelDataAccess>();

            //***PM: Install-Package Insight.Database
            SqlInsightDbProvider.RegisterProvider();
            //***Insight.Database.Json Class[Column(SerializationMode=SerializationMode.Json)]
            JsonNetObjectSerializer.Initialize();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseResponseCompression();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBlazorDebugging();
            }

            app.UseClientSideBlazorFiles<Client.Startup>();

            app.UseRouting();

            //***//
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseHttpsRedirection();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapFallbackToClientSideBlazor<Client.Startup>("index.html");
            });
        }
    }
}
