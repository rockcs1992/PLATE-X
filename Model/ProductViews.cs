using System;
namespace Model
{
	/// <summary>
	/// ProductViews:ʵ����(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
		/// �������
		/// </summary>
		public DateTime viewsTime
		{
			set{ _viewstime=value;}
			get{return _viewstime;}
		}
		#endregion Model

	}
}

