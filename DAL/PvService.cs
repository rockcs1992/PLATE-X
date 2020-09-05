using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace DAL
{
	/// <summary>
	/// ���ݷ�����:PvService
	/// </summary>
	public partial class PvService
	{
		public PvService()
		{}
		#region  BasicMethod
        /// <summary>
        /// ��������ͳ���������
        /// </summary>
        /// <param name="whereStr"></param>
        /// <param name="pageValue"></param>
        /// <returns></returns>
        public static int GetViews(string whereStr,string pageValue) 
        {
            string sql = "select count(id) from Pv where pageValue = '" + pageValue + "'" ;
            if(whereStr != "")
            {
                sql += " and " + whereStr;
            }
            object obj = DBHelperSQL.GetSingle(sql);
            if(obj != null)
            {
                return Convert.ToInt32(obj);
            }
            return 0;
        }

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Pv");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;
			return DBHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// ����һ������
		/// </summary>
		public static int Add(Model.Pv model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Pv(");
			strSql.Append("pageName,pageValue,viewsCount,addTime,ip,status,remark,infoType)");
			strSql.Append(" values (");
			strSql.Append("@pageName,@pageValue,@viewsCount,@addTime,@ip,@status,@remark,@infoType)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@pageName", SqlDbType.VarChar,50),
					new SqlParameter("@pageValue", SqlDbType.VarChar,50),
					new SqlParameter("@viewsCount", SqlDbType.Int,4),
					new SqlParameter("@addTime", SqlDbType.DateTime),
					new SqlParameter("@ip", SqlDbType.VarChar,20),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.VarChar,50),
					new SqlParameter("@infoType", SqlDbType.Int,4)};
			parameters[0].Value = model.pageName;
			parameters[1].Value = model.pageValue;
			parameters[2].Value = model.viewsCount;
			parameters[3].Value = model.addTime;
			parameters[4].Value = model.ip;
			parameters[5].Value = model.status;
			parameters[6].Value = model.remark;
			parameters[7].Value = model.infoType;

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
		/// ����һ������
		/// </summary>
		public bool Update(Model.Pv model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Pv set ");
			strSql.Append("pageName=@pageName,");
			strSql.Append("pageValue=@pageValue,");
			strSql.Append("viewsCount=@viewsCount,");
			strSql.Append("addTime=@addTime,");
			strSql.Append("ip=@ip,");
			strSql.Append("status=@status,");
			strSql.Append("remark=@remark,");
			strSql.Append("infoType=@infoType");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@pageName", SqlDbType.VarChar,50),
					new SqlParameter("@pageValue", SqlDbType.VarChar,50),
					new SqlParameter("@viewsCount", SqlDbType.Int,4),
					new SqlParameter("@addTime", SqlDbType.DateTime),
					new SqlParameter("@ip", SqlDbType.VarChar,20),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.VarChar,50),
					new SqlParameter("@infoType", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.pageName;
			parameters[1].Value = model.pageValue;
			parameters[2].Value = model.viewsCount;
			parameters[3].Value = model.addTime;
			parameters[4].Value = model.ip;
			parameters[5].Value = model.status;
			parameters[6].Value = model.remark;
			parameters[7].Value = model.infoType;
			parameters[8].Value = model.id;

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
		/// Deleteһ������
		/// </summary>
		public static bool Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Pv ");
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
		/// ����Delete����
		/// </summary>
		public bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Pv ");
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
		/// �õ�һ������ʵ��
		/// </summary>
		public Model.Pv GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,pageName,pageValue,viewsCount,addTime,ip,status,remark,infoType from Pv ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Model.Pv model=new Model.Pv();
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
		/// �õ�һ������ʵ��
		/// </summary>
		public Model.Pv DataRowToModel(DataRow row)
		{
			Model.Pv model=new Model.Pv();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["pageName"]!=null)
				{
					model.pageName=row["pageName"].ToString();
				}
				if(row["pageValue"]!=null)
				{
					model.pageValue=row["pageValue"].ToString();
				}
				if(row["viewsCount"]!=null && row["viewsCount"].ToString()!="")
				{
					model.viewsCount=int.Parse(row["viewsCount"].ToString());
				}
				if(row["addTime"]!=null && row["addTime"].ToString()!="")
				{
					model.addTime=DateTime.Parse(row["addTime"].ToString());
				}
				if(row["ip"]!=null)
				{
					model.ip=row["ip"].ToString();
				}
				if(row["status"]!=null && row["status"].ToString()!="")
				{
					model.status=int.Parse(row["status"].ToString());
				}
				if(row["remark"]!=null)
				{
					model.remark=row["remark"].ToString();
				}
				if(row["infoType"]!=null && row["infoType"].ToString()!="")
				{
					model.infoType=int.Parse(row["infoType"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public static DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,pageName,pageValue,viewsCount,addTime,ip,status,remark,infoType ");
			strSql.Append(" FROM Pv ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
            strSql.Append(" order by id desc");
			return DBHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// ���ǰ��������
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" id,pageName,pageValue,viewsCount,addTime,ip,status,remark,infoType ");
			strSql.Append(" FROM Pv ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DBHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// ��ȡ��¼����
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM Pv ");
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
		/// ��ҳ��ȡ�����б�
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
			strSql.Append(")AS Row, T.*  from Pv T ");
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
		/// ��ҳ��ȡ�����б�
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
			parameters[0].Value = "Pv";
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

