﻿using Easy.Log.Utility;
using System.Web;
using System.Web.Mvc;

namespace _01Easy.Log
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new HandleErrorAttribute());
            filters.Add(new ErrorAttribute());
        }
    }
}
