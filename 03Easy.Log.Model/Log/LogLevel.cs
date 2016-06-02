using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Log.Model.Log
{
    public enum LogLevel
    {
        /// <summary>
        /// 调试信息
        /// </summary>
        Debug = 1,
        /// <summary>
        /// 一般信息
        /// </summary>
        Info = 2,
        /// <summary>
        /// 警告
        /// </summary>
        Warn = 3,
        /// <summary>
        /// 一般错误
        /// </summary>
        Error = 4,
        /// <summary>
        /// 致命错误
        /// </summary>
        Fatal = 5,
        /// <summary>
        /// 打开所有日志
        /// </summary>
        All = 6,
        /// <summary>
        /// 关闭所有日志
        /// </summary>
        Off = 7
    }
}
