using Easy.Domain.Application;
using Easy.Log.Application.Models;
using Easy.Log.Application.Models.User;
using Easy.Log.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using M = Easy.Log.Model.User;

namespace Easy.Log.Application.User
{
    public class UserApplication: BaseApplication
    {

        public string Create(string username,string password,string realname)
        {
            M.User user = new M.User(username) { Password=password,RealName=realname};
            if (user.Validate())
            {
                RepositoryRegistry.User.Add(user);
                return string.Empty;
            }
            return user.GetBrokenRules()[0].Description;
        }

        public string Update(int userId,string password,string realname)
        {
            M.User user= RepositoryRegistry.User.FindBy(userId);
            user.Password = password;
            user.RealName = realname;
            if (user.Validate())
            {
                RepositoryRegistry.User.Update(user);
                return string.Empty;
            }
            return user.GetBrokenRules()[0].Description;
        }

        public UserModel FindById(int userId)
        {
            M.User user= RepositoryRegistry.User.FindBy(userId);
            if (user==null)
                return null;
            return new UserModel()
            {
                Id = user.Id,
                RealName = user.RealName,
                UserName = user.UserName,
                CreateDate = user.CreateDate,
                Password=user.Password
            };
        }

        public Return FindAll()
        {
            var list = RepositoryRegistry.User.FindAll();
            var listmodel = list.Select(m=>new UserModel() {
                Id=m.Id,
                RealName=m.RealName,
                UserName=m.UserName,
                CreateDate=m.CreateDate,
                Password=m.Password
            }).ToList();
            return new Return() { DataBody=listmodel };
        }


    }
}
