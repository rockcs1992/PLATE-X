using System;
namespace Model
{
	/// <summary>
	/// Shoper_User:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Shoper_User
	{
		public Shoper_User()
		{}
		#region Model
		private int _id;
		private int _shoperid;
		private string _shopername;
		private DateTime _addtime;
		private int _status;
		private string _remark;
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
		public int shoperId
		{
			set{ _shoperid=value;}
			get{return _shoperid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string shoperName
		{
			set{ _shopername=value;}
			get{return _shopername;}
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
		public int infoType
		{
			set{ _infotype=value;}
			get{return _infotype;}
		}
		#endregion Model

	}
}

