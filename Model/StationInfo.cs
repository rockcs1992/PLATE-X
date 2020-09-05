using System;
namespace Model
{
	/// <summary>
	/// StationInfo:ʵ����(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
		/// ����ID
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// ����ID
		/// </summary>
		public int subwayId
		{
			set{ _subwayid=value;}
			get{return _subwayid;}
		}
		/// <summary>
		/// ����Item Name
		/// </summary>
		public string subwayName
		{
			set{ _subwayname=value;}
			get{return _subwayname;}
		}
		/// <summary>
		/// վ̨Item Name
		/// </summary>
		public string stationName
		{
			set{ _stationname=value;}
			get{return _stationname;}
		}
		/// <summary>
		/// վ̨��
		/// </summary>
		public int stationNumber
		{
			set{ _stationnumber=value;}
			get{return _stationnumber;}
		}
		/// <summary>
		/// ��/����
		/// </summary>
		public string lineDirect
		{
			set{ _linedirect=value;}
			get{return _linedirect;}
		}
		/// <summary>
		/// �Ƿ񻻳�վ
		/// </summary>
		public int isTransfer
		{
			set{ _istransfer=value;}
			get{return _istransfer;}
		}
		/// <summary>
		/// ״̬
		/// </summary>
		public int status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// ��ע
		/// </summary>
		public string remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// ��ϢI am a
		/// </summary>
		public int infoType
		{
			set{ _infotype=value;}
			get{return _infotype;}
		}
		#endregion Model

	}
}

