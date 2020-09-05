/**  版本信息模板在安装目录下，可自行修改。
* ProductProperty.cs
*
* 功 能： N/A
* 类 名： ProductProperty
*
* Ver    变更日期             负责人  杨清锋
* ───────────────────────────────────
* V0.01  2014-8-28 15:36:38   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：千晨科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace Model
{
	/// <summary>
	/// ProductProperty:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ProductProperty
	{
		public ProductProperty()
		{}
		#region Model
		private int _id;
		private int _productid;
		private int _propertype;
		private string _propertypename;
		private string _propervalue;
		private int _status;
		private string _remark;
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
		/// 产品ID
		/// </summary>
		public int productId
		{
			set{ _productid=value;}
			get{return _productid;}
		}
		/// <summary>
		/// 属性I am a
		/// </summary>
		public int properType
		{
			set{ _propertype=value;}
			get{return _propertype;}
		}
		/// <summary>
		/// 属性I am aItem Name
		/// </summary>
		public string properTypeName
		{
			set{ _propertypename=value;}
			get{return _propertypename;}
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

