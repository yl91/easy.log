﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Easy.Public.MvcSecurity;
using Castle.Core.Internal;
using Easy.Log.Application;
using Easy.Log.Application.User;

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

        public ActionResult Register(int userId=0,string appIds="")
        {
            ViewBag.userId = userId;
            ViewBag.appIds = appIds;
            return View();
        }

        [HttpPost]
        public ActionResult RegisterPost(string userName, string password, string realName, string email,int userId,string appIds)
        {
            var user= ApplicationRegistry.User.Create(userName, password, realName, email);
            if (user!=null)
            {
                if (userId>0&&!string.IsNullOrEmpty(appIds))
                {
                    string[] ids = appIds.Split(new char[] { ',' }, StringSplitOptions.None);
                    ids.AsParallel().ForAll((m) => {
                        ApplicationRegistry.Relation.Create(userId, user.Id, int.Parse(m));
                    });
                }
                AuthenticateHelper.SetTicket(user.Id.ToString(), null, 0, userName);
                return Redirect("/Home/Index");
            }
            return Json("no");
        }

    }
}