using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Easy.Domain.RepositoryFramework;
using M=Easy.Log.Model.App;

namespace Easy.Log.Infrastructure.Repository.App
{
    public class AppRepository : M.IAppRepository,IDao
    {
        private static readonly Easy.Public.EntityPropertyHelper<M.App> helper = new Public.EntityPropertyHelper<M.App>();

        public void Add(M.App item)
        {
            using (var conn=Database.Open())
            {
                var tuple = AppSql.Add(item);
                int id=conn.ExecuteScalar<int>(tuple.Item1, (object) tuple.Item2);
                helper.SetValue(m => m.Id, item, id);
            }
        }

        public IList<M.App> FindAll()
        {
            using (var conn=Database.Open())
            {
                var sql=AppSql.FindAll();
                return conn.Query<M.App>(sql).ToArray();
            }
        }

        public M.App FindBy(int key)
        {
            using (var conn=Database.Open())
            {
                var tuple= AppSql.FindBy(key);
                return conn.Query<M.App>(tuple.Item1, (object) tuple.Item2).FirstOrDefault();
            }
        }

        public IList<M.App> GetGroupApp(int userId, Dictionary<int, int> invitedDic)
        {
            using (var conn = Database.Open())
            {
                 var sql= AppSql.GetGroupApp(userId,invitedDic);
                return conn.Query<M.App>(sql).ToArray();
            }
        }

        public void Remove(Model.App.App item)
        {
            using (var conn=Database.Open())
            {
                string sql= AppSql.Remove(item.Id);
                conn.Execute(sql);
            }
        }

        public void RemoveAll()
        {
            using (var conn=Database.Open())
            {
                string sql= AppSql.RemoveAll();
                conn.Execute(sql);
            }
        }

        public void Update(Model.App.App item)
        {
            using (var conn=Database.Open())
            {
                var tuple= AppSql.Update(item);
                conn.Execute(tuple.Item1, (object)tuple.Item2);
            }
        }
    }
}

