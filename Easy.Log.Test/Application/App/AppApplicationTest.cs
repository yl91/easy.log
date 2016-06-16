using Easy.Log.Application;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using M = Easy.Log.Model.App;

namespace Easy.Log.Test.Application.App
{
    public class AppApplicationTest
    {
        [Test]
        public void CreateTest()
        {
            var app = Create();
            var msg= ApplicationRegistry.App.Create(app.Name, app.Description, app.UserId, app.Ip);

        }

        [Test]
        public void RemoveTest()
        {
            ApplicationRegistry.App.Remove(28);
        }

        [Test]
        public void FindByIdTest()
        {
            var app= ApplicationRegistry.App.FindById(29);
        }

        [Test]
        public void FindAllTest()
        {
            var list= ApplicationRegistry.App.FindAll();
        }

        public M.App Create()
        {
            return new M.App("订单", "订单服务", 1, "172.0.0.1");
        }
    }
}
