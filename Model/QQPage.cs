using System;
namespace Model
{
	/// <summary>
	/// QQPage:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class QQPage
	{
		public QQPage()
		{}
		#region Model
		private int _id;
		private string _qqinfo;
		private string _inforemark;
		private DateTime _addtime;
		private int _adduser;
		private int _status;
		private string _remark;
		private int _infotype;
		/// <summary>
		/// 主键ID
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// qq信息
		/// </summary>
		public string qqInfo
		{
			set{ _qqinfo=value;}
			get{return _qqinfo;}
		}
		/// <summary>
		/// 信息备注
		/// </summary>
		public string infoRemark
		{
			set{ _inforemark=value;}
			get{return _inforemark;}
		}
		/// <summary>
		/// 添加时间
		/// </summary>
		public DateTime addTime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		/// <summary>
		/// 添加人
		/// </summary>
		public int addUser
		{
			set{ _adduser=value;}
			get{return _adduser;}
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
		/// <summary>
		/// 信息I am a
		/// </summary>
		public int infoType
		{
			set{ _infotype=value;}
			get{return _infotype;}
		}
		#endregion Model

	}
}

