/**  版本信息模板在安装目录下，可自行修改。
* Common_Links.cs
*
* 功 能： N/A
* 类 名： Common_Links
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-8-28 15:36:36   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：北京千晨科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace Model
{
	/// <summary>
	/// Common_Links:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Common_Links
	{
		public Common_Links()
		{}
		#region Model
		private int _id;
		private int _linktype;
		private int _linkplace;
		private string _linkname;
		private string _linktitle;
		private string _imgurl;
		private string _linkurl;
		private int _is_target;
		private int _ishot;
		private int _istj;
		private int _ordernum;
		private string _remark;
		private DateTime _addtime;
		private int _adduser;
		private int _status;
		private int _infotype;
		/// <summary>
		/// 主键ID
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 链接I am a
		/// </summary>
		public int linkType
		{
			set{ _linktype=value;}
			get{return _linktype;}
		}
		/// <summary>
		/// 链接放置位置
		/// </summary>
		public int linkPlace
		{
			set{ _linkplace=value;}
			get{return _linkplace;}
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
		/// 图片路径
		/// </summary>
		public string imgurl
		{
			set{ _imgurl=value;}
			get{return _imgurl;}
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
		/// 链接打开模式
		/// </summary>
		public int is_target
		{
			set{ _is_target=value;}
			get{return _is_target;}
		}
		/// <summary>
		/// 是否热点
		/// </summary>
		public int isHot
		{
			set{ _ishot=value;}
			get{return _ishot;}
		}
		/// <summary>
		/// 是否推荐
		/// </summary>
		public int isTj
		{
			set{ _istj=value;}
			get{return _istj;}
		}
		/// <summary>
		/// 顺序号
		/// </summary>
		public int orderNum
		{
			set{ _ordernum=value;}
			get{return _ordernum;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string remark
		{
			set{ _remark=value;}
			get{return _remark;}
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
		/// 状态
		/// </summary>
		public int status
		{
			set{ _status=value;}
			get{return _status;}
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

