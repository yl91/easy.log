using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Domain.RepositoryFramework;
using M = Easy.Log.Model.User;

namespace Easy.Log.Model.User
{
    public interface IUserRepository:IRepository<User,int>
    {
        IList<M.User> Select(UserQuery query, out int totalRows);

        M.User FindBy(string username);
    }
}
