using System;
namespace Model
{
	/// <summary>
	/// 实体类SysPrivileges 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class SysPrivileges
	{
		public SysPrivileges()
		{}
		#region Model
		private int _id;
		private int _roleid;
		private int _departmentid;
		private int _levelno;
		private int _parentlevelno;
		/// <summary>
		/// 自增ID
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 角色ID
		/// </summary>
		public int roleId
		{
			set{ _roleid=value;}
			get{return _roleid;}
		}
		/// <summary>
		/// 部门ID
		/// </summary>
		public int departmentId
		{
			set{ _departmentid=value;}
			get{return _departmentid;}
		}
		/// <summary>
        /// 权限节点编号
		/// </summary>
		public int levelNo
		{
			set{ _levelno=value;}
			get{return _levelno;}
		}
		/// <summary>
		/// 父权限节点编号
		/// </summary>
		public int parentLevelNo
		{
			set{ _parentlevelno=value;}
			get{return _parentlevelno;}
		}
		#endregion Model

	}
}

