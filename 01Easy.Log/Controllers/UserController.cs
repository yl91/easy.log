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
            var userId = UserSession.UserInfoDetail.Item1;

            int[] userIds = new int[] { };
            if (userId>0)
            {
                userIds = ApplicationRegistry.Relation.GetGroupUserIds(userId);
            }
            PageList<UserModel> pageList= ApplicationRegistry.User.Select(new UserQuery() {
                PageIndex = pageIndex,
                PageSize = pageSize,
                Name = name,
                CreateDate = createDate,
                UuserIds=userIds
            });
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
            var user= ApplicationRegistry.User.Create(userName, password, realName, email);
            if (user!=null)
            {
                ViewBag.Ok = "ok";
            }
            else
            {
                ViewBag.Ok = "no";
            }
            return View();
        }
   
    }
}