using System;
namespace Model
{
	/// <summary>
	/// ʵ����FriendsInfo ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class FriendsInfo
	{
		public FriendsInfo()
		{}
		#region Model
		private int _id;
		private string _title;
		private string _alt;
		private string _img1path;
		private string _img2path;
		private string _linkurl;
		private int _ordernum;
		private int _status;
		private DateTime _addtime;
		private int _adduser;
		private int _infotype;
		/// <summary>
		/// ����
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public string title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// alt
		/// </summary>
		public string alt
		{
			set{ _alt=value;}
			get{return _alt;}
		}
		/// <summary>
		/// ͼƬ1·��
		/// </summary>
		public string img1path
		{
			set{ _img1path=value;}
			get{return _img1path;}
		}
		/// <summary>
		/// ͼƬ2·��
		/// </summary>
		public string img2Path
		{
			set{ _img2path=value;}
			get{return _img2path;}
		}
		/// <summary>
		/// ����·��
		/// </summary>
		public string linkurl
		{
			set{ _linkurl=value;}
			get{return _linkurl;}
		}
		/// <summary>
		/// ˳���
		/// </summary>
		public int orderNum
		{
			set{ _ordernum=value;}
			get{return _ordernum;}
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

