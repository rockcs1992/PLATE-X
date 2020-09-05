using System;
namespace Model
{
	/// <summary>
	/// ProductGoods:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ProductGoods
	{
		public ProductGoods()
		{}
		#region Model
		private int _id;
		private int _productid;
		private int _quantitygoods;
		private int _brandgoods;
		private int _pricegoods;
		private int _setgoods;
		private int _beautifulgoods;
		private int _othergoods;
		private int _status;
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
		public int productId
		{
			set{ _productid=value;}
			get{return _productid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int quantityGoods
		{
			set{ _quantitygoods=value;}
			get{return _quantitygoods;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int brandGoods
		{
			set{ _brandgoods=value;}
			get{return _brandgoods;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int priceGoods
		{
			set{ _pricegoods=value;}
			get{return _pricegoods;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int setGoods
		{
			set{ _setgoods=value;}
			get{return _setgoods;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int beautifulGoods
		{
			set{ _beautifulgoods=value;}
			get{return _beautifulgoods;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int otherGoods
		{
			set{ _othergoods=value;}
			get{return _othergoods;}
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
		public int infoType
		{
			set{ _infotype=value;}
			get{return _infotype;}
		}
		#endregion Model

	}
}

