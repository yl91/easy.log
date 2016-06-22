using Easy.Domain.Application;
using Easy.Log.Application.Models;
using Easy.Log.Application.Models.App;
using Easy.Log.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using M = Easy.Log.Model.App;

namespace Easy.Log.Application.App
{
    public class AppApplication:BaseApplication
    {
        /// <summary>
        /// 创建应用
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="userId"></param>
        /// <param name="ip"></param>
        /// <returns></returns>
        public string Create(string name, string description, int userId, string ip)
        {
            M.App app = new M.App(name, description, userId, ip);
            if (app.Validate())
            {
                RepositoryRegistry.App.Add(app);
                return string.Empty;
            }
            return app.GetBrokenRules()[0].Description;
        }

        /// <summary>
        /// 删除应用
        /// </summary>
        /// <param name="appId"></param>
        public void Remove(int appId)
        {
            M.App app= RepositoryRegistry.App.FindBy(appId);
            if (app!=null)
            {
                RepositoryRegistry.App.Remove(app);
            }
        }

        /// <summary>
        /// 查询应用实体
        /// </summary>
        /// <param name="appId"></param>
        /// <returns></returns>
        public AppModel FindById(int appId)
        {
            var app= RepositoryRegistry.App.FindBy(appId);
            if (app == null)
                return null;
            return new AppModel() {
                UserId=app.UserId,
                Name=app.Name,
                CreateDate=app.CreateDate,
                Description=app.Description,
                IsRecord=app.IsRecord
            };
        }

        /// <summary>
        /// 查询应用列表
        /// </summary>
        /// <returns></returns>
        public Return FindAll()
        {
            var list = RepositoryRegistry.App.FindAll();
            var listModel = list.Select(m=>new AppModel() {
                Id=m.Id,
                UserId=m.UserId,
                CreateDate=m.CreateDate,
                Description=m.Description,
                IsRecord=m.IsRecord,
                Name=m.Name,
                Ip=m.Ip
            }).ToList();
            return new Return() { DataBody=listModel };
        }

    }
}
