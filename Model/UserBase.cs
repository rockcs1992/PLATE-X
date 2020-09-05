using System;
namespace Model
{
	/// <summary>
	/// UserBase:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class UserBase
	{
		public UserBase()
		{}
		#region Model
		private int _id;
		private int _userid;
		private string _fullname;
		private string _regcode;
		private string _createdate;
		private string _liveaddress;
		private double _memalltotal;
		private string _organizecode;
		private string _artificialname;
		private string _artificialbodycode;
		private string _artificialmobile;
        private string _artificialtelephone;
		private int _status;
		private string _remark;
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

        public string artificialtelephone
        {
            set { _artificialtelephone = value; }
            get { return _artificialtelephone; }
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
		public string fullName
		{
			set{ _fullname=value;}
			get{return _fullname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string regCode
		{
			set{ _regcode=value;}
			get{return _regcode;}
		}
		/// <summary>
		/// 
		/// </summary>
        public string createDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string liveAddress
		{
			set{ _liveaddress=value;}
			get{return _liveaddress;}
		}
		/// <summary>
		/// 
		/// </summary>
		public double memAllTotal
		{
			set{ _memalltotal=value;}
			get{return _memalltotal;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string organizeCode
		{
			set{ _organizecode=value;}
			get{return _organizecode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string artificialName
		{
			set{ _artificialname=value;}
			get{return _artificialname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string artificialBodyCode
		{
			set{ _artificialbodycode=value;}
			get{return _artificialbodycode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string artificialMobile
		{
			set{ _artificialmobile=value;}
			get{return _artificialmobile;}
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
		#endregion Model

	}
}

