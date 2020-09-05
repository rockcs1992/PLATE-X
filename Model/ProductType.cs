using System;
namespace Model
{
	/// <summary>
	/// ProductType:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ProductType
	{
		public ProductType()
		{}
		#region Model
		private int _id;
		private string _typename;
		private int _parentid;
		private int _oneid;
		private string _onename;
		private int _twoid;
		private string _twoname;
		private int _threeid;
		private string _threename;
		private int _fourid;
		private string _fourname;
		private string _imgurl;
		private string _diaryimg;
		private string _typecontent;
		private string _typedesc;
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
		public int oneId
		{
			set{ _oneid=value;}
			get{return _oneid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string oneName
		{
			set{ _onename=value;}
			get{return _onename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int twoId
		{
			set{ _twoid=value;}
			get{return _twoid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string twoName
		{
			set{ _twoname=value;}
			get{return _twoname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int threeId
		{
			set{ _threeid=value;}
			get{return _threeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string threeName
		{
			set{ _threename=value;}
			get{return _threename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int fourId
		{
			set{ _fourid=value;}
			get{return _fourid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string fourName
		{
			set{ _fourname=value;}
			get{return _fourname;}
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
		public string diaryImg
		{
			set{ _diaryimg=value;}
			get{return _diaryimg;}
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
		public string typeDesc
		{
			set{ _typedesc=value;}
			get{return _typedesc;}
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

