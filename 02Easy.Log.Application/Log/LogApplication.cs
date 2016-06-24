using Easy.Domain.Application;
using Easy.Log.Application.Models;
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

        public PageList<LogModel> Select(LogQuery query)
        {
            List<int> AppIds = new List<int>();
            

            var aList = RepositoryRegistry.App.FindAll();
            if (query.UserId>0)
            {
                if (aList != null && aList.Count > 0)
                {
                    AppIds.AddRange(aList.Where(p => p.UserId == query.UserId).Select(p => p.Id));
                }
                var rList = RepositoryRegistry.UserRelation.FindInviteAll(query.UserId, 0, 0);
                if (rList != null && rList.Count > 0)
                {
                    AppIds.AddRange(rList.Select(p => p.AppId));
                }
            }
            else
            {
                AppIds = aList.Select(p => p.Id).ToList();
            }
            if (AppIds==null||AppIds.Count==0)
            {
                return new PageList<LogModel>() { Collections=new List<LogModel>(), TotalRows=0 };
            }

            int totalRows = 0;
            IList<M.Log> list = RepositoryRegistry.Log.Select(new Model.Log.LogQuery
            {
                PageIndex = query.PageIndex,
                PageSize = query.PageSize,
                AppId=query.AppId,
                AppName=query.AppName,
                StartDate=query.StartDate ,
                EndDate=query.EndDate,
                LogLevel=query.LogLevel,
                Tag=query.Tag,
                AppIds= AppIds.ToArray()
            }, out totalRows);


            PageList<LogModel> pageList = new PageList<LogModel>();
            pageList.Collections = list.Select(m=>new LogModel() {
                AppId = m.AppInfo.AppId,
                AppName = m.AppInfo.AppName,
                Ip = m.Ip,
                CreateDate = m.CreateDate,
                Message = m.Message,
                Tag = m.Tag,
                LogLevel=m.LogLevel.GetHashCode(),
                Id=m.Id
            }).ToList();
            pageList.TotalRows = totalRows;
            return pageList;
        }



    }
}
