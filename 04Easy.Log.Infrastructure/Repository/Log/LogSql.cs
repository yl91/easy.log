using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using M = Easy.Log.Model.Log;

namespace Easy.Log.Infrastructure.Repository.Log
{
    public class LogSql
    {
        private static string BaseSelectSql()
        {
            return @"SELECT  id,message, createdate, tag, loglevel, ip ,1 AS split ,appid as appid, appname as appname FROM log";
        }

      



        public static string FindAll()
        {
            return string.Join("", BaseSelectSql(), " order by id desc ");
        }

        public static Tuple<string, dynamic> Add(M.Log log)
        {
            const string sql = @"INSERT INTO log
	                            (appid, appname, message, createdate, tag, loglevel, ip)
	                            VALUES (@AppId, @AppName, @Message,@CreateDate , @Tag, @LogLevel, @Ip);select last_insert_id()";

            return new Tuple<string, dynamic>(sql, new
            {
                AppId=log.AppInfo.AppId,
                AppName=log.AppInfo.AppName,
                Message=log.Message,
                CreateDate=log.CreateDate,
                Tag=log.Tag,
                LogLevel=log.LogLevel,
                Ip=log.Ip
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
            return "delete from log";
        }

        public static Tuple<string, dynamic> Update(M.Log log)
        {
            const string sql = @"UPDATE log
	                            SET
		                            appid=@AppId,
		                            appname=@AppName,
		                            message=@Message,
		                            createdate=@CreateDate,
		                            tag=@Tag,
		                            loglevel=@LogLevel,
		                            ip=@Ip
	                            WHERE id=@Id";

            return new Tuple<string, dynamic>(sql, new
            {
                AppId=log.AppInfo.AppId,
                AppName=log.AppInfo.AppName,
                Message=log.Message,
                CreateDate=log.CreateDate,
                Tag=log.Tag,
                LogLevel=log.LogLevel,
                Ip=log.Ip,
                Id=log.Id
            });
        }
    }
}
