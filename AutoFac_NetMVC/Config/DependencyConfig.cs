using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoFac_NetMVC.Config
{
    public class DependencyConfig
    {
        public static void Register()
        {
            var builder = new ContainerBuilder();

            ////Repositories的注入
            //builder.RegisterAssemblyTypes(typeof(UsersRepository).Assembly)
            //    .Where(t => t.Name.EndsWith("Repository"))
            //    .AsImplementedInterfaces()
            //    .InstancePerRequest()
            //    .PropertiesAutowired();

            ////Services的注入
            //builder.RegisterAssemblyTypes(typeof(FormsAuthenticationSvc).Assembly)
            //    .Where(t => t.Name.EndsWith("Svc"))
            //    .AsImplementedInterfaces()
            //    .InstancePerRequest()
            //    .PropertiesAutowired();

            ////Cache的注入，使用单例模式
            //builder.RegisterType<RedisCacheManager>()
            //    .As<ICacheManager>()
            //    .SingleInstance()
            //    .PropertiesAutowired();

            //var container = builder.Build();
            //DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}