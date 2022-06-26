using System;

namespace Rbac.Entity
{
    /// <summary>
    /// 角色表
    /// </summary>
    public class Role : PublicField
    {
        public int RoleId { get; set; }

        /// <summary>
        /// 角色名
        /// </summary>
        public string RoleName { get; set; }
    }
}
