using System;
namespace Model
{
	/// <summary>
	/// ʵ����OnLinePayStatus ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class OnLinePayStatus
	{
		public OnLinePayStatus()
		{}
		#region Model
		private int _id;
		private string _orderno;
		private int _onlinepaytype;
		private int _paystatus;
		private int _status;
		private int _count;
		private string _remark;
		private DateTime _addtime;
		/// <summary>
		/// ����ID
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// Order ID
		/// </summary>
		public string orderNo
		{
			set{ _orderno=value;}
			get{return _orderno;}
		}
		/// <summary>
		/// ���߸���I am a��1֧������2�Ƹ�ͨ��3����
		/// </summary>
		public int onLinePayType
		{
			set{ _onlinepaytype=value;}
			get{return _onlinepaytype;}
		}
		/// <summary>
		/// ����״̬��0δ����1�Ѹ�
		/// </summary>
		public int payStatus
		{
			set{ _paystatus=value;}
			get{return _paystatus;}
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
		/// ���ش���
		/// </summary>
		public int count
		{
			set{ _count=value;}
			get{return _count;}
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
		/// ���ʱ��
		/// </summary>
		public DateTime addTime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		#endregion Model

	}
}

