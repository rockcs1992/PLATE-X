using System;
namespace Model
{
	/// <summary>
	/// UserInfo:实体类(属性说明自动提取数据库字段的描述信息)
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
        /// 最好登陆时间
        /// </summary>
        public DateTime logintime
        {
            set { _logintime = value; }
            get { return _logintime; }
        }
        /// <summary>
        /// 最好登陆IP
        /// </summary>
        public string loginip
        {
            set { _loginip = value; }
            get { return _loginip; }
        }
        /// <summary>
        /// 座机
        /// </summary>
        public string telephone
        {
            set { _telephone = value; }
            get { return _telephone;}
        }


        /// <summary>
        /// 浏览次数
        /// </summary>
        public int viewscountd
        {
            set { _viewscount = value; }
            get { return _viewscount; }
        }
        /// <summary>
        /// 差评次数
        /// </summary>
        public int badcount
        {
            set { _badcount = value; }
            get { return _badcount; }
        }
        /// <summary>
        /// 好评次数
        /// </summary>
        public int goodcount
        {
            set { _goodcount = value; }
            get { return _goodcount; }
        }
        /// <summary>
        /// 分享次数
        /// </summary>
        public int sharecount
        {
            set { _sharecount = value; }
            get { return _sharecount; }
        }
        /// <summary>
        /// 产品I am a
        /// </summary>
        public int producttype
        {
            set { _producttype = value; }
            get { return _producttype; }
        }
        /// <summary>
        /// 评论次数
        /// </summary>
        public int assesscount
        {
            set { _assesscount = value; }
            get { return _assesscount; }
        }
        /// <summary>
        /// 企业会员关键字
        /// </summary>
        public string mainbrand
        {
            set { _mainbrand = value; }
            get { return _mainbrand; }
        }
        /// <summary>
        /// 企业会员网址
        /// </summary>
        public string shopingtime
        {
            set { _shopingtime = value; }
            get { return _shopingtime; }
        }
		/// <summary>
		/// 主键ID
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
		/// 是否绑定Phone
		/// </summary>
		public int isBindMobile
		{
			set{ _isbindmobile=value;}
			get{return _isbindmobile;}
		}
		/// <summary>
		/// 邮箱
		/// </summary>
		public string email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// 是否绑定邮箱
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
		/// md5加密Password
		/// </summary>
		public string md5Pass
		{
			set{ _md5pass=value;}
			get{return _md5pass;}
		}
		/// <summary>
		/// 联系人
		/// </summary>
		public string relName
		{
			set{ _relname=value;}
			get{return _relname;}
		}
		/// <summary>
		/// 备用
		/// </summary>
		public string bodyCode
		{
			set{ _bodycode=value;}
			get{return _bodycode;}
		}
		/// <summary>
		/// 公司Item Name
		/// </summary>
		public string comName
		{
			set{ _comname=value;}
			get{return _comname;}
		}
		/// <summary>
		/// 省
		/// </summary>
		public int pid
		{
			set{ _pid=value;}
			get{return _pid;}
		}
		/// <summary>
		/// 市
		/// </summary>
		public int cid
		{
			set{ _cid=value;}
			get{return _cid;}
		}
		/// <summary>
		/// 停车位信息
		/// </summary>
		public int regionId
		{
			set{ _regionid=value;}
			get{return _regionid;}
		}
		/// <summary>
		/// 地址
		/// </summary>
		public string address
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// 邮编
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
		/// 微信
		/// </summary>
		public string weixin
		{
			set{ _weixin=value;}
			get{return _weixin;}
		}
		/// <summary>
		/// 推荐
		/// </summary>
		public int isBindWeiXin
		{
			set{ _isbindweixin=value;}
			get{return _isbindweixin;}
		}
		/// <summary>
		/// 微博
		/// </summary>
		public string weibo
		{
			set{ _weibo=value;}
			get{return _weibo;}
		}
		/// <summary>
		/// 备用
		/// </summary>
		public int isBindWeiBo
		{
			set{ _isbindweibo=value;}
			get{return _isbindweibo;}
		}
		/// <summary>
		/// 经营I am a 1、Restaurant 2、Store 3、一般用户
		/// </summary>
		public int shopType
		{
			set{ _shoptype=value;}
			get{return _shoptype;}
		}
		/// <summary>
		/// 经营I am aItem Name
		/// </summary>
		public string shopTypeName
		{
			set{ _shoptypename=value;}
			get{return _shoptypename;}
		}
		/// <summary>
		/// 图片路径
		/// </summary>
		public string imgUrl
		{
			set{ _imgurl=value;}
			get{return _imgurl;}
		}
		/// <summary>
		/// 公司信息
		/// </summary>
		public string comInfo
		{
			set{ _cominfo=value;}
			get{return _cominfo;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 状态        一般用户默认状态是0 ，审核通过状态是1，未审核状态是2，未通过状态是3。
		/// </summary>
		public int status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 添加时间
		/// </summary>
		public DateTime addTime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		/// <summary>
		/// 电话
		/// </summary>
		public string mobileCode
		{
			set{ _mobilecode=value;}
			get{return _mobilecode;}
		}
		/// <summary>
		/// 企业会员地址乘车路线
		/// </summary>
		public string activeCode
		{
			set{ _activecode=value;}
			get{return _activecode;}
		}
		/// <summary>
		/// 信息I am a,1是个人，2是商家
		/// </summary>
		public int infoType
		{
			set{ _infotype=value;}
			get{return _infotype;}
		}
		#endregion Model

	}
}

