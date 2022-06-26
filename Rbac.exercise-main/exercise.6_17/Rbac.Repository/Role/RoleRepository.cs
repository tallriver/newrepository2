using Rbac.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rbac.Repository
{
    public class RoleRepository : BaseRepository<Role, int>, IRoleRepository
    {
        public RoleRepository(MyDbContext db)
        {
            this.DbContext = db;
        }
    }
}
