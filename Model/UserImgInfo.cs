using System;
namespace Model
{
	/// <summary>
	/// UserImgInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class UserImgInfo
	{
		public UserImgInfo()
		{}
		#region Model
		private int _id;
		private int _userid;
		private int _usertype;
		private string _imgurl;
		private string _imgtitle;
		private string _imglink;
		private string _imgdesc;
		private int _status;
		private string _remark;
		private DateTime _addtime;
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
		public int userId
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int userType
		{
			set{ _usertype=value;}
			get{return _usertype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string imgUrl
		{
			set{ _imgurl=value;}
			get{return _imgurl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string imgTitle
		{
			set{ _imgtitle=value;}
			get{return _imgtitle;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string imgLink
		{
			set{ _imglink=value;}
			get{return _imglink;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string imgDesc
		{
			set{ _imgdesc=value;}
			get{return _imgdesc;}
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
		public int infoType
		{
			set{ _infotype=value;}
			get{return _infotype;}
		}
		#endregion Model

	}
}

