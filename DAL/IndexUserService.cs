using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace DAL
{
	/// <summary>
	/// 数据访问类:IndexUserService
	/// </summary>
	public partial class IndexUserService
	{
		public IndexUserService()
		{}
		#region  BasicMethod
        /// <summary>
        /// 更新顺序号
        /// </summary>
        /// <param name="id"></param>
        /// <param name="infoType"></param>
        /// <returns></returns>
        public static int Update(int id,int infoType) 
        {
            string sql = "update IndexUser set infoType = " + infoType + " where id = " + id;
            return DBHelperSQL.ExecuteSql(sql);
        }
        /// <summary>
        /// Delete数据
        /// </summary>
        public static int DeleteByUserIdAndModuleId(int userId,int moduleId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from IndexUser ");
            strSql.Append(" where userId=@userId and moduleId = " + moduleId);
            SqlParameter[] parameters = {
					new SqlParameter("@userId", SqlDbType.Int,4)
			};
            parameters[0].Value = userId;

            return DBHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// Delete数据
        /// </summary>
        public static int DeleteByUserId(int userId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from IndexUser ");
            strSql.Append(" where userId=@userId");
            SqlParameter[] parameters = {
					new SqlParameter("@userId", SqlDbType.Int,4)
			};
            parameters[0].Value = userId;

            return DBHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public static bool Exists(int userId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from IndexUser");
            strSql.Append(" where userId=@userId");
			SqlParameter[] parameters = {
					new SqlParameter("@userId", SqlDbType.Int,4)
			};
            parameters[0].Value = userId;

			return DBHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public static int Add(Model.IndexUser model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into IndexUser(");
			strSql.Append("userId,moduleId,status,remark,addTime,infoType)");
			strSql.Append(" values (");
			strSql.Append("@userId,@moduleId,@status,@remark,@addTime,@infoType)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@userId", SqlDbType.Int,4),
					new SqlParameter("@moduleId", SqlDbType.Int,4),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.VarChar,150),
					new SqlParameter("@addTime", SqlDbType.DateTime),
					new SqlParameter("@infoType", SqlDbType.Int,4)};
			parameters[0].Value = model.userId;
			parameters[1].Value = model.moduleId;
			parameters[2].Value = model.status;
			parameters[3].Value = model.remark;
			parameters[4].Value = model.addTime;
			parameters[5].Value = model.infoType;

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
		public bool Update(Model.IndexUser model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update IndexUser set ");
			strSql.Append("userId=@userId,");
			strSql.Append("moduleId=@moduleId,");
			strSql.Append("status=@status,");
			strSql.Append("remark=@remark,");
			strSql.Append("addTime=@addTime,");
			strSql.Append("infoType=@infoType");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@userId", SqlDbType.Int,4),
					new SqlParameter("@moduleId", SqlDbType.Int,4),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.VarChar,150),
					new SqlParameter("@addTime", SqlDbType.DateTime),
					new SqlParameter("@infoType", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.userId;
			parameters[1].Value = model.moduleId;
			parameters[2].Value = model.status;
			parameters[3].Value = model.remark;
			parameters[4].Value = model.addTime;
			parameters[5].Value = model.infoType;
			parameters[6].Value = model.id;

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
			strSql.Append("delete from IndexUser ");
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
			strSql.Append("delete from IndexUser ");
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
		public static Model.IndexUser GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,userId,moduleId,status,remark,addTime,infoType from IndexUser ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Model.IndexUser model=new Model.IndexUser();
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
		public static Model.IndexUser DataRowToModel(DataRow row)
		{
			Model.IndexUser model=new Model.IndexUser();
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
				if(row["moduleId"]!=null && row["moduleId"].ToString()!="")
				{
					model.moduleId=int.Parse(row["moduleId"].ToString());
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
			strSql.Append("select id,userId,moduleId,status,remark,addTime,infoType ");
			strSql.Append(" FROM IndexUser ");
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
			strSql.Append(" id,userId,moduleId,status,remark,addTime,infoType ");
			strSql.Append(" FROM IndexUser ");
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
			strSql.Append("select count(1) FROM IndexUser ");
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
			strSql.Append(")AS Row, T.*  from IndexUser T ");
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
			parameters[0].Value = "IndexUser";
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

