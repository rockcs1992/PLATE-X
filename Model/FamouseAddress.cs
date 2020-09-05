using System;
namespace Model
{
	/// <summary>
	/// FamouseAddress:ʵ����(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public partial class FamouseAddress
	{
		public FamouseAddress()
		{}
		#region Model
		private int _id;
		private int _pid;
		private int _cid;
		private string _addressname;
		private int _addressvalue;
		private int _status;
		private string _remark;
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
		/// ʡ
		/// </summary>
		public int pid
		{
			set{ _pid=value;}
			get{return _pid;}
		}
		/// <summary>
		/// ��
		/// </summary>
		public int cid
		{
			set{ _cid=value;}
			get{return _cid;}
		}
		/// <summary>
		/// �ر�Item Name
		/// </summary>
		public string addressName
		{
			set{ _addressname=value;}
			get{return _addressname;}
		}
		/// <summary>
		/// �ر�ֵ
		/// </summary>
		public int addressValue
		{
			set{ _addressvalue=value;}
			get{return _addressvalue;}
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

