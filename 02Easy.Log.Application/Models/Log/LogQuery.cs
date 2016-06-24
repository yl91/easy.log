using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Log.Application.Models.Log
{
    public class LogQuery
    {
        public int Id;
        public int AppId;

        public string AppName;

        public DateTime? StartDate;

        public DateTime? EndDate;

        public string Tag;

        public int LogLevel;

        public int PageIndex;

        public int PageSize;

        public int[] AppIds;

        public int UserId;
    }
}
