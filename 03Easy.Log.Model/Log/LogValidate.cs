using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Domain.Validators;

namespace Easy.Log.Model.Log
{
    public class LogValidate: EntityValidation<Log>
    {
        public LogValidate()
        {
     
            this.IsNullOrWhiteSpace(m=>m.Tag,LogBrokenRuleMessage.LogTagIsEmpty);
            this.IsNullOrWhiteSpace(m=>m.Message.ToString(),LogBrokenRuleMessage.LogMessageIsEmpty);
            this.IsNullOrWhiteSpace(m=>m.AppInfo.AppName,LogBrokenRuleMessage.AppInfoNameIsEmpty);
            this.GreaterThan(m=>m.AppInfo.AppId,0,LogBrokenRuleMessage.AppIdIsError);
        }
    }
}
