using System;
namespace Model
{
	/// <summary>
	/// GuangGao:实体类(属性说明自动提取数据库字段的描述信息)
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
		/// 主键ID
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
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
		/// 标题
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
		/// 链接路径
		/// </summary>
		public string linkurl
		{
			set{ _linkurl=value;}
			get{return _linkurl;}
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
		/// 联系人
		/// </summary>
		public string relUser
		{
			set{ _reluser=value;}
			get{return _reluser;}
		}
		/// <summary>
		/// 联系电话
		/// </summary>
		public string tel
		{
			set{ _tel=value;}
			get{return _tel;}
		}
		/// <summary>
		/// 时间段
		/// </summary>
		public string timeStr
		{
			set{ _timestr=value;}
			get{return _timestr;}
		}
		/// <summary>
		/// 开始时间
		/// </summary>
		public DateTime timeFrom
		{
			set{ _timefrom=value;}
			get{return _timefrom;}
		}
		/// <summary>
		/// 结束时间
		/// </summary>
		public DateTime timeEnd
		{
			set{ _timeend=value;}
			get{return _timeend;}
		}
		/// <summary>
		/// 广告位置
		/// </summary>
		public int placeSite
		{
			set{ _placesite=value;}
			get{return _placesite;}
		}
		/// <summary>
		/// 位置Item Name
		/// </summary>
		public string placeName
		{
			set{ _placename=value;}
			get{return _placename;}
		}
		/// <summary>
		/// 是否推荐
		/// </summary>
		public int isTj
		{
			set{ _istj=value;}
			get{return _istj;}
		}
		/// <summary>
		/// 是否热点
		/// </summary>
		public int isHot
		{
			set{ _ishot=value;}
			get{return _ishot;}
		}
		/// <summary>
		/// 是否最新
		/// </summary>
		public int isNew
		{
			set{ _isnew=value;}
			get{return _isnew;}
		}
		/// <summary>
		/// 浏览次数
		/// </summary>
		public int views
		{
			set{ _views=value;}
			get{return _views;}
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
		/// <summary>
		/// 添加时间
		/// </summary>
		public DateTime addTime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		/// <summary>
		/// 添加人
		/// </summary>
		public int addUser
		{
			set{ _adduser=value;}
			get{return _adduser;}
		}
		/// <summary>
		/// 信息I am a
		/// </summary>
		public int infoType
		{
			set{ _infotype=value;}
			get{return _infotype;}
		}
		#endregion Model

	}
}

