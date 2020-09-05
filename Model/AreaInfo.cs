using System;
namespace Model
{
	/// <summary>
	/// AreaInfo:ʵ����(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public partial class AreaInfo
	{
		public AreaInfo()
		{}
		#region Model
		private int _id;
		private string _areaname;
		private int _parentid;
		private string _charindex;
		private string _remark;
		private int _status;
		private int _infotype;
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
		public string areaName
		{
			set{ _areaname=value;}
			get{return _areaname;}
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
		/// �ַ���ʶ
		/// </summary>
		public string charIndex
		{
			set{ _charindex=value;}
			get{return _charindex;}
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
		/// ״̬
		/// </summary>
		public int status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// ��ϢI am a
		/// </summary>
		public int infoType
		{
			set{ _infotype=value;}
			get{return _infotype;}
		}
		#endregion Model

	}
}

