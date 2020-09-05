using System;
namespace Model
{
	/// <summary>
	/// UserMemberInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class UserMemberInfo
	{
		public UserMemberInfo()
		{}
		#region Model
		private int _id;
		private int _userid;
		private int _memcount;
		private int _ishaveaccountuser;
		private int _managememcount;
		private int _taskuserworkyears;
		private string _busiusername;
		private string _tel;
		private string _address;
		private string _zipcode;
		private string _email;
		private string _fax;
		private string _institutedesc;
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
		public int userId
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int memCount
		{
			set{ _memcount=value;}
			get{return _memcount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int isHaveAccountUser
		{
			set{ _ishaveaccountuser=value;}
			get{return _ishaveaccountuser;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int manageMemCount
		{
			set{ _managememcount=value;}
			get{return _managememcount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int taskUserWorkYears
		{
			set{ _taskuserworkyears=value;}
			get{return _taskuserworkyears;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string busiUserName
		{
			set{ _busiusername=value;}
			get{return _busiusername;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string tel
		{
			set{ _tel=value;}
			get{return _tel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string address
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string zipCode
		{
			set{ _zipcode=value;}
			get{return _zipcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string fax
		{
			set{ _fax=value;}
			get{return _fax;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string instituteDesc
		{
			set{ _institutedesc=value;}
			get{return _institutedesc;}
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

