using System;
namespace Model
{
	/// <summary>
	/// RedPacage:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class RedPacage
	{
		public RedPacage()
		{}
		#region Model
		private int _id;
		private int _typeid;
		private string _typename;
		private string _packagename;
		private double _moneyvalue;
		private DateTime _fromtime;
		private DateTime _endtime;
		private int _status;
		private int _is_use;
		private string _packagedesc;
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
		public string packageName
		{
			set{ _packagename=value;}
			get{return _packagename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public double moneyValue
		{
			set{ _moneyvalue=value;}
			get{return _moneyvalue;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime fromTime
		{
			set{ _fromtime=value;}
			get{return _fromtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime endTime
		{
			set{ _endtime=value;}
			get{return _endtime;}
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
		public int is_use
		{
			set{ _is_use=value;}
			get{return _is_use;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string packageDesc
		{
			set{ _packagedesc=value;}
			get{return _packagedesc;}
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

