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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;

namespace GIns.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        public void ConfigureServices(IServiceCollection services)
        {
            
            //// configure jwt authentication
            //var appSettings = appSettingsSection.Get<AppSettings>();
            //var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            var key = Encoding.ASCII.GetBytes(ClsGlobal.Secret);// default authentication initialization


            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })

           .AddJwtBearer(x =>
           {
               x.RequireHttpsMetadata = false;
               x.SaveToken = true;
               x.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuerSigningKey = true,
                   IssuerSigningKey = new SymmetricSecurityKey(key),
                   ValidateIssuer = false,
                   ValidateAudience = false
               };
           });

            services.AddMvc().AddNewtonsoftJson();
            services.AddResponseCompression(opts =>
            {
                opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
                    new[] { "application/octet-stream" });
            });

            // configure DI for application services
            //***Inject Repository to DataAcess Binders();
            services.AddTransient<ICustomerRepository, CustomerDataAccess>();
            services.AddTransient<IPolicyRepository, PolicyDataAccess>();
            services.AddTransient<IUserRepository, UserDataAccess>();
            services.AddTransient<IExcelRepository, ExcelDataAccess>();



            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            
            //CORS services 
            //PM: Install-Package Microsoft.AspNetCore.Cors -Version 2.2.0
            //https://docs.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-3.0
            services.AddCors();


            //***PM: Install-Package Insight.Database
            SqlInsightDbProvider.RegisterProvider();
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


            //// global cors policy
            //app.UseCors(policy =>
            //    policy.WithOrigins("http://localhost:56693/","http://localhost:5000", "https://localhost:5001")
            //    .AllowAnyMethod()
            //    .WithHeaders(HeaderNames.ContentType, HeaderNames.Authorization, "x-custom-header")
            //    .AllowCredentials());

            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            // default authentication initialization
            app.UseAuthorization();
            //app.UseAuthentication();


            //***//
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseHttpsRedirection();

            app.UseClientSideBlazorFiles<Client.Startup>();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapFallbackToClientSideBlazor<Client.Startup>("index.html");
            });
        }
    }
}
