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

            return View(); 
        }

        public JsonResult Select(int pageIndex,int pageSize,string name="",DateTime? createDate=null)
        {
            PageList<UserModel> pageList= ApplicationRegistry.User.Select(new UserQuery() {
                PageIndex = pageIndex,
                PageSize = pageSize,
                Name = name,
                CreateDate = createDate
            });
            return Json(pageList);
        }
    }
}