using System;
namespace Model
{
	/// <summary>
	/// Invite:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Invite
	{
		public Invite()
		{}
		#region Model
		private int _id;
		private int _invitetype;
		private string _invitename;
		private string _inviteinfo;
		private string _invitedesc;
		private DateTime _addtime;
		private int _status;
        private string _inforemark;
        private string _descremark;
        /// <summary>
        /// 
        /// </summary>
        public string inforemark
        {
            set { _inforemark = value; }
            get { return _inforemark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string descremark
        {
            set { _descremark = value; }
            get { return _descremark; }
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
		public int inviteType
		{
			set{ _invitetype=value;}
			get{return _invitetype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string inviteName
		{
			set{ _invitename=value;}
			get{return _invitename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string inviteInfo
		{
			set{ _inviteinfo=value;}
			get{return _inviteinfo;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string inviteDesc
		{
			set{ _invitedesc=value;}
			get{return _invitedesc;}
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
		public int status
		{
			set{ _status=value;}
			get{return _status;}
		}
		#endregion Model

	}
}

