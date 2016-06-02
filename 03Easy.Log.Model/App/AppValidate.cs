using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Domain.Validators;

namespace Easy.Log.Model.App
{
    public class AppValidate:EntityValidation<App>
    {
        public AppValidate()
        {
            this.IsNullOrWhiteSpace(m=>m.Name,AppBrokenRuleMessage.AppNameIsEmpty);
            //TODO:应用服务名称是否已经存在
        }
    }
}
