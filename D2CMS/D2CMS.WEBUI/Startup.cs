using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using D2CMS.INFRA.Entities;
using D2CMS.INFRA.Infrastructure;
using D2CMS.INFRA.Repositories;
using D2CMS.SERVICE.Core;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace D2CMS.WEBUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.        
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
               .AddCookie(options =>
               {
                   options.LoginPath = "/authen/login";
                   options.LogoutPath = "/authen/logout";
               });

            //enforce URL to lowercase
            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddMvc();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            var builder = new ContainerBuilder();
            builder.RegisterAssemblyModules();
            //Register DI for UoW and DbFactory
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerLifetimeScope();

            //Generic Register
            builder.RegisterAssemblyTypes(typeof(UserRepository).Assembly)
               .Where(t => t.Name.EndsWith("Repository"))
               .AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(UserService).Assembly)
               .Where(t => t.Name.EndsWith("Service"))
               .AsImplementedInterfaces().InstancePerLifetimeScope();

            // types automatically.
            builder.Populate(services);

            IServiceProvider serviceProvider = new AutofacServiceProvider(builder.Build());
            return serviceProvider;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseAuthentication();
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "report history",
                    template: "report/{year}/{month}",
                    defaults: new { controller = "report", action = "history" },
                    constraints: new { year = new IntRouteConstraint(), month = new IntRouteConstraint() });

                routes.MapRoute(
                   name: "team reports",
                   template: "report/team",
                   defaults: new { controller = "report", action = "teamreport" });

                routes.MapRoute(
                   name: "team report History",
                   template: "report/team/{year}/{month}",
                   defaults: new { controller = "report", action = "teamreporthistory" },
                   constraints: new { year = new IntRouteConstraint(), month = new IntRouteConstraint() });

                routes.MapRoute(
                   name: "user report history",
                   template: "report/{account}/{year}/{month}",
                   defaults: new { controller = "report", action = "userreport" });

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
