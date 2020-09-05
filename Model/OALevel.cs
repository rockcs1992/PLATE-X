using System;
namespace Model
{
	/// <summary>
	/// ʵ����OALevel ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class OALevel
	{
		public OALevel()
		{}
		#region Model
		private int _id;
		private string _levelname;
		private int _levelno;
		private int _isparent;
		private int _parentlevelno;
		private string _url;
		private int _status;
		private string _remark;
		/// <summary>
		/// ����ID
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// Ȩ��Item Name
		/// </summary>
		public string levelName
		{
			set{ _levelname=value;}
			get{return _levelname;}
		}
		/// <summary>
		/// Ȩ�ޱ��
		/// </summary>
		public int levelNO
		{
			set{ _levelno=value;}
			get{return _levelno;}
		}
		/// <summary>
		/// �Ƿ񸸽ڵ�
		/// </summary>
		public int isParent
		{
			set{ _isparent=value;}
			get{return _isparent;}
		}
		/// <summary>
		/// ���ڵ�Ȩ�ޱ��
		/// </summary>
		public int parentLevelNo
		{
			set{ _parentlevelno=value;}
			get{return _parentlevelno;}
		}
		/// <summary>
		/// ����·��
		/// </summary>
		public string url
		{
			set{ _url=value;}
			get{return _url;}
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
		#endregion Model

	}
}

