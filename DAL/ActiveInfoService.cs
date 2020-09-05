using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace DAL
{
	/// <summary>
	/// 数据访问类:ActiveInfoService
	/// </summary>
	public partial class ActiveInfoService
	{
		public ActiveInfoService()
		{}
		#region  BasicMethod
        /// <summary>
        /// 更新状态
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public static int UpdateCheckInfo(int id,int status)
        {
            string sql = "update ActiveInfo set status = " + status + " where id = " + id;
            return DBHelperSQL.ExecuteSql(sql);
        }

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ActiveInfo");
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
		public static int Add(Model.ActiveInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ActiveInfo(");
			strSql.Append("userId,activeName,activeType,pid,cid,address,timeFrom,timeEnd,activeInfo,activeDesc,remark,status,addTime,infoType)");
			strSql.Append(" values (");
			strSql.Append("@userId,@activeName,@activeType,@pid,@cid,@address,@timeFrom,@timeEnd,@activeInfo,@activeDesc,@remark,@status,@addTime,@infoType)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@userId", SqlDbType.Int,4),
					new SqlParameter("@activeName", SqlDbType.VarChar,150),
					new SqlParameter("@activeType", SqlDbType.Int,4),
					new SqlParameter("@pid", SqlDbType.Int,4),
					new SqlParameter("@cid", SqlDbType.Int,4),
					new SqlParameter("@address", SqlDbType.VarChar,150),
					new SqlParameter("@timeFrom", SqlDbType.DateTime),
					new SqlParameter("@timeEnd", SqlDbType.DateTime),
					new SqlParameter("@activeInfo", SqlDbType.NText),
					new SqlParameter("@activeDesc", SqlDbType.VarChar,1550),
					new SqlParameter("@remark", SqlDbType.VarChar,150),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@addTime", SqlDbType.DateTime),
					new SqlParameter("@infoType", SqlDbType.Int,4)};
			parameters[0].Value = model.userId;
			parameters[1].Value = model.activeName;
			parameters[2].Value = model.activeType;
			parameters[3].Value = model.pid;
			parameters[4].Value = model.cid;
			parameters[5].Value = model.address;
			parameters[6].Value = model.timeFrom;
			parameters[7].Value = model.timeEnd;
			parameters[8].Value = model.activeInfo;
			parameters[9].Value = model.activeDesc;
			parameters[10].Value = model.remark;
			parameters[11].Value = model.status;
			parameters[12].Value = model.addTime;
			parameters[13].Value = model.infoType;

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
		public static bool Update(Model.ActiveInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ActiveInfo set ");
			strSql.Append("userId=@userId,");
			strSql.Append("activeName=@activeName,");
			strSql.Append("activeType=@activeType,");
			strSql.Append("pid=@pid,");
			strSql.Append("cid=@cid,");
			strSql.Append("address=@address,");
			strSql.Append("timeFrom=@timeFrom,");
			strSql.Append("timeEnd=@timeEnd,");
			strSql.Append("activeInfo=@activeInfo,");
			strSql.Append("activeDesc=@activeDesc,");
			strSql.Append("remark=@remark,");
			strSql.Append("status=@status,");
			strSql.Append("addTime=@addTime,");
			strSql.Append("infoType=@infoType");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@userId", SqlDbType.Int,4),
					new SqlParameter("@activeName", SqlDbType.VarChar,150),
					new SqlParameter("@activeType", SqlDbType.Int,4),
					new SqlParameter("@pid", SqlDbType.Int,4),
					new SqlParameter("@cid", SqlDbType.Int,4),
					new SqlParameter("@address", SqlDbType.VarChar,150),
					new SqlParameter("@timeFrom", SqlDbType.DateTime),
					new SqlParameter("@timeEnd", SqlDbType.DateTime),
					new SqlParameter("@activeInfo", SqlDbType.NText),
					new SqlParameter("@activeDesc", SqlDbType.VarChar,1550),
					new SqlParameter("@remark", SqlDbType.VarChar,150),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@addTime", SqlDbType.DateTime),
					new SqlParameter("@infoType", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.userId;
			parameters[1].Value = model.activeName;
			parameters[2].Value = model.activeType;
			parameters[3].Value = model.pid;
			parameters[4].Value = model.cid;
			parameters[5].Value = model.address;
			parameters[6].Value = model.timeFrom;
			parameters[7].Value = model.timeEnd;
			parameters[8].Value = model.activeInfo;
			parameters[9].Value = model.activeDesc;
			parameters[10].Value = model.remark;
			parameters[11].Value = model.status;
			parameters[12].Value = model.addTime;
			parameters[13].Value = model.infoType;
			parameters[14].Value = model.id;

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
			strSql.Append("delete from ActiveInfo ");
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
			strSql.Append("delete from ActiveInfo ");
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
		public static Model.ActiveInfo GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,userId,activeName,activeType,pid,cid,address,timeFrom,timeEnd,activeInfo,activeDesc,remark,status,addTime,infoType from ActiveInfo ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Model.ActiveInfo model=new Model.ActiveInfo();
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
		public static Model.ActiveInfo DataRowToModel(DataRow row)
		{
			Model.ActiveInfo model=new Model.ActiveInfo();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["userId"]!=null && row["userId"].ToString()!="")
				{
					model.userId=int.Parse(row["userId"].ToString());
				}
				if(row["activeName"]!=null)
				{
					model.activeName=row["activeName"].ToString();
				}
				if(row["activeType"]!=null && row["activeType"].ToString()!="")
				{
					model.activeType=int.Parse(row["activeType"].ToString());
				}
				if(row["pid"]!=null && row["pid"].ToString()!="")
				{
					model.pid=int.Parse(row["pid"].ToString());
				}
				if(row["cid"]!=null && row["cid"].ToString()!="")
				{
					model.cid=int.Parse(row["cid"].ToString());
				}
				if(row["address"]!=null)
				{
					model.address=row["address"].ToString();
				}
				if(row["timeFrom"]!=null && row["timeFrom"].ToString()!="")
				{
					model.timeFrom=DateTime.Parse(row["timeFrom"].ToString());
				}
				if(row["timeEnd"]!=null && row["timeEnd"].ToString()!="")
				{
					model.timeEnd=DateTime.Parse(row["timeEnd"].ToString());
				}
				if(row["activeInfo"]!=null)
				{
					model.activeInfo=row["activeInfo"].ToString();
				}
				if(row["activeDesc"]!=null)
				{
					model.activeDesc=row["activeDesc"].ToString();
				}
				if(row["remark"]!=null)
				{
					model.remark=row["remark"].ToString();
				}
				if(row["status"]!=null && row["status"].ToString()!="")
				{
					model.status=int.Parse(row["status"].ToString());
				}
				if(row["addTime"]!=null && row["addTime"].ToString()!="")
				{
					model.addTime=DateTime.Parse(row["addTime"].ToString());
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
			strSql.Append("select id,userId,activeName,activeType,pid,cid,address,timeFrom,timeEnd,activeInfo,activeDesc,remark,status,addTime,infoType ");
			strSql.Append(" FROM ActiveInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DBHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public static DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" id,userId,activeName,activeType,pid,cid,address,timeFrom,timeEnd,activeInfo,activeDesc,remark,status,addTime,infoType ");
			strSql.Append(" FROM ActiveInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder + " desc");
			return DBHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM ActiveInfo ");
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
			strSql.Append(")AS Row, T.*  from ActiveInfo T ");
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
			parameters[0].Value = "ActiveInfo";
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

