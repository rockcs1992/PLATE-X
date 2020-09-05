using System;
namespace Model
{
	/// <summary>
	/// Pv:ʵ����(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public partial class Pv
	{
		public Pv()
		{}
		#region Model
		private int _id;
		private string _pagename;
		private string _pagevalue;
		private int _viewscount;
		private DateTime _addtime;
		private string _ip;
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
		/// ҳ��Item Name
		/// </summary>
		public string pageName
		{
			set{ _pagename=value;}
			get{return _pagename;}
		}
		/// <summary>
		/// ҳ��ֵ
		/// </summary>
		public string pageValue
		{
			set{ _pagevalue=value;}
			get{return _pagevalue;}
		}
		/// <summary>
		/// �������
		/// </summary>
		public int viewsCount
		{
			set{ _viewscount=value;}
			get{return _viewscount;}
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
		/// IP
		/// </summary>
		public string ip
		{
			set{ _ip=value;}
			get{return _ip;}
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

