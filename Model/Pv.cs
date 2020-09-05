using System;
namespace Model
{
	/// <summary>
	/// Pv:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Pv
	{
		public Pv()
		{}
		#region Model
		private int _id;
		private string _pagename;
		private string _pagevalue;
		private int _viewscount;
		private DateTime _addtime;
		private string _ip;
		private int _status;
		private string _remark;
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
		/// 页面Item Name
		/// </summary>
		public string pageName
		{
			set{ _pagename=value;}
			get{return _pagename;}
		}
		/// <summary>
		/// 页面值
		/// </summary>
		public string pageValue
		{
			set{ _pagevalue=value;}
			get{return _pagevalue;}
		}
		/// <summary>
		/// 浏览次数
		/// </summary>
		public int viewsCount
		{
			set{ _viewscount=value;}
			get{return _viewscount;}
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
		/// IP
		/// </summary>
		public string ip
		{
			set{ _ip=value;}
			get{return _ip;}
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

