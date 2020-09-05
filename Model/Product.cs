using System;
namespace Model
{
	/// <summary>
	/// Product:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Product
	{
		public Product()
		{}
		#region Model
		private int _id;
		private string _proname;
		private string _pronameen;
		private int _producttype;
		private string _producttypename;
		private int _protype;
		private string _protypename;
		private int _oneid;
		private int _twoid;
		private int _threeid;
		private int _fourid;
		private string _listimgurl;
		private string _detailimg1;
		private string _detailimg2;
		private string _detailimg3;
		private string _detailimg4;
		private string _creditimg1;
		private string _creditimg2;
		private string _creditimg3;
		private string _creditimg4;
		private string _fromimg;
		private string _otherimg;
		private int _fromid;
		private string _fromname;
		private string _fromdesc;
		private int _brandid;
		private string _brandname;
		private int _varietyid;
		private string _varietyname;
		private int _relieveid;
		private string _relievename;
		private int _cookid;
		private string _cookname;
		private int _useid;
		private string _usename;
		private string _unit1;
		private double _price1;
		private string _unit2;
		private double _price2;
		private string _unit3;
		private double _price3;
		private string _unit4;
		private double _price4;
		private string _advantage;
		private string _saveinfo;
		private int _rankingtype;
		private string _rankingtypename;
		private int _ranking;
		private DateTime _listetime;
		private int _prograde;
		private string _progradename;
		private int _promaterial;
		private string _promaterialname;
		private int _speed;
		private int _stoptype;
		private string _stoptypename;
		private string _procontent;
		private string _prodesc;
		private string _imgdesc;
		private string _propertydesc;
		private string _labelinfo;
		private int _assesscount;
		private int _sharecount;
		private int _viewscount;
		private string _author;
		private int _istj;
		private int _ishot;
		private int _isnew;
		private int _goodcount;
		private int _badcount;
		private int _status;
		private string _remark;
		private DateTime _addtime;
		private int _adduser;
		private string _addusername;
		private int _savecount;
		private int _infotype;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string proName
		{
			set{ _proname=value;}
			get{return _proname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string proNameEn
		{
			set{ _pronameen=value;}
			get{return _pronameen;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int productType
		{
			set{ _producttype=value;}
			get{return _producttype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string productTypeName
		{
			set{ _producttypename=value;}
			get{return _producttypename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int proType
		{
			set{ _protype=value;}
			get{return _protype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string proTypeName
		{
			set{ _protypename=value;}
			get{return _protypename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int oneId
		{
			set{ _oneid=value;}
			get{return _oneid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int twoId
		{
			set{ _twoid=value;}
			get{return _twoid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int threeId
		{
			set{ _threeid=value;}
			get{return _threeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int fourId
		{
			set{ _fourid=value;}
			get{return _fourid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string listImgUrl
		{
			set{ _listimgurl=value;}
			get{return _listimgurl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string detailImg1
		{
			set{ _detailimg1=value;}
			get{return _detailimg1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string detailImg2
		{
			set{ _detailimg2=value;}
			get{return _detailimg2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string detailImg3
		{
			set{ _detailimg3=value;}
			get{return _detailimg3;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string detailImg4
		{
			set{ _detailimg4=value;}
			get{return _detailimg4;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string creditImg1
		{
			set{ _creditimg1=value;}
			get{return _creditimg1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string creditImg2
		{
			set{ _creditimg2=value;}
			get{return _creditimg2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string creditImg3
		{
			set{ _creditimg3=value;}
			get{return _creditimg3;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string creditImg4
		{
			set{ _creditimg4=value;}
			get{return _creditimg4;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string fromImg
		{
			set{ _fromimg=value;}
			get{return _fromimg;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string otherImg
		{
			set{ _otherimg=value;}
			get{return _otherimg;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int fromId
		{
			set{ _fromid=value;}
			get{return _fromid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string fromName
		{
			set{ _fromname=value;}
			get{return _fromname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string fromDesc
		{
			set{ _fromdesc=value;}
			get{return _fromdesc;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int brandId
		{
			set{ _brandid=value;}
			get{return _brandid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string brandName
		{
			set{ _brandname=value;}
			get{return _brandname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int varietyId
		{
			set{ _varietyid=value;}
			get{return _varietyid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string varietyName
		{
			set{ _varietyname=value;}
			get{return _varietyname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int relieveId
		{
			set{ _relieveid=value;}
			get{return _relieveid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string relieveName
		{
			set{ _relievename=value;}
			get{return _relievename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int cookId
		{
			set{ _cookid=value;}
			get{return _cookid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cookName
		{
			set{ _cookname=value;}
			get{return _cookname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int useId
		{
			set{ _useid=value;}
			get{return _useid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string useName
		{
			set{ _usename=value;}
			get{return _usename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string unit1
		{
			set{ _unit1=value;}
			get{return _unit1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public double price1
		{
			set{ _price1=value;}
			get{return _price1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string unit2
		{
			set{ _unit2=value;}
			get{return _unit2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public double price2
		{
			set{ _price2=value;}
			get{return _price2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string unit3
		{
			set{ _unit3=value;}
			get{return _unit3;}
		}
		/// <summary>
		/// 
		/// </summary>
		public double price3
		{
			set{ _price3=value;}
			get{return _price3;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string unit4
		{
			set{ _unit4=value;}
			get{return _unit4;}
		}
		/// <summary>
		/// 
		/// </summary>
		public double price4
		{
			set{ _price4=value;}
			get{return _price4;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string advantage
		{
			set{ _advantage=value;}
			get{return _advantage;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string saveInfo
		{
			set{ _saveinfo=value;}
			get{return _saveinfo;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int rankingType
		{
			set{ _rankingtype=value;}
			get{return _rankingtype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string rankingTypeName
		{
			set{ _rankingtypename=value;}
			get{return _rankingtypename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int ranking
		{
			set{ _ranking=value;}
			get{return _ranking;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime listeTime
		{
			set{ _listetime=value;}
			get{return _listetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int proGrade
		{
			set{ _prograde=value;}
			get{return _prograde;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string proGradeName
		{
			set{ _progradename=value;}
			get{return _progradename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int proMaterial
		{
			set{ _promaterial=value;}
			get{return _promaterial;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string proMaterialName
		{
			set{ _promaterialname=value;}
			get{return _promaterialname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int speed
		{
			set{ _speed=value;}
			get{return _speed;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int stopType
		{
			set{ _stoptype=value;}
			get{return _stoptype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string stopTypeName
		{
			set{ _stoptypename=value;}
			get{return _stoptypename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string proContent
		{
			set{ _procontent=value;}
			get{return _procontent;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string proDesc
		{
			set{ _prodesc=value;}
			get{return _prodesc;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ImgDesc
		{
			set{ _imgdesc=value;}
			get{return _imgdesc;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string propertyDesc
		{
			set{ _propertydesc=value;}
			get{return _propertydesc;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string labelInfo
		{
			set{ _labelinfo=value;}
			get{return _labelinfo;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int assessCount
		{
			set{ _assesscount=value;}
			get{return _assesscount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int shareCount
		{
			set{ _sharecount=value;}
			get{return _sharecount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int viewsCount
		{
			set{ _viewscount=value;}
			get{return _viewscount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string author
		{
			set{ _author=value;}
			get{return _author;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int isTj
		{
			set{ _istj=value;}
			get{return _istj;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int isHot
		{
			set{ _ishot=value;}
			get{return _ishot;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int isNew
		{
			set{ _isnew=value;}
			get{return _isnew;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int goodCount
		{
			set{ _goodcount=value;}
			get{return _goodcount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int badCount
		{
			set{ _badcount=value;}
			get{return _badcount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime addTime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int addUser
		{
			set{ _adduser=value;}
			get{return _adduser;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string addUserName
		{
			set{ _addusername=value;}
			get{return _addusername;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int saveCount
		{
			set{ _savecount=value;}
			get{return _savecount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int infoType
		{
			set{ _infotype=value;}
			get{return _infotype;}
		}
		#endregion Model

	}
}

