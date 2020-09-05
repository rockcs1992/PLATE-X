using System;
namespace Model
{
	/// <summary>
	/// Comment:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Comment
	{
		public Comment()
		{}
		#region Model
		private int _id;
		private int _orderid;
		private string _orderno;
		private int _productid;
		private int _commenttype;
		private int _datatype;
		private int _fromid;
		private string _commentinfo;
		private string _commentdesc;
		private string _img1url;
		private string _img2url;
		private string _img3url;
		private string _img4url;
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
		public int commentType
		{
			set{ _commenttype=value;}
			get{return _commenttype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int dataType
		{
			set{ _datatype=value;}
			get{return _datatype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int fromId
		{
			set{ _fromid=value;}
			get{return _fromid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string commentInfo
		{
			set{ _commentinfo=value;}
			get{return _commentinfo;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string commentDesc
		{
			set{ _commentdesc=value;}
			get{return _commentdesc;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string img1Url
		{
			set{ _img1url=value;}
			get{return _img1url;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string img2Url
		{
			set{ _img2url=value;}
			get{return _img2url;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string img3Url
		{
			set{ _img3url=value;}
			get{return _img3url;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string img4Url
		{
			set{ _img4url=value;}
			get{return _img4url;}
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

