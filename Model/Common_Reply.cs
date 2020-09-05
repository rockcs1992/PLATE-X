/**  版本信息模板在安装目录下，可自行修改。
* Common_Reply.cs
*
* 功 能： N/A
* 类 名： Common_Reply
*
* Ver    变更日期             负责人  杨清锋
* ───────────────────────────────────
* V0.01  2014-8-28 15:36:37   N/A    初版
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
	/// Common_Reply:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Common_Reply
	{
		public Common_Reply()
		{}
		#region Model
		private int _id;
		private int _mesid;
		private string _replytitle;
		private string _replycontent;
		private string _remark;
		private int _status;
		private DateTime _addtime;
		private int _adduserid;
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
		/// 信息ID
		/// </summary>
		public int mesId
		{
			set{ _mesid=value;}
			get{return _mesid;}
		}
		/// <summary>
		/// 回复标题
		/// </summary>
		public string replyTitle
		{
			set{ _replytitle=value;}
			get{return _replytitle;}
		}
		/// <summary>
		/// 回复内容
		/// </summary>
		public string replyContent
		{
			set{ _replycontent=value;}
			get{return _replycontent;}
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
		/// 状态
		/// </summary>
		public int status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 回复时间
		/// </summary>
		public DateTime addTime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		/// <summary>
		/// 回复人
		/// </summary>
		public int addUserId
		{
			set{ _adduserid=value;}
			get{return _adduserid;}
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

