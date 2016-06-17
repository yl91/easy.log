using Easy.Log.Application;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using M = Easy.Log.Model.User;

namespace Easy.Log.Test.Application.User
{
    public class UserApplicationTest
    {
        [Test]
        public void CreateTest()
        {
            var user = Create();
            ApplicationRegistry.User.Create(user.UserName, user.Password, user.RealName);

            var actual= ApplicationRegistry.User.FindById(user.Id);
        }

        [Test]
        public void UpdateTest()
        {
            var user= ApplicationRegistry.User.FindById(66);
            if (user!=null)
            {
                user.RealName = "李四";
                user.Password = "111111";
                string msg = ApplicationRegistry.User.Update(user.Id, user.Password, user.RealName);
            }
        }

        [Test]
        public void LoginTest()
        {
            var tuple= ApplicationRegistry.User.Login("abc", "123");

        }

        [Test]
        public void FindAllTest()
        {
            var list= ApplicationRegistry.User.FindAll();
        }

        public M.User Create()
        {
            return new M.User("test") { RealName="张三", Password="123456" };
        }
    }
}
