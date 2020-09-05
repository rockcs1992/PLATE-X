using System;
namespace Model
{
	/// <summary>
	/// BindInfo:ʵ����(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
		/// ����ID
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// ����I am a
		/// </summary>
		public int dataType
		{
			set{ _datatype=value;}
			get{return _datatype;}
		}
		/// <summary>
		/// ����Item Name
		/// </summary>
		public string dataPara
		{
			set{ _datapara=value;}
			get{return _datapara;}
		}
		/// <summary>
		/// �û�ID
		/// </summary>
		public int userId
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
        /// ����ֵ
		/// </summary>
		public string dataValue
		{
			set{ _datavalue=value;}
			get{return _datavalue;}
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

