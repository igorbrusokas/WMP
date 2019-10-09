using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;
using WebMotorsProject.Domain.Business;
using WebMotorsProject.Domain.Business.Interfaces;
using WebMotorsProject.Domain.Data.Converter;
using WebMotorsProject.Domain.Externals;
using WebMotorsProject.Domain.Externals.Interface;
using WebMotorsProject.Repository.Context;
using WebMotorsProject.Repository.Repository;
using WebMotorsProject.Repository.Repository.Interface;

namespace WebMotorsProject.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            //Content negociation - Support to XML and JSON
            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddMvc(options =>
            {
                options.RespectBrowserAcceptHeader = true;
                options.FormatterMappings.SetMediaTypeMappingForFormat("xml", MediaTypeHeaderValue.Parse("text/xml"));
                options.FormatterMappings.SetMediaTypeMappingForFormat("json", MediaTypeHeaderValue.Parse("application/json"));
                options.EnableEndpointRouting = false;

            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
              .AddXmlSerializerFormatters();

            //Connection to database
            var connectionString = Configuration["MySqlConnection:MySqlConnectionString"];
            services.AddDbContext<ContextDB>(option => option.UseMySql(connectionString,
                                                                       m => m.MigrationsAssembly("WebMotorsProject.Repository")));
                                                
            //Dependency Injection
            services.AddScoped<IAnuncioBusiness, AnuncioBusiness>();
            services.AddScoped<IAnuncioRepository, AnuncioRepository>();
            services.AddScoped<IMarcaBusiness, MarcaBusiness>();
            services.AddScoped<IModeloBusiness, ModeloBusiness>();
            services.AddScoped<IVersaoBusiness, VersaoBusiness>();
            services.AddScoped<IVeiculoBusiness, VeiculoBusiness>();
            services.AddScoped(typeof(IGenericsExternalServices<>), typeof(GenericsExternalServices<>));


            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            //Adding map routing
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "RouteDefault",
                    template: "{controller=Values}/{id?}");
            });
        }
    }
}
