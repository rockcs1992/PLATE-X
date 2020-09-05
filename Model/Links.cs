using System;
namespace Model
{
	/// <summary>
	/// ʵ����Links ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class Links
	{
		public Links()
		{}
		#region Model
		private int _id;
		private string _linkname;
		private string _linktitle;
		private string _linkurl;
		private DateTime _addtime;
        private int _istj;
        /// <summary>
        /// �Ƿ��Ƽ�
        /// </summary>
        public int istj
        {
            set { _istj = value; }
            get { return _istj; }
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
		/// ����Item Name
		/// </summary>
		public string linkname
		{
			set{ _linkname=value;}
			get{return _linkname;}
		}
		/// <summary>
		/// ���ӱ���
		/// </summary>
		public string linktitle
		{
			set{ _linktitle=value;}
			get{return _linktitle;}
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
		/// ���ʱ��
		/// </summary>
		public DateTime addtime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		#endregion Model

	}
}

