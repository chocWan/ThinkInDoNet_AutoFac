using log4net.Core;
using log4net.Layout.Pattern;
using log4net.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace AutoFac_NetCoreMVC.Helper
{
    public class MyMessagePatternConverter : PatternLayoutConverter
    {
        protected override void Convert(TextWriter writer, LoggingEvent loggingEvent)
        {
            if (Option != null)
            {
                PatternConverter.WriteObject(writer, loggingEvent.Repository, LookupProperty(Option, loggingEvent));
            }
            else
            {
                PatternConverter.WriteDictionary(writer, loggingEvent.Repository, loggingEvent.GetProperties());
            }
        }

        private object LookupProperty(string property, LoggingEvent loggingEvent)
        {
            object result = string.Empty;
            PropertyInfo property2 = loggingEvent.MessageObject.GetType().GetProperty(property);
            if (property2 != (PropertyInfo)null)
            {
                result = property2.GetValue(loggingEvent.MessageObject, null);
            }
            return result;
        }
    }
}
