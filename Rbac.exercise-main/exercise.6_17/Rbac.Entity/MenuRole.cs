using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rbac.Entity
{
    /// <summary>
    /// 菜单和角色的中间表
    /// </summary>
    public class MenuRole
    {
        public int Id { get; set; }
        public int MenuId { get; set; }
        public int RoleId { get; set; }
    }
}
