/**  版本信息模板在安装目录下，可自行修改。
* ProductImg.cs
*
* 功 能： N/A
* 类 名： ProductImg
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
	/// ProductImg:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ProductImg
	{
		public ProductImg()
		{}
		#region Model
		private int _id;
		private int _productid;
		private string _imgurl;
		private string _title;
		private string _alt;
		private string _linkurl;
		private int _status;
		private string _remark;
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
		/// 图片路径
		/// </summary>
		public string imgURL
		{
			set{ _imgurl=value;}
			get{return _imgurl;}
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
		/// alt
		/// </summary>
		public string alt
		{
			set{ _alt=value;}
			get{return _alt;}
		}
		/// <summary>
		///链接路径
		/// </summary>
		public string linkurl
		{
			set{ _linkurl=value;}
			get{return _linkurl;}
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
		#endregion Model

	}
}

