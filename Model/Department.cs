using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 本企业部门
    /// </summary>
    [Serializable]
   public class Department
    {
        private int id;
        /// <summary>
        /// 主键ID
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string name;
        /// <summary>
        /// 部门Item Name
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string remarks;
        /// <summary>
        /// 描述
        /// </summary>
        public string Remarks
        {
            get { return remarks; }
            set { remarks = value; }
        }
       
        private DateTime created;
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime Created
        {
            get { return created; }
            set { created = value; }
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
        
    }
}
