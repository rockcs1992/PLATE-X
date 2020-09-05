using System;
namespace Model
{
	/// <summary>
	/// StationInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class StationInfo
	{
		public StationInfo()
		{}
		#region Model
		private int _id;
		private int _subwayid;
		private string _subwayname;
		private string _stationname;
		private int _stationnumber;
		private string _linedirect;
		private int _istransfer;
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
		/// 地铁ID
		/// </summary>
		public int subwayId
		{
			set{ _subwayid=value;}
			get{return _subwayid;}
		}
		/// <summary>
		/// 地铁Item Name
		/// </summary>
		public string subwayName
		{
			set{ _subwayname=value;}
			get{return _subwayname;}
		}
		/// <summary>
		/// 站台Item Name
		/// </summary>
		public string stationName
		{
			set{ _stationname=value;}
			get{return _stationname;}
		}
		/// <summary>
		/// 站台号
		/// </summary>
		public int stationNumber
		{
			set{ _stationnumber=value;}
			get{return _stationnumber;}
		}
		/// <summary>
		/// 上/下行
		/// </summary>
		public string lineDirect
		{
			set{ _linedirect=value;}
			get{return _linedirect;}
		}
		/// <summary>
		/// 是否换乘站
		/// </summary>
		public int isTransfer
		{
			set{ _istransfer=value;}
			get{return _istransfer;}
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

