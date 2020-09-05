using System;
namespace Model
{
	/// <summary>
	/// ProperValue:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ProperValue
	{
		public ProperValue()
		{}
		#region Model
		private int _id;
        private int _infoType;
        private int _parentId;
		private int _properid;
		private string _propervalue;
		private int _status;
		private string _remark;
		private DateTime _addtime;
		private int _adduser;
        /// <summary>
        /// 信息I am a
        /// </summary>
        public int infoType
        {
            set { _infoType = value; }
            get { return _infoType; }
        }
        /// <summary>
        /// 父类ID
        /// </summary>
        public int parentId
        {
            set { _parentId = value; }
            get { return _parentId; }
        }
		/// <summary>
		/// 主键ID
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 属性ID
		/// </summary>
		public int properId
		{
			set{ _properid=value;}
			get{return _properid;}
		}
		/// <summary>
		/// 属性值
		/// </summary>
		public string properValue
		{
			set{ _propervalue=value;}
			get{return _propervalue;}
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
		#endregion Model

	}
}

