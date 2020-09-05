/**  版本信息模板在安装目录下，可自行修改。
* ProperType.cs
*
* 功 能： N/A
* 类 名： ProperType
*
* Ver    变更日期             负责人  杨清锋
* ───────────────────────────────────
* V0.01  2014-8-28 15:36:38   N/A    初版
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
	/// ProperType:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ProperType
	{
		public ProperType()
		{}
		#region Model
		private int _id;
		private int _infotype;
		private string _propername;
		private string _propervalue;
		private int _parentid;
		private int _status;
		private string _remark;
		private DateTime _addtime;
		private int _adduser;
		/// <summary>
		/// 主键ID
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 信息I am a
		/// </summary>
		public int infoType
		{
			set{ _infotype=value;}
			get{return _infotype;}
		}
		/// <summary>
		/// 属性Item Name
		/// </summary>
		public string properName
		{
			set{ _propername=value;}
			get{return _propername;}
		}
		/// <summary>
		/// 属性值
		/// </summary>
		public string properValue
		{
			set{ _propervalue=value;}
			get{return _propervalue;}
		}
		/// <summary>
		/// 父类ID
		/// </summary>
		public int parentId
		{
			set{ _parentid=value;}
			get{return _parentid;}
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
		#endregion Model

	}
}

