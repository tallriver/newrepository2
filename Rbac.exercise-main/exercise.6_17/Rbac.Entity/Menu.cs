using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rbac.Entity
{
    /// <summary>
    /// 菜单表
    /// </summary>
    public class Menu: PublicField
    {
        public int MenuId { get; set; }
        public string MenuName { get; set; }
        public string LinkUrl { get; set; }

        /// <summary>
        /// 父Id
        /// </summary>
        public int ParentId { get; set; }
    }
}
