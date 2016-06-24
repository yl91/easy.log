using Easy.Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using M = Easy.Log.Model.Relation;

namespace Easy.Log.Infrastructure.Repository.Relation
{
    public class UserRelationSql
    {
        private static string BaseSelectSql()
        {
            return @"SELECT id, userid, inviteuserid, appid, isaccept, createdate,email FROM log_relation";
        }


     
        public static string FindAll()
        {
            return string.Join("", BaseSelectSql(), " order by id desc ");
        }

        public static Tuple<string,dynamic> FindInviteAll(int inviteUserId,int appId,int userId)
        {
            var builder = new SQLBuilder();
            builder.AppendWhere();
            builder.Append(inviteUserId > 0, "and", "inviteuserid=@InviteUserId");
            builder.Append(appId>0,"and", "appid=@AppId");
            builder.Append(userId > 0, "and", "userid=@UserId");

            string sql = string.Join(" ", BaseSelectSql(), builder.Sql(), "order by id desc");

            return new Tuple<string, dynamic>(sql,new {
                InviteUserId=inviteUserId,
                AppId=appId,
                UserId=userId
            });
        }

        public static Tuple<string, dynamic> Add(M.UserRelation userRelation)
        {
            const string sql = @"INSERT INTO log_relation
	                            (userid, inviteuserid, appid, isaccept, createdate,email)
	                            VALUES (@UserId, @Inviteuserid , @AppId, @IsAccept, @CreateDate,@Email);select last_insert_id()";

            return new Tuple<string, dynamic>(sql, new
            {
                UserId = userRelation.UserId,
                Inviteuserid = userRelation.InviteUserId,
                AppId = userRelation.AppId,
                IsAccept = userRelation.IsAccept,
                CreateDate=userRelation.CreateDate,
                Email=userRelation.Email
            });
        }

        public static string FindPendingInvite(int inviteUserId)
        {
            SQLBuilder builder = new SQLBuilder();
            builder.AppendWhere();
            builder.Append(inviteUserId > 0, "and", "inviteuserid=" + inviteUserId);
            return string.Join(" ",BaseSelectSql(),builder.Sql());
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
		                            createdate=@CreateDate,
                                    email=@Email
	                            WHERE id=@Id";

            return new Tuple<string, dynamic>(sql, new
            {
                Id=userRelation.Id,
                UserId=userRelation.UserId,
                InviteUserId=userRelation.InviteUserId,
                AppId=userRelation.AppId,
                IsAccept=userRelation.IsAccept,
                CreateDate=userRelation.CreateDate,
                Email=userRelation.Email
            });
        }

    }
}
