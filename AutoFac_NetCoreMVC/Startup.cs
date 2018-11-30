﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using ThinkInDoNet_AutoFac.Controllers;
using ThinkInDoNet_AutoFac.Models;
using ThinkInDoNet_AutoFac.Modules;
using ThinkInDoNet_AutoFac.Services;

namespace ThinkInDoNet_AutoFac
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public IContainer ApplicationContainer { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            //替换控制器所有者，因为控制器实例默认由NetCore管理
            services.Replace(ServiceDescriptor.Transient<IControllerActivator, ServiceBasedControllerActivator>());
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            #region 单个注入
            //var builder = new ContainerBuilder();//实例化 AutoFac  容器            
            //builder.Populate(services);
            ////builder.RegisterType<ReadService>().As<IReadService>();
            //ApplicationContainer = builder.Build();
            //return new AutofacServiceProvider(ApplicationContainer);
            #endregion
            #region 扫描注入
            //var builder = new ContainerBuilder();//实例化 AutoFac  容器     
            //var dataAccess = Assembly.GetExecutingAssembly();
            //builder.RegisterAssemblyTypes(dataAccess).Where(t => t.Name.EndsWith("Service")).AsImplementedInterfaces();
            //builder.Populate(services);
            //ApplicationContainer = builder.Build();
            //return new AutofacServiceProvider(ApplicationContainer);
            #endregion
            #region 扫描注入 添加模块
            var builder = new ContainerBuilder();    
            var dataAccess = Assembly.GetExecutingAssembly();
            builder.RegisterModule(new AutofacModule());
            builder.Populate(services);
            ApplicationContainer = builder.Build();
            return new AutofacServiceProvider(ApplicationContainer);
            #endregion
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
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

    }
}
