using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Domain.Base;

namespace Easy.Log.Model.Platform
{
    public class PlatformBrokenRuleMessage : BrokenRuleMessage
    {
        public const string PlatformNameIsEmpty = "10001";
        public const string PlatformNameExists = "10002";

        protected override void PopulateMessage()
        {
            this.Messages.Add(PlatformNameIsEmpty, "平台名称不能为空");
            this.Messages.Add(PlatformNameExists, "平台名称已经存在");
        }
    }
}
