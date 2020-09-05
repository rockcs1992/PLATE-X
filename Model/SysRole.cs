using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    [Serializable]
    public class SysRole
    {
        #region###系统角色

        private int isPayOrder;
        /// <summary>
        /// 是否有后台更新订单状态，后台付款权限
        /// </summary>
        public int IsPayOrder
        {
            get { return isPayOrder; }
            set { isPayOrder = value; }
        }

        private int id;
        /// <summary>
        /// 主键
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string roleName;
        /// <summary>
        /// 角色Item Name
        /// </summary>
        public string RoleName
        {
            get { return roleName; }
            set { roleName = value; }
        }
        private string roleDesc;
        /// <summary>
        /// 角色描述 
        /// </summary>
        public string RoleDesc
        {
            get { return roleDesc; }
            set { roleDesc = value; }
        }
        private DateTime creatingTime;
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatingTime
        {
            get { return creatingTime; }
            set { creatingTime = value; }
        }
        private int department;
        /// <summary>
        /// 部门
        /// </summary>
        public int DepartmentId
        {
            get { return department; }
            set { department = value; }
        }
        private int status;
        /// <summary>
        /// 状态
        /// </summary>
        public int Status
        {
            get { return status; }
            set { status = value; }
        }
        public string levelId;
        /// <summary>
        /// 权限ID集合
        /// </summary>
        public string LevelId
        {
            get { return levelId; }
            set { levelId = value; }
        }
        #endregion
        
    }    
}
