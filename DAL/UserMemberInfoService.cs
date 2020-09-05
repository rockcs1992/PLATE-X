using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace DAL
{
	/// <summary>
	/// 数据访问类:UserMemberInfoService
	/// </summary>
	public partial class UserMemberInfoService
	{
		public UserMemberInfoService()
		{}
		#region  BasicMethod
        /// <summary>
        ///修改所有信息时更新机构运营状况信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static int UpdateModALl2(Model.UserMemberInfo model)
        {
            string sql = "update UserMemberInfo set manageMemCount = " + model.manageMemCount + ",taskUserWorkYears = " + model.taskUserWorkYears + ",busiUserName = '" + model.busiUserName + "',tel = '" + model.tel + "',address = '" + model.address + "',zipCode = '" + model.zipCode + "',email = '" + model.email + "',fax = '" + model.fax + "' where userId = " + model.userId;
            return DBHelperSQL.ExecuteSql(sql);
        }
        /// <summary>
        /// 修改所有信息时更新我的主页顶部信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static int UpdateModAll(Model.UserMemberInfo model) 
        {
            string sql = "update UserMemberInfo set busiUserName = '" + model.busiUserName + "',tel = '" + model.tel + "',zipCode = '" + model.zipCode + "',address = '" + model.address + "' where userId = " + model.userId;
            return DBHelperSQL.ExecuteSql(sql);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Model.UserMemberInfo GetModelByUserId(int userId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,userId,memCount,isHaveAccountUser,manageMemCount,taskUserWorkYears,busiUserName,tel,address,zipCode,email,fax,instituteDesc,status,remark,addTime,addUser,infoType from UserMemberInfo ");
            strSql.Append(" where userId=@userId");
            SqlParameter[] parameters = {
					new SqlParameter("@userId", SqlDbType.Int,4)
			};
            parameters[0].Value = userId;

            Model.UserMemberInfo model = new Model.UserMemberInfo();
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
		/// 是否存在该记录
		/// </summary>
        public static bool Exists(int userId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from UserMemberInfo");
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
		public static int Add(Model.UserMemberInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into UserMemberInfo(");
			strSql.Append("userId,memCount,isHaveAccountUser,manageMemCount,taskUserWorkYears,busiUserName,tel,address,zipCode,email,fax,instituteDesc,status,remark,addTime,addUser,infoType)");
			strSql.Append(" values (");
			strSql.Append("@userId,@memCount,@isHaveAccountUser,@manageMemCount,@taskUserWorkYears,@busiUserName,@tel,@address,@zipCode,@email,@fax,@instituteDesc,@status,@remark,@addTime,@addUser,@infoType)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@userId", SqlDbType.Int,4),
					new SqlParameter("@memCount", SqlDbType.Int,4),
					new SqlParameter("@isHaveAccountUser", SqlDbType.Int,4),
					new SqlParameter("@manageMemCount", SqlDbType.Int,4),
					new SqlParameter("@taskUserWorkYears", SqlDbType.Int,4),
					new SqlParameter("@busiUserName", SqlDbType.VarChar,50),
					new SqlParameter("@tel", SqlDbType.VarChar,50),
					new SqlParameter("@address", SqlDbType.VarChar,150),
					new SqlParameter("@zipCode", SqlDbType.VarChar,50),
					new SqlParameter("@email", SqlDbType.VarChar,50),
					new SqlParameter("@fax", SqlDbType.VarChar,50),
					new SqlParameter("@instituteDesc", SqlDbType.NText),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.VarChar,150),
					new SqlParameter("@addTime", SqlDbType.DateTime),
					new SqlParameter("@addUser", SqlDbType.Int,4),
					new SqlParameter("@infoType", SqlDbType.Int,4)};
			parameters[0].Value = model.userId;
			parameters[1].Value = model.memCount;
			parameters[2].Value = model.isHaveAccountUser;
			parameters[3].Value = model.manageMemCount;
			parameters[4].Value = model.taskUserWorkYears;
			parameters[5].Value = model.busiUserName;
			parameters[6].Value = model.tel;
			parameters[7].Value = model.address;
			parameters[8].Value = model.zipCode;
			parameters[9].Value = model.email;
			parameters[10].Value = model.fax;
			parameters[11].Value = model.instituteDesc;
			parameters[12].Value = model.status;
			parameters[13].Value = model.remark;
			parameters[14].Value = model.addTime;
			parameters[15].Value = model.addUser;
			parameters[16].Value = model.infoType;

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
		public static int Update(Model.UserMemberInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update UserMemberInfo set ");
			strSql.Append("userId=@userId,");
			strSql.Append("memCount=@memCount,");
			strSql.Append("isHaveAccountUser=@isHaveAccountUser,");
			strSql.Append("manageMemCount=@manageMemCount,");
			strSql.Append("taskUserWorkYears=@taskUserWorkYears,");
			strSql.Append("busiUserName=@busiUserName,");
			strSql.Append("tel=@tel,");
			strSql.Append("address=@address,");
			strSql.Append("zipCode=@zipCode,");
			strSql.Append("email=@email,");
			strSql.Append("fax=@fax,");
			strSql.Append("instituteDesc=@instituteDesc,");
			strSql.Append("status=@status,");
			strSql.Append("remark=@remark,");
			strSql.Append("addTime=@addTime,");
			strSql.Append("addUser=@addUser,");
			strSql.Append("infoType=@infoType");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@userId", SqlDbType.Int,4),
					new SqlParameter("@memCount", SqlDbType.Int,4),
					new SqlParameter("@isHaveAccountUser", SqlDbType.Int,4),
					new SqlParameter("@manageMemCount", SqlDbType.Int,4),
					new SqlParameter("@taskUserWorkYears", SqlDbType.Int,4),
					new SqlParameter("@busiUserName", SqlDbType.VarChar,50),
					new SqlParameter("@tel", SqlDbType.VarChar,50),
					new SqlParameter("@address", SqlDbType.VarChar,150),
					new SqlParameter("@zipCode", SqlDbType.VarChar,50),
					new SqlParameter("@email", SqlDbType.VarChar,50),
					new SqlParameter("@fax", SqlDbType.VarChar,50),
					new SqlParameter("@instituteDesc", SqlDbType.NText),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.VarChar,150),
					new SqlParameter("@addTime", SqlDbType.DateTime),
					new SqlParameter("@addUser", SqlDbType.Int,4),
					new SqlParameter("@infoType", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.userId;
			parameters[1].Value = model.memCount;
			parameters[2].Value = model.isHaveAccountUser;
			parameters[3].Value = model.manageMemCount;
			parameters[4].Value = model.taskUserWorkYears;
			parameters[5].Value = model.busiUserName;
			parameters[6].Value = model.tel;
			parameters[7].Value = model.address;
			parameters[8].Value = model.zipCode;
			parameters[9].Value = model.email;
			parameters[10].Value = model.fax;
			parameters[11].Value = model.instituteDesc;
			parameters[12].Value = model.status;
			parameters[13].Value = model.remark;
			parameters[14].Value = model.addTime;
			parameters[15].Value = model.addUser;
			parameters[16].Value = model.infoType;
			parameters[17].Value = model.id;

			int rows=DBHelperSQL.ExecuteSql(strSql.ToString(),parameters);
            return rows;
		}

		/// <summary>
		/// Delete一条数据
		/// </summary>
		public bool Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from UserMemberInfo ");
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
			strSql.Append("delete from UserMemberInfo ");
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
		public static Model.UserMemberInfo GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,userId,memCount,isHaveAccountUser,manageMemCount,taskUserWorkYears,busiUserName,tel,address,zipCode,email,fax,instituteDesc,status,remark,addTime,addUser,infoType from UserMemberInfo ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Model.UserMemberInfo model=new Model.UserMemberInfo();
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
		public static Model.UserMemberInfo DataRowToModel(DataRow row)
		{
			Model.UserMemberInfo model=new Model.UserMemberInfo();
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
				if(row["memCount"]!=null && row["memCount"].ToString()!="")
				{
					model.memCount=int.Parse(row["memCount"].ToString());
				}
				if(row["isHaveAccountUser"]!=null && row["isHaveAccountUser"].ToString()!="")
				{
					model.isHaveAccountUser=int.Parse(row["isHaveAccountUser"].ToString());
				}
				if(row["manageMemCount"]!=null && row["manageMemCount"].ToString()!="")
				{
					model.manageMemCount=int.Parse(row["manageMemCount"].ToString());
				}
				if(row["taskUserWorkYears"]!=null && row["taskUserWorkYears"].ToString()!="")
				{
					model.taskUserWorkYears=int.Parse(row["taskUserWorkYears"].ToString());
				}
				if(row["busiUserName"]!=null)
				{
					model.busiUserName=row["busiUserName"].ToString();
				}
				if(row["tel"]!=null)
				{
					model.tel=row["tel"].ToString();
				}
				if(row["address"]!=null)
				{
					model.address=row["address"].ToString();
				}
				if(row["zipCode"]!=null)
				{
					model.zipCode=row["zipCode"].ToString();
				}
				if(row["email"]!=null)
				{
					model.email=row["email"].ToString();
				}
				if(row["fax"]!=null)
				{
					model.fax=row["fax"].ToString();
				}
				if(row["instituteDesc"]!=null)
				{
					model.instituteDesc=row["instituteDesc"].ToString();
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
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,userId,memCount,isHaveAccountUser,manageMemCount,taskUserWorkYears,busiUserName,tel,address,zipCode,email,fax,instituteDesc,status,remark,addTime,addUser,infoType ");
			strSql.Append(" FROM UserMemberInfo ");
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
			strSql.Append(" id,userId,memCount,isHaveAccountUser,manageMemCount,taskUserWorkYears,busiUserName,tel,address,zipCode,email,fax,instituteDesc,status,remark,addTime,addUser,infoType ");
			strSql.Append(" FROM UserMemberInfo ");
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
			strSql.Append("select count(1) FROM UserMemberInfo ");
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
			strSql.Append(")AS Row, T.*  from UserMemberInfo T ");
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
			parameters[0].Value = "UserMemberInfo";
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

