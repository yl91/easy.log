using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Log.Application.Models.Log
{
    public class LogParameter
    {
        public string tag;

        public string message;

        public LogLevel logLevel;

        public int appId;

        public string appName;

        public string ip;
    }
}
