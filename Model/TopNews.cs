using System;
namespace Model
{
	/// <summary>
	/// TopNews:实体类(属性说明自动提取数据库字段的描述信息)
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
        /// 添加时间
        /// </summary>
        public DateTime addtime
        {
            set { _addtime = value; }
            get { return _addtime; }
        }
        /// <summary>
        /// 添加人
        /// </summary>
        public int adduser
        {
            set { _adduser = value; }
            get { return _adduser; }
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
		/// 信息ID
		/// </summary>
		public int newsId
		{
			set{ _newsid=value;}
			get{return _newsid;}
		}
		/// <summary>
		///资讯I am a
		/// </summary>
		public int newsType
		{
			set{ _newstype=value;}
			get{return _newstype;}
		}
		/// <summary>
		/// 图片路径
		/// </summary>
		public string imgURL
		{
			set{ _imgurl=value;}
			get{return _imgurl;}
		}
		/// <summary>
		/// 基本信息
		/// </summary>
		public string baseInfo
		{
			set{ _baseinfo=value;}
			get{return _baseinfo;}
		}
		/// <summary>
		/// 顺序号
		/// </summary>
		public int orderNum
		{
			set{ _ordernum=value;}
			get{return _ordernum;}
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

