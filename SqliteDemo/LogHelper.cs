using NLog;
using System;
using System.Collections.Generic;
using System.Text;

namespace SqliteDemo
{
    public class LogHelper
    {

        public static ILogger requestLogger = LogManager.GetLogger("SqliteTarget_LogRequest");
        public static ILogger logger = LogManager.GetCurrentClassLogger();

        public static void LogRequest()
        {
            LogEventInfo lei = new LogEventInfo();
            lei.Properties["FName"] = "hello ";
            lei.Properties["FRequestUrl"] = "hello ";
            lei.Properties["FRequestType"] = "hello ";
            lei.Properties["FParameters"] = "hello ";
            lei.Properties["FMessage"] = "hello ";
            lei.Properties["FDetails"] = "hello ";
            lei.Properties["FIPAddress"] = "hello ";
            lei.Properties["FRequestUser"] = "hello ";
            lei.Properties["FRequestTime"] = "hello ";
            lei.Level = LogLevel.Info;
            requestLogger.Info(lei);
        }

        public LogEventInfo GetLogEventInfo()
        {
            LogEventInfo lei = new LogEventInfo();
            lei.Properties["FName"] = "hello ";
            lei.Properties["FRequestUrl"] = "hello ";
            lei.Properties["FRequestType"] = "hello ";
            lei.Properties["FParameters"] = "hello ";
            lei.Properties["FMessage"] = "hello ";
            lei.Properties["FDetails"] = "hello ";
            lei.Properties["FIPAddress"] = "hello ";
            lei.Properties["FRequestUser"] = "hello ";
            lei.Properties["FRequestTime"] = "hello ";
            lei.Level = LogLevel.Info;
            return lei;
        }


    }
    /// <summary>
    /// 操作类型枚举
    /// </summary>
    public enum OperationType
    {
        /// <summary>
        /// 保存或添加
        /// </summary>
        [System.ComponentModel.Description("保存或添加")]
        ADD,
        /// <summary>
        /// 更新
        /// </summary>
        [System.ComponentModel.Description("更新")]
        UPDATE,
        /// <summary>
        /// 审核
        /// </summary>
        [System.ComponentModel.Description("审核")]
        AUDIT,
        /// <summary>
        /// 删除
        /// </summary>
        [System.ComponentModel.Description("删除")]
        DELETE,
        /// <summary>
        /// 读取/查询
        /// </summary>
        [System.ComponentModel.Description("读取/查询")]
        RETRIEVE,
        /// <summary>
        /// 登录
        /// </summary>
        [System.ComponentModel.Description("登录")]
        LOGIN,
        /// <summary>
        /// 查看
        /// </summary>
        [System.ComponentModel.Description("查看")]
        LOOK
    }
}
