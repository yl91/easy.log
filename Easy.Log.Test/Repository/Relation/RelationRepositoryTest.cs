using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Log.Model;
using NUnit.Framework;
using M= Easy.Log.Model.Relation;

namespace Easy.Log.Test.Repository.Relation
{
    public class RelationRepositoryTest
    {
        [Test]
        public void AddTest()
        {
            var relation = Create(); 
            RepositoryRegistry.UserRelation.Add(relation);
            Assert.IsTrue(relation.Id > 0);
            var actual = RepositoryRegistry.UserRelation.FindBy(relation.Id);
            UserAssert(relation, actual);
        }

        [Test]
        public void FindAllTest()
        {
            var relation1 = Create();
            var relation2 = Create();

            RepositoryRegistry.UserRelation.Add(relation1);
            RepositoryRegistry.UserRelation.Add(relation2);

            var actual = RepositoryRegistry.UserRelation.FindAll();

            Assert.IsTrue(actual.Count > 0);
        }

        [Test]
        public void RemoveTest()
        {
            var relation = Create();
            RepositoryRegistry.UserRelation.Add(relation);

            RepositoryRegistry.UserRelation.Remove(relation);

            var actual = RepositoryRegistry.UserRelation.FindBy(relation.Id);

            Assert.IsNull(actual);
        }

        [Test]
        public void UpdateTest()
        {
            var relation = Create();
            RepositoryRegistry.UserRelation.Add(relation);

            var model = RepositoryRegistry.UserRelation.FindBy(relation.Id);

            model.IsAccept = false;

            RepositoryRegistry.UserRelation.Update(model);
        }

        [TearDown]
        public void Clear()
        {
            Model.RepositoryRegistry.UserRelation.RemoveAll();
        }

        void UserAssert(M.UserRelation expected, M.UserRelation actual)
        {
            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.CreateDate.Hour, actual.CreateDate.Hour);
            Assert.AreEqual(expected.AppId, actual.AppId);
            Assert.AreEqual(expected.InviteUserId, actual.InviteUserId);
            Assert.AreEqual(expected.UserId, actual.UserId);
            Assert.AreEqual(expected.IsAccept, actual.IsAccept);
        }

        public static M.UserRelation Create()
        {
           return new M.UserRelation(1,1,1);
        }
    }
}
