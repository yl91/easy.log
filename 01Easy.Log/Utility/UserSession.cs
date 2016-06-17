using Easy.Public.MvcSecurity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Easy.Log.Utility
{
    public static class UserSession
    {
        public static string User
        {
            get
            {
                var user = HttpContext.Current.User as AuthenticateUser;
                if (user==null)
                {
                    return "";
                }
                return user.UserData;
            }
        }

        public static Tuple<int, string> UserInfoDetail
        {
            get
            {
                var user = HttpContext.Current.User as AuthenticateUser;

                int id = int.Parse(user.Identity.Name);
                string username = user.UserData;
                return new Tuple<int, string>(id, username);
            }
        }
    }
}