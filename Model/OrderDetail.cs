using System;
namespace Model
{
	/// <summary>
	/// OrderDetail:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class OrderDetail
	{
		public OrderDetail()
		{}
		#region Model
		private int _id;
		private int _orderid;
		private string _orderno;
		private int _productid;
		private int _productcount;
		private int _isactive;
		private string _activecode;
		private double _activemoney;
		private double _total;
		private int _satus;
		private string _remark;
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
		public int orderId
		{
			set{ _orderid=value;}
			get{return _orderid;}
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
		public int productId
		{
			set{ _productid=value;}
			get{return _productid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int productCount
		{
			set{ _productcount=value;}
			get{return _productcount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int isActive
		{
			set{ _isactive=value;}
			get{return _isactive;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string activeCode
		{
			set{ _activecode=value;}
			get{return _activecode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public double activeMoney
		{
			set{ _activemoney=value;}
			get{return _activemoney;}
		}
		/// <summary>
		/// 
		/// </summary>
		public double total
		{
			set{ _total=value;}
			get{return _total;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int satus
		{
			set{ _satus=value;}
			get{return _satus;}
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
		public int infoType
		{
			set{ _infotype=value;}
			get{return _infotype;}
		}
		#endregion Model

	}
}

