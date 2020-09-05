using System;
namespace Model
{
	/// <summary>
	/// 实体类OnLinePayStatus 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class OnLinePayStatus
	{
		public OnLinePayStatus()
		{}
		#region Model
		private int _id;
		private string _orderno;
		private int _onlinepaytype;
		private int _paystatus;
		private int _status;
		private int _count;
		private string _remark;
		private DateTime _addtime;
		/// <summary>
		/// 自增ID
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// Order ID
		/// </summary>
		public string orderNo
		{
			set{ _orderno=value;}
			get{return _orderno;}
		}
		/// <summary>
		/// 在线付款I am a，1支付宝，2财付通，3线下
		/// </summary>
		public int onLinePayType
		{
			set{ _onlinepaytype=value;}
			get{return _onlinepaytype;}
		}
		/// <summary>
		/// 付款状态，0未付，1已付
		/// </summary>
		public int payStatus
		{
			set{ _paystatus=value;}
			get{return _paystatus;}
		}
		/// <summary>
		/// 状态
		/// </summary>
		public int status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 返回次数
		/// </summary>
		public int count
		{
			set{ _count=value;}
			get{return _count;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 添加时间
		/// </summary>
		public DateTime addTime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		#endregion Model

	}
}

