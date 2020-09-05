using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace DAL
{
	/// <summary>
	/// 数据访问类:UserAccountService
	/// </summary>
	public partial class UserAccountService
	{
		public UserAccountService()
		{}
		#region  BasicMethod
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Model.UserAccount GetModelByUserId(int userId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from UserAccount ");
            strSql.Append(" where userId=@userId order by id desc");
            SqlParameter[] parameters = {
					new SqlParameter("@userId", SqlDbType.Int,4)
			};
            parameters[0].Value = userId;

            Model.UserAccount model = new Model.UserAccount();
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
        /// 获取原乡卡总余额
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static string GetUseTotal(int userId, int status)
        {
            string sql = "select sum(orderTotal) as orderTotal from UserAccount where status = " + status;
            object obj = DBHelperSQL.GetSingle(sql);
            if (obj != null)
            {
                return Convert.ToDouble(obj).ToString("0.00");
            }
            return "0";
        }
		/// <summary>
		/// 是否存在该记录
		/// </summary>
        public static bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from UserAccount");
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
		public static int Add(Model.UserAccount model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into UserAccount(");
			strSql.Append("typeId,typeName,userId,orderId,orderNo,orderTotal,payType,moneyValue,status,remark,addTime,addUser,infoType)");
			strSql.Append(" values (");
			strSql.Append("@typeId,@typeName,@userId,@orderId,@orderNo,@orderTotal,@payType,@moneyValue,@status,@remark,@addTime,@addUser,@infoType)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@typeId", SqlDbType.Int,4),
					new SqlParameter("@typeName", SqlDbType.VarChar,150),
					new SqlParameter("@userId", SqlDbType.Int,4),
					new SqlParameter("@orderId", SqlDbType.Int,4),
					new SqlParameter("@orderNo", SqlDbType.VarChar,150),
					new SqlParameter("@orderTotal", SqlDbType.Money,8),
					new SqlParameter("@payType", SqlDbType.Int,4),
					new SqlParameter("@moneyValue", SqlDbType.Money,8),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.VarChar,150),
					new SqlParameter("@addTime", SqlDbType.DateTime),
					new SqlParameter("@addUser", SqlDbType.Int,4),
					new SqlParameter("@infoType", SqlDbType.Int,4)};
			parameters[0].Value = model.typeId;
			parameters[1].Value = model.typeName;
			parameters[2].Value = model.userId;
			parameters[3].Value = model.orderId;
			parameters[4].Value = model.orderNo;
			parameters[5].Value = model.orderTotal;
			parameters[6].Value = model.payType;
			parameters[7].Value = model.moneyValue;
			parameters[8].Value = model.status;
			parameters[9].Value = model.remark;
			parameters[10].Value = model.addTime;
			parameters[11].Value = model.addUser;
			parameters[12].Value = model.infoType;

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
        public static bool Update(Model.UserAccount model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update UserAccount set ");
			strSql.Append("typeId=@typeId,");
			strSql.Append("typeName=@typeName,");
			strSql.Append("userId=@userId,");
			strSql.Append("orderId=@orderId,");
			strSql.Append("orderNo=@orderNo,");
			strSql.Append("orderTotal=@orderTotal,");
			strSql.Append("payType=@payType,");
			strSql.Append("moneyValue=@moneyValue,");
			strSql.Append("status=@status,");
			strSql.Append("remark=@remark,");
			strSql.Append("addTime=@addTime,");
			strSql.Append("addUser=@addUser,");
			strSql.Append("infoType=@infoType");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@typeId", SqlDbType.Int,4),
					new SqlParameter("@typeName", SqlDbType.VarChar,150),
					new SqlParameter("@userId", SqlDbType.Int,4),
					new SqlParameter("@orderId", SqlDbType.Int,4),
					new SqlParameter("@orderNo", SqlDbType.VarChar,150),
					new SqlParameter("@orderTotal", SqlDbType.Money,8),
					new SqlParameter("@payType", SqlDbType.Int,4),
					new SqlParameter("@moneyValue", SqlDbType.Money,8),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.VarChar,150),
					new SqlParameter("@addTime", SqlDbType.DateTime),
					new SqlParameter("@addUser", SqlDbType.Int,4),
					new SqlParameter("@infoType", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.typeId;
			parameters[1].Value = model.typeName;
			parameters[2].Value = model.userId;
			parameters[3].Value = model.orderId;
			parameters[4].Value = model.orderNo;
			parameters[5].Value = model.orderTotal;
			parameters[6].Value = model.payType;
			parameters[7].Value = model.moneyValue;
			parameters[8].Value = model.status;
			parameters[9].Value = model.remark;
			parameters[10].Value = model.addTime;
			parameters[11].Value = model.addUser;
			parameters[12].Value = model.infoType;
			parameters[13].Value = model.id;

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
			strSql.Append("delete from UserAccount ");
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
        public static bool DeleteList(string idlist)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from UserAccount ");
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
        public static Model.UserAccount GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,typeId,typeName,userId,orderId,orderNo,orderTotal,payType,moneyValue,status,remark,addTime,addUser,infoType from UserAccount ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Model.UserAccount model=new Model.UserAccount();
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
        public static Model.UserAccount DataRowToModel(DataRow row)
		{
			Model.UserAccount model=new Model.UserAccount();
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
				if(row["userId"]!=null && row["userId"].ToString()!="")
				{
					model.userId=int.Parse(row["userId"].ToString());
				}
				if(row["orderId"]!=null && row["orderId"].ToString()!="")
				{
					model.orderId=int.Parse(row["orderId"].ToString());
				}
				if(row["orderNo"]!=null)
				{
					model.orderNo=row["orderNo"].ToString();
				}
				if(row["orderTotal"]!=null && row["orderTotal"].ToString()!="")
				{
					model.orderTotal=double.Parse(row["orderTotal"].ToString());
				}
				if(row["payType"]!=null && row["payType"].ToString()!="")
				{
					model.payType=int.Parse(row["payType"].ToString());
				}
				if(row["moneyValue"]!=null && row["moneyValue"].ToString()!="")
				{
					model.moneyValue=double.Parse(row["moneyValue"].ToString());
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
			strSql.Append("select id,typeId,typeName,userId,orderId,orderNo,orderTotal,payType,moneyValue,status,remark,addTime,addUser,infoType ");
			strSql.Append(" FROM UserAccount ");
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
        public static DataSet GetList(int Top, string strWhere, string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" id,typeId,typeName,userId,orderId,orderNo,orderTotal,payType,moneyValue,status,remark,addTime,addUser,infoType ");
			strSql.Append(" FROM UserAccount ");
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
			strSql.Append("select count(1) FROM UserAccount ");
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
			strSql.Append(")AS Row, T.*  from UserAccount T ");
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
			parameters[0].Value = "UserAccount";
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

