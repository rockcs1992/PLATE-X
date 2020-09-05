using System;
namespace Model
{
	/// <summary>
	/// ProductViews:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ProductViews
	{
		public ProductViews()
		{}
		#region Model
		private int _id;
		private int _productid;
		private DateTime _viewstime;
		/// <summary>
		/// 主键ID
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 产品ID
		/// </summary>
		public int productId
		{
			set{ _productid=value;}
			get{return _productid;}
		}
		/// <summary>
		/// 浏览次数
		/// </summary>
		public DateTime viewsTime
		{
			set{ _viewstime=value;}
			get{return _viewstime;}
		}
		#endregion Model

	}
}

