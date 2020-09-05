using System;
namespace Model
{
	/// <summary>
	/// GuangGao:ʵ����(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public partial class GuangGao
	{
		public GuangGao()
		{}
		#region Model
		private int _id;
		private string _imgurl;
		private string _title;
		private string _alt;
		private string _linkurl;
		private string _comname;
		private string _reluser;
		private string _tel;
		private string _timestr;
		private DateTime _timefrom;
		private DateTime _timeend;
		private int _placesite;
		private string _placename;
		private int _istj;
		private int _ishot;
		private int _isnew;
		private int _views;
		private int _status;
		private string _remark;
		private DateTime _addtime;
		private int _adduser;
		private int _infotype;
		/// <summary>
		/// ����ID
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// ͼƬ·��
		/// </summary>
		public string imgUrl
		{
			set{ _imgurl=value;}
			get{return _imgurl;}
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
		/// alt
		/// </summary>
		public string alt
		{
			set{ _alt=value;}
			get{return _alt;}
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
		/// ��˾Item Name
		/// </summary>
		public string comName
		{
			set{ _comname=value;}
			get{return _comname;}
		}
		/// <summary>
		/// ��ϵ��
		/// </summary>
		public string relUser
		{
			set{ _reluser=value;}
			get{return _reluser;}
		}
		/// <summary>
		/// ��ϵ�绰
		/// </summary>
		public string tel
		{
			set{ _tel=value;}
			get{return _tel;}
		}
		/// <summary>
		/// ʱ���
		/// </summary>
		public string timeStr
		{
			set{ _timestr=value;}
			get{return _timestr;}
		}
		/// <summary>
		/// ��ʼʱ��
		/// </summary>
		public DateTime timeFrom
		{
			set{ _timefrom=value;}
			get{return _timefrom;}
		}
		/// <summary>
		/// ����ʱ��
		/// </summary>
		public DateTime timeEnd
		{
			set{ _timeend=value;}
			get{return _timeend;}
		}
		/// <summary>
		/// ���λ��
		/// </summary>
		public int placeSite
		{
			set{ _placesite=value;}
			get{return _placesite;}
		}
		/// <summary>
		/// λ��Item Name
		/// </summary>
		public string placeName
		{
			set{ _placename=value;}
			get{return _placename;}
		}
		/// <summary>
		/// �Ƿ��Ƽ�
		/// </summary>
		public int isTj
		{
			set{ _istj=value;}
			get{return _istj;}
		}
		/// <summary>
		/// �Ƿ��ȵ�
		/// </summary>
		public int isHot
		{
			set{ _ishot=value;}
			get{return _ishot;}
		}
		/// <summary>
		/// �Ƿ�����
		/// </summary>
		public int isNew
		{
			set{ _isnew=value;}
			get{return _isnew;}
		}
		/// <summary>
		/// �������
		/// </summary>
		public int views
		{
			set{ _views=value;}
			get{return _views;}
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
		public int addUser
		{
			set{ _adduser=value;}
			get{return _adduser;}
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

