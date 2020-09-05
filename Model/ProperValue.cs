using System;
namespace Model
{
	/// <summary>
	/// ProperValue:ʵ����(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
        /// ��ϢI am a
        /// </summary>
        public int infoType
        {
            set { _infoType = value; }
            get { return _infoType; }
        }
        /// <summary>
        /// ����ID
        /// </summary>
        public int parentId
        {
            set { _parentId = value; }
            get { return _parentId; }
        }
		/// <summary>
		/// ����ID
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// ����ID
		/// </summary>
		public int properId
		{
			set{ _properid=value;}
			get{return _properid;}
		}
		/// <summary>
		/// ����ֵ
		/// </summary>
		public string properValue
		{
			set{ _propervalue=value;}
			get{return _propervalue;}
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
		#endregion Model

	}
}

