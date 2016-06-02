using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Domain.Base;

namespace Easy.Log.Model.User
{
    public class UserBrokenRuleMessage : BrokenRuleMessage
    {
        public const string UserNameIsError = "10001";
        public const string PasswordIsError = "10002";

        protected override void PopulateMessage()
        {
            this.Messages.Add(UserNameIsError,"用户名称错误");
            this.Messages.Add(PasswordIsError, "用户密码错误");
        }
    }
}
