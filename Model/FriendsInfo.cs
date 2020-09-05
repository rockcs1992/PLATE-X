using System;
namespace Model
{
	/// <summary>
	/// 实体类FriendsInfo 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class FriendsInfo
	{
		public FriendsInfo()
		{}
		#region Model
		private int _id;
		private string _title;
		private string _alt;
		private string _img1path;
		private string _img2path;
		private string _linkurl;
		private int _ordernum;
		private int _status;
		private DateTime _addtime;
		private int _adduser;
		private int _infotype;
		/// <summary>
		/// 主键
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
		/// alt
		/// </summary>
		public string alt
		{
			set{ _alt=value;}
			get{return _alt;}
		}
		/// <summary>
		/// 图片1路径
		/// </summary>
		public string img1path
		{
			set{ _img1path=value;}
			get{return _img1path;}
		}
		/// <summary>
		/// 图片2路径
		/// </summary>
		public string img2Path
		{
			set{ _img2path=value;}
			get{return _img2path;}
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

