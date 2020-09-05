using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace DAL
{
	/// <summary>
	/// 数据访问类:TypeInfoService
	/// </summary>
	public partial class TypeInfoService
	{
		public TypeInfoService()
		{}
		#region  BasicMethod
        /// <summary>
        /// 获取I am aItem Name
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string GetById(int id) 
        {
            string sql = "select typeName from TypeInfo where id  = " + id;
            object obj = DBHelperSQL.GetSingle(sql);
            if(obj != null)
            {
                return obj.ToString();
            }
            return "";
        }

		/// <summary>
		/// 是否存在该记录
		/// </summary>
        public static bool Exists(Model.TypeInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from TypeInfo");
            strSql.Append(" where infoType=@infoType and typeName=@typeName");
			SqlParameter[] parameters = {
					new SqlParameter("@infoType", SqlDbType.Int,4),new SqlParameter("@typeName", SqlDbType.VarChar,54)
			};
            parameters[0].Value = model.infoType;
            parameters[1].Value = model.typeName;

			return DBHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public static int Add(Model.TypeInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into TypeInfo(");
			strSql.Append("infoType,typeName,typeValue,remark,status,addTime,addUser)");
			strSql.Append(" values (");
			strSql.Append("@infoType,@typeName,@typeValue,@remark,@status,@addTime,@addUser)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@infoType", SqlDbType.Int,4),
					new SqlParameter("@typeName", SqlDbType.VarChar,150),
					new SqlParameter("@typeValue", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.VarChar,150),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@addTime", SqlDbType.DateTime),
					new SqlParameter("@addUser", SqlDbType.Int,4)};
			parameters[0].Value = model.infoType;
			parameters[1].Value = model.typeName;
			parameters[2].Value = model.typeValue;
			parameters[3].Value = model.remark;
			parameters[4].Value = model.status;
			parameters[5].Value = model.addTime;
			parameters[6].Value = model.addUser;

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
		public static int Update(int id,string typeName)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update TypeInfo set ");
			strSql.Append("typeName=@typeName");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@typeName", SqlDbType.VarChar,150),					
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = typeName;
			parameters[1].Value = id;

			return DBHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// Delete一条数据
		/// </summary>
		public static bool Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from TypeInfo ");
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
			strSql.Append("delete from TypeInfo ");
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
		public static Model.TypeInfo GetModel(int id)
		{			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,infoType,typeName,typeValue,remark,status,addTime,addUser from TypeInfo ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Model.TypeInfo model=new Model.TypeInfo();
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
		public static Model.TypeInfo DataRowToModel(DataRow row)
		{
			Model.TypeInfo model=new Model.TypeInfo();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["infoType"]!=null && row["infoType"].ToString()!="")
				{
					model.infoType=int.Parse(row["infoType"].ToString());
				}
				if(row["typeName"]!=null)
				{
					model.typeName=row["typeName"].ToString();
				}
				if(row["typeValue"]!=null && row["typeValue"].ToString()!="")
				{
					model.typeValue=int.Parse(row["typeValue"].ToString());
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
				if(row["addUser"]!=null && row["addUser"].ToString()!="")
				{
					model.addUser=int.Parse(row["addUser"].ToString());
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
			strSql.Append("select id,infoType,typeName,typeValue,remark,status,addTime,addUser ");
			strSql.Append(" FROM TypeInfo ");
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
			strSql.Append(" id,infoType,typeName,typeValue,remark,status,addTime,addUser ");
			strSql.Append(" FROM TypeInfo ");
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
			strSql.Append("select count(1) FROM TypeInfo ");
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
			strSql.Append(")AS Row, T.*  from TypeInfo T ");
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
			parameters[0].Value = "TypeInfo";
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

