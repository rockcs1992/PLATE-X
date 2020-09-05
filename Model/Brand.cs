using System;
namespace Model
{
	/// <summary>
	/// Brand:实体类(属性说明自动提取数据库字段的描述信息)
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
		/// 主键ID
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 品牌Item Name
		/// </summary>
		public string brandName
		{
			set{ _brandname=value;}
			get{return _brandname;}
		}
		/// <summary>
		/// 上市时间
		/// </summary>
		public string brandNameEn
		{
			set{ _brandnameen=value;}
			get{return _brandnameen;}
		}
		/// <summary>
		/// 品牌值
		/// </summary>
		public int brandValue
		{
			set{ _brandvalue=value;}
			get{return _brandvalue;}
		}
		/// <summary>
		/// 主营产品
		/// </summary>
		public string mainProduct
		{
			set{ _mainproduct=value;}
			get{return _mainproduct;}
		}
		/// <summary>
		/// 所属国家
		/// </summary>
		public string country
		{
			set{ _country=value;}
			get{return _country;}
		}
		/// <summary>
		///官方网站
		/// </summary>
		public string website
		{
			set{ _website=value;}
			get{return _website;}
		}
		/// <summary>
		/// 基本信息
		/// </summary>
		public string baseInfo
		{
			set{ _baseinfo=value;}
			get{return _baseinfo;}
		}
		/// <summary>
		/// 图片路径
		/// </summary>
		public string imgURL
		{
			set{ _imgurl=value;}
			get{return _imgurl;}
		}
		/// <summary>
		/// 图片大小
		/// </summary>
		public string imgSize
		{
			set{ _imgsize=value;}
			get{return _imgsize;}
		}
		/// <summary>
		/// 图片高度
		/// </summary>
		public int height
		{
			set{ _height=value;}
			get{return _height;}
		}
		/// <summary>
		/// 图片宽度
		/// </summary>
		public int width
		{
			set{ _width=value;}
			get{return _width;}
		}
		/// <summary>
		/// 是否推荐
		/// </summary>
		public int ispromote
		{
			set{ _ispromote=value;}
			get{return _ispromote;}
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
		/// 添加时间
		/// </summary>
		public DateTime addTime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		/// <summary>
		/// 添加人
		/// </summary>
		public int addUser
		{
			set{ _adduser=value;}
			get{return _adduser;}
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

