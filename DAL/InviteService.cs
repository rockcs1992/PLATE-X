using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace DAL
{
	/// <summary>
	/// 数据访问类:InviteService
	/// </summary>
	public partial class InviteService
	{
		public InviteService()
		{}
		#region  BasicMethod
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Model.Invite GetModelByTypeId(int inviteType)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from Invite ");
            strSql.Append(" where inviteType=@inviteType");
            SqlParameter[] parameters = {
					new SqlParameter("@inviteType", SqlDbType.Int,4)
			};
            parameters[0].Value = inviteType;
            Model.Invite model = new Model.Invite();
            DataSet ds = DBHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 专家顾问
        /// </summary>
        /// <returns></returns>
        public static DataSet GetListSpecial()
        {
            string sql = "select max(inviteName) as inviteName from Invite where inviteType = 0 and status = 0 group by inviteName order by inviteName asc ";
            return DBHelperSQL.Query(sql);
        }
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Invite");
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
		public static int Add(Model.Invite model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Invite(");
			strSql.Append("inviteType,inviteName,inviteInfo,inviteDesc,addTime,status,infoRemark,descRemark)");
			strSql.Append(" values (");
			strSql.Append("@inviteType,@inviteName,@inviteInfo,@inviteDesc,@addTime,@status,@infoRemark,@descRemark)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@inviteType", SqlDbType.Int,4),
					new SqlParameter("@inviteName", SqlDbType.VarChar,50),
					new SqlParameter("@inviteInfo", SqlDbType.NText),
					new SqlParameter("@inviteDesc", SqlDbType.NText),
					new SqlParameter("@addTime", SqlDbType.DateTime),
					new SqlParameter("@status", SqlDbType.Int,4),
                    new SqlParameter("@infoRemark",SqlDbType.VarChar,1500),new SqlParameter("@descRemark",SqlDbType.VarChar,1500)};
			parameters[0].Value = model.inviteType;
			parameters[1].Value = model.inviteName;
			parameters[2].Value = model.inviteInfo;
			parameters[3].Value = model.inviteDesc;
			parameters[4].Value = model.addTime;
			parameters[5].Value = model.status;
            parameters[6].Value = model.inforemark;
            parameters[7].Value = model.descremark;
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
		public static bool Update(Model.Invite model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Invite set ");

			strSql.Append("inviteName=@inviteName,");
			strSql.Append("inviteInfo=@inviteInfo,");
			strSql.Append("inviteDesc=@inviteDesc,");
            strSql.Append("infoRemark=@infoRemark,");
            strSql.Append("descremark=@descremark,");
            strSql.Append("inviteType=@inviteType");
            strSql.Append(" where id=@id");
			SqlParameter[] parameters = {				
					new SqlParameter("@inviteName", SqlDbType.VarChar,50),
					new SqlParameter("@inviteInfo", SqlDbType.NText),
					new SqlParameter("@inviteDesc", SqlDbType.NText),
					
					new SqlParameter("@inviteType", SqlDbType.Int,4),
                    new SqlParameter("@infoRemark",SqlDbType.VarChar,1500),new SqlParameter("@descremark",SqlDbType.VarChar,1500),new SqlParameter("@id",SqlDbType.Int,4)};
			parameters[0].Value = model.inviteName;
			parameters[1].Value = model.inviteInfo;
			parameters[2].Value = model.inviteDesc;
            parameters[3].Value = model.inviteType;
            parameters[4].Value = model.inforemark;
            parameters[5].Value = model.descremark;
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
		/// 删除一条数据
		/// </summary>
		public static bool Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Invite ");
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
			strSql.Append("delete from Invite ");
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
		public static Model.Invite GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 * from Invite ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Model.Invite model=new Model.Invite();
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
		public static Model.Invite DataRowToModel(DataRow row)
		{
			Model.Invite model=new Model.Invite();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["inviteType"]!=null && row["inviteType"].ToString()!="")
				{
					model.inviteType=int.Parse(row["inviteType"].ToString());
				}
				if(row["inviteName"]!=null)
				{
					model.inviteName=row["inviteName"].ToString();
				}
				if(row["inviteInfo"]!=null)
				{
					model.inviteInfo=row["inviteInfo"].ToString();
				}
				if(row["inviteDesc"]!=null)
				{
					model.inviteDesc=row["inviteDesc"].ToString();
				}
				if(row["addTime"]!=null && row["addTime"].ToString()!="")
				{
					model.addTime=DateTime.Parse(row["addTime"].ToString());
				}
				if(row["status"]!=null && row["status"].ToString()!="")
				{
					model.status=int.Parse(row["status"].ToString());
				}


                if (row["inforemark"] != null)
                {
                    model.inforemark = row["inforemark"].ToString();
                }
                if (row["descremark"] != null)
                {
                    model.descremark = row["descremark"].ToString();
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
			strSql.Append("select * ");
			strSql.Append(" FROM Invite ");
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
			strSql.Append(" * ");
			strSql.Append(" FROM Invite ");
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
			strSql.Append("select count(1) FROM Invite ");
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
			strSql.Append(")AS Row, T.*  from Invite T ");
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
			parameters[0].Value = "Invite";
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

