using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Domain.Base;

namespace Easy.Log.Model.App
{
    public class AppBrokenRuleMessage : BrokenRuleMessage
    {
        public const string AppNameIsEmpty = "20001";
        public const string AppNameIsExists = "20002";

        protected override void PopulateMessage()
        {
            this.Messages.Add(AppNameIsEmpty,"应用服务名称为空");
            this.Messages.Add(AppNameIsExists,"应用服务名称已经存在");
        }
    }
}
