using Easy.Log.Application;
using Easy.Log.Application.Models;
using Easy.Log.Application.Models.App;
using Easy.Log.Utility;
using Easy.Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Easy.Log.Controllers
{
    [WebAuthorize]
    public class AppController : Controller
    {
        // GET: App
        public ActionResult Index()
        {
            var list = List();
            if (UserSession.UserInfoDetail.Item1>0)
            {
                list = List().Where(p => p.UserId == UserSession.UserInfoDetail.Item1).ToList();
            }
            ViewBag.list = list;
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }



        public List<AppModel> List()
        {
            Return @return=ApplicationRegistry.App.FindAll();
            return (List<AppModel>)@return.DataBody;
        }

        [HttpPost]
        public ActionResult AddPost(string name,string description)
        {
            string ip = IpHelper.IntranetIp4();
            var r=ApplicationRegistry.App.Create(name, description, UserSession.UserInfoDetail.Item1, ip);
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