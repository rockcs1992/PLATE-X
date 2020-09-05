using System;
namespace Model
{
	/// <summary>
	/// AnswerInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class AnswerInfo
	{
		public AnswerInfo()
		{}
		#region Model
		private int _id;
		private int _questionid;
		private string _answercontent;
		private string _answerdesc;
		private string _remark;
		private int _status;
		private int _isgood;
		private int _isbad;
		private int _istj;
		private int _ishot;
		private int _isnew;
		private DateTime _addtime;
		private int _adduser;
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
		public int questionId
		{
			set{ _questionid=value;}
			get{return _questionid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string answerContent
		{
			set{ _answercontent=value;}
			get{return _answercontent;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string answerDesc
		{
			set{ _answerdesc=value;}
			get{return _answerdesc;}
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
		public int status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int isGood
		{
			set{ _isgood=value;}
			get{return _isgood;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int isBad
		{
			set{ _isbad=value;}
			get{return _isbad;}
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
		public int infoType
		{
			set{ _infotype=value;}
			get{return _infotype;}
		}
		#endregion Model

	}
}

