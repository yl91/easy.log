using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using M=Easy.Log.Model.User;

namespace Easy.Log.Infrastructure.Repository.User
{
    public class UserSql
    {
        private static string BaseSelectSql()
        {
            return @"select id,username,realname,password,createdate from log_user";
        }

        public static string FindAll()
        {
            return string.Join("", BaseSelectSql()," order by id desc ");
        }

        public static Tuple<string, dynamic> Add(M.User user)
        {
            const string sql = @"INSERT INTO log_user
	                            (username, realname, password, createdate)
	                            VALUES (@UserName,@RealName, @Password, @CreateDate);select last_insert_id()";

            return new Tuple<string, dynamic>(sql,new
            {
                UserName=user.UserName,
                RealName=user.RealName,
                Password=user.Password,
                CreateDate=user.CreateDate
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
		                            password=@Password
	                            WHERE id=@Id";

            return new Tuple<string, dynamic>(sql,new
            {
                UserName=user.UserName,
                RealName=user.RealName,
                Password=user.Password,
                Id=user.Id
            });
        }

    }
}
