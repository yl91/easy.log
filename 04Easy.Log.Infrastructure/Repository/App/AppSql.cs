using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using M=Easy.Log.Model.App;

namespace Easy.Log.Infrastructure.Repository.App
{
    public class AppSql
    {
        private static string BaseSelectSql()
        {
            return @"SELECT id,name, description, userid, isrecord, createdate,ip FROM log_app";
        }



        public static string FindAll()
        {
            return string.Join("", BaseSelectSql(), " order by id desc ");
        }

        public static Tuple<string, dynamic> Add(M.App app)
        {
            const string sql = @"INSERT INTO log_app
	                            (name, description, userid, isrecord, createdate,ip)
	                            VALUES (@Name, @Description, @UserId, @Isrecord, @CreateDate,@Ip);select last_insert_id()";

            return new Tuple<string, dynamic>(sql, new
            {
                Name=app.Name,
                Description=app.Description,
                UserId=app.UserId,
                Isrecord=app.IsRecord,
                CreateDate=app.CreateDate,
                Ip=app.Ip
            });
        }

        public static Tuple<string, dynamic> FindBy(int id)
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
            return "delete from log_app";
        }

        public static Tuple<string, dynamic> Update(M.App app)
        {
            const string sql = @"UPDATE log_app
	                            SET
		                            name=@Name,
		                            description=@Description,
		                            userid=@UserId,
		                            isrecord=@IsRecord,
		                            createdate=@CreateDate,
                                    ip=@Ip
	                            WHERE id=@Id";

            return new Tuple<string, dynamic>(sql, new
            {
                Id=app.Id,
                Name=app.Name,
                Description=app.Description,
                UserId=app.UserId,
                IsRecord=app.IsRecord,
                CreateDate=app.CreateDate,
                Ip=app.Ip
            });
        }
    }
}
