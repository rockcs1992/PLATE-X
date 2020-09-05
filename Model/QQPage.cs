using System;
namespace Model
{
	/// <summary>
	/// QQPage:ʵ����(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public partial class QQPage
	{
		public QQPage()
		{}
		#region Model
		private int _id;
		private string _qqinfo;
		private string _inforemark;
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
		/// qq��Ϣ
		/// </summary>
		public string qqInfo
		{
			set{ _qqinfo=value;}
			get{return _qqinfo;}
		}
		/// <summary>
		/// ��Ϣ��ע
		/// </summary>
		public string infoRemark
		{
			set{ _inforemark=value;}
			get{return _inforemark;}
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

