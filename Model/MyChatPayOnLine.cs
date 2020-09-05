using System;
namespace Model
{
	/// <summary>
	/// MyChatPayOnLine:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class MyChatPayOnLine
	{
		public MyChatPayOnLine()
		{}
		#region Model
		private int _id;
		private int _typeid;
		private string _typename;
		private string _appid;
		private string _mch_id;
		private string _device_info;
		private string _nonce_str;
		private string _sign;
		private string _result_code;
		private string _err_code;
		private string _err_code_des;
		private string _openid;
		private string _is_subscribe;
		private string _trade_type;
		private string _bank_type;
		private string _total_fee;
		private string _settlement_total_fee;
		private string _fee_type;
		private string _cash_fee;
		private string _cash_fee_type;
		private string _coupon_fee;
		private string _coupon_count;
		private string _transaction_id;
		private string _out_trade_no;
		private string _attach;
		private string _time_end;
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
		public string typeName
		{
			set{ _typename=value;}
			get{return _typename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string appid
		{
			set{ _appid=value;}
			get{return _appid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string mch_id
		{
			set{ _mch_id=value;}
			get{return _mch_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string device_info
		{
			set{ _device_info=value;}
			get{return _device_info;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string nonce_str
		{
			set{ _nonce_str=value;}
			get{return _nonce_str;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sign
		{
			set{ _sign=value;}
			get{return _sign;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string result_code
		{
			set{ _result_code=value;}
			get{return _result_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string err_code
		{
			set{ _err_code=value;}
			get{return _err_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string err_code_des
		{
			set{ _err_code_des=value;}
			get{return _err_code_des;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string openid
		{
			set{ _openid=value;}
			get{return _openid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string is_subscribe
		{
			set{ _is_subscribe=value;}
			get{return _is_subscribe;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string trade_type
		{
			set{ _trade_type=value;}
			get{return _trade_type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string bank_type
		{
			set{ _bank_type=value;}
			get{return _bank_type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string total_fee
		{
			set{ _total_fee=value;}
			get{return _total_fee;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string settlement_total_fee
		{
			set{ _settlement_total_fee=value;}
			get{return _settlement_total_fee;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string fee_type
		{
			set{ _fee_type=value;}
			get{return _fee_type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cash_fee
		{
			set{ _cash_fee=value;}
			get{return _cash_fee;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cash_fee_type
		{
			set{ _cash_fee_type=value;}
			get{return _cash_fee_type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string coupon_fee
		{
			set{ _coupon_fee=value;}
			get{return _coupon_fee;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string coupon_count
		{
			set{ _coupon_count=value;}
			get{return _coupon_count;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string transaction_id
		{
			set{ _transaction_id=value;}
			get{return _transaction_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string out_trade_no
		{
			set{ _out_trade_no=value;}
			get{return _out_trade_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string attach
		{
			set{ _attach=value;}
			get{return _attach;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string time_end
		{
			set{ _time_end=value;}
			get{return _time_end;}
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

