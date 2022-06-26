using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rbac.Application
{
    public class MenuDto
    {
        public int MenuId { get; set; }
        public string MenuName { get; set; }
        public string LinkUrl { get; set; }
        /// <summary>
        /// 实例化，否则为null
        /// </summary>
        public List<MenuDto> Children { get; set; }=new List<MenuDto>();
    }
}
