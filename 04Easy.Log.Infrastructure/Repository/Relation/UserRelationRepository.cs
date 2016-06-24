using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Easy.Domain.RepositoryFramework;
using Easy.Log.Model.Relation;
using Easy.Log.Model.User;

namespace Easy.Log.Infrastructure.Repository.Relation
{
    public class UserRelationRepository : IUserRelationRepository, IDao
    {
        private static readonly Easy.Public.EntityPropertyHelper<UserRelation> helper = new Public.EntityPropertyHelper<UserRelation>();
        public void Add(UserRelation item)
        {
            using (var conn=Database.Open())
            {
                Tuple<string,dynamic> tuple = UserRelationSql.Add(item);
                int id= conn.ExecuteScalar<int>(tuple.Item1, (object) tuple.Item2);
                helper.SetValue(m => m.Id, item, id);
            }
        }

        public IList<UserRelation> FindAll()
        {
            using (var conn=Database.Open())
            {
                string sql= UserRelationSql.FindAll();
                return conn.Query<UserRelation>(sql).ToArray();
            }
        }

        public IList<UserRelation> FindInviteAll(int inviteUserId,int appId,int userId)
        {
            using (var conn=Database.Open())
            {
                var tuple = UserRelationSql.FindInviteAll(inviteUserId, appId,userId);
                return conn.Query<UserRelation>(tuple.Item1, (object)tuple.Item2).ToArray();
            }
        }

        public IList<UserRelation> FindPendingInvite(int inviteUserId)
        {
            using (var conn=Database.Open())
            {
                var sql = UserRelationSql.FindPendingInvite(inviteUserId);
                return conn.Query<UserRelation>(sql).ToArray();
            }
        }

        public UserRelation FindBy(int key)
        {
            using (var conn=Database.Open())
            {
                var tuple = UserRelationSql.FindBy(key);
                return conn.Query<UserRelation>(tuple.Item1, (object) tuple.Item2).FirstOrDefault();
            }
        }

        public UserRelation FindBy(int userId, int appId)
        {
            using (var conn=Database.Open())
            {
                var tuple = UserRelationSql.FindBy(userId, appId);
                return conn.Query<UserRelation>(tuple.Item1, (object)tuple.Item2).FirstOrDefault();
            }
        }

        public void Remove(UserRelation item)
        {
            using (var conn=Database.Open())
            {
                string sql = UserRelationSql.Remove(item.Id);
                conn.Execute(sql);
            }
        }

        public void RemoveAll()
        {
            using (var conn=Database.Open())
            {
                string sql = UserRelationSql.RemoveAll();
                conn.Execute(sql);
            }
        }

        public void Update(UserRelation item)
        {
            using (var conn=Database.Open())
            {
                var tuple = UserRelationSql.Update(item);
                conn.ExecuteScalar(tuple.Item1, (object)tuple.Item2);
            }
        }
    }
}
