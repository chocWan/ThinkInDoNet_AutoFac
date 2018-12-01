using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoFac_NetCoreMVC.Context;
using AutoFac_NetCoreMVC.Models;
using AutoFac_NetCoreMVC.Modules;
using log4net;
using log4net.Config;
using log4net.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace AutoFac_NetCoreMVC
{
    public class Startup
    {

        public static ILoggerRepository LogRepository { get; set; }
        public IConfiguration Configuration { get; }
        public IContainer ApplicationContainer { get; private set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            //log4net
            LogRepository = LogManager.CreateRepository("NETCoreRepository");
            //指定配置文件
            XmlConfigurator.Configure(LogRepository, new FileInfo("log4net.config"));
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            //生成当前项目根目录下
            var connection = @"Filename=raeclass.db";
            services.AddDbContext<RaeClassContext>(options => options.UseSqlite(connection));
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
            #region 扫描注入 添加模块 建议使用此种方法
            var builder = new ContainerBuilder();    
            var dataAccess = Assembly.GetExecutingAssembly();
            builder.RegisterModule(new AutofacModule());
            //builder.RegisterModule(new LoggingModule());//it does nto work!!!!
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

            InitData(app.ApplicationServices);
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

        private void InitData(IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                //获取注入的RaeClassContext
                var db = serviceScope.ServiceProvider.GetService<RaeClassContext>();
                db.Database.EnsureCreated();//如果数据库不存在则创建，存在不做操作。
                if (db.ReadContentSet.Count() == 0)
                {
                    var readContents = new List<ReadContent>{
                        new ReadContent{ FNumber="001",FName = "Read001",FLevel = "1",FJsonData = "{name:\"choc\"}",FCreateTime = DateTime.Now,FModifyTime = DateTime.Now},
                        new ReadContent{ FNumber="002",FName = "Read002",FLevel = "2",FJsonData = "{name:\"choc\"}",FCreateTime = DateTime.Now,FModifyTime = DateTime.Now},
                        new ReadContent{ FNumber="003",FName = "Read003",FLevel = "3",FJsonData = "{name:\"choc\"}",FCreateTime = DateTime.Now,FModifyTime = DateTime.Now},
                        new ReadContent{ FNumber="004",FName = "Read004",FLevel = "4",FJsonData = "{name:\"choc\"}",FCreateTime = DateTime.Now,FModifyTime = DateTime.Now},
                        new ReadContent{ FNumber="005",FName = "Read004",FLevel = "4",FJsonData = "{name:\"chocTest\"}",FCreateTime = DateTime.Now,FModifyTime = DateTime.Now},
                    };
                    db.ReadContentSet.AddRange(readContents);
                    db.SaveChanges();
                }
            }
        }

    }
}
