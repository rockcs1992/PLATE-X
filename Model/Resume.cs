using System;
namespace Model
{
	/// <summary>
	/// Resume:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Resume
	{
		public Resume()
		{}
		#region Model
		private int _id;
		private int _inviteid;
		private string _realname;
		private string _mobile;
		private string _qq;
		private string _invitename;
		private string _workyears;
		private string _selfinfo;
		private int _status;
		private DateTime _addtime;
		private string _remark;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int inviteId
		{
			set{ _inviteid=value;}
			get{return _inviteid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string realName
		{
			set{ _realname=value;}
			get{return _realname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string mobile
		{
			set{ _mobile=value;}
			get{return _mobile;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string QQ
		{
			set{ _qq=value;}
			get{return _qq;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string inviteName
		{
			set{ _invitename=value;}
			get{return _invitename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string workYears
		{
			set{ _workyears=value;}
			get{return _workyears;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string selfInfo
		{
			set{ _selfinfo=value;}
			get{return _selfinfo;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime addTime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		#endregion Model

	}
}

