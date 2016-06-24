using Easy.Log.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Log.Application.User
{
    public class UserAuthenticationService
    {
        public UserDescriptor Authenticate(string userName,string password)
        {
            var user= RepositoryRegistry.User.FindBy(userName);
            if (user==null&&userName=="admin"&&password=="100001")
            {
                return new UserDescriptor(0, "admin");
            }
            if (user==null)
            {
                return null;
            }
            if (user.Password!=new PasswordService().Encrypt(password))
            {
                return null;
            }
            return new UserDescriptor(user.Id, user.UserName);
        }
    }
}
