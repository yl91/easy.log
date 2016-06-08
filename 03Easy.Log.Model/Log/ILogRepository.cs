using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Domain.RepositoryFramework;

namespace Easy.Log.Model.Log
{
    public interface ILogRepository:IRepository<Log,int>
    {
    }
}
