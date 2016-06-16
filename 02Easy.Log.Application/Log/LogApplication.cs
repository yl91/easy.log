using Easy.Domain.Application;
using Easy.Log.Application.Models.Log;
using Easy.Log.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using M = Easy.Log.Model.Log;

namespace Easy.Log.Application.Log
{
    public class LogApplication:BaseApplication
    {
        /// <summary>
        ///创建日志
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public string Create(LogParameter param)
        {
            M.Log log = new M.Log(param.tag, param.message, (M.LogLevel)param.logLevel, new M.AppInfo() { AppId = param.appId, AppName = param.appName }, param.ip);
            if (log.Validate())
            {
                RepositoryRegistry.Log.Add(log);
            }
            return log.GetBrokenRules()[0].Description;
        }

        /// <summary>
        ///删除日志
        /// </summary>
        /// <param name="logId"></param>
        public void Remove(int logId)
        {
            M.Log log= RepositoryRegistry.Log.FindBy(logId);
            RepositoryRegistry.Log.Remove(log);
        }

    }
}
