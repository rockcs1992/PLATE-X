using System;
namespace Model
{
	/// <summary>
	/// ʵ����SysPrivileges ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
		/// ����ID
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// ��ɫID
		/// </summary>
		public int roleId
		{
			set{ _roleid=value;}
			get{return _roleid;}
		}
		/// <summary>
		/// ����ID
		/// </summary>
		public int departmentId
		{
			set{ _departmentid=value;}
			get{return _departmentid;}
		}
		/// <summary>
        /// Ȩ�޽ڵ���
		/// </summary>
		public int levelNo
		{
			set{ _levelno=value;}
			get{return _levelno;}
		}
		/// <summary>
		/// ��Ȩ�޽ڵ���
		/// </summary>
		public int parentLevelNo
		{
			set{ _parentlevelno=value;}
			get{return _parentlevelno;}
		}
		#endregion Model

	}
}

