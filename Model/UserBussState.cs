using System;
namespace Model
{
	/// <summary>
	/// UserBussState:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class UserBussState
	{
		public UserBussState()
		{}
		#region Model
		private int _id;
		private string _businessarea;
		private string _ishaveseperate;
        private string _serverpid;
		private int _servercid;
		private int _serverregionid;
		private string _serveraddress;
		private int _status;
		private string _remark;
		private DateTime _addtime;
		private int _adduser;
		private int _infotype;

        private string _serverPName;
        private string _serverCName;
        private string _serverRName;

        /// <summary>
        /// 
        /// </summary>
        public string serverPName
        {
            set { _serverPName = value; }
            get { return _serverPName; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string serverCName
        {
            set { _serverCName = value; }
            get { return _serverCName; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string serverRName
        {
            set { _serverRName = value; }
            get { return _serverRName; }
        }




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
		public string businessArea
		{
			set{ _businessarea=value;}
			get{return _businessarea;}
		}
		/// <summary>
		/// 
		/// </summary>
        public string isHaveSeperate
		{
			set{ _ishaveseperate=value;}
			get{return _ishaveseperate;}
		}
		/// <summary>
		/// 
		/// </summary>
        public string serverPid
		{
			set{ _serverpid=value;}
			get{return _serverpid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int serverCid
		{
			set{ _servercid=value;}
			get{return _servercid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int serverRegionId
		{
			set{ _serverregionid=value;}
			get{return _serverregionid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string serverAddress
		{
			set{ _serveraddress=value;}
			get{return _serveraddress;}
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

