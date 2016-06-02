using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Domain.Base;

namespace Easy.Log.Model.Log
{
    public class LogBrokenRuleMessage : BrokenRuleMessage
    {
        public const string AppIdIsError = "30001";
        public const string LogMessageIsEmpty = "30002";
        public const string LogTagIsEmpty = "30003";
        public const string AppInfoNameIsEmpty = "30004";

        protected override void PopulateMessage()
        {
            this.Messages.Add(AppIdIsError, "应用服务ID必须大于零");
            this.Messages.Add(LogMessageIsEmpty, "日志信息不能为空");
            this.Messages.Add(LogTagIsEmpty, "日志标记不能为空");
            this.Messages.Add(AppInfoNameIsEmpty,"应用服务名称不能为空");
        }
    }
}
