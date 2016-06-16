using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using M=Easy.Log.Model.Relation;

namespace Easy.Log.Infrastructure.Repository.Relation
{
    public class UserRelationSql
    {
        private static string BaseSelectSql()
        {
            return @"SELECT id, userid, inviteuserid, appid, isaccept, createdate FROM log_relation";
        }


     
        public static string FindAll()
        {
            return string.Join("", BaseSelectSql(), " order by id desc ");
        }

        public static Tuple<string, dynamic> Add(M.UserRelation userRelation)
        {
            const string sql = @"INSERT INTO log_relation
	                            (userid, inviteuserid, appid, isaccept, createdate)
	                            VALUES (@UserId, @Inviteuserid , @AppId, @IsAccept, @CreateDate);select last_insert_id()";

            return new Tuple<string, dynamic>(sql, new
            {
                UserId = userRelation.UserId,
                Inviteuserid = userRelation.InviteUserId,
                AppId = userRelation.AppId,
                IsAccept = userRelation.IsAccept,
                CreateDate=userRelation.CreateDate
            });
        }

        public static Tuple<string, dynamic> FindBy(int id)
        {
            string sql = string.Join(" ", BaseSelectSql(), "where", "Id=@Id");
            return new Tuple<string, dynamic>(sql, new { Id = id });
        }

        public static Tuple<string, dynamic> FindBy(int userId,int appId)
        {
            string sql = string.Join(" ", BaseSelectSql(), "where", "userid=@UserId and appid=@AppId");
            return new Tuple<string, dynamic>(sql, new { UserId = userId, AppId=appId });
        }

        public static string Remove(int id)
        {
            return string.Concat(RemoveAll(), " where id=" + id);
        }

        public static string RemoveAll()
        {
            return "delete from log_relation";
        }

        public static Tuple<string, dynamic> Update(M.UserRelation userRelation)
        {
            const string sql = @"UPDATE log_relation
	                            SET
		                            userid=@UserId,
		                            inviteuserid=@InviteUserId,
		                            appid=@AppId,
		                            isaccept=@IsAccept,
		                            createdate=@CreateDate
	                            WHERE id=@Id";

            return new Tuple<string, dynamic>(sql, new
            {
                Id=userRelation.Id,
                UserId=userRelation.UserId,
                InviteUserId=userRelation.InviteUserId,
                AppId=userRelation.AppId,
                IsAccept=userRelation.IsAccept,
                CreateDate=userRelation.CreateDate
            });
        }

    }
}
