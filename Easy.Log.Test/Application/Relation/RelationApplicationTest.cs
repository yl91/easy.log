using Easy.Log.Application;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using M = Easy.Log.Model.Relation;

namespace Easy.Log.Test.Application.Relation
{
    public class RelationApplicationTest
    {
        [Test]
        public void CreateTest()
        {
            var user = Create();
            ApplicationRegistry.Relation.Create(user.UserId, user.InviteUserId, user.AppId);
        }

        [Test]
        public void RemoveTest()
        {
            ApplicationRegistry.Relation.Remove(1, 1);
        }

        public M.UserRelation Create()
        {
            return new M.UserRelation(1, 1, 1) { IsAccept=false };
        }
    }
}
