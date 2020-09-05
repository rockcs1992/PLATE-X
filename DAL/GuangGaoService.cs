using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace DAL
{
	/// <summary>
	/// 数据访问类:GuangGaoService
	/// </summary>
	public partial class GuangGaoService
	{
		public GuangGaoService()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from GuangGao");
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
		public static int Add(Model.GuangGao model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into GuangGao(");
			strSql.Append("imgUrl,title,alt,linkurl,comName,relUser,tel,timeStr,timeFrom,timeEnd,placeSite,placeName,isTj,isHot,isNew,views,status,remark,addTime,addUser,infoType)");
			strSql.Append(" values (");
			strSql.Append("@imgUrl,@title,@alt,@linkurl,@comName,@relUser,@tel,@timeStr,@timeFrom,@timeEnd,@placeSite,@placeName,@isTj,@isHot,@isNew,@views,@status,@remark,@addTime,@addUser,@infoType)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@imgUrl", SqlDbType.VarChar,50),
					new SqlParameter("@title", SqlDbType.VarChar,50),
					new SqlParameter("@alt", SqlDbType.VarChar,50),
					new SqlParameter("@linkurl", SqlDbType.VarChar,50),
					new SqlParameter("@comName", SqlDbType.VarChar,50),
					new SqlParameter("@relUser", SqlDbType.VarChar,20),
					new SqlParameter("@tel", SqlDbType.VarChar,20),
					new SqlParameter("@timeStr", SqlDbType.VarChar,50),
					new SqlParameter("@timeFrom", SqlDbType.DateTime),
					new SqlParameter("@timeEnd", SqlDbType.DateTime),
					new SqlParameter("@placeSite", SqlDbType.Int,4),
					new SqlParameter("@placeName", SqlDbType.VarChar,50),
					new SqlParameter("@isTj", SqlDbType.Int,4),
					new SqlParameter("@isHot", SqlDbType.Int,4),
					new SqlParameter("@isNew", SqlDbType.Int,4),
					new SqlParameter("@views", SqlDbType.Int,4),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.VarChar,50),
					new SqlParameter("@addTime", SqlDbType.DateTime),
					new SqlParameter("@addUser", SqlDbType.Int,4),
					new SqlParameter("@infoType", SqlDbType.Int,4)};
			parameters[0].Value = model.imgUrl;
			parameters[1].Value = model.title;
			parameters[2].Value = model.alt;
			parameters[3].Value = model.linkurl;
			parameters[4].Value = model.comName;
			parameters[5].Value = model.relUser;
			parameters[6].Value = model.tel;
			parameters[7].Value = model.timeStr;
			parameters[8].Value = model.timeFrom;
			parameters[9].Value = model.timeEnd;
			parameters[10].Value = model.placeSite;
			parameters[11].Value = model.placeName;
			parameters[12].Value = model.isTj;
			parameters[13].Value = model.isHot;
			parameters[14].Value = model.isNew;
			parameters[15].Value = model.views;
			parameters[16].Value = model.status;
			parameters[17].Value = model.remark;
			parameters[18].Value = model.addTime;
			parameters[19].Value = model.addUser;
			parameters[20].Value = model.infoType;

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
		public static int Update(Model.GuangGao model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update GuangGao set ");
			strSql.Append("imgUrl=@imgUrl,");
			strSql.Append("title=@title,");
			strSql.Append("alt=@alt,");
			strSql.Append("linkurl=@linkurl,");
			strSql.Append("comName=@comName,");
			strSql.Append("relUser=@relUser,");
			strSql.Append("tel=@tel,");
			strSql.Append("timeStr=@timeStr,");
			strSql.Append("timeFrom=@timeFrom,");
			strSql.Append("timeEnd=@timeEnd,");
			strSql.Append("placeSite=@placeSite,");
			strSql.Append("placeName=@placeName,");			
			strSql.Append("infoType=@infoType,");
            strSql.Append("isNew=@isNew");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@imgUrl", SqlDbType.VarChar,50),
					new SqlParameter("@title", SqlDbType.VarChar,50),
					new SqlParameter("@alt", SqlDbType.VarChar,50),
					new SqlParameter("@linkurl", SqlDbType.VarChar,50),
					new SqlParameter("@comName", SqlDbType.VarChar,50),
					new SqlParameter("@relUser", SqlDbType.VarChar,20),
					new SqlParameter("@tel", SqlDbType.VarChar,20),
					new SqlParameter("@timeStr", SqlDbType.VarChar,50),
					new SqlParameter("@timeFrom", SqlDbType.DateTime),
					new SqlParameter("@timeEnd", SqlDbType.DateTime),
					new SqlParameter("@placeSite", SqlDbType.Int,4),
					new SqlParameter("@placeName", SqlDbType.VarChar,50),					
					new SqlParameter("@infoType", SqlDbType.Int,4),new SqlParameter("@isNew", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.imgUrl;
			parameters[1].Value = model.title;
			parameters[2].Value = model.alt;
			parameters[3].Value = model.linkurl;
			parameters[4].Value = model.comName;
			parameters[5].Value = model.relUser;
			parameters[6].Value = model.tel;
			parameters[7].Value = model.timeStr;
			parameters[8].Value = model.timeFrom;
			parameters[9].Value = model.timeEnd;
			parameters[10].Value = model.placeSite;
			parameters[11].Value = model.placeName;
			parameters[12].Value = model.infoType;
            parameters[13].Value = model.isNew;
			parameters[14].Value = model.id;

			return DBHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// Delete一条数据
		/// </summary>
		public static bool Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from GuangGao ");
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
			strSql.Append("delete from GuangGao ");
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
        public static DataSet GetModelByPlace(int placeSite)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from GuangGao where placeSite = " + placeSite + " and timeEnd >= '" + DateTime.Now.ToString("yyyy-MM-dd") + "' order by isNew asc");

            Model.GuangGao model = new Model.GuangGao();
            return  DBHelperSQL.Query(strSql.ToString());
        }
        ///// <summary>
        ///// 得到一个对象实体
        ///// </summary>
        //public static Model.GuangGao GetModelByPlace(int placeSite)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("select  top 1 * from GuangGao where placeSite = " + placeSite + " and timeEnd >= '" + DateTime.Now.ToString("yyyy-MM-dd") + "' order by id desc");
            
        //    Model.GuangGao model = new Model.GuangGao();
        //    DataSet ds = DBHelperSQL.Query(strSql.ToString());
        //    if (ds.Tables[0].Rows.Count > 0)
        //    {
        //        return DataRowToModel(ds.Tables[0].Rows[0]);
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public static Model.GuangGao GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,imgUrl,title,alt,linkurl,comName,relUser,tel,timeStr,timeFrom,timeEnd,placeSite,placeName,isTj,isHot,isNew,views,status,remark,addTime,addUser,infoType from GuangGao ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Model.GuangGao model=new Model.GuangGao();
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
		public static Model.GuangGao DataRowToModel(DataRow row)
		{
			Model.GuangGao model=new Model.GuangGao();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["imgUrl"]!=null)
				{
					model.imgUrl=row["imgUrl"].ToString();
				}
				if(row["title"]!=null)
				{
					model.title=row["title"].ToString();
				}
				if(row["alt"]!=null)
				{
					model.alt=row["alt"].ToString();
				}
				if(row["linkurl"]!=null)
				{
					model.linkurl=row["linkurl"].ToString();
				}
				if(row["comName"]!=null)
				{
					model.comName=row["comName"].ToString();
				}
				if(row["relUser"]!=null)
				{
					model.relUser=row["relUser"].ToString();
				}
				if(row["tel"]!=null)
				{
					model.tel=row["tel"].ToString();
				}
				if(row["timeStr"]!=null)
				{
					model.timeStr=row["timeStr"].ToString();
				}
				if(row["timeFrom"]!=null && row["timeFrom"].ToString()!="")
				{
					model.timeFrom=DateTime.Parse(row["timeFrom"].ToString());
				}
				if(row["timeEnd"]!=null && row["timeEnd"].ToString()!="")
				{
					model.timeEnd=DateTime.Parse(row["timeEnd"].ToString());
				}
				if(row["placeSite"]!=null && row["placeSite"].ToString()!="")
				{
					model.placeSite=int.Parse(row["placeSite"].ToString());
				}
				if(row["placeName"]!=null)
				{
					model.placeName=row["placeName"].ToString();
				}
				if(row["isTj"]!=null && row["isTj"].ToString()!="")
				{
					model.isTj=int.Parse(row["isTj"].ToString());
				}
				if(row["isHot"]!=null && row["isHot"].ToString()!="")
				{
					model.isHot=int.Parse(row["isHot"].ToString());
				}
				if(row["isNew"]!=null && row["isNew"].ToString()!="")
				{
					model.isNew=int.Parse(row["isNew"].ToString());
				}
				if(row["views"]!=null && row["views"].ToString()!="")
				{
					model.views=int.Parse(row["views"].ToString());
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
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,imgUrl,title,alt,linkurl,comName,relUser,tel,timeStr,timeFrom,timeEnd,placeSite,placeName,isTj,isHot,isNew,views,status,remark,addTime,addUser,infoType ");
			strSql.Append(" FROM GuangGao ");
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
			strSql.Append(" id,imgUrl,title,alt,linkurl,comName,relUser,tel,timeStr,timeFrom,timeEnd,placeSite,placeName,isTj,isHot,isNew,views,status,remark,addTime,addUser,infoType ");
			strSql.Append(" FROM GuangGao ");
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
			strSql.Append("select count(1) FROM GuangGao ");
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
			strSql.Append(")AS Row, T.*  from GuangGao T ");
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
			parameters[0].Value = "GuangGao";
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

