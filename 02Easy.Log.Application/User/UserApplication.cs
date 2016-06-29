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
        public PageList<UserModel> Select(UserQuery query)
        {
            int totalRows = 0;
            IList<M.User> list= RepositoryRegistry.User.Select(new Model.User.UserQuery{
                PageIndex =query.PageIndex,
                PageSize =query.PageSize,
                Name =query.Name,
                CreateDate =query.CreateDate,
                UserIds=query.UuserIds
            },out totalRows);
            PageList<UserModel> pageList = new PageList<UserModel>();
            pageList.Collections = list.Select(m => new UserModel() {
                Id = m.Id,
                UserName = m.UserName,
                RealName = m.RealName,
                CreateDate = m.CreateDate,
                Password = m.Password,
                Email = m.Email,
                Secret=m.Secret
            }).ToList();
            pageList.TotalRows = totalRows;
            return pageList;
        }

        /// <summary>
        /// 用户登陆
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public Tuple<int, string> Login(string userName,string password)
        {
            UserDescriptor user= new UserAuthenticationService().Authenticate(userName, password);
            if (user == null)
            {
                return null;
            }
            return new Tuple<int, string>(user.Id, user.Name);
        }

        public UserModel Create(string username,string password,string realname,string email)
        {
            password= new PasswordService().Encrypt(password);
            M.User user = new M.User(username,email) { Password=password,RealName=realname};
            if (user.Validate())
            {
                RepositoryRegistry.User.Add(user);
                return new UserModel() { Id = user.Id, CreateDate = user.CreateDate, Email = user.Email, Password = user.Password, RealName = user.RealName, UserName = username };
            }
            return null;
        }

        public string Update(int userId,string password,string realname,string email)
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
                Password=user.Password,
                Email=user.Email,
                Secret=user.Secret
            };
        }

        public UserModel FindByName(string name)
        {
            M.User user = RepositoryRegistry.User.FindBy(name);
            if (user == null)
                return null;
            return new UserModel()
            {
                Id = user.Id,
                RealName = user.RealName,
                UserName = user.UserName,
                CreateDate = user.CreateDate,
                Password = user.Password,
                Email = user.Email,
                Secret=user.Secret
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
                Password=m.Password,
                Email=m.Email,
                Secret=m.Secret
            }).ToList();
            return new Return() { DataBody=listmodel };
        }

    }
}
