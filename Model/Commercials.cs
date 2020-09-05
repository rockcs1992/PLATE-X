using System;
namespace Model
{
	/// <summary>
	/// Commercials:实体类(属性说明自动提取数据库字段的描述信息)，广告表（没有用上，用GuangGao表替换）
	/// </summary>
	[Serializable]
	public partial class Commercials
	{
		public Commercials()
		{}
		#region Model
		private int _id;
		private string _title;
		private int _datatype;
		private string _commercialscontent;
		private string _imgurl;
		private string _imgsize;
		private int _height;
		private int _width;
		private string _reluser;
		private string _reltel;
		private string _relmobile;
		private string _comname;
		private string _timesize;
		private DateTime _timefrom;
		private DateTime _timeend;
		private int _place;
		private string _placename;
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
		public string title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int dataType
		{
			set{ _datatype=value;}
			get{return _datatype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string commercialsContent
		{
			set{ _commercialscontent=value;}
			get{return _commercialscontent;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string imgURL
		{
			set{ _imgurl=value;}
			get{return _imgurl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string imgSize
		{
			set{ _imgsize=value;}
			get{return _imgsize;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int height
		{
			set{ _height=value;}
			get{return _height;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int width
		{
			set{ _width=value;}
			get{return _width;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string relUser
		{
			set{ _reluser=value;}
			get{return _reluser;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string relTel
		{
			set{ _reltel=value;}
			get{return _reltel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string relMobile
		{
			set{ _relmobile=value;}
			get{return _relmobile;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string comName
		{
			set{ _comname=value;}
			get{return _comname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string timeSize
		{
			set{ _timesize=value;}
			get{return _timesize;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime timeFrom
		{
			set{ _timefrom=value;}
			get{return _timefrom;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime timeEnd
		{
			set{ _timeend=value;}
			get{return _timeend;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int place
		{
			set{ _place=value;}
			get{return _place;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string placeName
		{
			set{ _placename=value;}
			get{return _placename;}
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

