using Easy.Domain.Application;
using Easy.Log.Application.App;
using Easy.Log.Application.Log;
using Easy.Log.Application.Relation;
using Easy.Log.Application.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Log.Application
{
    public class ApplicationRegistry
    {
        static ApplicationRegistry()
        {
            ApplicationFactory.Instance().Register(new UserApplication());
            ApplicationFactory.Instance().Register(new RelationApplication());
            ApplicationFactory.Instance().Register(new AppApplication());
            ApplicationFactory.Instance().Register(new LogApplication());
        }


        /// <summary>
        /// 用户
        /// </summary>
        public static UserApplication User
        {
            get
            {
                return ApplicationFactory.Instance().Get<UserApplication>();
            }
        }

        /// <summary>
        /// 用户间关系
        /// </summary>
        public static RelationApplication Relation
        {
            get
            {
                return ApplicationFactory.Instance().Get<RelationApplication>();
            }
        }

        /// <summary>
        /// 应用
        /// </summary>
        public static AppApplication App
        {
            get
            {
                return ApplicationFactory.Instance().Get<AppApplication>();
            }
        }

        /// <summary>
        /// 日志
        /// </summary>
        public static LogApplication Log
        {
            get
            {
                return ApplicationFactory.Instance().Get<LogApplication>();
            }
        }


    }
}
