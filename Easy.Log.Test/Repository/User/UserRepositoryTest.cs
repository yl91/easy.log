using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Log.Model;
using NUnit.Framework;
using M=Easy.Log.Model.User;

namespace Easy.Log.Test.Repository.User
{
    public class UserRepositoryTest
    {
        [Test]
        public void AddTest()
        {
            var user = Create();
            RepositoryRegistry.User.Add(user);
            Assert.IsTrue(user.Id>0);
            var actual = RepositoryRegistry.User.FindBy(user.Id);
            UserAssert(user,actual);
        }

        [Test]
        public void FindAllTest()
        {
            var user1 = Create();
            var user2 = Create();

            RepositoryRegistry.User.Add(user1);
            RepositoryRegistry.User.Add(user2);

            var actual= RepositoryRegistry.User.FindAll();

            Assert.IsTrue(actual.Count>0);
        }

        [Test]
        public void RemoveTest()
        {
            var user = Create();
            RepositoryRegistry.User.Add(user);

            RepositoryRegistry.User.Remove(user);

            var actual= RepositoryRegistry.User.FindBy(user.Id);

            Assert.IsNull(actual);
        }

        [Test]
        public void UpdateTest()
        {
            var user = Create();
            RepositoryRegistry.User.Add(user);

            var model= RepositoryRegistry.User.FindBy(user.Id);
            model.RealName = "李四";
            model.Password = "cba321";
            
            RepositoryRegistry.User.Update(model);
        }

        [TearDown]
        public void Clear()
        {
            Model.RepositoryRegistry.User.RemoveAll();
        }

        void UserAssert(M.User expected, M.User actual)
        {
            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.Password, actual.Password);
            Assert.AreEqual(expected.UserName, actual.UserName);
            Assert.AreEqual(expected.CreateDate.Hour, actual.CreateDate.Hour);
            Assert.AreEqual(expected.RealName, actual.RealName);
        }

        public static M.User Create()
        {
            var model= new M.User("sky");
            model.RealName = "张三";
            model.Password = "abc123";
            return model;
        }
    }
}
