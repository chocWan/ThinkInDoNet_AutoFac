using Autofac;
using AutoFac_NetCoreMVC.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoFac_NetCoreMVC.Modules
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var dataAccess = System.Reflection.Assembly.GetExecutingAssembly();
            //添加PropertiesAutowired即为属性注入，不添加则默认为构造方法注入
            builder
                .RegisterAssemblyTypes(dataAccess)
                .Where(t => t.Name.EndsWith("Controller"))
                .PropertiesAutowired();
            builder
                .RegisterAssemblyTypes(dataAccess)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .PropertiesAutowired();
            builder
                .RegisterGeneric(typeof(BaseRepository<>))
                .As(typeof(IRepository<>))
                .InstancePerDependency();//注册仓储泛型

        }
    }
}
