using System;
namespace Model
{
	/// <summary>
	/// Product_ProperValue:ʵ����(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
		/// ����ID
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// ��ƷID
		/// </summary>
		public int productId
		{
			set{ _productid=value;}
			get{return _productid;}
		}
		/// <summary>
		/// ����ֵID
		/// </summary>
		public int properValueId
		{
			set{ _propervalueid=value;}
			get{return _propervalueid;}
		}
		/// <summary>
		/// ����ֵItem Name
		/// </summary>
		public string properValueText
		{
			set{ _propervaluetext=value;}
			get{return _propervaluetext;}
		}
		/// <summary>
		/// ����ID
		/// </summary>
		public int properId
		{
			set{ _properid=value;}
			get{return _properid;}
		}
		/// <summary>
		/// ����ID
		/// </summary>
		public int parentId
		{
			set{ _parentid=value;}
			get{return _parentid;}
		}
		#endregion Model

	}
}

