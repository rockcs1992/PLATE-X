using System;
namespace Model
{
	/// <summary>
	/// MyViewsHistory:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class MyViewsHistory
	{
		public MyViewsHistory()
		{}
		#region Model
		private int _id;
		private int _comid;
		private string _comname;
		private string _comdesc;
		private string _compageurl;
		private int _status;
		private string _remark;
		private DateTime _addtime;
		private int _adduser;
		private int _infotype;
		private string _ip;
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
		public int comId
		{
			set{ _comid=value;}
			get{return _comid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string comName
		{
			set{ _comname=value;}
			get{return _comname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string comDesc
		{
			set{ _comdesc=value;}
			get{return _comdesc;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string comPageURL
		{
			set{ _compageurl=value;}
			get{return _compageurl;}
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
		public string remark
		{
			set{ _remark=value;}
			get{return _remark;}
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
		public int addUser
		{
			set{ _adduser=value;}
			get{return _adduser;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int infoType
		{
			set{ _infotype=value;}
			get{return _infotype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ip
		{
			set{ _ip=value;}
			get{return _ip;}
		}
		#endregion Model

	}
}

