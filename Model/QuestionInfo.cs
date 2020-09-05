using System;
namespace Model
{
	/// <summary>
	/// QuestionInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class QuestionInfo
	{
		public QuestionInfo()
		{}
		#region Model
		private int _id;
		private int _docdepartid;
		private int _illtypeid;
		private int _infotypeid;
		private int _othertypeid;
		private string _questiontitle;
		private string _questioncontent;
		private string _questiondesc;
		private string _questionremark;
		private string _remark;
		private int _status;
		private DateTime _addtime;
		private int _adduser;
		private int _infotype;
        private int _answerCount;
        /// <summary>
        /// 
        /// </summary>
        public int answerCount
        {
            set { _answerCount = value; }
            get { return _answerCount; }
        }
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
		public int docDepartId
		{
			set{ _docdepartid=value;}
			get{return _docdepartid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int illTypeId
		{
			set{ _illtypeid=value;}
			get{return _illtypeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int infoTypeId
		{
			set{ _infotypeid=value;}
			get{return _infotypeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int otherTypeId
		{
			set{ _othertypeid=value;}
			get{return _othertypeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string questionTitle
		{
			set{ _questiontitle=value;}
			get{return _questiontitle;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string questionContent
		{
			set{ _questioncontent=value;}
			get{return _questioncontent;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string questionDesc
		{
			set{ _questiondesc=value;}
			get{return _questiondesc;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string questionRemark
		{
			set{ _questionremark=value;}
			get{return _questionremark;}
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

