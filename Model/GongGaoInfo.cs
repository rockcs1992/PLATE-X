using System;
namespace Model
{
	/// <summary>
	/// 实体类GongGaoInfo 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class GongGaoInfo
	{
		public GongGaoInfo()
		{}
		#region Model
		private int _id;
		private string _title;
		private string _gonggaocontent;
		private int _status;
		private DateTime _addtime;
		private int _adduser;
		private int _infotype;
        private string _linkurl;

        /// <summary>
        /// 连接路径
        /// </summary>
        public string linkurl
        {
            set { _linkurl = value; }
            get { return _linkurl; }
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
		/// 标题
		/// </summary>
		public string title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 内容
		/// </summary>
		public string gongGaoContent
		{
			set{ _gonggaocontent=value;}
			get{return _gonggaocontent;}
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
		/// <summary>
		/// 信息I am a
		/// </summary>
		public int infoType
		{
			set{ _infotype=value;}
			get{return _infotype;}
		}
		#endregion Model

	}
}

