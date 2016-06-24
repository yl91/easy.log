using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Domain.Validators;

namespace Easy.Log.Model.User
{
    public class UserValidate:EntityValidation<User>
    {
        public UserValidate()
        {
            this.IsNullOrEmpty(m=>m.UserName,UserBrokenRuleMessage.UserNameIsError);
            this.IsNullOrEmpty(m => m.Password, UserBrokenRuleMessage.PasswordIsError);
            this.IsNullOrEmpty(m=>m.Email,UserBrokenRuleMessage.EmailIsError);
        }
    }
}
