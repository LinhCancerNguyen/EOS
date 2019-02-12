using System;
using System.Linq;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using EXAMSYSTEM.CORE.Models;
using EXAMSYSTEM.INFRA.Infrastructure;
using EXAMSYSTEM.INFRA.Repositories;
using EXAMSYSTEM.INFRA.Validator;
using EXAMSYSTEM.SERVICE.Core;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace EXAMSYSTEM.WEBUI
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
                   options.LoginPath = "/quizz/login";
                   options.LogoutPath = "/quizz/logout";
               });

            services.AddDistributedMemoryCache();
            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromMinutes(1);
            });

            //enforce URL to lowercase
            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddMvc().AddFluentValidation(fv => { fv.RegisterValidatorsFromAssemblyContaining<Startup>(); });
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

            services.AddSingleton<AbstractValidator<User>, UserValidator>();
            services.AddSingleton<IValidator<User>, UserValidator>();

            IServiceProvider serviceProvider = new AutofacServiceProvider(builder.Build());
            return serviceProvider;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
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
            app.UseSession();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Quizz}/{action=Login}/{id?}");
            });
        }
    }
}
