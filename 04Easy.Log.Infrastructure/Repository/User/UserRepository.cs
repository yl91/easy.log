using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Easy.Domain.RepositoryFramework;
using M=Easy.Log.Model.User;

namespace Easy.Log.Infrastructure.Repository.User
{
    public class UserRepository : M.IUserRepository, IDao
    {
        private static readonly Easy.Public.EntityPropertyHelper<M.User> helper = new Public.EntityPropertyHelper<M.User>();
        public void Add(M.User item)
        {
            using (var conn=Database.Open())
            {
                var tuple= UserSql.Add(item);
                int id = conn.ExecuteScalar<int>(tuple.Item1, (object)tuple.Item2);
                helper.SetValue(m => m.Id, item, id);
            }
        }

        public IList<M.User> FindAll()
        {
            using (var conn=Database.Open())
            {
                var sql = UserSql.FindAll();
                return conn.Query<M.User>(sql).ToArray();
            }
        }

        public M.User FindBy(int key)
        {
            using (var conn=Database.Open())
            {
                var tuple = UserSql.FindBy(key);
                return conn.Query<M.User>(tuple.Item1, (object)tuple.Item2).FirstOrDefault();
            }
        }

        public void Remove(M.User item)
        {
            using (var conn=Database.Open())
            {
                conn.Execute(UserSql.Remove(item.Id));
            }
        }

        public void RemoveAll()
        {
            using (var conn=Database.Open())
            {
                conn.Execute(UserSql.RemoveAll());
            }
        }

        public void Update(M.User item)
        {
            using (var conn=Database.Open())
            {
                var tuple = UserSql.Update(item);
                conn.ExecuteScalar(tuple.Item1, (object) tuple.Item2);
            }
        }
    }
}
