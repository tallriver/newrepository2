using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rbac.Application
{
    public class MenuAddDto
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
