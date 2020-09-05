using System;
namespace Model
{
	/// <summary>
	/// ʵ����BaseConfig ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class BaseConfig
	{
		public BaseConfig()
		{}
		#region Model
		private int _id;
		private int _protype;
		private string _proname;
		private string _provalue;
		private int _parentid;
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
		/// ��ĿI am a
		/// </summary>
		public int proType
		{
			set{ _protype=value;}
			get{return _protype;}
		}
		/// <summary>
		/// ��ĿItem Name
		/// </summary>
		public string proName
		{
			set{ _proname=value;}
			get{return _proname;}
		}
		/// <summary>
		/// ��Ŀֵ
		/// </summary>
		public string proValue
		{
			set{ _provalue=value;}
			get{return _provalue;}
		}
		/// <summary>
		/// ����ID
		/// </summary>
		public int parentId
		{
			set{ _parentid=value;}
			get{return _parentid;}
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

