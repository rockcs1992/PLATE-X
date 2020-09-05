using System;
namespace Model
{
	/// <summary>
	/// Order:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class OrderInfo
	{
		public OrderInfo()
		{}
		#region Model
		private int _id;
		private string _orderno;
		private string _ordername;
		private double _prototal;
		private double _sendtotal;
		private double _ordertotal;
		private string _orderdesc;
		private string _remark;
		private string _recieveuser;
		private int _pid;
		private string _pname;
		private int _cid;
		private string _cname;
		private int _regionid;
		private string _reginname;
		private string _address;
		private string _mobile;
		private string _tel;
		private int _status;
		private DateTime _addtime;
		private int _infotype;
        private int _addUser;
        /// <summary>
        /// 
        /// </summary>
        public int addUser
        {
            set { _addUser = value; }
            get { return _addUser; }
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
		public string orderNo
		{
			set{ _orderno=value;}
			get{return _orderno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string orderName
		{
			set{ _ordername=value;}
			get{return _ordername;}
		}
		/// <summary>
		/// 
		/// </summary>
		public double proTotal
		{
			set{ _prototal=value;}
			get{return _prototal;}
		}
		/// <summary>
		/// 
		/// </summary>
		public double sendTotal
		{
			set{ _sendtotal=value;}
			get{return _sendtotal;}
		}
		/// <summary>
		/// 
		/// </summary>
		public double orderTotal
		{
			set{ _ordertotal=value;}
			get{return _ordertotal;}
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
		public string remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string recieveUser
		{
			set{ _recieveuser=value;}
			get{return _recieveuser;}
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
		public string PName
		{
			set{ _pname=value;}
			get{return _pname;}
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
		public string CName
		{
			set{ _cname=value;}
			get{return _cname;}
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
		public string ReginName
		{
			set{ _reginname=value;}
			get{return _reginname;}
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
		public string mobile
		{
			set{ _mobile=value;}
			get{return _mobile;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string tel
		{
			set{ _tel=value;}
			get{return _tel;}
		}
		/// <summary>
		/// 订单状态
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
		/// 付款状态
		/// </summary>
		public int infoType
		{
			set{ _infotype=value;}
			get{return _infotype;}
		}
		#endregion Model

	}
}

