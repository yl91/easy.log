using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Log.Application.Models.User
{
    public class UserQuery
    {
        public string Name;
        public DateTime? CreateDate;
        public int PageIndex;
        public int PageSize;
        public int[] UuserIds;
    }
}
