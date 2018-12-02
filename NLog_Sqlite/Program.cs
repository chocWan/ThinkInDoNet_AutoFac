using NLog;
using System;
using System.IO;

namespace SqliteDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            LogHelper.LogRequest();
            Logger log = LogManager.GetCurrentClassLogger();
            LogManager.ThrowExceptions = true;
            log.Info("test begin...");
            for (int i = 0; i < 2; i++)
            {
                try
                {
                    int a = 0;
                    int b = 1 / a;
                }
                catch (Exception ex)
                {
                    log.Error(ex, "wancaho");
                }
            }
            log.Info("test end...");
        }
    }
}
