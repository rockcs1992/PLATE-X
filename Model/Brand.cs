using System;
namespace Model
{
	/// <summary>
	/// Brand:ʵ����(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public partial class Brand
	{
		public Brand()
		{}
		#region Model
		private int _id;
		private string _brandname;
		private string _brandnameen;
		private int _brandvalue;
		private string _mainproduct;
		private string _country;
		private string _website;
		private string _baseinfo;
		private string _imgurl;
		private string _imgsize;
		private int _height;
		private int _width;
		private int _ispromote;
		private int _status;
		private string _remark;
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
		/// Ʒ��Item Name
		/// </summary>
		public string brandName
		{
			set{ _brandname=value;}
			get{return _brandname;}
		}
		/// <summary>
		/// ����ʱ��
		/// </summary>
		public string brandNameEn
		{
			set{ _brandnameen=value;}
			get{return _brandnameen;}
		}
		/// <summary>
		/// Ʒ��ֵ
		/// </summary>
		public int brandValue
		{
			set{ _brandvalue=value;}
			get{return _brandvalue;}
		}
		/// <summary>
		/// ��Ӫ��Ʒ
		/// </summary>
		public string mainProduct
		{
			set{ _mainproduct=value;}
			get{return _mainproduct;}
		}
		/// <summary>
		/// ��������
		/// </summary>
		public string country
		{
			set{ _country=value;}
			get{return _country;}
		}
		/// <summary>
		///�ٷ���վ
		/// </summary>
		public string website
		{
			set{ _website=value;}
			get{return _website;}
		}
		/// <summary>
		/// ������Ϣ
		/// </summary>
		public string baseInfo
		{
			set{ _baseinfo=value;}
			get{return _baseinfo;}
		}
		/// <summary>
		/// ͼƬ·��
		/// </summary>
		public string imgURL
		{
			set{ _imgurl=value;}
			get{return _imgurl;}
		}
		/// <summary>
		/// ͼƬ��С
		/// </summary>
		public string imgSize
		{
			set{ _imgsize=value;}
			get{return _imgsize;}
		}
		/// <summary>
		/// ͼƬ�߶�
		/// </summary>
		public int height
		{
			set{ _height=value;}
			get{return _height;}
		}
		/// <summary>
		/// ͼƬ���
		/// </summary>
		public int width
		{
			set{ _width=value;}
			get{return _width;}
		}
		/// <summary>
		/// �Ƿ��Ƽ�
		/// </summary>
		public int ispromote
		{
			set{ _ispromote=value;}
			get{return _ispromote;}
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

