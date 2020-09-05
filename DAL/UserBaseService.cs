using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Model;

namespace DAL
{
	/// <summary>
	/// 数据访问类:UserBaseService
	/// </summary>
	public partial class UserBaseService
	{
		public UserBaseService()
		{}
		#region  BasicMethod
        /// <summary>
        /// 更新全称
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fullName"></param>
        /// <returns></returns>
        public static int UpdateFullName(int id,string fullName) 
        {
            string sql = "update UserBase set fullName = '" + fullName + "' where id = " + id;
            return DBHelperSQL.ExecuteSql(sql);
        }

        /// <summary>
        /// 修改所有信息中更改基本信息
        /// </summary>
        /// <returns></returns>
        public static int UpdateModAll(UserBase item)
        {
            string sql = "update UserBase set fullName = '" + item.fullName + "',regCode = '" + item.regCode + "',createDate = '" + item.createDate + "',liveAddress = '" + item.liveAddress + "',organizeCode = '" + item.organizeCode + "',artificialName = '" + item.artificialName + "',artificialBodyCode = '" + item.artificialBodyCode + "',artificialMobile = '" + item.artificialMobile + "',remark = '" + item.remark + "' where id = " + item.id;
            return DBHelperSQL.ExecuteSql(sql);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Model.UserBase GetModelByUserId(int userId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from UserBase ");
            strSql.Append(" where userId=@userId ");
            SqlParameter[] parameters = {
					new SqlParameter("@userId", SqlDbType.Int,4)			};
            parameters[0].Value = userId;

            Model.UserBase model = new Model.UserBase();
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
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DBHelperSQL.GetMaxID("id", "UserBase"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
        public static bool Exists(int userId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from UserBase");
            strSql.Append(" where userId=@userId ");
			SqlParameter[] parameters = {
					new SqlParameter("@userId", SqlDbType.Int,4)			};
            parameters[0].Value = userId;

			return DBHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public static int Add(Model.UserBase model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into UserBase(");
            strSql.Append("userId,fullName,regCode,createDate,liveAddress,memAllTotal,organizeCode,artificialName,artificialBodyCode,artificialMobile,status,remark,addTime,addUser,infoType)");
			strSql.Append(" values (");
			strSql.Append("@userId,@fullName,@regCode,@createDate,@liveAddress,@memAllTotal,@organizeCode,@artificialName,@artificialBodyCode,@artificialMobile,@status,@remark,@addTime,@addUser,@infoType)");
			SqlParameter[] parameters = {
					new SqlParameter("@userId", SqlDbType.Int,4),
					new SqlParameter("@fullName", SqlDbType.VarChar,150),
					new SqlParameter("@regCode", SqlDbType.VarChar,50),
					new SqlParameter("@createDate", SqlDbType.VarChar,150),
					new SqlParameter("@liveAddress", SqlDbType.VarChar,150),
					new SqlParameter("@memAllTotal", SqlDbType.Money,8),
					new SqlParameter("@organizeCode", SqlDbType.VarChar,1500),
					new SqlParameter("@artificialName", SqlDbType.VarChar,50),
					new SqlParameter("@artificialBodyCode", SqlDbType.VarChar,50),
					new SqlParameter("@artificialMobile", SqlDbType.VarChar,50),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.VarChar,500),
					new SqlParameter("@addTime", SqlDbType.DateTime),
					new SqlParameter("@addUser", SqlDbType.Int,4),
					new SqlParameter("@infoType", SqlDbType.Int,4)};
			parameters[0].Value = model.userId;
			parameters[1].Value = model.fullName;
			parameters[2].Value = model.regCode;
			parameters[3].Value = model.createDate;
			parameters[4].Value = model.liveAddress;
			parameters[5].Value = model.memAllTotal;
			parameters[6].Value = model.organizeCode;
			parameters[7].Value = model.artificialName;
			parameters[8].Value = model.artificialBodyCode;
			parameters[9].Value = model.artificialMobile;
			parameters[10].Value = model.status;
			parameters[11].Value = model.remark;
			parameters[12].Value = model.addTime;
			parameters[13].Value = model.addUser;
			parameters[14].Value = model.infoType;

			int rows=DBHelperSQL.ExecuteSql(strSql.ToString(),parameters);
            return rows;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public static int Update(Model.UserBase model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update UserBase set ");
			strSql.Append("userId=@userId,");
			strSql.Append("fullName=@fullName,");
			strSql.Append("regCode=@regCode,");
			strSql.Append("createDate=@createDate,");
			strSql.Append("liveAddress=@liveAddress,");
			strSql.Append("memAllTotal=@memAllTotal,");
			strSql.Append("organizeCode=@organizeCode,");
			strSql.Append("artificialName=@artificialName,");
			strSql.Append("artificialBodyCode=@artificialBodyCode,");
			strSql.Append("artificialMobile=@artificialMobile,");
            strSql.Append("status=@status,");
			strSql.Append("remark=@remark,");
			strSql.Append("addTime=@addTime,");
			strSql.Append("addUser=@addUser,");
			strSql.Append("infoType=@infoType");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@userId", SqlDbType.Int,4),
					new SqlParameter("@fullName", SqlDbType.VarChar,150),
					new SqlParameter("@regCode", SqlDbType.VarChar,50),
					new SqlParameter("@createDate", SqlDbType.VarChar,150),
					new SqlParameter("@liveAddress", SqlDbType.VarChar,150),
					new SqlParameter("@memAllTotal", SqlDbType.Money,8),
					new SqlParameter("@organizeCode", SqlDbType.VarChar,1500),
					new SqlParameter("@artificialName", SqlDbType.VarChar,50),
					new SqlParameter("@artificialBodyCode", SqlDbType.VarChar,50),
					new SqlParameter("@artificialMobile", SqlDbType.VarChar,50),

					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.VarChar,500),
					new SqlParameter("@addTime", SqlDbType.DateTime),
					new SqlParameter("@addUser", SqlDbType.Int,4),
					new SqlParameter("@infoType", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.userId;
			parameters[1].Value = model.fullName;
			parameters[2].Value = model.regCode;
			parameters[3].Value = model.createDate;
			parameters[4].Value = model.liveAddress;
			parameters[5].Value = model.memAllTotal;
			parameters[6].Value = model.organizeCode;
			parameters[7].Value = model.artificialName;
			parameters[8].Value = model.artificialBodyCode;
			parameters[9].Value = model.artificialMobile;
			parameters[10].Value = model.status;
			parameters[11].Value = model.remark;
			parameters[12].Value = model.addTime;
			parameters[13].Value = model.addUser;
			parameters[14].Value = model.infoType;
			parameters[15].Value = model.id;

			int rows=DBHelperSQL.ExecuteSql(strSql.ToString(),parameters);
            return rows;
		}

		/// <summary>
		/// Delete一条数据
		/// </summary>
		public bool Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from UserBase ");
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
			strSql.Append("delete from UserBase ");
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
		public static Model.UserBase GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 * from UserBase ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)			};
			parameters[0].Value = id;

			Model.UserBase model=new Model.UserBase();
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
		public static Model.UserBase DataRowToModel(DataRow row)
		{
			Model.UserBase model=new Model.UserBase();
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
				if(row["fullName"]!=null)
				{
					model.fullName=row["fullName"].ToString();
				}
				if(row["regCode"]!=null)
				{
					model.regCode=row["regCode"].ToString();
				}
				if(row["createDate"]!=null && row["createDate"].ToString()!="")
				{
					model.createDate=row["createDate"].ToString();
				}
				if(row["liveAddress"]!=null)
				{
					model.liveAddress=row["liveAddress"].ToString();
				}
				if(row["memAllTotal"]!=null && row["memAllTotal"].ToString()!="")
				{
					model.memAllTotal=double.Parse(row["memAllTotal"].ToString());
				}
				if(row["organizeCode"]!=null)
				{
					model.organizeCode=row["organizeCode"].ToString();
				}
				if(row["artificialName"]!=null)
				{
					model.artificialName=row["artificialName"].ToString();
				}
				if(row["artificialBodyCode"]!=null)
				{
					model.artificialBodyCode=row["artificialBodyCode"].ToString();
				}
				if(row["artificialMobile"]!=null)
				{
					model.artificialMobile=row["artificialMobile"].ToString();
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
		/// 获得数据列表
		/// </summary>
		public static DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select * ");
			strSql.Append(" FROM UserBase ");
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
            strSql.Append(" * ");
			strSql.Append(" FROM UserBase ");
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
			strSql.Append("select count(1) FROM UserBase ");
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
			strSql.Append(")AS Row, T.*  from UserBase T ");
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
			parameters[0].Value = "UserBase";
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

