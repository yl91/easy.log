using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Log.Application.Models.Log
{
    public class LogModel
    {
        public int Id;

        public string Message;

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate;

        /// <summary>
        /// 标记
        /// </summary>
        public string Tag;

        /// <summary>
        /// 日志级别
        /// </summary>
        public int LogLevel;

        /// <summary>
        /// 应用服务器Ip
        /// </summary>
        public string Ip;

        public int AppId;

        public string AppName;
    }
}
