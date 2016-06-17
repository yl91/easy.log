using Easy.Public.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Log.Application.User
{
    public class PasswordService
    {
        public string Encrypt(string password)
        {
            return MD5Helper.Encrypt("@#*ooo" + password);
        }
    }
}
