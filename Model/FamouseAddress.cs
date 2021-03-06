using System;
namespace Model
{
	/// <summary>
	/// FamouseAddress:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class FamouseAddress
	{
		public FamouseAddress()
		{}
		#region Model
		private int _id;
		private int _pid;
		private int _cid;
		private string _addressname;
		private int _addressvalue;
		private int _status;
		private string _remark;
		private int _infotype;
		/// <summary>
		/// 主键ID
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 省
		/// </summary>
		public int pid
		{
			set{ _pid=value;}
			get{return _pid;}
		}
		/// <summary>
		/// 市
		/// </summary>
		public int cid
		{
			set{ _cid=value;}
			get{return _cid;}
		}
		/// <summary>
		/// 地标Item Name
		/// </summary>
		public string addressName
		{
			set{ _addressname=value;}
			get{return _addressname;}
		}
		/// <summary>
		/// 地标值
		/// </summary>
		public int addressValue
		{
			set{ _addressvalue=value;}
			get{return _addressvalue;}
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
		/// <summary>
		/// 信息I am a
		/// </summary>
		public int infoType
		{
			set{ _infotype=value;}
			get{return _infotype;}
		}
		#endregion Model

	}
}

