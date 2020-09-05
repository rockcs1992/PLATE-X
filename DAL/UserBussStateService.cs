using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Model;

namespace DAL
{
	/// <summary>
	/// 数据访问类:UserBussStateService
	/// </summary>
	public partial class UserBussStateService
	{
		public UserBussStateService()
		{}


		#region  BasicMethod
        /// <summary>
        /// 更新所获荣誉和政府支持
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static int UpdateGovAndHonour(UserBussState model) 
        {
            string sql = "update UserBussState set serverAddress = '" + model.serverAddress + "',serverRName = '" + model.serverRName + "' where id = " + model.id;
            return DBHelperSQL.ExecuteSql(sql);
        }
        /// <summary>
        /// 修改所有信息时更新机构运营状态信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static int UpdateModAll(UserBussState model) 
        {
            string sql = "update UserBussState set businessArea = '" + model.businessArea + "',isHaveSeperate = '" + model.isHaveSeperate + "',serverPid = '" + model.serverPid + "',serverCid = " + model.serverCid + ",serverRegionId = " + model.serverRegionId + ",serverAddress = '" + model.serverAddress + "',remark = '" + model.remark + "',addTime = '" + model.addTime +"',infoType = " + model.infoType + ",serverPName = '" + model.serverPName + "',serverCName = '" + model.serverCName + "',serverRName = '" + model.serverRName + "' where addUser = " + model.addUser;
            return DBHelperSQL.ExecuteSql(sql);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Model.UserBussState GetModelByUserId(int addUser)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from UserBussState ");
            strSql.Append(" where addUser=@addUser");
            SqlParameter[] parameters = {
					new SqlParameter("@addUser", SqlDbType.Int,4)
			};
            parameters[0].Value = addUser;

            Model.UserBussState model = new Model.UserBussState();
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
        public static bool Exists(int addUser)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from UserBussState");
            strSql.Append(" where addUser=@addUser");
			SqlParameter[] parameters = {
					new SqlParameter("@addUser", SqlDbType.Int,4)
			};
            parameters[0].Value = addUser;

			return DBHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public static int Add(Model.UserBussState model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into UserBussState(");
            strSql.Append("businessArea,isHaveSeperate,serverPid,serverCid,serverRegionId,serverAddress,status,remark,addTime,addUser,infoType,serverPName,serverCName,serverRName)");
			strSql.Append(" values (");
            strSql.Append("@businessArea,@isHaveSeperate,@serverPid,@serverCid,@serverRegionId,@serverAddress,@status,@remark,@addTime,@addUser,@infoType,@serverPName,@serverCName,@serverRName)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@businessArea", SqlDbType.VarChar,1500),
					new SqlParameter("@isHaveSeperate", SqlDbType.VarChar,1504),
					new SqlParameter("@serverPid", SqlDbType.VarChar,1504),
					new SqlParameter("@serverCid", SqlDbType.Int,4),
					new SqlParameter("@serverRegionId", SqlDbType.Int,4),
					new SqlParameter("@serverAddress", SqlDbType.NText),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.VarChar,1500),
					new SqlParameter("@addTime", SqlDbType.DateTime),
					new SqlParameter("@addUser", SqlDbType.Int,4),
					new SqlParameter("@infoType", SqlDbType.Int,4),
                                        new SqlParameter("@serverPName", SqlDbType.VarChar,1500),
                                        new SqlParameter("@serverCName", SqlDbType.VarChar,1500),
                                        new SqlParameter("@serverRName", SqlDbType.NText)};
			parameters[0].Value = model.businessArea;
			parameters[1].Value = model.isHaveSeperate;
			parameters[2].Value = model.serverPid;
			parameters[3].Value = model.serverCid;
			parameters[4].Value = model.serverRegionId;
			parameters[5].Value = model.serverAddress;
			parameters[6].Value = model.status;
			parameters[7].Value = model.remark;
			parameters[8].Value = model.addTime;
			parameters[9].Value = model.addUser;
			parameters[10].Value = model.infoType;

            parameters[11].Value = model.serverPName;

            parameters[12].Value = model.serverCName;

            parameters[13].Value = model.serverRName;

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
		public static int Update(Model.UserBussState model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update UserBussState set ");
			strSql.Append("businessArea=@businessArea,");
			strSql.Append("isHaveSeperate=@isHaveSeperate,");
			strSql.Append("serverPid=@serverPid,");
			strSql.Append("serverCid=@serverCid,");
			strSql.Append("serverRegionId=@serverRegionId,");
			strSql.Append("serverAddress=@serverAddress,");
			strSql.Append("status=@status,");
			strSql.Append("remark=@remark,");
			strSql.Append("addTime=@addTime,");
			strSql.Append("addUser=@addUser,");
			strSql.Append("infoType=@infoType,");

            strSql.Append("serverPName=@serverPName,");
            strSql.Append("serverCName=@serverCName,");
            strSql.Append("serverRName=@serverRName");

			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@businessArea", SqlDbType.VarChar,1500),
					new SqlParameter("@isHaveSeperate", SqlDbType.VarChar,1504),
					new SqlParameter("@serverPid", SqlDbType.VarChar,1504),
					new SqlParameter("@serverCid", SqlDbType.Int,4),
					new SqlParameter("@serverRegionId", SqlDbType.Int,4),
					new SqlParameter("@serverAddress", SqlDbType.NText),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.VarChar,1500),
					new SqlParameter("@addTime", SqlDbType.DateTime),
					new SqlParameter("@addUser", SqlDbType.Int,4),
					new SqlParameter("@infoType", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4),
                    new SqlParameter("@serverPName", SqlDbType.VarChar,1500),
                                        new SqlParameter("@serverCName", SqlDbType.VarChar,1500),
                                        new SqlParameter("@serverRName", SqlDbType.NText)};
			parameters[0].Value = model.businessArea;
			parameters[1].Value = model.isHaveSeperate;
			parameters[2].Value = model.serverPid;
			parameters[3].Value = model.serverCid;
			parameters[4].Value = model.serverRegionId;
			parameters[5].Value = model.serverAddress;
			parameters[6].Value = model.status;
			parameters[7].Value = model.remark;
			parameters[8].Value = model.addTime;
			parameters[9].Value = model.addUser;
			parameters[10].Value = model.infoType;
			parameters[11].Value = model.id;

            parameters[12].Value = model.serverPName;
            parameters[13].Value = model.serverCName;
            parameters[14].Value = model.serverRName;

			int rows=DBHelperSQL.ExecuteSql(strSql.ToString(),parameters);
            return rows;
		}

		/// <summary>
		/// Delete一条数据
		/// </summary>
		public bool Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from UserBussState ");
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
			strSql.Append("delete from UserBussState ");
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
		public static Model.UserBussState GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,businessArea,isHaveSeperate,serverPid,serverCid,serverRegionId,serverAddress,status,remark,addTime,addUser,infoType from UserBussState ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Model.UserBussState model=new Model.UserBussState();
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
		public static Model.UserBussState DataRowToModel(DataRow row)
		{
			Model.UserBussState model=new Model.UserBussState();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["businessArea"]!=null)
				{
					model.businessArea=row["businessArea"].ToString();
				}
                model.isHaveSeperate = row["isHaveSeperate"].ToString();
                model.serverPid = row["serverPid"].ToString();
				if(row["serverCid"]!=null && row["serverCid"].ToString()!="")
				{
					model.serverCid=int.Parse(row["serverCid"].ToString());
				}
				if(row["serverRegionId"]!=null && row["serverRegionId"].ToString()!="")
				{
					model.serverRegionId=int.Parse(row["serverRegionId"].ToString());
				}
				if(row["serverAddress"]!=null)
				{
					model.serverAddress=row["serverAddress"].ToString();
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
                model.serverPName = row["serverPName"].ToString();
                model.serverCName = row["serverCName"].ToString();
                model.serverRName = row["serverRName"].ToString();
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,businessArea,isHaveSeperate,serverPid,serverCid,serverRegionId,serverAddress,status,remark,addTime,addUser,infoType ");
			strSql.Append(" FROM UserBussState ");
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
			strSql.Append(" id,businessArea,isHaveSeperate,serverPid,serverCid,serverRegionId,serverAddress,status,remark,addTime,addUser,infoType ");
			strSql.Append(" FROM UserBussState ");
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
			strSql.Append("select count(1) FROM UserBussState ");
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
			strSql.Append(")AS Row, T.*  from UserBussState T ");
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
			parameters[0].Value = "UserBussState";
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

