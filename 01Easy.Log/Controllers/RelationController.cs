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
        // GET: UserRelation
        public ActionResult Index()
        {
            return View();
        }


    }
}