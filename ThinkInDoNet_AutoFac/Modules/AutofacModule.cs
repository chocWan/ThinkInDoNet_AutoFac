using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThinkInDoNet_AutoFac.Modules
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var dataAccess = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(dataAccess).Where(t => t.Name.EndsWith("Service")).AsImplementedInterfaces();
        }
    }
}
