using System;
namespace Model
{
	/// <summary>
	/// CartTemp:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class CartTemp
	{
		public CartTemp()
		{}
		#region Model
		private int _id;
		private int _productid;
		private int _productcount;
		private int _adduser;
		private int _status;
		private string _remark;
        private int _sel;
        /// <summary>
        /// 
        /// </summary>
        public int sel
        {
            set { _sel = value; }
            get { return _sel; }
        }
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
		public int productCount
		{
			set{ _productcount=value;}
			get{return _productcount;}
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
		#endregion Model

	}
}

