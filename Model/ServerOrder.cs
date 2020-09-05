using System;
namespace Model
{
	/// <summary>
	/// ServerOrder:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ServerOrder
	{
		public ServerOrder()
		{}
		#region Model
		private int _id;
		private int _servertype;
		private int _pid;
		private int _cid;
		private int _regionid;
		private string _address;
		private DateTime _servertime;
		private int _agearea;
		private int _workexperience;
		private int _salaryarea;
		private int _persongood;
		private int _languageid;
		private string _proxyid;
		private int _sisterid;
		private string _title;
		private string _orderdesc;
		private int _status;
		private string _remark;
		private string _otherinfo;
		private string _otherremark;
		private DateTime _addtime;
		private int _adduser;
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
		public int serverType
		{
			set{ _servertype=value;}
			get{return _servertype;}
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
		public int regionId
		{
			set{ _regionid=value;}
			get{return _regionid;}
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
		public DateTime serverTime
		{
			set{ _servertime=value;}
			get{return _servertime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int ageArea
		{
			set{ _agearea=value;}
			get{return _agearea;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int workExperience
		{
			set{ _workexperience=value;}
			get{return _workexperience;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int salaryArea
		{
			set{ _salaryarea=value;}
			get{return _salaryarea;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int personGood
		{
			set{ _persongood=value;}
			get{return _persongood;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int languageId
		{
			set{ _languageid=value;}
			get{return _languageid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string proxyId
		{
			set{ _proxyid=value;}
			get{return _proxyid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int sisterId
		{
			set{ _sisterid=value;}
			get{return _sisterid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string orderDesc
		{
			set{ _orderdesc=value;}
			get{return _orderdesc;}
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
		public string otherInfo
		{
			set{ _otherinfo=value;}
			get{return _otherinfo;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string otherRemark
		{
			set{ _otherremark=value;}
			get{return _otherremark;}
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
		#endregion Model

	}
}

