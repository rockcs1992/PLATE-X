using System;
namespace Model
{
	/// <summary>
	/// ʵ����NewsType ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
        /// I am aժҪ
        /// </summary>
        public string pagename
        {
            set { _pagename = value; }
            get { return _pagename; }
        }

        /// <summary>
        /// I am a����
        /// </summary>
        public string typedesc
        {
            set { _typedesc = value; }
            get { return _typedesc; }
        }

		/// <summary>
		/// ����ID
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
		/// ����ID
		/// </summary>
		public int parentId
		{
			set{ _parentid=value;}
			get{return _parentid;}
		}
		/// <summary>
		/// ״̬
		/// </summary>
		public int status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// ��ע
		/// </summary>
		public string remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		#endregion Model

	}
}

