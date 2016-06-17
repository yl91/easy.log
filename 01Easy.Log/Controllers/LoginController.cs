using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Easy.Public.MvcSecurity;
using Castle.Core.Internal;
using Easy.Log.Application;

namespace Easy.Log.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginPost(string userName,string password)
        {
            if (userName.IsNullOrEmpty() || password.IsNullOrEmpty())
            {
                return Redirect("/login/index");
            }
            var tuple = ApplicationRegistry.User.Login(userName, password);
            if (tuple==null)
            {
                return Redirect("/login/index");
            }
            AuthenticateHelper.SetTicket(tuple.Item1.ToString(), null, 0, tuple.Item2);
            return Redirect("/Home/Index");
        }

        public ActionResult Logout()
        {
            AuthenticateHelper.DestroyTicket();
            return Redirect("/login/index");
        }
    }
}