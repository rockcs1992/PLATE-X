using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace DAL
{
	/// <summary>
	/// 数据访问类:Common_LinksService
	/// </summary>
	public partial class Common_LinksService
	{
		public Common_LinksService()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Common_Links");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			return DBHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public static int Add(Model.Common_Links model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Common_Links(");
			strSql.Append("linkType,linkPlace,linkname,linktitle,imgurl,linkurl,is_target,isHot,isTj,orderNum,remark,addTime,addUser,status,infoType)");
			strSql.Append(" values (");
			strSql.Append("@linkType,@linkPlace,@linkname,@linktitle,@imgurl,@linkurl,@is_target,@isHot,@isTj,@orderNum,@remark,@addTime,@addUser,@status,@infoType)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@linkType", SqlDbType.Int,4),
					new SqlParameter("@linkPlace", SqlDbType.Int,4),
					new SqlParameter("@linkname", SqlDbType.NVarChar,50),
					new SqlParameter("@linktitle", SqlDbType.VarChar,50),
					new SqlParameter("@imgurl", SqlDbType.VarChar,50),
					new SqlParameter("@linkurl", SqlDbType.NVarChar,100),
					new SqlParameter("@is_target", SqlDbType.Int,4),
					new SqlParameter("@isHot", SqlDbType.Int,4),
					new SqlParameter("@isTj", SqlDbType.Int,4),
					new SqlParameter("@orderNum", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.VarChar,50),
					new SqlParameter("@addTime", SqlDbType.DateTime),
					new SqlParameter("@addUser", SqlDbType.Int,4),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@infoType", SqlDbType.Int,4)};
			parameters[0].Value = model.linkType;
			parameters[1].Value = model.linkPlace;
			parameters[2].Value = model.linkname;
			parameters[3].Value = model.linktitle;
			parameters[4].Value = model.imgurl;
			parameters[5].Value = model.linkurl;
			parameters[6].Value = model.is_target;
			parameters[7].Value = model.isHot;
			parameters[8].Value = model.isTj;
			parameters[9].Value = model.orderNum;
			parameters[10].Value = model.remark;
			parameters[11].Value = model.addTime;
			parameters[12].Value = model.addUser;
			parameters[13].Value = model.status;
			parameters[14].Value = model.infoType;

			object obj = DBHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public static int Update(Model.Common_Links model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Common_Links set ");
			strSql.Append("linkType=@linkType,");
			strSql.Append("linkPlace=@linkPlace,");
			strSql.Append("linkname=@linkname,");
			strSql.Append("linktitle=@linktitle,");
			strSql.Append("imgurl=@imgurl,");
			strSql.Append("linkurl=@linkurl,");
			strSql.Append("is_target=@is_target,");
			strSql.Append("isHot=@isHot,");
			strSql.Append("isTj=@isTj,");
			strSql.Append("orderNum=@orderNum,");
			strSql.Append("remark=@remark,");		
			strSql.Append("addUser=@addUser,");
			strSql.Append("status=@status,");
			strSql.Append("infoType=@infoType");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@linkType", SqlDbType.Int,4),
					new SqlParameter("@linkPlace", SqlDbType.Int,4),
					new SqlParameter("@linkname", SqlDbType.NVarChar,50),
					new SqlParameter("@linktitle", SqlDbType.VarChar,50),
					new SqlParameter("@imgurl", SqlDbType.VarChar,50),
					new SqlParameter("@linkurl", SqlDbType.NVarChar,100),
					new SqlParameter("@is_target", SqlDbType.Int,4),
					new SqlParameter("@isHot", SqlDbType.Int,4),
					new SqlParameter("@isTj", SqlDbType.Int,4),
					new SqlParameter("@orderNum", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.VarChar,50),					
					new SqlParameter("@addUser", SqlDbType.Int,4),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@infoType", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.linkType;
			parameters[1].Value = model.linkPlace;
			parameters[2].Value = model.linkname;
			parameters[3].Value = model.linktitle;
			parameters[4].Value = model.imgurl;
			parameters[5].Value = model.linkurl;
			parameters[6].Value = model.is_target;
			parameters[7].Value = model.isHot;
			parameters[8].Value = model.isTj;
			parameters[9].Value = model.orderNum;
			parameters[10].Value = model.remark;	
			parameters[11].Value = model.addUser;
			parameters[12].Value = model.status;
			parameters[13].Value = model.infoType;
			parameters[14].Value = model.id;

			return DBHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// Delete一条数据
		/// </summary>
		public static bool Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Common_Links ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			int rows=DBHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量Delete数据
		/// </summary>
		public bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Common_Links ");
			strSql.Append(" where id in ("+idlist + ")  ");
			int rows=DBHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public static Model.Common_Links GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,linkType,linkPlace,linkname,linktitle,imgurl,linkurl,is_target,isHot,isTj,orderNum,remark,addTime,addUser,status,infoType from Common_Links ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Model.Common_Links model=new Model.Common_Links();
			DataSet ds=DBHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public static Model.Common_Links DataRowToModel(DataRow row)
		{
			Model.Common_Links model=new Model.Common_Links();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["linkType"]!=null && row["linkType"].ToString()!="")
				{
					model.linkType=int.Parse(row["linkType"].ToString());
				}
				if(row["linkPlace"]!=null && row["linkPlace"].ToString()!="")
				{
					model.linkPlace=int.Parse(row["linkPlace"].ToString());
				}
				if(row["linkname"]!=null)
				{
					model.linkname=row["linkname"].ToString();
				}
				if(row["linktitle"]!=null)
				{
					model.linktitle=row["linktitle"].ToString();
				}
				if(row["imgurl"]!=null)
				{
					model.imgurl=row["imgurl"].ToString();
				}
				if(row["linkurl"]!=null)
				{
					model.linkurl=row["linkurl"].ToString();
				}
				if(row["is_target"]!=null && row["is_target"].ToString()!="")
				{
					model.is_target=int.Parse(row["is_target"].ToString());
				}
				if(row["isHot"]!=null && row["isHot"].ToString()!="")
				{
					model.isHot=int.Parse(row["isHot"].ToString());
				}
				if(row["isTj"]!=null && row["isTj"].ToString()!="")
				{
					model.isTj=int.Parse(row["isTj"].ToString());
				}
				if(row["orderNum"]!=null && row["orderNum"].ToString()!="")
				{
					model.orderNum=int.Parse(row["orderNum"].ToString());
				}
				if(row["remark"]!=null)
				{
					model.remark=row["remark"].ToString();
				}
				if(row["addTime"]!=null && row["addTime"].ToString()!="")
				{
					model.addTime=DateTime.Parse(row["addTime"].ToString());
				}
				if(row["addUser"]!=null && row["addUser"].ToString()!="")
				{
					model.addUser=int.Parse(row["addUser"].ToString());
				}
				if(row["status"]!=null && row["status"].ToString()!="")
				{
					model.status=int.Parse(row["status"].ToString());
				}
				if(row["infoType"]!=null && row["infoType"].ToString()!="")
				{
					model.infoType=int.Parse(row["infoType"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public static DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,linkType,linkPlace,linkname,linktitle,imgurl,linkurl,is_target,isHot,isTj,orderNum,remark,addTime,addUser,status,infoType ");
			strSql.Append(" FROM Common_Links ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DBHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" id,linkType,linkPlace,linkname,linktitle,imgurl,linkurl,is_target,isHot,isTj,orderNum,remark,addTime,addUser,status,infoType ");
			strSql.Append(" FROM Common_Links ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DBHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM Common_Links ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DBHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.id desc");
			}
			strSql.Append(")AS Row, T.*  from Common_Links T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DBHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "Common_Links";
			parameters[1].Value = "id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DBHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

