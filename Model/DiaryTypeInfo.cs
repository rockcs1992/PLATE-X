using System;
namespace Model
{
	/// <summary>
	/// DiaryTypeInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class DiaryTypeInfo
	{
		public DiaryTypeInfo()
		{}
		#region Model
		private int _id;
		private int _typeid;
		private string _typename;
		private int _parentid;
		private string _parentname;
		private string _headimg;
		private string _title;
		private string _typedesc;
		private string _typecontent;
		private string _author;
		private string _fromstr;
		private DateTime _releasetime;
		private string _releasetimestr;
		private string _img1url;
		private string _img2url;
		private string _img3url;
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
		public int typeId
		{
			set{ _typeid=value;}
			get{return _typeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string typeName
		{
			set{ _typename=value;}
			get{return _typename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int parentId
		{
			set{ _parentid=value;}
			get{return _parentid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string parentName
		{
			set{ _parentname=value;}
			get{return _parentname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string headImg
		{
			set{ _headimg=value;}
			get{return _headimg;}
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
		public string typeDesc
		{
			set{ _typedesc=value;}
			get{return _typedesc;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string typeContent
		{
			set{ _typecontent=value;}
			get{return _typecontent;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string author
		{
			set{ _author=value;}
			get{return _author;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string fromStr
		{
			set{ _fromstr=value;}
			get{return _fromstr;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime releaseTime
		{
			set{ _releasetime=value;}
			get{return _releasetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string releaseTimeStr
		{
			set{ _releasetimestr=value;}
			get{return _releasetimestr;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string img1Url
		{
			set{ _img1url=value;}
			get{return _img1url;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string img2Url
		{
			set{ _img2url=value;}
			get{return _img2url;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string img3Url
		{
			set{ _img3url=value;}
			get{return _img3url;}
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

