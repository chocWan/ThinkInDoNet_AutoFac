using log4net.Layout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoFac_NetCoreMVC.Helper
{
    public class CustomLayout: PatternLayout
    {
        public CustomLayout()
        {
            AddConverter("property", typeof(MyMessagePatternConverter));
        }
    }
}
