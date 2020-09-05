using System;
namespace Model
{
	/// <summary>
	/// ActiveInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ActiveInfo
	{
		public ActiveInfo()
		{}
		#region Model
		private int _id;
		private int _userid;
		private string _activename;
		private int _activetype;
		private int _pid;
		private int _cid;
		private string _address;
		private DateTime _timefrom;
		private DateTime _timeend;
		private string _activeinfo;
		private string _activedesc;
		private string _remark;
		private int _status;
		private DateTime _addtime;
		private int _infotype;
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
		public int userId
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string activeName
		{
			set{ _activename=value;}
			get{return _activename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int activeType
		{
			set{ _activetype=value;}
			get{return _activetype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int pid
		{
			set{ _pid=value;}
			get{return _pid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int cid
		{
			set{ _cid=value;}
			get{return _cid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string address
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime timeFrom
		{
			set{ _timefrom=value;}
			get{return _timefrom;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime timeEnd
		{
			set{ _timeend=value;}
			get{return _timeend;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string activeInfo
		{
			set{ _activeinfo=value;}
			get{return _activeinfo;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string activeDesc
		{
			set{ _activedesc=value;}
			get{return _activedesc;}
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
		public int infoType
		{
			set{ _infotype=value;}
			get{return _infotype;}
		}
		#endregion Model

	}
}

