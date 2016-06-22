using Easy.Log.Application;
using Easy.Log.Application.Models;
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
    public class UserController : Controller
    {
       
        public ActionResult Index()
        {
            var list = Select(1, 20);
            ViewBag.list = list;

            return View(); 
        }

        public PageList<UserModel> Select(int pageIndex,int pageSize,string name="",DateTime? createDate=null)
        {
            PageList<UserModel> pageList= ApplicationRegistry.User.Select(new UserQuery() {
                PageIndex = pageIndex,
                PageSize = pageSize,
                Name = name,
                CreateDate = createDate
            });

            var userId = UserSession.UserInfoDetail.Item1;
            if (userId==0) //管理员
            {
                return pageList;
            }

            pageList.Collections = pageList.Collections.Where(p => p.Id == userId).ToList();
            pageList.TotalRows = pageList.Collections.Count();
            return pageList;
        }


        public ActionResult Add()
        {
            ViewBag.Active = "Dir";
            return View();
        }


        [HttpPost]
        public ActionResult AddPost(string userName, string password, string realName, string email)
        {
            var r= ApplicationRegistry.User.Create(userName, password, realName, email);
            if (string.IsNullOrEmpty(r))
            {
                ViewBag.Ok = "ok";
            }
            else
            {
                ViewBag.Ok = r;
            }
            return View();
        }
   
    }
}