using System;
namespace Model
{
	/// <summary>
	/// ShoperInfo:ʵ����(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public partial class ShoperInfo
	{
		public ShoperInfo()
		{}
		#region Model
		private int _id;
		private string _shopername;
		private string _imgurl;
		private string _tel;
		private string _mobile;
		private double _price;
		private int _pid;
		private int _cid;
		private int _regionid;
		private string _address;
		private string _remark;
		private int _status;
		private DateTime _addtime;
		private int _adduser;
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
		/// ������Item Name
		/// </summary>
		public string shoperName
		{
			set{ _shopername=value;}
			get{return _shopername;}
		}
		/// <summary>
		/// logo
		/// </summary>
		public string imgUrl
		{
			set{ _imgurl=value;}
			get{return _imgurl;}
		}
		/// <summary>
		/// �绰
		/// </summary>
		public string tel
		{
			set{ _tel=value;}
			get{return _tel;}
		}
		/// <summary>
		/// Phone
		/// </summary>
		public string mobile
		{
			set{ _mobile=value;}
			get{return _mobile;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public double price
		{
			set{ _price=value;}
			get{return _price;}
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
		/// ��
		/// </summary>
		public int cid
		{
			set{ _cid=value;}
			get{return _cid;}
		}
		/// <summary>
		/// ��Ȧ
		/// </summary>
		public int regionId
		{
			set{ _regionid=value;}
			get{return _regionid;}
		}
		/// <summary>
		/// ��ϸ��ַ
		/// </summary>
		public string address
		{
			set{ _address=value;}
			get{return _address;}
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

