using Easy.Domain.Application;
using Easy.Log.Application.Models;
using Easy.Log.Application.Models.Relation;
using Easy.Log.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using M = Easy.Log.Model.Relation;

namespace Easy.Log.Application.Relation
{
    public class RelationApplication: BaseApplication
    {
        public string Create(int userId,int inviteUserId,int appId)
        {
            M.UserRelation relation = new Model.Relation.UserRelation(userId,inviteUserId,appId);
            if (relation.Validate())
            {
                RepositoryRegistry.UserRelation.Add(relation);
                return string.Empty;
            }
            return relation.GetBrokenRules()[0].Description;
        }

        public void Remove(int userId,int appId)
        {
            M.UserRelation relation= RepositoryRegistry.UserRelation.FindBy(userId, appId);
            RepositoryRegistry.UserRelation.Remove(relation);
        }

        public string Update()
        {
            return null;
        }

        public string AgreeInvite(int id)
        {
            M.UserRelation relation= RepositoryRegistry.UserRelation.FindBy(id);
            relation.IsAccept = true;
            if (relation.Validate())
            {
                RepositoryRegistry.UserRelation.Update(relation);
                return string.Empty;
            }
            return relation.GetBrokenRules()[0].Description;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Return FindInviteAll(int inviteUserId,int appId)
        {
            IList<M.UserRelation> list= RepositoryRegistry.UserRelation.FindInviteAll(inviteUserId,appId,0);
            return new Return() { DataBody=list };
        }

        public Return FindPendingInvite(int inviteUserId)
        {
            IList<M.UserRelation> list= RepositoryRegistry.UserRelation.FindPendingInvite(inviteUserId);

            return new Return() {
                DataBody = list.Select(m => new PendingUserRelationModel()
                {
                    Id = m.Id,
                    CreateDate = m.CreateDate,
                    AppName = RepositoryRegistry.App.FindBy(m.AppId) == null ? "" : RepositoryRegistry.App.FindBy(m.AppId).Name,
                    IsAccept = m.IsAccept,
                    InvietUserName = RepositoryRegistry.User.FindBy(m.UserId) == null?"" : RepositoryRegistry.User.FindBy(m.UserId).UserName
                }).ToList()
            };
        }

        /// <summary>
        /// 获取当前用户组集合 (自己及邀请的用户)
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public int[] GetGroupUserIds(int userId)
        {
            IList<M.UserRelation> list= RepositoryRegistry.UserRelation.FindInviteAll(0, 0, userId);
            List<int> ids = new List<int>() { userId};
            if (list==null||list.Count==0)
            {
                return ids.ToArray();
            }
            ids.AddRange(list.Select(m => m.InviteUserId));
            return  ids.ToArray();
        }
    }
}
