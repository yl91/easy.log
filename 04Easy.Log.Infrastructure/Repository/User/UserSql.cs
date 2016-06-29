using Easy.Public;
using Easy.Public.MyLog;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using M = Easy.Log.Model.User;

namespace Easy.Log.Infrastructure.Repository.User
{
    public class UserSql
    {
        private static string BaseSelectSql()
        {
            return @"select id,username,realname,password,email,createdate,secret from log_user";
        }

        public static Tuple<string, string, dynamic> Select(M.UserQuery query)
        {
            string whereSql = QuerySql(query);
            string countSql = string.Format("select count(id) as Count from log_user {0}; ",whereSql);
            string orderbySql = " order by createdate desc ";

            string selectsql = string.Join(" ", BaseSelectSql(), whereSql, orderbySql, "limit @limit offset @offset;");
            LogManager.Info("Select", JsonConvert.SerializeObject(query));

            return new Tuple<string, string, dynamic>(countSql, selectsql, new
            {
                limit=query.Limit,
                offset=query.Offset,
                CreateDate = query.CreateDate
            });
        }


        public static string FindAll()
        {
            return string.Join("", BaseSelectSql()," order by id desc ");
        }

        public static Tuple<string, dynamic> Add(M.User user)
        {
            const string sql = @"INSERT INTO log_user
	                            (username, realname, password, createdate,email,secret)
	                            VALUES (@UserName,@RealName, @Password, @CreateDate,@Email,@Secret);select last_insert_id()";

            return new Tuple<string, dynamic>(sql, new
            {
                UserName = user.UserName,
                RealName = user.RealName,
                Password = user.Password,
                CreateDate = user.CreateDate,
                Email = user.Email,
                Secret=user.Secret
            });
        }

        public static Tuple<string,dynamic> FindBy(int id)
        {
            string sql = string.Join(" ", BaseSelectSql(), "where", "Id=@Id");
            return new Tuple<string, dynamic>(sql, new { Id = id });
        }

        public static string Remove(int id)
        {
            return string.Concat(RemoveAll(), " where id=" + id);
        }

        public static string RemoveAll()
        {
            return "delete from log_user";
        }

        public static Tuple<string, dynamic> Update(M.User user)
        {
            const string sql = @"UPDATE log_user
	                            SET
		                            username=@UserName,
		                            realname=@RealName,
		                            password=@Password,
                                    email=@Email
	                            WHERE id=@Id";

            return new Tuple<string, dynamic>(sql,new
            {
                UserName=user.UserName,
                RealName=user.RealName,
                Password=user.Password,
                Id=user.Id
            });
        }

        public static Tuple<string,dynamic> FindByName(string username)
        {
             string sql = string.Join(" ", BaseSelectSql(), "where", "username=@UserName");
            return new Tuple<string, dynamic>(sql, new { UserName=username });
        }

        private static String QuerySql(M.UserQuery query)
        {
            var build = new SQLBuilder();
            build.AppendWhere();
            build.Append(!string.IsNullOrEmpty(query.Name), "and", $"username like '%{query.Name}%'");
            build.Append(query.CreateDate != null, "and", "createdate>=@CreateDate");
            build.Append(query.UserIds!=null&&query.UserIds.Length>0,"and",$"id in({string.Join(",",query.UserIds)})");
            return build.Sql();
        }
    }
}
