using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rbac.Application
{
    public class MenuListDto
    {
        public int value { get; set; }
        public string label { get; set; }
        /// <summary>
        /// 实例化，否则为null
        /// </summary>
        public List<MenuListDto> children { get; set; } = new List<MenuListDto>();
    }
}
