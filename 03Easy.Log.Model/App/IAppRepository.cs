using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Domain.RepositoryFramework;
using M = Easy.Log.Model.App;

namespace Easy.Log.Model.App
{
    public interface IAppRepository: IRepository<App, int>
    {
        IList<M.App> GetGroupApp(int userId,Dictionary<int,int> invitedDic); 
    }
}
