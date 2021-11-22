using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RentApplication.BLL.Interfaces;
using RentApplication.BLL.Services;
using RentApplication.BLL.Services.Handlers;
using RentApplication.DAL;
using RentApplication.PL.Builders;
using RentApplication.PL.Builders.Interfaces;
using RentApplication.PL.Interfaces;
using RentApplication.PL.Repositories;

namespace RentApplication
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<RentApplicationDbContext>(options => options
                .UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddSpaStaticFiles(configuration => { configuration.RootPath = "ClientApp/dist"; });
            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            // repositories
            services.AddTransient<IClientRepository, ClientRepository>();
            services.AddTransient<IPropertyRepository, PropertyRepository>();
            services.AddTransient<IRealtorRepository, RealtorRepository>();
            services.AddTransient<IRequestRepository, RequestRepository>();
            services.AddTransient<ITenantRepository, TenantRepository>();

            // services
            services.AddTransient<IRentService, RentService>();
            services.AddTransient<IPropertyListService, PropertyListService>();
            services.AddTransient<IPropertyInfoService, PropertyInfoService>();

            // handlers
            services.AddTransient<IHandler, AbstractHandler>();
            services.AddTransient<IHandler, PropertyListHandler>();
            services.AddTransient<IHandler, PriceListHandler>();
            services.AddTransient<IHandler, DetailsHandler>();

            // builders
            services.AddTransient<IClientBuilder, ClientBuilder>();
            services.AddTransient<IPropertyBuilder, PropertyBuilder>();
            services.AddTransient<IRequestBuilder, RequestBuilder>();
            services.AddTransient<IRealtorBuilder, RealtorBuilder>();
            services.AddTransient<ITenantBuilder, TenantBuilder>();

            // var config = Configuration.GetSection("subservice").Get<PropertyInfoService>();
            // var config2 = Configuration.GetSection("subservice").Get<PropertyListService>();
            // services.AddScoped<RentService>(servide => new RentService(config, config2));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}