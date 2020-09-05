using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace DAL
{
	/// <summary>
	/// 数据访问类:NavInfoService
	/// </summary>
	public partial class NavInfoService
	{
		public NavInfoService()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public static bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from NavInfo");
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
        public static int Add(Model.NavInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into NavInfo(");
			strSql.Append("indexTitle,indexTitle2,indexImg,linkurl,title,infoDesc,infoRemark,status,remark,addTime,addUser,infoType)");
			strSql.Append(" values (");
			strSql.Append("@indexTitle,@indexTitle2,@indexImg,@linkurl,@title,@infoDesc,@infoRemark,@status,@remark,@addTime,@addUser,@infoType)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@indexTitle", SqlDbType.VarChar,150),
					new SqlParameter("@indexTitle2", SqlDbType.VarChar,150),
					new SqlParameter("@indexImg", SqlDbType.VarChar,50),
					new SqlParameter("@linkurl", SqlDbType.VarChar,150),
					new SqlParameter("@title", SqlDbType.VarChar,150),
					new SqlParameter("@infoDesc", SqlDbType.NText),
					new SqlParameter("@infoRemark", SqlDbType.VarChar,150),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.VarChar,150),
					new SqlParameter("@addTime", SqlDbType.DateTime),
					new SqlParameter("@addUser", SqlDbType.Int,4),
					new SqlParameter("@infoType", SqlDbType.Int,4)};
			parameters[0].Value = model.indexTitle;
			parameters[1].Value = model.indexTitle2;
			parameters[2].Value = model.indexImg;
			parameters[3].Value = model.linkurl;
			parameters[4].Value = model.title;
			parameters[5].Value = model.infoDesc;
			parameters[6].Value = model.infoRemark;
			parameters[7].Value = model.status;
			parameters[8].Value = model.remark;
			parameters[9].Value = model.addTime;
			parameters[10].Value = model.addUser;
			parameters[11].Value = model.infoType;

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
        public static bool Update(Model.NavInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update NavInfo set ");
			strSql.Append("indexTitle=@indexTitle,");
			strSql.Append("indexTitle2=@indexTitle2,");
			strSql.Append("indexImg=@indexImg,");
			strSql.Append("linkurl=@linkurl,");
			strSql.Append("title=@title,");
			strSql.Append("infoDesc=@infoDesc,");
			strSql.Append("infoRemark=@infoRemark,");
			strSql.Append("status=@status,");
			strSql.Append("remark=@remark,");
			strSql.Append("addTime=@addTime,");
			strSql.Append("addUser=@addUser,");
			strSql.Append("infoType=@infoType");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@indexTitle", SqlDbType.VarChar,150),
					new SqlParameter("@indexTitle2", SqlDbType.VarChar,150),
					new SqlParameter("@indexImg", SqlDbType.VarChar,50),
					new SqlParameter("@linkurl", SqlDbType.VarChar,150),
					new SqlParameter("@title", SqlDbType.VarChar,150),
					new SqlParameter("@infoDesc", SqlDbType.NText),
					new SqlParameter("@infoRemark", SqlDbType.VarChar,150),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.VarChar,150),
					new SqlParameter("@addTime", SqlDbType.DateTime),
					new SqlParameter("@addUser", SqlDbType.Int,4),
					new SqlParameter("@infoType", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.indexTitle;
			parameters[1].Value = model.indexTitle2;
			parameters[2].Value = model.indexImg;
			parameters[3].Value = model.linkurl;
			parameters[4].Value = model.title;
			parameters[5].Value = model.infoDesc;
			parameters[6].Value = model.infoRemark;
			parameters[7].Value = model.status;
			parameters[8].Value = model.remark;
			parameters[9].Value = model.addTime;
			parameters[10].Value = model.addUser;
			parameters[11].Value = model.infoType;
			parameters[12].Value = model.id;

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
		/// Delete一条数据
		/// </summary>
        public static bool Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from NavInfo ");
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
        public static bool DeleteList(string idlist)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from NavInfo ");
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
        public static Model.NavInfo GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,indexTitle,indexTitle2,indexImg,linkurl,title,infoDesc,infoRemark,status,remark,addTime,addUser,infoType from NavInfo ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Model.NavInfo model=new Model.NavInfo();
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
        public static Model.NavInfo DataRowToModel(DataRow row)
		{
			Model.NavInfo model=new Model.NavInfo();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["indexTitle"]!=null)
				{
					model.indexTitle=row["indexTitle"].ToString();
				}
				if(row["indexTitle2"]!=null)
				{
					model.indexTitle2=row["indexTitle2"].ToString();
				}
				if(row["indexImg"]!=null)
				{
					model.indexImg=row["indexImg"].ToString();
				}
				if(row["linkurl"]!=null)
				{
					model.linkurl=row["linkurl"].ToString();
				}
				if(row["title"]!=null)
				{
					model.title=row["title"].ToString();
				}
				if(row["infoDesc"]!=null)
				{
					model.infoDesc=row["infoDesc"].ToString();
				}
				if(row["infoRemark"]!=null)
				{
					model.infoRemark=row["infoRemark"].ToString();
				}
				if(row["status"]!=null && row["status"].ToString()!="")
				{
					model.status=int.Parse(row["status"].ToString());
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
			strSql.Append("select id,indexTitle,indexTitle2,indexImg,linkurl,title,infoDesc,infoRemark,status,remark,addTime,addUser,infoType ");
			strSql.Append(" FROM NavInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DBHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
        public static DataSet GetList(int Top, string strWhere, string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" id,indexTitle,indexTitle2,indexImg,linkurl,title,infoDesc,infoRemark,status,remark,addTime,addUser,infoType ");
			strSql.Append(" FROM NavInfo ");
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
			strSql.Append("select count(1) FROM NavInfo ");
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
			strSql.Append(")AS Row, T.*  from NavInfo T ");
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
			parameters[0].Value = "NavInfo";
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

