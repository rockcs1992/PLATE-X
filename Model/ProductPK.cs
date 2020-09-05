/**  版本信息模板在安装目录下，可自行修改。
* ProductPK.cs
*
* 功 能： N/A
* 类 名： ProductPK
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
	/// ProductPK:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ProductPK
	{
		public ProductPK()
		{}
		#region Model
		private int _id;
		private int _productid;
		private int _quantiycount;
		private int _brandcount;
		private int _pricecount;
		private int _configcount;
		private int _appearancecount;
		private int _othercount;
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
		///整体值
		/// </summary>
		public int quantiyCount
		{
			set{ _quantiycount=value;}
			get{return _quantiycount;}
		}
		/// <summary>
		/// 品牌值
		/// </summary>
		public int brandCount
		{
			set{ _brandcount=value;}
			get{return _brandcount;}
		}
		/// <summary>
		/// 价格值
		/// </summary>
		public int priceCount
		{
			set{ _pricecount=value;}
			get{return _pricecount;}
		}
		/// <summary>
		/// 配置值
		/// </summary>
		public int configCount
		{
			set{ _configcount=value;}
			get{return _configcount;}
		}
		/// <summary>
		/// 出现次数
		/// </summary>
		public int appearanceCount
		{
			set{ _appearancecount=value;}
			get{return _appearancecount;}
		}
		/// <summary>
		/// 其他值
		/// </summary>
		public int otherCount
		{
			set{ _othercount=value;}
			get{return _othercount;}
		}
		#endregion Model

	}
}

