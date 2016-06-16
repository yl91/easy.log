using Easy.Log.Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using M = Easy.Log.Model.Log;

namespace Easy.Log.Test.Repository.Log
{
    public class LogRepositoryTest
    {
        [Test]
        public void AddTest()
        {
            var log = Create();
            RepositoryRegistry.Log.Add(log);
            Assert.IsTrue(log.Id > 0);
            var actual = RepositoryRegistry.Log.FindBy(log.Id);
            AppAssert(log, actual);
        }

        [Test]
        public void FindAllTest()
        {
            var log1 = Create();
            var log2 = Create();

            RepositoryRegistry.Log.Add(log1);
            RepositoryRegistry.Log.Add(log2);

            var actual = RepositoryRegistry.Log.FindAll();

            Assert.IsTrue(actual.Count > 0);
        }

        [Test]
        public void RemoveTest()
        {
            var log = Create();
            RepositoryRegistry.Log.Add(log);

            RepositoryRegistry.Log.Remove(log);

            var actual = RepositoryRegistry.Log.FindBy(log.Id);

            Assert.IsNull(actual);
        }

        [Test]
        public void UpdateTest()
        {
            var log = Create();
            RepositoryRegistry.Log.Add(log);

            var model = RepositoryRegistry.Log.FindBy(log.Id);

            RepositoryRegistry.Log.Update(model);

            var model2 = RepositoryRegistry.Log.FindBy(log.Id);

            AppAssert(model, model2);

        }

        [TearDown]
        public void Clear()
        {
            Model.RepositoryRegistry.Log.RemoveAll();
        }

        void AppAssert(M.Log expected, M.Log actual)
        {
            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.AppInfo.AppId, actual.AppInfo.AppId);
            Assert.AreEqual(expected.AppInfo.AppName, actual.AppInfo.AppName);
            Assert.AreEqual(expected.Message, actual.Message);
            Assert.AreEqual(expected.CreateDate.Date, actual.CreateDate.Date);
            Assert.AreEqual(expected.Tag, actual.Tag);
            Assert.AreEqual(expected.LogLevel, actual.LogLevel);
            Assert.AreEqual(expected.Ip, actual.Ip);
        }

        public static M.Log Create()
        {
            return new M.Log("face", "当面付", M.LogLevel.Info, new M.AppInfo() { AppId = 1, AppName = "订单" },"127.0.0.1");
        }
    }
}
