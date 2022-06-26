using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rbac.Entity
{
    /// <summary>
    /// 用户和角色的中间表
    /// </summary>
    public class UserRole
    {
        public int Id { get; set; }
        public long UserId { get; set; }
        public int RoleId { get; set; }
    }
}
