using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Log.Model.Log
{
    public class LogQuery
    {
        public int AppId;

        public string AppName;

        public DateTime? StartDate;

        public DateTime? EndDate;

        public string Tag;

        public int LogLevel; 

        public int PageIndex;

        public int PageSize;

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
