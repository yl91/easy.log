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
    public class AppApplication : BaseApplication
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
            M.App app = RepositoryRegistry.App.FindBy(appId);
            if (app != null)
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
            var app = RepositoryRegistry.App.FindBy(appId);
            if (app == null)
                return null;
            return new AppModel()
            {
                UserId = app.UserId,
                Name = app.Name,
                CreateDate = app.CreateDate,
                Description = app.Description,
                IsRecord = app.IsRecord
            };
        }

        /// <summary>
        /// 查询应用列表
        /// </summary>
        /// <returns></returns>
        public Return FindAll()
        {
            var list = RepositoryRegistry.App.FindAll();
            var listModel = list.Select(m => new AppModel()
            {
                Id = m.Id,
                UserId = m.UserId,
                CreateDate = m.CreateDate,
                Description = m.Description,
                IsRecord = m.IsRecord,
                Name = m.Name,
                Ip = m.Ip
            }).ToList();
            return new Return() { DataBody = listModel };
        }

        public Return GetGroupApp(int inviteUserId)
        {
            if (inviteUserId==0)
            {
                return FindAll();
            }

            Dictionary<int, int> dic = new Dictionary<int, int>();
            var rList= RepositoryRegistry.UserRelation.FindInviteAll(inviteUserId, 0, 0);
            if (rList!=null)
            {
                var gList= rList.Select(p => new { appId = p.AppId, userId = p.UserId }).ToList();
                gList.AsParallel().ForAll((m)=> {
                    dic.Add(m.appId, m.userId);
                });
            }

            IList<M.App> list= RepositoryRegistry.App.GetGroupApp(inviteUserId, dic);
            return new Return() { DataBody=list.Select(m=>new AppModel() {
                Id = m.Id,
                UserId = m.UserId,
                CreateDate = m.CreateDate,
                Description = m.Description,
                IsRecord = m.IsRecord,
                Name = m.Name,
                Ip = m.Ip,
            }).ToList()}; 
        }

        //public Return FindInviteAll(int userId=0)
        //{
            //List<AppModel> list = new List<AppModel>();
            //var result = FindAll();
            //if (result.DataBody!=null)
            //{
            //    var fList = (List<AppModel>)result.DataBody;
            //    if (userId==0)
            //    {
            //        list.AddRange(fList);
            //        return new Return() { DataBody = list };
            //    }
            //    list.AddRange(fList.Where(p => p.UserId == userId));
            //}

            //var rList = RepositoryRegistry.UserRelation.FindInviteAll(userId, 0,0);
            //if (true)
            //{
            //    var fList = (List<AppModel>)result.DataBody;
            //    var userIds = rList.Select(m => new { m.UserId ,m.AppId});

            //    userIds.ToList().ForEach((item) =>
            //    {
            //        list.AddRange(fList.Where(p => p.UserId == item.UserId&&p.Id==item.AppId));
            //    });
            //}
            //return new Return() { DataBody=list };
        //}
    }
}
