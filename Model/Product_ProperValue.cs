using System;
namespace Model
{
	/// <summary>
	/// Product_ProperValue:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Product_ProperValue
	{
		public Product_ProperValue()
		{}
		#region Model
		private int _id;
		private int _productid;
		private int _propervalueid;
		private string _propervaluetext;
		private int _properid;
		private int _parentid;
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
		/// 属性值ID
		/// </summary>
		public int properValueId
		{
			set{ _propervalueid=value;}
			get{return _propervalueid;}
		}
		/// <summary>
		/// 属性值Item Name
		/// </summary>
		public string properValueText
		{
			set{ _propervaluetext=value;}
			get{return _propervaluetext;}
		}
		/// <summary>
		/// 属性ID
		/// </summary>
		public int properId
		{
			set{ _properid=value;}
			get{return _properid;}
		}
		/// <summary>
		/// 父级ID
		/// </summary>
		public int parentId
		{
			set{ _parentid=value;}
			get{return _parentid;}
		}
		#endregion Model

	}
}

