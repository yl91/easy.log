using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Easy.Domain.RepositoryFramework;
using M=Easy.Log.Model.Log;

namespace Easy.Log.Infrastructure.Repository.Log
{
    public class LogRepository : M.ILogRepository, IDao
    {
        private static readonly Easy.Public.EntityPropertyHelper<M.Log> helper = new Public.EntityPropertyHelper<M.Log>();


        private M.Log SelectConvert(M.Log log, M.AppInfo info)
        {
            helper.SetValue(m => m.AppInfo, log, info);
            return log;
        }

        public void Add(M.Log item)
        {
            using (var conn=Database.Open())
            {
                var tuple= LogSql.Add(item);
                int id= conn.ExecuteScalar<int>(tuple.Item1, (object) tuple.Item2);
                helper.SetValue(m => m.Id, item, id);
            }
        }

        public IList<M.Log> FindAll()
        {
            using (var conn=Database.Open())
            {
                string sql= LogSql.FindAll();
                return conn.Query<M.Log>(sql).ToArray();
            }
        }

        public M.Log FindBy(int key)
        {
            using (var conn=Database.Open())
            {
                var tuple = LogSql.FindBy(key);
                return conn.Query<M.Log, M.AppInfo, M.Log>(tuple.Item1, SelectConvert, (object)tuple.Item2, splitOn: "split").FirstOrDefault();
            }
        }

        public void Remove(M.Log item)
        {
            using (var conn=Database.Open())
            {
                var sql= LogSql.Remove(item.Id);
                conn.Execute(sql);
            }
        }

        public void RemoveAll()
        {
            using (var conn=Database.Open())
            {
                var sql= LogSql.RemoveAll();
                conn.Execute(sql);
            }
        }

        public void Update(M.Log item)
        {
            using (var conn=Database.Open())
            {
                var tuple= LogSql.Update(item);
                conn.Execute(tuple.Item1, (object) tuple.Item2);
            }
        }
    }
}
