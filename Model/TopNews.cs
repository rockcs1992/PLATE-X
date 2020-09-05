using System;
namespace Model
{
	/// <summary>
	/// TopNews:ʵ����(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public partial class TopNews
	{
		public TopNews()
		{}
		#region Model
		private int _id;
		private int _newsid;
		private int _newstype;
		private string _imgurl;
		private string _baseinfo;
		private int _ordernum;
		private int _status;
		private string _remark;
        private DateTime _addtime;
        private int _adduser;
		private int _infotype;
        /// <summary>
        /// ���ʱ��
        /// </summary>
        public DateTime addtime
        {
            set { _addtime = value; }
            get { return _addtime; }
        }
        /// <summary>
        /// �����
        /// </summary>
        public int adduser
        {
            set { _adduser = value; }
            get { return _adduser; }
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
		/// ��ϢID
		/// </summary>
		public int newsId
		{
			set{ _newsid=value;}
			get{return _newsid;}
		}
		/// <summary>
		///��ѶI am a
		/// </summary>
		public int newsType
		{
			set{ _newstype=value;}
			get{return _newstype;}
		}
		/// <summary>
		/// ͼƬ·��
		/// </summary>
		public string imgURL
		{
			set{ _imgurl=value;}
			get{return _imgurl;}
		}
		/// <summary>
		/// ������Ϣ
		/// </summary>
		public string baseInfo
		{
			set{ _baseinfo=value;}
			get{return _baseinfo;}
		}
		/// <summary>
		/// ˳���
		/// </summary>
		public int orderNum
		{
			set{ _ordernum=value;}
			get{return _ordernum;}
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
		/// <summary>
		/// ��ϢI am a
		/// </summary>
		public int infoType
		{
			set{ _infotype=value;}
			get{return _infotype;}
		}
		#endregion Model

	}
}

