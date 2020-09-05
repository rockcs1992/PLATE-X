using System;
namespace Model
{
	/// <summary>
	/// Message:ʵ����(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public partial class Message
	{
		public Message()
		{}
		#region Model
		private int _id;
		private int _pid;
		private int _shopid;
		private string _messcontent;
		private DateTime _addtime;
		private int _adduser;
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
		/// ʡ
		/// </summary>
		public int pid
		{
			set{ _pid=value;}
			get{return _pid;}
		}
		/// <summary>
		/// ����ID
		/// </summary>
		public int shopId
		{
			set{ _shopid=value;}
			get{return _shopid;}
		}
		/// <summary>
		/// ��Ϣ����
		/// </summary>
		public string messContent
		{
			set{ _messcontent=value;}
			get{return _messcontent;}
		}
		/// <summary>
		/// ���ʱ��
		/// </summary>
		public DateTime addTime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		/// <summary>
		/// �����
		/// </summary>
		public int addUser
		{
			set{ _adduser=value;}
			get{return _adduser;}
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

