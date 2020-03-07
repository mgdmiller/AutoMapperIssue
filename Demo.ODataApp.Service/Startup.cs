using AutoMapper;
using Demo.ODataApp.Service.Context;
using Demo.ODataApp.Service.Domain;
using Demo.ODataApp.Service.Models;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OData.Edm;

namespace Demo.ODataApp.Service
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
            services.AddDbContext<OrdersContext>(o =>
            {
                o.UseInMemoryDatabase("test");
                o.UseLazyLoadingProxies();
            });

            services.AddOData();
            services.AddAutoMapper( GetType());
            
            services.AddMvc(options => { options.EnableEndpointRouting = false; }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, OrdersContext context,IMapper mapper)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                mapper.ConfigurationProvider.AssertConfigurationIsValid();
            }
           
            Seed(context);
            
            app.UseMvc(routes =>
            {
                routes.Select().Expand().Filter().OrderBy().MaxTop(100).Count();
                routes.MapODataServiceRoute("a", "api", GetModel());
            });
        }

        private static IEdmModel GetModel()
        {
            var builder = new ODataConventionModelBuilder();

            builder.EntitySet<OrderModel>("Orders").EntityType.HasKey(x => x.Id);
            
            return builder.GetEdmModel();
        }

        private static void Seed(DbContext context)
        {
            context.Set<Order>().AddRange(new Order
            {
                Id = 1,
                Positions =
                {
                    new OrderPosition
                    {
                        Amount = 6566
                    }
                }
            }, new Order
            {
                Id = 2,
                Positions =
                {
                    new OrderPosition
                    {
                        Amount = 234234
                    },
                    new OrderPosition
                    {
                        Amount = 56757
                    }
                }
            });

            context.SaveChanges();
        }
    }
}