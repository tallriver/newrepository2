using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rbac.Entity
{
    /// <summary>
    /// 公共字段表
    /// </summary>
    public class PublicField
    {
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        public int CreateId { get; set; }

        /// <summary>
        /// 删除状态
        /// </summary>
        public bool DelState { get; set; }
    }
}
