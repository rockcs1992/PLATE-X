using System;
namespace Model.Model
{
	/// <summary>
	/// CaseType:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class CaseType
	{
		public CaseType()
		{}
		#region Model
		private int _id;
		private string _typename;
		private string _typedesc;
		private string _typeimg;
		private int? _status;
		private string _remark;
		private DateTime? _addtime;
		private int? _infotype;
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
		public string typeDesc
		{
			set{ _typedesc=value;}
			get{return _typedesc;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string typeImg
		{
			set{ _typeimg=value;}
			get{return _typeimg;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? status
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
		public DateTime? addTime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? infoType
		{
			set{ _infotype=value;}
			get{return _infotype;}
		}
		#endregion Model

	}
}

