using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Domain.Validators;

namespace Easy.Log.Model.Platform
{
    public class PlatformValidate:EntityValidation<Platform>
    {
        public PlatformValidate()
        {
            this.IsNullOrWhiteSpace(m=>m.Name,PlatformBrokenRuleMessage.PlatformNameIsEmpty);
            //TODO:名称是否存在
        }
    }
}
