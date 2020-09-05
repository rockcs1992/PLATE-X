using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace DAL
{
	/// <summary>
	/// 数据访问类:ServerOrderService
	/// </summary>
	public partial class ServerOrderService
	{
		public ServerOrderService()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ServerOrder");
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
		public static int Add(Model.ServerOrder model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ServerOrder(");
			strSql.Append("serverType,pid,cid,regionId,address,serverTime,ageArea,workExperience,salaryArea,personGood,languageId,proxyId,sisterId,title,orderDesc,status,remark,otherInfo,otherRemark,addTime,addUser,infoType)");
			strSql.Append(" values (");
			strSql.Append("@serverType,@pid,@cid,@regionId,@address,@serverTime,@ageArea,@workExperience,@salaryArea,@personGood,@languageId,@proxyId,@sisterId,@title,@orderDesc,@status,@remark,@otherInfo,@otherRemark,@addTime,@addUser,@infoType)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@serverType", SqlDbType.Int,4),
					new SqlParameter("@pid", SqlDbType.Int,4),
					new SqlParameter("@cid", SqlDbType.Int,4),
					new SqlParameter("@regionId", SqlDbType.Int,4),
					new SqlParameter("@address", SqlDbType.VarChar,150),
					new SqlParameter("@serverTime", SqlDbType.DateTime),
					new SqlParameter("@ageArea", SqlDbType.Int,4),
					new SqlParameter("@workExperience", SqlDbType.Int,4),
					new SqlParameter("@salaryArea", SqlDbType.Int,4),
					new SqlParameter("@personGood", SqlDbType.Int,4),
					new SqlParameter("@languageId", SqlDbType.Int,4),
					new SqlParameter("@proxyId", SqlDbType.NChar,10),
					new SqlParameter("@sisterId", SqlDbType.Int,4),
					new SqlParameter("@title", SqlDbType.VarChar,150),
					new SqlParameter("@orderDesc", SqlDbType.VarChar,1500),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.VarChar,1500),
					new SqlParameter("@otherInfo", SqlDbType.NText),
					new SqlParameter("@otherRemark", SqlDbType.VarChar,150),
					new SqlParameter("@addTime", SqlDbType.DateTime),
					new SqlParameter("@addUser", SqlDbType.Int,4),
					new SqlParameter("@infoType", SqlDbType.Int,4)};
			parameters[0].Value = model.serverType;
			parameters[1].Value = model.pid;
			parameters[2].Value = model.cid;
			parameters[3].Value = model.regionId;
			parameters[4].Value = model.address;
			parameters[5].Value = model.serverTime;
			parameters[6].Value = model.ageArea;
			parameters[7].Value = model.workExperience;
			parameters[8].Value = model.salaryArea;
			parameters[9].Value = model.personGood;
			parameters[10].Value = model.languageId;
			parameters[11].Value = model.proxyId;
			parameters[12].Value = model.sisterId;
			parameters[13].Value = model.title;
			parameters[14].Value = model.orderDesc;
			parameters[15].Value = model.status;
			parameters[16].Value = model.remark;
			parameters[17].Value = model.otherInfo;
			parameters[18].Value = model.otherRemark;
			parameters[19].Value = model.addTime;
			parameters[20].Value = model.addUser;
			parameters[21].Value = model.infoType;

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
		public bool Update(Model.ServerOrder model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ServerOrder set ");
			strSql.Append("serverType=@serverType,");
			strSql.Append("pid=@pid,");
			strSql.Append("cid=@cid,");
			strSql.Append("regionId=@regionId,");
			strSql.Append("address=@address,");
			strSql.Append("serverTime=@serverTime,");
			strSql.Append("ageArea=@ageArea,");
			strSql.Append("workExperience=@workExperience,");
			strSql.Append("salaryArea=@salaryArea,");
			strSql.Append("personGood=@personGood,");
			strSql.Append("languageId=@languageId,");
			strSql.Append("proxyId=@proxyId,");
			strSql.Append("sisterId=@sisterId,");
			strSql.Append("title=@title,");
			strSql.Append("orderDesc=@orderDesc,");
			strSql.Append("status=@status,");
			strSql.Append("remark=@remark,");
			strSql.Append("otherInfo=@otherInfo,");
			strSql.Append("otherRemark=@otherRemark,");
			strSql.Append("addTime=@addTime,");
			strSql.Append("addUser=@addUser,");
			strSql.Append("infoType=@infoType");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@serverType", SqlDbType.Int,4),
					new SqlParameter("@pid", SqlDbType.Int,4),
					new SqlParameter("@cid", SqlDbType.Int,4),
					new SqlParameter("@regionId", SqlDbType.Int,4),
					new SqlParameter("@address", SqlDbType.VarChar,150),
					new SqlParameter("@serverTime", SqlDbType.DateTime),
					new SqlParameter("@ageArea", SqlDbType.Int,4),
					new SqlParameter("@workExperience", SqlDbType.Int,4),
					new SqlParameter("@salaryArea", SqlDbType.Int,4),
					new SqlParameter("@personGood", SqlDbType.Int,4),
					new SqlParameter("@languageId", SqlDbType.Int,4),
					new SqlParameter("@proxyId", SqlDbType.NChar,10),
					new SqlParameter("@sisterId", SqlDbType.Int,4),
					new SqlParameter("@title", SqlDbType.VarChar,150),
					new SqlParameter("@orderDesc", SqlDbType.VarChar,1500),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.VarChar,1500),
					new SqlParameter("@otherInfo", SqlDbType.NText),
					new SqlParameter("@otherRemark", SqlDbType.VarChar,150),
					new SqlParameter("@addTime", SqlDbType.DateTime),
					new SqlParameter("@addUser", SqlDbType.Int,4),
					new SqlParameter("@infoType", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.serverType;
			parameters[1].Value = model.pid;
			parameters[2].Value = model.cid;
			parameters[3].Value = model.regionId;
			parameters[4].Value = model.address;
			parameters[5].Value = model.serverTime;
			parameters[6].Value = model.ageArea;
			parameters[7].Value = model.workExperience;
			parameters[8].Value = model.salaryArea;
			parameters[9].Value = model.personGood;
			parameters[10].Value = model.languageId;
			parameters[11].Value = model.proxyId;
			parameters[12].Value = model.sisterId;
			parameters[13].Value = model.title;
			parameters[14].Value = model.orderDesc;
			parameters[15].Value = model.status;
			parameters[16].Value = model.remark;
			parameters[17].Value = model.otherInfo;
			parameters[18].Value = model.otherRemark;
			parameters[19].Value = model.addTime;
			parameters[20].Value = model.addUser;
			parameters[21].Value = model.infoType;
			parameters[22].Value = model.id;

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
			strSql.Append("delete from ServerOrder ");
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
			strSql.Append("delete from ServerOrder ");
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
		public Model.ServerOrder GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,serverType,pid,cid,regionId,address,serverTime,ageArea,workExperience,salaryArea,personGood,languageId,proxyId,sisterId,title,orderDesc,status,remark,otherInfo,otherRemark,addTime,addUser,infoType from ServerOrder ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Model.ServerOrder model=new Model.ServerOrder();
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
		public Model.ServerOrder DataRowToModel(DataRow row)
		{
			Model.ServerOrder model=new Model.ServerOrder();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["serverType"]!=null && row["serverType"].ToString()!="")
				{
					model.serverType=int.Parse(row["serverType"].ToString());
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
				if(row["serverTime"]!=null && row["serverTime"].ToString()!="")
				{
					model.serverTime=DateTime.Parse(row["serverTime"].ToString());
				}
				if(row["ageArea"]!=null && row["ageArea"].ToString()!="")
				{
					model.ageArea=int.Parse(row["ageArea"].ToString());
				}
				if(row["workExperience"]!=null && row["workExperience"].ToString()!="")
				{
					model.workExperience=int.Parse(row["workExperience"].ToString());
				}
				if(row["salaryArea"]!=null && row["salaryArea"].ToString()!="")
				{
					model.salaryArea=int.Parse(row["salaryArea"].ToString());
				}
				if(row["personGood"]!=null && row["personGood"].ToString()!="")
				{
					model.personGood=int.Parse(row["personGood"].ToString());
				}
				if(row["languageId"]!=null && row["languageId"].ToString()!="")
				{
					model.languageId=int.Parse(row["languageId"].ToString());
				}
				if(row["proxyId"]!=null)
				{
					model.proxyId=row["proxyId"].ToString();
				}
				if(row["sisterId"]!=null && row["sisterId"].ToString()!="")
				{
					model.sisterId=int.Parse(row["sisterId"].ToString());
				}
				if(row["title"]!=null)
				{
					model.title=row["title"].ToString();
				}
				if(row["orderDesc"]!=null)
				{
					model.orderDesc=row["orderDesc"].ToString();
				}
				if(row["status"]!=null && row["status"].ToString()!="")
				{
					model.status=int.Parse(row["status"].ToString());
				}
				if(row["remark"]!=null)
				{
					model.remark=row["remark"].ToString();
				}
				if(row["otherInfo"]!=null)
				{
					model.otherInfo=row["otherInfo"].ToString();
				}
				if(row["otherRemark"]!=null)
				{
					model.otherRemark=row["otherRemark"].ToString();
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
			strSql.Append("select id,serverType,pid,cid,regionId,address,serverTime,ageArea,workExperience,salaryArea,personGood,languageId,proxyId,sisterId,title,orderDesc,status,remark,otherInfo,otherRemark,addTime,addUser,infoType ");
			strSql.Append(" FROM ServerOrder ");
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
			strSql.Append(" id,serverType,pid,cid,regionId,address,serverTime,ageArea,workExperience,salaryArea,personGood,languageId,proxyId,sisterId,title,orderDesc,status,remark,otherInfo,otherRemark,addTime,addUser,infoType ");
			strSql.Append(" FROM ServerOrder ");
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
			strSql.Append("select count(1) FROM ServerOrder ");
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
			strSql.Append(")AS Row, T.*  from ServerOrder T ");
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
			parameters[0].Value = "ServerOrder";
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

