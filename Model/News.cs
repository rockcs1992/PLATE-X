using System;
namespace Model
{
	/// <summary>
	/// 实体类News 。(属性说明自动提取数据库字段的描述信息)
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
		/// 自增ID
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
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
        /// 备用
		/// </summary>
		public string pageName
		{
			set{ _pagename=value;}
			get{return _pagename;}
		}
		/// <summary>
		/// 新闻I am a
		/// </summary>
		public int newsType
		{
			set{ _newstype=value;}
			get{return _newstype;}
		}
		/// <summary>
		/// 图片路径
		/// </summary>
		public string newImg
		{
			set{ _newimg=value;}
			get{return _newimg;}
		}
		/// <summary>
		/// 内容
		/// </summary>
		public string newsContent
		{
			set{ _newscontent=value;}
			get{return _newscontent;}
		}
		/// <summary>
		/// 关键字
		/// </summary>
		public string keyword
		{
			set{ _keyword=value;}
			get{return _keyword;}
		}
		/// <summary>
		/// 备注信息
		/// </summary>
		public string newsDesc
		{
			set{ _newsdesc=value;}
			get{return _newsdesc;}
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
		/// 是否推荐
		/// </summary>
		public int is_tj
		{
			set{ _is_tj=value;}
			get{return _is_tj;}
		}

        /// <summary>
        /// 是否热点
        /// </summary>
        public int is_hot
        {
            set { _is_hot = value; }
            get { return _is_hot; }
        }
		/// <summary>
        /// 状态 0正常，5屏蔽
		/// </summary>
		public int ordernum
		{
			set{ _ordernum=value;}
			get{return _ordernum;}
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
		public int add_userid
		{
			set{ _add_userid=value;}
			get{return _add_userid;}
		}
		/// <summary>
		/// 浏览次数
		/// </summary>
		public int res_views
		{
			set{ _res_views=value;}
			get{return _res_views;}
		}
		/// <summary>
		/// 公开程度
		/// </summary>
		public int areaid
		{
			set{ _areaid=value;}
			get{return _areaid;}
		}
		/// <summary>
		/// 标签
		/// </summary>
		public string sid
		{
			set{ _sid=value;}
			get{return _sid;}
		}
		/// <summary>
		/// 发布时间
		/// </summary>
		public DateTime releaseTime
		{
			set{ _releasetime=value;}
			get{return _releasetime;}
		}
		/// <summary>
		/// 来源/作者
		/// </summary>
		public string author
		{
			set{ _author=value;}
			get{return _author;}
		}
		#endregion Model

	}
}

