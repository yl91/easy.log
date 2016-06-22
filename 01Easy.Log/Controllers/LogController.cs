using Easy.Log.Application;
using Easy.Log.Application.Models;
using Easy.Log.Application.Models.Log;
using Easy.Log.Application.Models.User;
using Easy.Log.Utility;
using System;
using System.Collections.Generic;
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
            PageList<LogModel> pageList = ApplicationRegistry.Log.Select(new LogQuery() {
                PageIndex=pageIndex,
                PageSize=pageSize
            });
            var userId = UserSession.UserInfoDetail.Item1;
            if (userId == 0) //管理员
            {
                return pageList;
            }

            pageList.Collections = pageList.Collections.Where(p => p.Id == userId).ToList();
            pageList.TotalRows = pageList.Collections.Count();

            
            return pageList;
        }
    }
}