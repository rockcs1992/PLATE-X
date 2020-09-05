using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace DAL
{
	/// <summary>
	/// ���ݷ�����:Common_ReplyService
	/// </summary>
	public partial class Common_ReplyService
	{
		public Common_ReplyService()
		{}
		#region  BasicMethod
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Common_Reply");
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
		public int Add(Model.Common_Reply model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Common_Reply(");
			strSql.Append("mesId,replyTitle,replyContent,remark,status,addTime,addUserId,infoType)");
			strSql.Append(" values (");
			strSql.Append("@mesId,@replyTitle,@replyContent,@remark,@status,@addTime,@addUserId,@infoType)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@mesId", SqlDbType.Int,4),
					new SqlParameter("@replyTitle", SqlDbType.VarChar,100),
					new SqlParameter("@replyContent", SqlDbType.NText),
					new SqlParameter("@remark", SqlDbType.VarChar,150),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@addTime", SqlDbType.DateTime),
					new SqlParameter("@addUserId", SqlDbType.Int,4),
					new SqlParameter("@infoType", SqlDbType.Int,4)};
			parameters[0].Value = model.mesId;
			parameters[1].Value = model.replyTitle;
			parameters[2].Value = model.replyContent;
			parameters[3].Value = model.remark;
			parameters[4].Value = model.status;
			parameters[5].Value = model.addTime;
			parameters[6].Value = model.addUserId;
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
		public bool Update(Model.Common_Reply model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Common_Reply set ");
			strSql.Append("mesId=@mesId,");
			strSql.Append("replyTitle=@replyTitle,");
			strSql.Append("replyContent=@replyContent,");
			strSql.Append("remark=@remark,");
			strSql.Append("status=@status,");
			strSql.Append("addTime=@addTime,");
			strSql.Append("addUserId=@addUserId,");
			strSql.Append("infoType=@infoType");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@mesId", SqlDbType.Int,4),
					new SqlParameter("@replyTitle", SqlDbType.VarChar,100),
					new SqlParameter("@replyContent", SqlDbType.NText),
					new SqlParameter("@remark", SqlDbType.VarChar,150),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@addTime", SqlDbType.DateTime),
					new SqlParameter("@addUserId", SqlDbType.Int,4),
					new SqlParameter("@infoType", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.mesId;
			parameters[1].Value = model.replyTitle;
			parameters[2].Value = model.replyContent;
			parameters[3].Value = model.remark;
			parameters[4].Value = model.status;
			parameters[5].Value = model.addTime;
			parameters[6].Value = model.addUserId;
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
		public bool Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Common_Reply ");
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
			strSql.Append("delete from Common_Reply ");
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
		public Model.Common_Reply GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,mesId,replyTitle,replyContent,remark,status,addTime,addUserId,infoType from Common_Reply ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Model.Common_Reply model=new Model.Common_Reply();
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
		public Model.Common_Reply DataRowToModel(DataRow row)
		{
			Model.Common_Reply model=new Model.Common_Reply();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["mesId"]!=null && row["mesId"].ToString()!="")
				{
					model.mesId=int.Parse(row["mesId"].ToString());
				}
				if(row["replyTitle"]!=null)
				{
					model.replyTitle=row["replyTitle"].ToString();
				}
				if(row["replyContent"]!=null)
				{
					model.replyContent=row["replyContent"].ToString();
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
				if(row["addUserId"]!=null && row["addUserId"].ToString()!="")
				{
					model.addUserId=int.Parse(row["addUserId"].ToString());
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
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,mesId,replyTitle,replyContent,remark,status,addTime,addUserId,infoType ");
			strSql.Append(" FROM Common_Reply ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
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
			strSql.Append(" id,mesId,replyTitle,replyContent,remark,status,addTime,addUserId,infoType ");
			strSql.Append(" FROM Common_Reply ");
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
			strSql.Append("select count(1) FROM Common_Reply ");
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
			strSql.Append(")AS Row, T.*  from Common_Reply T ");
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
			parameters[0].Value = "Common_Reply";
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

