using System;
namespace Model
{
	/// <summary>
	/// 实体类OALevel 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class OALevel
	{
		public OALevel()
		{}
		#region Model
		private int _id;
		private string _levelname;
		private int _levelno;
		private int _isparent;
		private int _parentlevelno;
		private string _url;
		private int _status;
		private string _remark;
		/// <summary>
		/// 自增ID
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 权限Item Name
		/// </summary>
		public string levelName
		{
			set{ _levelname=value;}
			get{return _levelname;}
		}
		/// <summary>
		/// 权限编号
		/// </summary>
		public int levelNO
		{
			set{ _levelno=value;}
			get{return _levelno;}
		}
		/// <summary>
		/// 是否父节点
		/// </summary>
		public int isParent
		{
			set{ _isparent=value;}
			get{return _isparent;}
		}
		/// <summary>
		/// 父节点权限编号
		/// </summary>
		public int parentLevelNo
		{
			set{ _parentlevelno=value;}
			get{return _parentlevelno;}
		}
		/// <summary>
		/// 链接路径
		/// </summary>
		public string url
		{
			set{ _url=value;}
			get{return _url;}
		}
		/// <summary>
		/// 状态
		/// </summary>
		public int status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		#endregion Model

	}
}

