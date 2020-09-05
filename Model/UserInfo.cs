using System;
namespace Model
{
	/// <summary>
	/// UserInfo:ʵ����(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public partial class UserInfo
	{
		public UserInfo()
		{}
		#region Model
		private int _id;
		private string _username;
		private string _mobile;
        private string _telephone;
		private int _isbindmobile;
		private string _email;
		private int _isbindemail;
		private string _password;
		private string _md5pass;
		private string _relname;
		private string _bodycode;
		private string _comname;
		private int _pid;
		private int _cid;
		private int _regionid;
		private string _address;
		private string _zipcode;
		private string _qq;
		private string _weixin;
		private int _isbindweixin;
		private string _weibo;
		private int _isbindweibo;
		private int _shoptype;
		private string _shoptypename;
		private string _imgurl;
		private string _cominfo;
		private string _remark;
		private int _status;
		private DateTime _addtime;
		private string _mobilecode;
		private string _activecode;
		private int _infotype;
        private string _shopingtime;
        private string _mainbrand;
        private int _assesscount;
        private int _producttype;
        private int _sharecount;
        private int _goodcount;
        private int _badcount;
        private int _viewscount;
        private DateTime _logintime;
        private string _loginip;

        /// <summary>
        /// ��õ�½ʱ��
        /// </summary>
        public DateTime logintime
        {
            set { _logintime = value; }
            get { return _logintime; }
        }
        /// <summary>
        /// ��õ�½IP
        /// </summary>
        public string loginip
        {
            set { _loginip = value; }
            get { return _loginip; }
        }
        /// <summary>
        /// ����
        /// </summary>
        public string telephone
        {
            set { _telephone = value; }
            get { return _telephone;}
        }


        /// <summary>
        /// �������
        /// </summary>
        public int viewscountd
        {
            set { _viewscount = value; }
            get { return _viewscount; }
        }
        /// <summary>
        /// ��������
        /// </summary>
        public int badcount
        {
            set { _badcount = value; }
            get { return _badcount; }
        }
        /// <summary>
        /// ��������
        /// </summary>
        public int goodcount
        {
            set { _goodcount = value; }
            get { return _goodcount; }
        }
        /// <summary>
        /// �������
        /// </summary>
        public int sharecount
        {
            set { _sharecount = value; }
            get { return _sharecount; }
        }
        /// <summary>
        /// ��ƷI am a
        /// </summary>
        public int producttype
        {
            set { _producttype = value; }
            get { return _producttype; }
        }
        /// <summary>
        /// ���۴���
        /// </summary>
        public int assesscount
        {
            set { _assesscount = value; }
            get { return _assesscount; }
        }
        /// <summary>
        /// ��ҵ��Ա�ؼ���
        /// </summary>
        public string mainbrand
        {
            set { _mainbrand = value; }
            get { return _mainbrand; }
        }
        /// <summary>
        /// ��ҵ��Ա��ַ
        /// </summary>
        public string shopingtime
        {
            set { _shopingtime = value; }
            get { return _shopingtime; }
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
		/// Username
		/// </summary>
		public string username
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// Phone
		/// </summary>
		public string mobile
		{
			set{ _mobile=value;}
			get{return _mobile;}
		}
		/// <summary>
		/// �Ƿ��Phone
		/// </summary>
		public int isBindMobile
		{
			set{ _isbindmobile=value;}
			get{return _isbindmobile;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public string email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// �Ƿ������
		/// </summary>
		public int isBindEmail
		{
			set{ _isbindemail=value;}
			get{return _isbindemail;}
		}
		/// <summary>
		/// Password
		/// </summary>
		public string password
		{
			set{ _password=value;}
			get{return _password;}
		}
		/// <summary>
		/// md5����Password
		/// </summary>
		public string md5Pass
		{
			set{ _md5pass=value;}
			get{return _md5pass;}
		}
		/// <summary>
		/// ��ϵ��
		/// </summary>
		public string relName
		{
			set{ _relname=value;}
			get{return _relname;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public string bodyCode
		{
			set{ _bodycode=value;}
			get{return _bodycode;}
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
		/// ʡ
		/// </summary>
		public int pid
		{
			set{ _pid=value;}
			get{return _pid;}
		}
		/// <summary>
		/// ��
		/// </summary>
		public int cid
		{
			set{ _cid=value;}
			get{return _cid;}
		}
		/// <summary>
		/// ͣ��λ��Ϣ
		/// </summary>
		public int regionId
		{
			set{ _regionid=value;}
			get{return _regionid;}
		}
		/// <summary>
		/// ��ַ
		/// </summary>
		public string address
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// �ʱ�
		/// </summary>
		public string zipCode
		{
			set{ _zipcode=value;}
			get{return _zipcode;}
		}
		/// <summary>
		/// QQ
		/// </summary>
		public string qq
		{
			set{ _qq=value;}
			get{return _qq;}
		}
		/// <summary>
		/// ΢��
		/// </summary>
		public string weixin
		{
			set{ _weixin=value;}
			get{return _weixin;}
		}
		/// <summary>
		/// �Ƽ�
		/// </summary>
		public int isBindWeiXin
		{
			set{ _isbindweixin=value;}
			get{return _isbindweixin;}
		}
		/// <summary>
		/// ΢��
		/// </summary>
		public string weibo
		{
			set{ _weibo=value;}
			get{return _weibo;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public int isBindWeiBo
		{
			set{ _isbindweibo=value;}
			get{return _isbindweibo;}
		}
		/// <summary>
		/// ��ӪI am a 1��Restaurant 2��Store 3��һ���û�
		/// </summary>
		public int shopType
		{
			set{ _shoptype=value;}
			get{return _shoptype;}
		}
		/// <summary>
		/// ��ӪI am aItem Name
		/// </summary>
		public string shopTypeName
		{
			set{ _shoptypename=value;}
			get{return _shoptypename;}
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
		/// ��˾��Ϣ
		/// </summary>
		public string comInfo
		{
			set{ _cominfo=value;}
			get{return _cominfo;}
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
		/// ״̬        һ���û�Ĭ��״̬��0 �����ͨ��״̬��1��δ���״̬��2��δͨ��״̬��3��
		/// </summary>
		public int status
		{
			set{ _status=value;}
			get{return _status;}
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
		/// �绰
		/// </summary>
		public string mobileCode
		{
			set{ _mobilecode=value;}
			get{return _mobilecode;}
		}
		/// <summary>
		/// ��ҵ��Ա��ַ�˳�·��
		/// </summary>
		public string activeCode
		{
			set{ _activecode=value;}
			get{return _activecode;}
		}
		/// <summary>
		/// ��ϢI am a,1�Ǹ��ˣ�2���̼�
		/// </summary>
		public int infoType
		{
			set{ _infotype=value;}
			get{return _infotype;}
		}
		#endregion Model

	}
}

