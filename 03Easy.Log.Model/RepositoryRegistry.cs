using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Easy.Domain.RepositoryFramework;
using Easy.Log.Model.App;
using Easy.Log.Model.Log;
using Easy.Log.Model.Relation;
using Easy.Log.Model.User;

namespace Easy.Log.Model
{
    
    public static class RepositoryRegistry
    {
        readonly static RepositoryFactory factory;
        static RepositoryRegistry()
        {
            RepositoryFactoryBuilder b = new RepositoryFactoryBuilder();
            string path = Path.Combine(AppDomain.CurrentDomain.RelativeSearchPath ?? AppDomain.CurrentDomain.BaseDirectory, "Easy.Log.Infrastructure.dll");
            //string path= Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Easy.Log.Infrastructure.dll");
            Stream stream = Assembly.ReflectionOnlyLoadFrom(path).GetManifestResourceStream("Easy.Log.Infrastructure.Repository.repository.xml");
            factory = b.Build(stream);
        }

        public static IUserRepository User
        {
            get
            {
                return factory.Get<IUserRepository>();
            }
        }

        public static IUserRelationRepository UserRelation
        {
            get
            {
                return factory.Get<IUserRelationRepository>();
            }
        }

        public static IAppRepository App
        {
            get
            {
                return factory.Get<IAppRepository>();
            }
        }

        public static ILogRepository Log
        {
            get
            {
                return factory.Get<ILogRepository>();
            }
        }

    }
}
