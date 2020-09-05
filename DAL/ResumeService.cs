using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace DAL
{
	/// <summary>
	/// 数据访问类:ResumeService
	/// </summary>
	public partial class ResumeService
	{
		public ResumeService()
		{}
		#region  BasicMethod
        /// <summary>
        /// 该职位应聘人数
        /// </summary>
        /// <param name="inviteId"></param>
        /// <returns></returns>
        public static int GetCount(int inviteId)
        {
            string sql = "select count(1) from Resume where inviteId = " + inviteId;
            object obj = DBHelperSQL.GetSingle(sql);
            if(obj != null)
            {
                return Convert.ToInt32(obj);
            }
            return 0;
        }
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Resume");
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
		public static int Add(Model.Resume model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Resume(");
			strSql.Append("inviteId,realName,mobile,QQ,inviteName,workYears,selfInfo,status,addTime,remark)");
			strSql.Append(" values (");
			strSql.Append("@inviteId,@realName,@mobile,@QQ,@inviteName,@workYears,@selfInfo,@status,@addTime,@remark)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@inviteId", SqlDbType.Int,4),
					new SqlParameter("@realName", SqlDbType.VarChar,50),
					new SqlParameter("@mobile", SqlDbType.VarChar,20),
					new SqlParameter("@QQ", SqlDbType.VarChar,20),
					new SqlParameter("@inviteName", SqlDbType.VarChar,50),
					new SqlParameter("@workYears", SqlDbType.VarChar,24),
					new SqlParameter("@selfInfo", SqlDbType.NText),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@addTime", SqlDbType.DateTime),
					new SqlParameter("@remark", SqlDbType.VarChar,500)};
			parameters[0].Value = model.inviteId;
			parameters[1].Value = model.realName;
			parameters[2].Value = model.mobile;
			parameters[3].Value = model.QQ;
			parameters[4].Value = model.inviteName;
			parameters[5].Value = model.workYears;
			parameters[6].Value = model.selfInfo;
			parameters[7].Value = model.status;
			parameters[8].Value = model.addTime;
			parameters[9].Value = model.remark;

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
		public bool Update(Model.Resume model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Resume set ");
			strSql.Append("inviteId=@inviteId,");
			strSql.Append("realName=@realName,");
			strSql.Append("mobile=@mobile,");
			strSql.Append("QQ=@QQ,");
			strSql.Append("inviteName=@inviteName,");
			strSql.Append("workYears=@workYears,");
			strSql.Append("selfInfo=@selfInfo,");
			strSql.Append("status=@status,");
			strSql.Append("addTime=@addTime,");
			strSql.Append("remark=@remark");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@inviteId", SqlDbType.Int,4),
					new SqlParameter("@realName", SqlDbType.VarChar,50),
					new SqlParameter("@mobile", SqlDbType.VarChar,20),
					new SqlParameter("@QQ", SqlDbType.VarChar,20),
					new SqlParameter("@inviteName", SqlDbType.VarChar,50),
					new SqlParameter("@workYears", SqlDbType.VarChar,24),
					new SqlParameter("@selfInfo", SqlDbType.NText),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@addTime", SqlDbType.DateTime),
					new SqlParameter("@remark", SqlDbType.VarChar,500),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.inviteId;
			parameters[1].Value = model.realName;
			parameters[2].Value = model.mobile;
			parameters[3].Value = model.QQ;
			parameters[4].Value = model.inviteName;
			parameters[5].Value = model.workYears;
			parameters[6].Value = model.selfInfo;
			parameters[7].Value = model.status;
			parameters[8].Value = model.addTime;
			parameters[9].Value = model.remark;
			parameters[10].Value = model.id;

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
		/// 删除一条数据
		/// </summary>
		public static bool Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Resume ");
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
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Resume ");
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
		public static Model.Resume GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,inviteId,realName,mobile,QQ,inviteName,workYears,selfInfo,status,addTime,remark from Resume ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Model.Resume model=new Model.Resume();
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
		public static Model.Resume DataRowToModel(DataRow row)
		{
			Model.Resume model=new Model.Resume();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["inviteId"]!=null && row["inviteId"].ToString()!="")
				{
					model.inviteId=int.Parse(row["inviteId"].ToString());
				}
				if(row["realName"]!=null)
				{
					model.realName=row["realName"].ToString();
				}
				if(row["mobile"]!=null)
				{
					model.mobile=row["mobile"].ToString();
				}
				if(row["QQ"]!=null)
				{
					model.QQ=row["QQ"].ToString();
				}
				if(row["inviteName"]!=null)
				{
					model.inviteName=row["inviteName"].ToString();
				}
                model.workYears = row["workYears"].ToString();
				if(row["selfInfo"]!=null)
				{
					model.selfInfo=row["selfInfo"].ToString();
				}
				if(row["status"]!=null && row["status"].ToString()!="")
				{
					model.status=int.Parse(row["status"].ToString());
				}
				if(row["addTime"]!=null && row["addTime"].ToString()!="")
				{
					model.addTime=DateTime.Parse(row["addTime"].ToString());
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
			strSql.Append("select id,inviteId,realName,mobile,QQ,inviteName,workYears,selfInfo,status,addTime,remark ");
			strSql.Append(" FROM Resume ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
            strSql.Append(" order by id desc");
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
			strSql.Append(" id,inviteId,realName,mobile,QQ,inviteName,workYears,selfInfo,status,addTime,remark ");
			strSql.Append(" FROM Resume ");
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
			strSql.Append("select count(1) FROM Resume ");
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
			strSql.Append(")AS Row, T.*  from Resume T ");
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
			parameters[0].Value = "Resume";
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

