using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Domain.Base;

namespace Easy.Log.Model.Log
{
    /// <summary>
    /// 日志
    /// </summary>
    public class Log:EntityBase<int>
    {

        public Log(string tag,string message,LogLevel logLevel,AppInfo appInfo,string ip)
        {
            this.Tag = tag;
            this.Message = message;
            this.LogLevel = logLevel;
            this.AppInfo = appInfo;
            this.CreateDate=DateTime.Now;
            this.Ip = ip;
        }

        public AppInfo AppInfo
        {
            get ;
            private set;
        }

        /// <summary>
        /// 日志信息
        /// </summary>
        public string Message
        {
            get;
            private set;
        }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate
        {
            get;
            private set;
        }

        /// <summary>
        /// 标记
        /// </summary>
        public string Tag
        {
            get;
            private set;
        }

        /// <summary>
        /// 日志级别
        /// </summary>
        public LogLevel LogLevel
        {
            get;
            private set;
        }

        /// <summary>
        /// 应用服务器Ip
        /// </summary>
        public string Ip
        {
            get;
            private set;
        }

        public override bool Validate()
        {
            return new LogValidate().IsSatisfy(this);
        }

        protected override BrokenRuleMessage GetBrokenRuleMessages()
        {
            return new LogBrokenRuleMessage();
        }
    }
}
