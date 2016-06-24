using Easy.Public;
using Easy.Public.MyLog;
using Newtonsoft.Json;
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


        public static Tuple<string, string, dynamic> Select(M.LogQuery query)
        {
            string whereSql = QuerySql(query);
            string countSql = string.Format("select count(id) as Count from log {0}; ", whereSql);
            string orderbySql = " order by createdate desc ";

            string selectsql = string.Join(" ", BaseSelectSql(), whereSql, orderbySql, "limit @limit offset @offset;");
            LogManager.Info("Select", JsonConvert.SerializeObject(query));

            return new Tuple<string, string, dynamic>(countSql, selectsql, new
            {
                limit = query.Limit,
                offset = query.Offset,
                AppId=query.AppId,
                StartDate=query.StartDate,
                EndDate=query.EndDate,
                LogLevel=query.LogLevel
            });
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

        private static String QuerySql(M.LogQuery query)
        {
            var build = new SQLBuilder();
            build.AppendWhere();
            build.Append(query.AppId > 0, "and", "appid=@AppId");
            build.Append(!string.IsNullOrEmpty(query.AppName), "and", $"appname like '%{query.AppName}%'");
            build.Append(query.StartDate != null, "and", "createdate>=@StartDate");
            build.Append(query.EndDate != null, "and", "createdate<=@EndDate");
            build.Append(!string.IsNullOrEmpty(query.Tag), "and", $"tag like '%{query.Tag}%' ");
            build.Append(query.LogLevel > 0, "and", "loglevel=@LogLevel");
            build.Append(query.AppIds != null && query.AppIds.Length > 0, "and", $"appid in ({string.Join(",",query.AppIds)})");
            return build.Sql();
        }
    }
}
