using System;
namespace Model
{
	/// <summary>
	/// 实体类BaseConfig 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class BaseConfig
	{
		public BaseConfig()
		{}
		#region Model
		private int _id;
		private int _protype;
		private string _proname;
		private string _provalue;
		private int _parentid;
		private int _status;
		private string _remark;
		/// <summary>
		/// 自增ID
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 项目I am a
		/// </summary>
		public int proType
		{
			set{ _protype=value;}
			get{return _protype;}
		}
		/// <summary>
		/// 项目Item Name
		/// </summary>
		public string proName
		{
			set{ _proname=value;}
			get{return _proname;}
		}
		/// <summary>
		/// 项目值
		/// </summary>
		public string proValue
		{
			set{ _provalue=value;}
			get{return _provalue;}
		}
		/// <summary>
		/// 父类ID
		/// </summary>
		public int parentId
		{
			set{ _parentid=value;}
			get{return _parentid;}
		}
		/// <summary>
		/// 状态
		/// </summary>
		public int status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		#endregion Model

	}
}

