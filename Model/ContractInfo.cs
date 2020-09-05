using System;
namespace Model
{
	/// <summary>
	/// ContractInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ContractInfo
	{
		public ContractInfo()
		{}
		#region Model
		private int _id;
		private string _contractnumber;
		private int _userid;
		private int _contracttype;
		private int _typeid;
		private DateTime _timefrom;
		private DateTime _timeend;
		private double _storemoney;
		private int _status;
		private string _remark;
		private DateTime _addtime;
		private DateTime _othertime;
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
		public string contractNumber
		{
			set{ _contractnumber=value;}
			get{return _contractnumber;}
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
		public int contractType
		{
			set{ _contracttype=value;}
			get{return _contracttype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int typeId
		{
			set{ _typeid=value;}
			get{return _typeid;}
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
		public double storeMoney
		{
			set{ _storemoney=value;}
			get{return _storemoney;}
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
		public DateTime otherTime
		{
			set{ _othertime=value;}
			get{return _othertime;}
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

