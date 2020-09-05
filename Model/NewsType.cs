using System;
namespace Model
{
	/// <summary>
	/// 实体类NewsType 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class NewsType
	{
		public NewsType()
		{}
		#region Model
		private int _id;
		private string _name;
		private int _parentid;
		private int _status;
		private string _remark;
        private string _typedesc;
        private string _pagename;
        /// <summary>
        /// I am a摘要
        /// </summary>
        public string pagename
        {
            set { _pagename = value; }
            get { return _pagename; }
        }

        /// <summary>
        /// I am a描述
        /// </summary>
        public string typedesc
        {
            set { _typedesc = value; }
            get { return _typedesc; }
        }

		/// <summary>
		/// 自增ID
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// I am aItem Name
		/// </summary>
		public string name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 父类ID
		/// </summary>
		public int parentId
		{
			set{ _parentid=value;}
			get{return _parentid;}
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
		/// 备注
		/// </summary>
		public string remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		#endregion Model

	}
}

