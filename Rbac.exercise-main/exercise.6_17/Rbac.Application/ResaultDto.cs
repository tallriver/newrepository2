using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rbac.Application
{
    public class ResaultDto
    {
        /// <summary>
        /// 请求状态
        /// </summary>
        public bool Code { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string Msg { get; set; }
    }
}
