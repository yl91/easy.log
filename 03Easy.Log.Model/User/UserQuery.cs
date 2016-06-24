using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Log.Model.User
{
    public class UserQuery
    {
        public string Name;
        public DateTime? CreateDate;
        public int PageIndex;
        public int PageSize;
        public int[] UserIds;

        public Int32 Limit
        {
            get
            {
                return this.PageSize;
            }
        }

        public Int32 Offset
        {
            get
            {
                return (this.PageIndex - 1) * this.PageSize;
            }
        }
    }
}
