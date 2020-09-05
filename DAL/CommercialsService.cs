using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace DAL
{
	/// <summary>
	/// 数据访问类:CommercialsService
	/// </summary>
	public partial class CommercialsService
	{
		public CommercialsService()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Commercials");
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
		public int Add(Model.Commercials model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Commercials(");
			strSql.Append("title,dataType,commercialsContent,imgURL,imgSize,height,width,relUser,relTel,relMobile,comName,timeSize,timeFrom,timeEnd,place,placeName,status,remark,addTime,addUser,infoType)");
			strSql.Append(" values (");
			strSql.Append("@title,@dataType,@commercialsContent,@imgURL,@imgSize,@height,@width,@relUser,@relTel,@relMobile,@comName,@timeSize,@timeFrom,@timeEnd,@place,@placeName,@status,@remark,@addTime,@addUser,@infoType)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.VarChar,50),
					new SqlParameter("@dataType", SqlDbType.Int,4),
					new SqlParameter("@commercialsContent", SqlDbType.VarChar,500),
					new SqlParameter("@imgURL", SqlDbType.VarChar,50),
					new SqlParameter("@imgSize", SqlDbType.VarChar,50),
					new SqlParameter("@height", SqlDbType.Int,4),
					new SqlParameter("@width", SqlDbType.Int,4),
					new SqlParameter("@relUser", SqlDbType.VarChar,50),
					new SqlParameter("@relTel", SqlDbType.VarChar,50),
					new SqlParameter("@relMobile", SqlDbType.VarChar,50),
					new SqlParameter("@comName", SqlDbType.VarChar,50),
					new SqlParameter("@timeSize", SqlDbType.VarChar,50),
					new SqlParameter("@timeFrom", SqlDbType.DateTime),
					new SqlParameter("@timeEnd", SqlDbType.DateTime),
					new SqlParameter("@place", SqlDbType.Int,4),
					new SqlParameter("@placeName", SqlDbType.VarChar,50),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.VarChar,150),
					new SqlParameter("@addTime", SqlDbType.DateTime),
					new SqlParameter("@addUser", SqlDbType.Int,4),
					new SqlParameter("@infoType", SqlDbType.Int,4)};
			parameters[0].Value = model.title;
			parameters[1].Value = model.dataType;
			parameters[2].Value = model.commercialsContent;
			parameters[3].Value = model.imgURL;
			parameters[4].Value = model.imgSize;
			parameters[5].Value = model.height;
			parameters[6].Value = model.width;
			parameters[7].Value = model.relUser;
			parameters[8].Value = model.relTel;
			parameters[9].Value = model.relMobile;
			parameters[10].Value = model.comName;
			parameters[11].Value = model.timeSize;
			parameters[12].Value = model.timeFrom;
			parameters[13].Value = model.timeEnd;
			parameters[14].Value = model.place;
			parameters[15].Value = model.placeName;
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
		public bool Update(Model.Commercials model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Commercials set ");
			strSql.Append("title=@title,");
			strSql.Append("dataType=@dataType,");
			strSql.Append("commercialsContent=@commercialsContent,");
			strSql.Append("imgURL=@imgURL,");
			strSql.Append("imgSize=@imgSize,");
			strSql.Append("height=@height,");
			strSql.Append("width=@width,");
			strSql.Append("relUser=@relUser,");
			strSql.Append("relTel=@relTel,");
			strSql.Append("relMobile=@relMobile,");
			strSql.Append("comName=@comName,");
			strSql.Append("timeSize=@timeSize,");
			strSql.Append("timeFrom=@timeFrom,");
			strSql.Append("timeEnd=@timeEnd,");
			strSql.Append("place=@place,");
			strSql.Append("placeName=@placeName,");
			strSql.Append("status=@status,");
			strSql.Append("remark=@remark,");
			strSql.Append("addTime=@addTime,");
			strSql.Append("addUser=@addUser,");
			strSql.Append("infoType=@infoType");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.VarChar,50),
					new SqlParameter("@dataType", SqlDbType.Int,4),
					new SqlParameter("@commercialsContent", SqlDbType.VarChar,500),
					new SqlParameter("@imgURL", SqlDbType.VarChar,50),
					new SqlParameter("@imgSize", SqlDbType.VarChar,50),
					new SqlParameter("@height", SqlDbType.Int,4),
					new SqlParameter("@width", SqlDbType.Int,4),
					new SqlParameter("@relUser", SqlDbType.VarChar,50),
					new SqlParameter("@relTel", SqlDbType.VarChar,50),
					new SqlParameter("@relMobile", SqlDbType.VarChar,50),
					new SqlParameter("@comName", SqlDbType.VarChar,50),
					new SqlParameter("@timeSize", SqlDbType.VarChar,50),
					new SqlParameter("@timeFrom", SqlDbType.DateTime),
					new SqlParameter("@timeEnd", SqlDbType.DateTime),
					new SqlParameter("@place", SqlDbType.Int,4),
					new SqlParameter("@placeName", SqlDbType.VarChar,50),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.VarChar,150),
					new SqlParameter("@addTime", SqlDbType.DateTime),
					new SqlParameter("@addUser", SqlDbType.Int,4),
					new SqlParameter("@infoType", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.title;
			parameters[1].Value = model.dataType;
			parameters[2].Value = model.commercialsContent;
			parameters[3].Value = model.imgURL;
			parameters[4].Value = model.imgSize;
			parameters[5].Value = model.height;
			parameters[6].Value = model.width;
			parameters[7].Value = model.relUser;
			parameters[8].Value = model.relTel;
			parameters[9].Value = model.relMobile;
			parameters[10].Value = model.comName;
			parameters[11].Value = model.timeSize;
			parameters[12].Value = model.timeFrom;
			parameters[13].Value = model.timeEnd;
			parameters[14].Value = model.place;
			parameters[15].Value = model.placeName;
			parameters[16].Value = model.status;
			parameters[17].Value = model.remark;
			parameters[18].Value = model.addTime;
			parameters[19].Value = model.addUser;
			parameters[20].Value = model.infoType;
			parameters[21].Value = model.id;

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
		public bool Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Commercials ");
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
			strSql.Append("delete from Commercials ");
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
		public Model.Commercials GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,title,dataType,commercialsContent,imgURL,imgSize,height,width,relUser,relTel,relMobile,comName,timeSize,timeFrom,timeEnd,place,placeName,status,remark,addTime,addUser,infoType from Commercials ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Model.Commercials model=new Model.Commercials();
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
		public Model.Commercials DataRowToModel(DataRow row)
		{
			Model.Commercials model=new Model.Commercials();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["title"]!=null)
				{
					model.title=row["title"].ToString();
				}
				if(row["dataType"]!=null && row["dataType"].ToString()!="")
				{
					model.dataType=int.Parse(row["dataType"].ToString());
				}
				if(row["commercialsContent"]!=null)
				{
					model.commercialsContent=row["commercialsContent"].ToString();
				}
				if(row["imgURL"]!=null)
				{
					model.imgURL=row["imgURL"].ToString();
				}
				if(row["imgSize"]!=null)
				{
					model.imgSize=row["imgSize"].ToString();
				}
				if(row["height"]!=null && row["height"].ToString()!="")
				{
					model.height=int.Parse(row["height"].ToString());
				}
				if(row["width"]!=null && row["width"].ToString()!="")
				{
					model.width=int.Parse(row["width"].ToString());
				}
				if(row["relUser"]!=null)
				{
					model.relUser=row["relUser"].ToString();
				}
				if(row["relTel"]!=null)
				{
					model.relTel=row["relTel"].ToString();
				}
				if(row["relMobile"]!=null)
				{
					model.relMobile=row["relMobile"].ToString();
				}
				if(row["comName"]!=null)
				{
					model.comName=row["comName"].ToString();
				}
				if(row["timeSize"]!=null)
				{
					model.timeSize=row["timeSize"].ToString();
				}
				if(row["timeFrom"]!=null && row["timeFrom"].ToString()!="")
				{
					model.timeFrom=DateTime.Parse(row["timeFrom"].ToString());
				}
				if(row["timeEnd"]!=null && row["timeEnd"].ToString()!="")
				{
					model.timeEnd=DateTime.Parse(row["timeEnd"].ToString());
				}
				if(row["place"]!=null && row["place"].ToString()!="")
				{
					model.place=int.Parse(row["place"].ToString());
				}
				if(row["placeName"]!=null)
				{
					model.placeName=row["placeName"].ToString();
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
			strSql.Append("select id,title,dataType,commercialsContent,imgURL,imgSize,height,width,relUser,relTel,relMobile,comName,timeSize,timeFrom,timeEnd,place,placeName,status,remark,addTime,addUser,infoType ");
			strSql.Append(" FROM Commercials ");
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
			strSql.Append(" id,title,dataType,commercialsContent,imgURL,imgSize,height,width,relUser,relTel,relMobile,comName,timeSize,timeFrom,timeEnd,place,placeName,status,remark,addTime,addUser,infoType ");
			strSql.Append(" FROM Commercials ");
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
			strSql.Append("select count(1) FROM Commercials ");
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
			strSql.Append(")AS Row, T.*  from Commercials T ");
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
			parameters[0].Value = "Commercials";
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

