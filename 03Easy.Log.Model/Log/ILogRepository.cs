using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Domain.RepositoryFramework;
using M = Easy.Log.Model.Log;

namespace Easy.Log.Model.Log
{
    public interface ILogRepository:IRepository<Log,int>
    {
        IList<M.Log> Select(M.LogQuery query, out int totalRows);
    }
}
