using System;
namespace Model
{
	/// <summary>
	/// BindInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class BindInfo
	{
		public BindInfo()
		{}
		#region Model
		private int _id;
		private int _datatype;
		private string _datapara;
		private int _userid;
		private string _datavalue;
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
		/// 数据I am a
		/// </summary>
		public int dataType
		{
			set{ _datatype=value;}
			get{return _datatype;}
		}
		/// <summary>
		/// 参数Item Name
		/// </summary>
		public string dataPara
		{
			set{ _datapara=value;}
			get{return _datapara;}
		}
		/// <summary>
		/// 用户ID
		/// </summary>
		public int userId
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
        /// 数据值
		/// </summary>
		public string dataValue
		{
			set{ _datavalue=value;}
			get{return _datavalue;}
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

