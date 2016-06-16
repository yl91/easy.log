using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Domain.Base;

namespace Easy.Log.Model.App
{
    /// <summary>
    /// 应用服务
    /// </summary>
    public class App : EntityBase<int>
    {
        public App() { }
        public App(string name,string description,int userId,string ip)
        {
            this.Name = name;
            this.Description = description;
            this.UserId = userId;
            this.IsRecord = true;
            this.Ip = ip;
            this.CreateDate = DateTime.Now;
        } 

        /// <summary>
        /// 服务名称
        /// </summary>
        public string Name
        {
            get;
            private set;
        }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description
        {
            get;
            private set;
        }

        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserId
        {
            get;
            private set;
        }

        /// <summary>
        /// 是否记录
        /// </summary>
        public bool IsRecord
        {
            get;
            set;
        }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate
        {
            get;
            private set;
        }

        public string Ip
        {
            get;
            private set;
        }

        public override bool Validate()
        {
            return new AppValidate().IsSatisfy(this);
        }

        protected override BrokenRuleMessage GetBrokenRuleMessages()
        {
            return new AppBrokenRuleMessage();
        }
    }
}
