using System;
namespace Model
{
	/// <summary>
	/// 实体类KeyWordInfo 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class KeyWordInfo
	{
		public KeyWordInfo()
		{}
		#region Model
		private int _id;
		private string _pagename;
		private string _title;
		private string _keyword;
		private string _description;
		private string _pagenamevalue;
		/// <summary>
		/// 自增ID
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 页面Item Name，中文说明
		/// </summary>
		public string pageName
		{
			set{ _pagename=value;}
			get{return _pagename;}
		}
		/// <summary>
		/// 页面标题
		/// </summary>
		public string title
		{
			set{ _title=value;}
			get{return _title;}
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
		/// 描述
		/// </summary>
		public string description
		{
			set{ _description=value;}
			get{return _description;}
		}
		/// <summary>
		/// 页面路径
		/// </summary>
		public string pageNameValue
		{
			set{ _pagenamevalue=value;}
			get{return _pagenamevalue;}
		}
		#endregion Model

	}
}

