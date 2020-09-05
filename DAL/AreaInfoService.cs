using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace DAL
{
	/// <summary>
	/// ���ݷ�����:AreaInfoService
	/// </summary>
	public partial class AreaInfoService
	{
		public AreaInfoService()
		{}
		#region  BasicMethod
        /// <summary>
        /// ��ȡ����Item Name
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string GetName(int id) 
        {
            string sql = "select areaName from AreaInfo where id = " + id;
            object obj = DBHelperSQL.GetSingle(sql);
            if(obj != null)
            {
                return obj.ToString();
            }
            return "";
        }
        /// <summary>
        /// ��ѯ���ַ���Ϣ
        /// </summary>
        /// <returns></returns>
        public static DataSet GetCharList()
        {
            string sql = "select Max(id) as id,Max(charIndex) as charIndex from AreaInfo group by charIndex order by charIndex asc";
            return DBHelperSQL.Query(sql);
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int SetHot(int id,int status) 
        {
            string sql = "update AreaInfo set status = " + status + " where id = " + id;
            return DBHelperSQL.ExecuteSql(sql);
        }

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from AreaInfo");
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
		public static int Add(Model.AreaInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into AreaInfo(");
			strSql.Append("areaName,parentId,charIndex,remark,status,infoType)");
			strSql.Append(" values (");
			strSql.Append("@areaName,@parentId,@charIndex,@remark,@status,@infoType)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@areaName", SqlDbType.VarChar,50),
					new SqlParameter("@parentId", SqlDbType.Int,4),
					new SqlParameter("@charIndex", SqlDbType.VarChar,20),
					new SqlParameter("@remark", SqlDbType.VarChar,50),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@infoType", SqlDbType.Int,4)};
			parameters[0].Value = model.areaName;
			parameters[1].Value = model.parentId;
			parameters[2].Value = model.charIndex;
			parameters[3].Value = model.remark;
			parameters[4].Value = model.status;
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
        /// ����һ������
        /// </summary>
        public static bool Update(int id, string name,string ch)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update AreaInfo set ");
            strSql.Append("areaName=@areaName,");          
            strSql.Append("charIndex=@charIndex");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@areaName", SqlDbType.VarChar,50),					
					new SqlParameter("@charIndex", SqlDbType.VarChar,20),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = name;
            parameters[1].Value = ch;            
            parameters[2].Value = id;
            int rows = DBHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
		/// ����һ������
		/// </summary>
		public bool Update(Model.AreaInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update AreaInfo set ");
			strSql.Append("areaName=@areaName,");
			strSql.Append("parentId=@parentId,");
			strSql.Append("charIndex=@charIndex,");
			strSql.Append("remark=@remark,");
			strSql.Append("status=@status,");
			strSql.Append("infoType=@infoType");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@areaName", SqlDbType.VarChar,50),
					new SqlParameter("@parentId", SqlDbType.Int,4),
					new SqlParameter("@charIndex", SqlDbType.VarChar,20),
					new SqlParameter("@remark", SqlDbType.VarChar,50),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@infoType", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.areaName;
			parameters[1].Value = model.parentId;
			parameters[2].Value = model.charIndex;
			parameters[3].Value = model.remark;
			parameters[4].Value = model.status;
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
		/// Deleteһ������
		/// </summary>
		public static int Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from AreaInfo ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			return DBHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// ����Delete����
		/// </summary>
		public bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from AreaInfo ");
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
		public static Model.AreaInfo GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,areaName,parentId,charIndex,remark,status,infoType from AreaInfo ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Model.AreaInfo model=new Model.AreaInfo();
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
		public static Model.AreaInfo DataRowToModel(DataRow row)
		{
			Model.AreaInfo model=new Model.AreaInfo();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["areaName"]!=null)
				{
					model.areaName=row["areaName"].ToString();
				}
				if(row["parentId"]!=null && row["parentId"].ToString()!="")
				{
					model.parentId=int.Parse(row["parentId"].ToString());
				}
				if(row["charIndex"]!=null)
				{
					model.charIndex=row["charIndex"].ToString();
				}
				if(row["remark"]!=null)
				{
					model.remark=row["remark"].ToString();
				}
				if(row["status"]!=null && row["status"].ToString()!="")
				{
					model.status=int.Parse(row["status"].ToString());
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
			strSql.Append("select id,areaName,parentId,charIndex,remark,status,infoType ");
			strSql.Append(" FROM AreaInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DBHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// ���ǰ��������
		/// </summary>
		public static DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" id,areaName,parentId,charIndex,remark,status,infoType ");
			strSql.Append(" FROM AreaInfo ");
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
			strSql.Append("select count(1) FROM AreaInfo ");
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
			strSql.Append(")AS Row, T.*  from AreaInfo T ");
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
			parameters[0].Value = "AreaInfo";
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

