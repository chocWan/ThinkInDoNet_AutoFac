using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThinkInDoNet_AutoFac.Controllers;

namespace ThinkInDoNet_AutoFac.Modules
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var dataAccess = System.Reflection.Assembly.GetExecutingAssembly();
            //属性注入控制器
            builder.RegisterType<HomeController>().PropertiesAutowired();
            builder.RegisterAssemblyTypes(dataAccess)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .InstancePerRequest()
                .PropertiesAutowired();
            
        }
    }
}
