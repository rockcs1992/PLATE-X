using System;
namespace Model
{
	/// <summary>
	/// IndexProduct:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class IndexProduct
	{
		public IndexProduct()
		{}
		#region Model
		private int _id;
		private int _typeid;
		private string _typename;
		private string _proname;
		private string _prodesc;
		private double _proprice;
		private string _pricestr;
		private string _unitdesc;
		private string _imgurl;
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
		public string proName
		{
			set{ _proname=value;}
			get{return _proname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string proDesc
		{
			set{ _prodesc=value;}
			get{return _prodesc;}
		}
		/// <summary>
		/// 
		/// </summary>
		public double proPrice
		{
			set{ _proprice=value;}
			get{return _proprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string priceStr
		{
			set{ _pricestr=value;}
			get{return _pricestr;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string unitDesc
		{
			set{ _unitdesc=value;}
			get{return _unitdesc;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string imgUrl
		{
			set{ _imgurl=value;}
			get{return _imgurl;}
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

