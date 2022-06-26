using Rbac.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rbac.Repository
{
    public class UserRepository: BaseRepository<User, int>,IUserRepository
    {
        public UserRepository(MyDbContext myDb)
        {
            DbContext = myDb;
        }

    }
}
