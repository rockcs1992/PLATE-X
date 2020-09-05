using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace DAL
{
	/// <summary>
	/// ���ݷ�����:UserFavoriteInfoService
	/// </summary>
	public partial class UserFavoriteInfoService
	{
		public UserFavoriteInfoService()
		{}
		#region  BasicMethod
        /// <summary>
        /// Deleteһ������
        /// </summary>
        public static bool Delete(int userId,int shoperId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from UserFavoriteInfo ");
            strSql.Append(" where objId=@objId and addUser = " + userId);
            SqlParameter[] parameters = {
					new SqlParameter("@objId", SqlDbType.Int,4)
			};
            parameters[0].Value = shoperId;

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
        /// �Ƿ���ڸü�¼
        /// </summary>
        public static bool Exists(int userId,int shoperId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from UserFavoriteInfo");
            strSql.Append(" where objId=@objId and addUser = " + userId);
            SqlParameter[] parameters = {
					new SqlParameter("@objId", SqlDbType.Int,4)
			};
            parameters[0].Value = shoperId;

            return DBHelperSQL.Exists(strSql.ToString(), parameters);
        }
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public static bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from UserFavoriteInfo");
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
        public static int Add(Model.UserFavoriteInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into UserFavoriteInfo(");
			strSql.Append("typeId,typeName,objId,objName,status,remark,addTime,addUser,infoType)");
			strSql.Append(" values (");
			strSql.Append("@typeId,@typeName,@objId,@objName,@status,@remark,@addTime,@addUser,@infoType)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@typeId", SqlDbType.Int,4),
					new SqlParameter("@typeName", SqlDbType.VarChar,150),
					new SqlParameter("@objId", SqlDbType.Int,4),
					new SqlParameter("@objName", SqlDbType.VarChar,150),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.VarChar,1500),
					new SqlParameter("@addTime", SqlDbType.DateTime),
					new SqlParameter("@addUser", SqlDbType.Int,4),
					new SqlParameter("@infoType", SqlDbType.Int,4)};
			parameters[0].Value = model.typeId;
			parameters[1].Value = model.typeName;
			parameters[2].Value = model.objId;
			parameters[3].Value = model.objName;
			parameters[4].Value = model.status;
			parameters[5].Value = model.remark;
			parameters[6].Value = model.addTime;
			parameters[7].Value = model.addUser;
			parameters[8].Value = model.infoType;

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
        public static bool Update(Model.UserFavoriteInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update UserFavoriteInfo set ");
			strSql.Append("typeId=@typeId,");
			strSql.Append("typeName=@typeName,");
			strSql.Append("objId=@objId,");
			strSql.Append("objName=@objName,");
			strSql.Append("status=@status,");
			strSql.Append("remark=@remark,");
			strSql.Append("addTime=@addTime,");
			strSql.Append("addUser=@addUser,");
			strSql.Append("infoType=@infoType");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@typeId", SqlDbType.Int,4),
					new SqlParameter("@typeName", SqlDbType.VarChar,150),
					new SqlParameter("@objId", SqlDbType.Int,4),
					new SqlParameter("@objName", SqlDbType.VarChar,150),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.VarChar,1500),
					new SqlParameter("@addTime", SqlDbType.DateTime),
					new SqlParameter("@addUser", SqlDbType.Int,4),
					new SqlParameter("@infoType", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.typeId;
			parameters[1].Value = model.typeName;
			parameters[2].Value = model.objId;
			parameters[3].Value = model.objName;
			parameters[4].Value = model.status;
			parameters[5].Value = model.remark;
			parameters[6].Value = model.addTime;
			parameters[7].Value = model.addUser;
			parameters[8].Value = model.infoType;
			parameters[9].Value = model.id;

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
			strSql.Append("delete from UserFavoriteInfo ");
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
        public static bool DeleteList(string idlist)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from UserFavoriteInfo ");
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
        public static Model.UserFavoriteInfo GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,typeId,typeName,objId,objName,status,remark,addTime,addUser,infoType from UserFavoriteInfo ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Model.UserFavoriteInfo model=new Model.UserFavoriteInfo();
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
        public static Model.UserFavoriteInfo DataRowToModel(DataRow row)
		{
			Model.UserFavoriteInfo model=new Model.UserFavoriteInfo();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["typeId"]!=null && row["typeId"].ToString()!="")
				{
					model.typeId=int.Parse(row["typeId"].ToString());
				}
				if(row["typeName"]!=null)
				{
					model.typeName=row["typeName"].ToString();
				}
				if(row["objId"]!=null && row["objId"].ToString()!="")
				{
					model.objId=int.Parse(row["objId"].ToString());
				}
				if(row["objName"]!=null)
				{
					model.objName=row["objName"].ToString();
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
		/// ��������б�
		/// </summary>
        public static DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,typeId,typeName,objId,objName,status,remark,addTime,addUser,infoType ");
			strSql.Append(" FROM UserFavoriteInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DBHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// ���ǰ��������
		/// </summary>
        public static DataSet GetList(int Top, string strWhere, string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" id,typeId,typeName,objId,objName,status,remark,addTime,addUser,infoType ");
			strSql.Append(" FROM UserFavoriteInfo ");
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
			strSql.Append("select count(1) FROM UserFavoriteInfo ");
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
			strSql.Append(")AS Row, T.*  from UserFavoriteInfo T ");
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
			parameters[0].Value = "UserFavoriteInfo";
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

