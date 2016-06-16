using Easy.Log.Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using M = Easy.Log.Model.App;

namespace Easy.Log.Test.Repository.App
{
    public class AppRepositoryTest
    {

        [Test]
        public void AddTest()
        {
            var app = Create();
            RepositoryRegistry.App.Add(app);
            Assert.IsTrue(app.Id > 0);
            var actual = RepositoryRegistry.App.FindBy(app.Id);
            AppAssert(app, actual);
        }

        [Test]
        public void FindAllTest()
        {
            var app1 = Create();
            var app2 = Create();

            RepositoryRegistry.App.Add(app1);
            RepositoryRegistry.App.Add(app2);

            var actual = RepositoryRegistry.App.FindAll();

            Assert.IsTrue(actual.Count > 0);
        }

        [Test]
        public void RemoveTest()
        {
            var app = Create();
            RepositoryRegistry.App.Add(app);

            RepositoryRegistry.App.Remove(app);

            var actual = RepositoryRegistry.App.FindBy(app.Id);

            Assert.IsNull(actual);
        }

        [Test]
        public void UpdateTest()
        {
            var app = Create();
            RepositoryRegistry.App.Add(app);

            var model = RepositoryRegistry.App.FindBy(app.Id);
            model.IsRecord = false;

            RepositoryRegistry.App.Update(model);

            var model2 = RepositoryRegistry.App.FindBy(app.Id);

            AppAssert(model, model2);

        }

        [TearDown]
        public void Clear()
        {
            Model.RepositoryRegistry.App.RemoveAll();
        }

        void AppAssert(M.App expected, M.App actual)
        {
            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.CreateDate.Hour, actual.CreateDate.Hour);
            Assert.AreEqual(expected.Description, actual.Description);
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.UserId, actual.UserId);
            Assert.AreEqual(expected.IsRecord, actual.IsRecord);
        }

        public static M.App Create()
        {
            var model = new M.App("订单", "订单服务", 1, "127.0.0.1");
            return model;
        }
    }
}
