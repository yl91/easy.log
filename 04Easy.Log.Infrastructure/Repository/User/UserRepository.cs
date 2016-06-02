using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Domain.RepositoryFramework;
using M=Easy.Log.Model.User;

namespace Easy.Log.Infrastructure.Repository.User
{
    public class UserRepository : M.IUserRepository, IDao
    {
        private static readonly Easy.Public.EntityPropertyHelper<M.User> helper = new Public.EntityPropertyHelper<M.User>();
        public void Add(M.User item)
        {
            using (var conn=Database.Open())
            {
                
            }
        }

        public IList<M.User> FindAll()
        {
            throw new NotImplementedException();
        }

        public M.User FindBy(int key)
        {
            throw new NotImplementedException();
        }

        public void Remove(M.User item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAll()
        {
            throw new NotImplementedException();
        }

        public void Update(M.User item)
        {
            throw new NotImplementedException();
        }
    }
}
