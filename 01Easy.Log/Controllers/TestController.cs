using Easy.Log.Application;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Easy.Log.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            var list= ApplicationRegistry.User.FindAll();

            ViewBag.list =JsonConvert.SerializeObject(list.DataBody);

            return View();
        }
    }
}