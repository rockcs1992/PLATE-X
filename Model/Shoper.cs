/**  版本信息模板在安装目录下，可自行修改。
* Shoper.cs
*
* 功 能： N/A
* 类 名： Shoper
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
	/// Shoper:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Shoper
	{
		public Shoper()
		{}
		#region Model
		private int _id;
		private string _shopername;
		private int _pid;
		private int _cid;
		private int _regionid;
		private string _address;
		private string _mapinfo;
		private string _shopingtime;
		private string _tel;
		private string _moible;
		private string _email;
		private string _qq;
		private string _qqisbind;
		private string _mainbrand;
		private int _goodcount;
		private int _assesscount;
		private int _sharecount;
		private int _status;
		private string _remark;
		private DateTime _addtime;
		private int _adduser;
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
		/// 经销商Item Name
		/// </summary>
		public string shoperName
		{
			set{ _shopername=value;}
			get{return _shopername;}
		}
		/// <summary>
		/// 省
		/// </summary>
		public int pid
		{
			set{ _pid=value;}
			get{return _pid;}
		}
		/// <summary>
		/// 市
		/// </summary>
		public int cid
		{
			set{ _cid=value;}
			get{return _cid;}
		}
		/// <summary>
		/// 商圈
		/// </summary>
		public int regionId
		{
			set{ _regionid=value;}
			get{return _regionid;}
		}
		/// <summary>
		/// 地址
		/// </summary>
		public string address
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// 地图信息
		/// </summary>
		public string mapInfo
		{
			set{ _mapinfo=value;}
			get{return _mapinfo;}
		}
		/// <summary>
		/// 营业时间
		/// </summary>
		public string shopingTime
		{
			set{ _shopingtime=value;}
			get{return _shopingtime;}
		}
		/// <summary>
		/// 联系电话
		/// </summary>
		public string tel
		{
			set{ _tel=value;}
			get{return _tel;}
		}
		/// <summary>
		/// Phone
		/// </summary>
		public string moible
		{
			set{ _moible=value;}
			get{return _moible;}
		}
		/// <summary>
		/// 邮箱
		/// </summary>
		public string email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// QQ
		/// </summary>
		public string qq
		{
			set{ _qq=value;}
			get{return _qq;}
		}
		/// <summary>
		/// 是否绑定QQ
		/// </summary>
		public string qqisBind
		{
			set{ _qqisbind=value;}
			get{return _qqisbind;}
		}
		/// <summary>
		/// 主营品牌
		/// </summary>
		public string mainBrand
		{
			set{ _mainbrand=value;}
			get{return _mainbrand;}
		}
		/// <summary>
		/// 好评次数
		/// </summary>
		public int goodCount
		{
			set{ _goodcount=value;}
			get{return _goodcount;}
		}
		/// <summary>
		/// 评论次数
		/// </summary>
		public int assessCount
		{
			set{ _assesscount=value;}
			get{return _assesscount;}
		}
		/// <summary>
		/// 分享次数
		/// </summary>
		public int shareCount
		{
			set{ _sharecount=value;}
			get{return _sharecount;}
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

