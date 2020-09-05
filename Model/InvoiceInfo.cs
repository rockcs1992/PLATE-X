using System;
namespace Model
{
	/// <summary>
	/// InvoiceInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class InvoiceInfo
	{
		public InvoiceInfo()
		{}
		#region Model
		private int _id;
		private int _typeid;
		private string _typename;
		private string _invoicetitle;
		private decimal _invoicemoney;
		private decimal _sendmoney;
		private string _invoicedesc;
		private int _status;
		private string _remark;
		private DateTime _addtime;
		private int _adduser;
		private int _issend;
		private int _isrecive;
		private string _recievetel;
		private string _recievename;
		private string _recieveaddr;
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
		public string invoiceTitle
		{
			set{ _invoicetitle=value;}
			get{return _invoicetitle;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal invoiceMoney
		{
			set{ _invoicemoney=value;}
			get{return _invoicemoney;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal sendMoney
		{
			set{ _sendmoney=value;}
			get{return _sendmoney;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string invoiceDesc
		{
			set{ _invoicedesc=value;}
			get{return _invoicedesc;}
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
		public int isSend
		{
			set{ _issend=value;}
			get{return _issend;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int isRecive
		{
			set{ _isrecive=value;}
			get{return _isrecive;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string recieveTel
		{
			set{ _recievetel=value;}
			get{return _recievetel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string recieveName
		{
			set{ _recievename=value;}
			get{return _recievename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string recieveAddr
		{
			set{ _recieveaddr=value;}
			get{return _recieveaddr;}
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

