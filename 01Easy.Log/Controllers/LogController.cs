using Easy.Log.Application;
using Easy.Log.Application.Models;
using Easy.Log.Application.Models.Log;
using Easy.Log.Application.Models.User;
using Easy.Log.Utility;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Easy.Log.Controllers
{
    [WebAuthorize]
    public class LogController : Controller
    {
        // GET: Log
        public ActionResult Index(int pageIndex=1)
        {
            int pageSize = 2;
            var list = Select(pageIndex, pageSize);
            var pageCount = 0;
            if (list!=null&&list.TotalRows>0)
            {
                if (list.TotalRows % pageSize==0)
                {
                    pageCount = list.TotalRows / pageSize;
                }
                else
                {
                    pageCount = (list.TotalRows / pageSize)+1;
                }
            }
            ViewBag.pageCount = pageCount;
            if (pageIndex<1)
                pageIndex++;
            if (pageIndex > pageCount)
                pageIndex--;
            ViewBag.index = pageIndex;
            ViewBag.list = list;
            ViewBag.Pdisabled = (pageIndex <= 1) ? "disabled":"";
            ViewBag.Ndisabled = (pageIndex >= pageCount) ? "disabled" : "";
            return View();
        }

        public PageList<LogModel> Select(int pageIndex, int pageSize)
        {
            var userId = UserSession.UserInfoDetail.Item1;
            PageList<LogModel> pageList = ApplicationRegistry.Log.Select(new LogQuery() {
                PageIndex=pageIndex,
                PageSize=pageSize,
                UserId=userId
            });
            return pageList;
        }

        public ActionResult Immediate(int appId)
        {
            var url= ConfigurationManager.AppSettings["SignalR_Url"].ToString();
            var app= ApplicationRegistry.App.FindById(appId);
            var user =ApplicationRegistry.User.FindById(app.UserId);
            var group = $"{user.Secret}_{app.Name}";

            ViewBag.url = url;
            ViewBag.group = group;
            return View();
        }

        /// <summary>
        /// 服务列表
        /// </summary>
        /// <returns></returns>
        public ActionResult Service()
        {
            var userId = UserSession.UserInfoDetail.Item1;
            var result = new Return();
            result=ApplicationRegistry.App.GetGroupApp(userId);
            ViewBag.list = result.DataBody;
            return View();
        }
    }
}