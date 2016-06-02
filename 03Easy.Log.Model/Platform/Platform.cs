using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Easy.Domain.Base;

namespace Easy.Log.Model.Platform
{
    /// <summary>
    /// 日志平台系统
    /// </summary>
    public class Platform : EntityBase<int>
    {
        public Platform(string name)
        {
            this.Name = name;
            this.CreateDate = DateTime.Now;
        }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name
        {
            get;
            private set;
        }


        /// <summary>
        /// 创建时间 
        /// </summary>
        public DateTime CreateDate
        {
            get; private set;
        }

        public override bool Validate()
        {
            return new PlatformValidate().IsSatisfy(this);
        }

        protected override BrokenRuleMessage GetBrokenRuleMessages()
        {
            return new PlatformBrokenRuleMessage();
        }
    }
}
