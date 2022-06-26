using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rbac.Entity
{
    /// <summary>
    /// 用户表
    /// </summary>
    public class User: PublicField
    {
        public long UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        /// <summary>
        /// 最后一次登录时间
        /// </summary>
        public DateTime? LastLoginDate { get; set; }

        /// <summary>
        /// 最后一次登录的IP
        /// </summary>
        public string LastLoginIP { get; set; }

        /// <summary>
        /// 是否锁定
        /// </summary>
        public byte IsLock { get; set; }

    }
}
