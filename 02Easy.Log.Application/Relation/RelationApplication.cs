using Easy.Domain.Application;
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

    }
}
