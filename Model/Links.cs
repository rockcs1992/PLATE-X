using System;
namespace Model
{
	/// <summary>
	/// 实体类Links 。(属性说明自动提取数据库字段的描述信息)
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
        /// 是否推荐
        /// </summary>
        public int istj
        {
            set { _istj = value; }
            get { return _istj; }
        }
		/// <summary>
		/// 自增ID
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 链接Item Name
		/// </summary>
		public string linkname
		{
			set{ _linkname=value;}
			get{return _linkname;}
		}
		/// <summary>
		/// 链接标题
		/// </summary>
		public string linktitle
		{
			set{ _linktitle=value;}
			get{return _linktitle;}
		}
		/// <summary>
		/// 链接路径
		/// </summary>
		public string linkurl
		{
			set{ _linkurl=value;}
			get{return _linkurl;}
		}
		/// <summary>
		/// 添加时间
		/// </summary>
		public DateTime addtime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		#endregion Model

	}
}

