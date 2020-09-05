using System;
namespace Model
{
	/// <summary>
	/// ʵ����KeyWordInfo ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class KeyWordInfo
	{
		public KeyWordInfo()
		{}
		#region Model
		private int _id;
		private string _pagename;
		private string _title;
		private string _keyword;
		private string _description;
		private string _pagenamevalue;
		/// <summary>
		/// ����ID
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// ҳ��Item Name������˵��
		/// </summary>
		public string pageName
		{
			set{ _pagename=value;}
			get{return _pagename;}
		}
		/// <summary>
		/// ҳ�����
		/// </summary>
		public string title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// �ؼ���
		/// </summary>
		public string keyword
		{
			set{ _keyword=value;}
			get{return _keyword;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public string description
		{
			set{ _description=value;}
			get{return _description;}
		}
		/// <summary>
		/// ҳ��·��
		/// </summary>
		public string pageNameValue
		{
			set{ _pagenamevalue=value;}
			get{return _pagenamevalue;}
		}
		#endregion Model

	}
}

