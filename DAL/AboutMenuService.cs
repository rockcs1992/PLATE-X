using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace DAL
{
	/// <summary>
	/// 数据访问类:AboutMenuService
	/// </summary>
	public partial class AboutMenuService
	{
		public AboutMenuService()
		{}
		#region  BasicMethod
        /// <summary>
        /// 项目Item Name信息设置
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int SetProNameValue(int id, string value)
        {
            string sql = "update AboutMenu set proName = '" + value + "' where id = " + id;
            return DBHelperSQL.ExecuteSql(sql);
        }
        /// <summary>
        /// 信息设置
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int SetValue(int id,string value)
        {
            string sql = "update AboutMenu set proValue = '" + value + "' where id = " + id;
            return DBHelperSQL.ExecuteSql(sql);
        }
        /// <summary>
        /// 获取项目Item Name信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string GetProNameById(int id)
        {
            string sql = "select proName from AboutMenu where id = " + id;
            object obj = DBHelperSQL.GetSingle(sql);
            if (obj != null)
            {
                return obj.ToString();
            }
            return "";
        }
        /// <summary>
        /// 获取信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string GetById(int id)
        {
            string sql = "select proValue from AboutMenu where id = " + id;
            object obj = DBHelperSQL.GetSingle(sql);
            if(obj != null)
            {
                return obj.ToString();
            }
            return "";
        }

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DBHelperSQL.GetMaxID("id", "AboutMenu"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from AboutMenu");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)			};
			parameters[0].Value = id;

			return DBHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public static bool Add(Model.AboutMenu model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into AboutMenu(");
			strSql.Append("proName,proValue,infoType,remark)");
			strSql.Append(" values (");
			strSql.Append("@proName,@proValue,@infoType,@remark)");
			SqlParameter[] parameters = {
					new SqlParameter("@proName", SqlDbType.VarChar,150),
					new SqlParameter("@proValue", SqlDbType.NText),
					new SqlParameter("@infoType", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.VarChar,150)};
			parameters[0].Value = model.proName;
			parameters[1].Value = model.proValue;
			parameters[2].Value = model.infoType;
			parameters[3].Value = model.remark;

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
		/// 更新一条数据
		/// </summary>
		public static bool Update(Model.AboutMenu model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update AboutMenu set ");
			strSql.Append("proName=@proName,");
			strSql.Append("proValue=@proValue,");
			strSql.Append("infoType=@infoType,");
			strSql.Append("remark=@remark");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@proName", SqlDbType.VarChar,150),
					new SqlParameter("@proValue", SqlDbType.NText),
					new SqlParameter("@infoType", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.VarChar,150),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.proName;
			parameters[1].Value = model.proValue;
			parameters[2].Value = model.infoType;
			parameters[3].Value = model.remark;
			parameters[4].Value = model.id;

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
			strSql.Append("delete from AboutMenu ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)			};
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
			strSql.Append("delete from AboutMenu ");
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
		public static Model.AboutMenu GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,proName,proValue,infoType,remark from AboutMenu ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)			};
			parameters[0].Value = id;

			Model.AboutMenu model=new Model.AboutMenu();
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
		public static Model.AboutMenu DataRowToModel(DataRow row)
		{
			Model.AboutMenu model=new Model.AboutMenu();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["proName"]!=null)
				{
					model.proName=row["proName"].ToString();
				}
				if(row["proValue"]!=null)
				{
					model.proValue=row["proValue"].ToString();
				}
				if(row["infoType"]!=null && row["infoType"].ToString()!="")
				{
					model.infoType=int.Parse(row["infoType"].ToString());
				}
				if(row["remark"]!=null)
				{
					model.remark=row["remark"].ToString();
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
			strSql.Append("select id,proName,proValue,infoType,remark ");
			strSql.Append(" FROM AboutMenu ");
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
			strSql.Append(" id,proName,proValue,infoType,remark ");
			strSql.Append(" FROM AboutMenu ");
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
			strSql.Append("select count(1) FROM AboutMenu ");
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
			strSql.Append(")AS Row, T.*  from AboutMenu T ");
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
			parameters[0].Value = "AboutMenu";
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

