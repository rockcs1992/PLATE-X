using System;
namespace Model
{
	/// <summary>
	/// NavInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class NavInfo
	{
		public NavInfo()
		{}
		#region Model
		private int _id;
		private string _indextitle;
		private string _indextitle2;
		private string _indeximg;
		private string _linkurl;
		private string _title;
		private string _infodesc;
		private string _inforemark;
		private int _status;
		private string _remark;
		private DateTime _addtime;
		private int _adduser;
		private int _infotype;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string indexTitle
		{
			set{ _indextitle=value;}
			get{return _indextitle;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string indexTitle2
		{
			set{ _indextitle2=value;}
			get{return _indextitle2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string indexImg
		{
			set{ _indeximg=value;}
			get{return _indeximg;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string linkurl
		{
			set{ _linkurl=value;}
			get{return _linkurl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string infoDesc
		{
			set{ _infodesc=value;}
			get{return _infodesc;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string infoRemark
		{
			set{ _inforemark=value;}
			get{return _inforemark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime addTime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int addUser
		{
			set{ _adduser=value;}
			get{return _adduser;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int infoType
		{
			set{ _infotype=value;}
			get{return _infotype;}
		}
		#endregion Model

	}
}

