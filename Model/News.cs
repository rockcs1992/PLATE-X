using System;
namespace Model
{
	/// <summary>
	/// ʵ����News ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class News
	{
		public News()
		{}
		#region Model
		private int _id;
		private string _title;
		private string _pagename;
		private int _newstype;
		private string _newimg;
		private string _newscontent;
		private string _keyword;
		private string _newsdesc;
		private string _linkurl;
		private int _is_tj;
        private int _is_hot;
		private int _ordernum;
		private DateTime _addtime;
		private int _add_userid;
		private int _res_views;
		private int _areaid;
		private string _sid;
		private DateTime _releasetime;
		private string _author;
		/// <summary>
		/// ����ID
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public string title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
        /// ����
		/// </summary>
		public string pageName
		{
			set{ _pagename=value;}
			get{return _pagename;}
		}
		/// <summary>
		/// ����I am a
		/// </summary>
		public int newsType
		{
			set{ _newstype=value;}
			get{return _newstype;}
		}
		/// <summary>
		/// ͼƬ·��
		/// </summary>
		public string newImg
		{
			set{ _newimg=value;}
			get{return _newimg;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public string newsContent
		{
			set{ _newscontent=value;}
			get{return _newscontent;}
		}
		/// <summary>
		/// �ؼ���
		/// </summary>
		public string keyword
		{
			set{ _keyword=value;}
			get{return _keyword;}
		}
		/// <summary>
		/// ��ע��Ϣ
		/// </summary>
		public string newsDesc
		{
			set{ _newsdesc=value;}
			get{return _newsdesc;}
		}
		/// <summary>
		/// ����·��
		/// </summary>
		public string linkurl
		{
			set{ _linkurl=value;}
			get{return _linkurl;}
		}
		/// <summary>
		/// �Ƿ��Ƽ�
		/// </summary>
		public int is_tj
		{
			set{ _is_tj=value;}
			get{return _is_tj;}
		}

        /// <summary>
        /// �Ƿ��ȵ�
        /// </summary>
        public int is_hot
        {
            set { _is_hot = value; }
            get { return _is_hot; }
        }
		/// <summary>
        /// ״̬ 0������5����
		/// </summary>
		public int ordernum
		{
			set{ _ordernum=value;}
			get{return _ordernum;}
		}
		/// <summary>
		/// ���ʱ��
		/// </summary>
		public DateTime addTime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		/// <summary>
		/// �����
		/// </summary>
		public int add_userid
		{
			set{ _add_userid=value;}
			get{return _add_userid;}
		}
		/// <summary>
		/// �������
		/// </summary>
		public int res_views
		{
			set{ _res_views=value;}
			get{return _res_views;}
		}
		/// <summary>
		/// �����̶�
		/// </summary>
		public int areaid
		{
			set{ _areaid=value;}
			get{return _areaid;}
		}
		/// <summary>
		/// ��ǩ
		/// </summary>
		public string sid
		{
			set{ _sid=value;}
			get{return _sid;}
		}
		/// <summary>
		/// ����ʱ��
		/// </summary>
		public DateTime releaseTime
		{
			set{ _releasetime=value;}
			get{return _releasetime;}
		}
		/// <summary>
		/// ��Դ/����
		/// </summary>
		public string author
		{
			set{ _author=value;}
			get{return _author;}
		}
		#endregion Model

	}
}

