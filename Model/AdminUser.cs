using System;
namespace Model
{
	/// <summary>
	/// 实体类AdminUser 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class AdminUser
	{
		public AdminUser()
		{}
		#region Model
		private int _id;
		private string _username;
		private string _password;
		private string _md5pass;
		private string _realname;
		private int _roleid;
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
		/// Username
		/// </summary>
		public string username
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// Password
		/// </summary>
		public string password
		{
			set{ _password=value;}
			get{return _password;}
		}
		/// <summary>
		/// 加密Password
		/// </summary>
		public string md5Pass
		{
			set{ _md5pass=value;}
			get{return _md5pass;}
		}
		/// <summary>
		/// 真实姓名
		/// </summary>
		public string realName
		{
			set{ _realname=value;}
			get{return _realname;}
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

