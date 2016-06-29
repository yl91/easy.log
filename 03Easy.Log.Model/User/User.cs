using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Domain.Base;

namespace Easy.Log.Model.User
{
    public class User : EntityBase<int>
    {
        public User()
        {
        }

        public User(string userName,string email)
        {
            this.UserName = userName;
            this.Email = email;
            this.CreateDate = DateTime.Now;
            this.Secret = Guid.NewGuid().ToString("N");
        }

        /// <summary>
        /// 账号
        /// </summary>
        public string UserName
        {
            get;
            private set;
        }

        /// <summary>
        /// 真是姓名
        /// </summary>
        public string RealName
        {
            get;
            set;
        }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password
        {
            get;
            set;
        }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate
        {
            get; private set;
        }

        public string Email
        {
            get;
            private set;
        }

        public string Secret
        {
            get;
            private set;
        }


        public override bool Validate()
        {
            return new UserValidate().IsSatisfy(this);
        }

        protected override BrokenRuleMessage GetBrokenRuleMessages()
        {
            return new UserBrokenRuleMessage();
        }
    }
}
