using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace DAL
{
	/// <summary>
	/// 数据访问类:ShoperService
	/// </summary>
	public partial class ShoperService
	{
		public ShoperService()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Shoper");
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
		public int Add(Model.Shoper model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Shoper(");
			strSql.Append("shoperName,pid,cid,regionId,address,mapInfo,shopingTime,tel,moible,email,qq,qqisBind,mainBrand,goodCount,assessCount,shareCount,status,remark,addTime,addUser,infoType)");
			strSql.Append(" values (");
			strSql.Append("@shoperName,@pid,@cid,@regionId,@address,@mapInfo,@shopingTime,@tel,@moible,@email,@qq,@qqisBind,@mainBrand,@goodCount,@assessCount,@shareCount,@status,@remark,@addTime,@addUser,@infoType)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@shoperName", SqlDbType.VarChar,150),
					new SqlParameter("@pid", SqlDbType.Int,4),
					new SqlParameter("@cid", SqlDbType.Int,4),
					new SqlParameter("@regionId", SqlDbType.Int,4),
					new SqlParameter("@address", SqlDbType.VarChar,150),
					new SqlParameter("@mapInfo", SqlDbType.NText),
					new SqlParameter("@shopingTime", SqlDbType.VarChar,50),
					new SqlParameter("@tel", SqlDbType.VarChar,50),
					new SqlParameter("@moible", SqlDbType.VarChar,50),
					new SqlParameter("@email", SqlDbType.VarChar,50),
					new SqlParameter("@qq", SqlDbType.VarChar,20),
					new SqlParameter("@qqisBind", SqlDbType.NChar,10),
					new SqlParameter("@mainBrand", SqlDbType.VarChar,150),
					new SqlParameter("@goodCount", SqlDbType.Int,4),
					new SqlParameter("@assessCount", SqlDbType.Int,4),
					new SqlParameter("@shareCount", SqlDbType.Int,4),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.VarChar,150),
					new SqlParameter("@addTime", SqlDbType.DateTime),
					new SqlParameter("@addUser", SqlDbType.Int,4),
					new SqlParameter("@infoType", SqlDbType.Int,4)};
			parameters[0].Value = model.shoperName;
			parameters[1].Value = model.pid;
			parameters[2].Value = model.cid;
			parameters[3].Value = model.regionId;
			parameters[4].Value = model.address;
			parameters[5].Value = model.mapInfo;
			parameters[6].Value = model.shopingTime;
			parameters[7].Value = model.tel;
			parameters[8].Value = model.moible;
			parameters[9].Value = model.email;
			parameters[10].Value = model.qq;
			parameters[11].Value = model.qqisBind;
			parameters[12].Value = model.mainBrand;
			parameters[13].Value = model.goodCount;
			parameters[14].Value = model.assessCount;
			parameters[15].Value = model.shareCount;
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
		public bool Update(Model.Shoper model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Shoper set ");
			strSql.Append("shoperName=@shoperName,");
			strSql.Append("pid=@pid,");
			strSql.Append("cid=@cid,");
			strSql.Append("regionId=@regionId,");
			strSql.Append("address=@address,");
			strSql.Append("mapInfo=@mapInfo,");
			strSql.Append("shopingTime=@shopingTime,");
			strSql.Append("tel=@tel,");
			strSql.Append("moible=@moible,");
			strSql.Append("email=@email,");
			strSql.Append("qq=@qq,");
			strSql.Append("qqisBind=@qqisBind,");
			strSql.Append("mainBrand=@mainBrand,");
			strSql.Append("goodCount=@goodCount,");
			strSql.Append("assessCount=@assessCount,");
			strSql.Append("shareCount=@shareCount,");
			strSql.Append("status=@status,");
			strSql.Append("remark=@remark,");
			strSql.Append("addTime=@addTime,");
			strSql.Append("addUser=@addUser,");
			strSql.Append("infoType=@infoType");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@shoperName", SqlDbType.VarChar,150),
					new SqlParameter("@pid", SqlDbType.Int,4),
					new SqlParameter("@cid", SqlDbType.Int,4),
					new SqlParameter("@regionId", SqlDbType.Int,4),
					new SqlParameter("@address", SqlDbType.VarChar,150),
					new SqlParameter("@mapInfo", SqlDbType.NText),
					new SqlParameter("@shopingTime", SqlDbType.VarChar,50),
					new SqlParameter("@tel", SqlDbType.VarChar,50),
					new SqlParameter("@moible", SqlDbType.VarChar,50),
					new SqlParameter("@email", SqlDbType.VarChar,50),
					new SqlParameter("@qq", SqlDbType.VarChar,20),
					new SqlParameter("@qqisBind", SqlDbType.NChar,10),
					new SqlParameter("@mainBrand", SqlDbType.VarChar,150),
					new SqlParameter("@goodCount", SqlDbType.Int,4),
					new SqlParameter("@assessCount", SqlDbType.Int,4),
					new SqlParameter("@shareCount", SqlDbType.Int,4),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.VarChar,150),
					new SqlParameter("@addTime", SqlDbType.DateTime),
					new SqlParameter("@addUser", SqlDbType.Int,4),
					new SqlParameter("@infoType", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.shoperName;
			parameters[1].Value = model.pid;
			parameters[2].Value = model.cid;
			parameters[3].Value = model.regionId;
			parameters[4].Value = model.address;
			parameters[5].Value = model.mapInfo;
			parameters[6].Value = model.shopingTime;
			parameters[7].Value = model.tel;
			parameters[8].Value = model.moible;
			parameters[9].Value = model.email;
			parameters[10].Value = model.qq;
			parameters[11].Value = model.qqisBind;
			parameters[12].Value = model.mainBrand;
			parameters[13].Value = model.goodCount;
			parameters[14].Value = model.assessCount;
			parameters[15].Value = model.shareCount;
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
			strSql.Append("delete from Shoper ");
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
			strSql.Append("delete from Shoper ");
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
		public Model.Shoper GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,shoperName,pid,cid,regionId,address,mapInfo,shopingTime,tel,moible,email,qq,qqisBind,mainBrand,goodCount,assessCount,shareCount,status,remark,addTime,addUser,infoType from Shoper ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Model.Shoper model=new Model.Shoper();
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
		public Model.Shoper DataRowToModel(DataRow row)
		{
			Model.Shoper model=new Model.Shoper();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["shoperName"]!=null)
				{
					model.shoperName=row["shoperName"].ToString();
				}
				if(row["pid"]!=null && row["pid"].ToString()!="")
				{
					model.pid=int.Parse(row["pid"].ToString());
				}
				if(row["cid"]!=null && row["cid"].ToString()!="")
				{
					model.cid=int.Parse(row["cid"].ToString());
				}
				if(row["regionId"]!=null && row["regionId"].ToString()!="")
				{
					model.regionId=int.Parse(row["regionId"].ToString());
				}
				if(row["address"]!=null)
				{
					model.address=row["address"].ToString();
				}
				if(row["mapInfo"]!=null)
				{
					model.mapInfo=row["mapInfo"].ToString();
				}
				if(row["shopingTime"]!=null)
				{
					model.shopingTime=row["shopingTime"].ToString();
				}
				if(row["tel"]!=null)
				{
					model.tel=row["tel"].ToString();
				}
				if(row["moible"]!=null)
				{
					model.moible=row["moible"].ToString();
				}
				if(row["email"]!=null)
				{
					model.email=row["email"].ToString();
				}
				if(row["qq"]!=null)
				{
					model.qq=row["qq"].ToString();
				}
				if(row["qqisBind"]!=null)
				{
					model.qqisBind=row["qqisBind"].ToString();
				}
				if(row["mainBrand"]!=null)
				{
					model.mainBrand=row["mainBrand"].ToString();
				}
				if(row["goodCount"]!=null && row["goodCount"].ToString()!="")
				{
					model.goodCount=int.Parse(row["goodCount"].ToString());
				}
				if(row["assessCount"]!=null && row["assessCount"].ToString()!="")
				{
					model.assessCount=int.Parse(row["assessCount"].ToString());
				}
				if(row["shareCount"]!=null && row["shareCount"].ToString()!="")
				{
					model.shareCount=int.Parse(row["shareCount"].ToString());
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
			strSql.Append("select id,shoperName,pid,cid,regionId,address,mapInfo,shopingTime,tel,moible,email,qq,qqisBind,mainBrand,goodCount,assessCount,shareCount,status,remark,addTime,addUser,infoType ");
			strSql.Append(" FROM Shoper ");
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
			strSql.Append(" id,shoperName,pid,cid,regionId,address,mapInfo,shopingTime,tel,moible,email,qq,qqisBind,mainBrand,goodCount,assessCount,shareCount,status,remark,addTime,addUser,infoType ");
			strSql.Append(" FROM Shoper ");
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
			strSql.Append("select count(1) FROM Shoper ");
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
			strSql.Append(")AS Row, T.*  from Shoper T ");
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
			parameters[0].Value = "Shoper";
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

