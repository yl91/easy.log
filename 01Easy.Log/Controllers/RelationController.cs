using Easy.Log.Application;
using Easy.Log.Application.Models;
using Easy.Log.Application.Models.Relation;
using Easy.Log.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Easy.Log.Controllers
{
    [WebAuthorize]
    public class RelationController : Controller
    {
        public ActionResult Manage()
        {
            var result= ApplicationRegistry.Relation.FindPendingInvite(UserSession.UserInfoDetail.Item1);

            ViewBag.list = (List<UserRelationModel>)result.DataBody;

            return View();
        }

        public ActionResult Invite()
        {
            var userId = UserSession.UserInfoDetail.Item1;
            Return @return = ApplicationRegistry.App.GetGroupApp(userId);

            ViewBag.list = @return.DataBody;
            return View();
        }

        public ActionResult SendPost(string email)
        {
            var userId = UserSession.UserInfoDetail.Item1;
            var content = $"http://localhost:37477/Login/Register?userid={userId}&code=";
            var result=SendMail.sendMail("smtp.etao.cn", "yang.li@etao.cn", "yangli123", "易淘_日志中心", "yang.li@etao.cn", email, "主题", "测试:"+ content);


            if (result)
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