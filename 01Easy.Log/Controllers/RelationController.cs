using Easy.Log.Application;
using Easy.Log.Application.Models;
using Easy.Log.Application.Models.App;
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

            ViewBag.list = (List<PendingUserRelationModel>)result.DataBody;

            return View();
        }

        public ActionResult Invite()
        {
            var userId = UserSession.UserInfoDetail.Item1;
            Return @return = ApplicationRegistry.App.FindAll();
            if (@return.DataBody==null)
            {
                ViewBag.list = null;
            }
            else
            {
                List<AppModel> list = (List<AppModel>)@return.DataBody;
                ViewBag.list = list.Where(m => m.UserId == userId).ToList();
            }
            return View();
        }

        public ActionResult Bind()
        {
            var userId = UserSession.UserInfoDetail.Item1;
            Return @return = ApplicationRegistry.App.FindAll();
            if (@return.DataBody == null)
            {
                ViewBag.list = null;
            }
            else
            {
                List<AppModel> list = (List<AppModel>)@return.DataBody;
                ViewBag.list = list.Where(m => m.UserId == userId).ToList();
            }
            return View();
        }


        public ActionResult SendPost(string email,string ids)
        {
            var userId = UserSession.UserInfoDetail.Item1;
            
            var content = $"http://{Request.Url.Authority}/Login/Register?userId={userId}&appIds={ids}";
            var result=SendMail.sendMail("smtp.etao.cn", "yang.li@etao.cn", "yangli123", "易淘_日志中心", "yang.li@etao.cn", email, "主题", "信息来自："+Request.Url.Authority+",测试:"+ content);


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

        public ActionResult AgreePost(int id)
        {
            string msg= ApplicationRegistry.Relation.AgreeInvite(id);
            if (string.IsNullOrEmpty(msg))
            {

                ViewBag.Ok = "ok";
            }
            else
            {
                ViewBag.Ok = "no";
            }
            return View();
        }

        public ActionResult BindPost(string username, string ids)
        {
            var userId = UserSession.UserInfoDetail.Item1;
            var user= ApplicationRegistry.User.FindByName(username);
            if (user==null||string.IsNullOrEmpty(ids))
            {
                ViewBag.Ok = "no";
                return View();
            }
            string[] array = ids.Split(new char[] { ','}, StringSplitOptions.None);
            foreach (var item in array)
            {
                ApplicationRegistry.Relation.Create(userId, user.Id, int.Parse(item));
            }
            ViewBag.Ok = "ok";
            return View();
        }
    }
}