using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace DAL
{
	/// <summary>
	/// 数据访问类OnLinePayStatusService。
	/// </summary>
	public class OnLinePayStatusService
	{
		public OnLinePayStatusService()
		{}
		#region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool Exists(string orderNo,int num,string trade_no)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from OnLinePayStatus");
            if(num == 2 || num == 4)
            {
                strSql.Append(" where orderNo=@orderNo and payStatus=0");
                SqlParameter[] parameters = {
					new SqlParameter("@orderNo", SqlDbType.VarChar,50)};
                parameters[0].Value = orderNo;
                return DBHelperSQL.Exists(strSql.ToString(), parameters);
            }
            else if (num == 1)
            {
                strSql.Append(" where orderNo=@orderNo and payStatus=0 and remark='" + trade_no + "'");
                SqlParameter[] parameters = {
					new SqlParameter("@orderNo", SqlDbType.VarChar,50)};
                parameters[0].Value = orderNo;
                return DBHelperSQL.Exists(strSql.ToString(), parameters);
            }
            else if (num == 5)
            {
                strSql.Append(" where orderNo=@orderNo");
                SqlParameter[] parameters = {
					new SqlParameter("@orderNo", SqlDbType.VarChar,50)};
                parameters[0].Value = orderNo;
                return DBHelperSQL.Exists(strSql.ToString(), parameters);
            }
            else
            {
                return true;
            }
            
            
        }
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from OnLinePayStatus");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			return DBHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public static int Add(Model.OnLinePayStatus model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into OnLinePayStatus(");
			strSql.Append("orderNo,onLinePayType,payStatus,status,count,remark,addTime)");
			strSql.Append(" values (");
			strSql.Append("@orderNo,@onLinePayType,@payStatus,@status,@count,@remark,@addTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@orderNo", SqlDbType.VarChar,50),
					new SqlParameter("@onLinePayType", SqlDbType.Int,4),
					new SqlParameter("@payStatus", SqlDbType.Int,4),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@count", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.VarChar,150),
					new SqlParameter("@addTime", SqlDbType.DateTime)};
			parameters[0].Value = model.orderNo;
			parameters[1].Value = model.onLinePayType;
			parameters[2].Value = model.payStatus;
			parameters[3].Value = model.status;
			parameters[4].Value = model.count;
			parameters[5].Value = model.remark;
			parameters[6].Value = model.addTime;

			object obj = DBHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 1;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Model.OnLinePayStatus model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update OnLinePayStatus set ");
			strSql.Append("orderNo=@orderNo,");
			strSql.Append("onLinePayType=@onLinePayType,");
			strSql.Append("payStatus=@payStatus,");
			strSql.Append("status=@status,");
			strSql.Append("count=@count,");
			strSql.Append("remark=@remark,");
			strSql.Append("addTime=@addTime");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@orderNo", SqlDbType.VarChar,50),
					new SqlParameter("@onLinePayType", SqlDbType.Int,4),
					new SqlParameter("@payStatus", SqlDbType.Int,4),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@count", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.VarChar,150),
					new SqlParameter("@addTime", SqlDbType.DateTime)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.orderNo;
			parameters[2].Value = model.onLinePayType;
			parameters[3].Value = model.payStatus;
			parameters[4].Value = model.status;
			parameters[5].Value = model.count;
			parameters[6].Value = model.remark;
			parameters[7].Value = model.addTime;

			DBHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// Delete一条数据
		/// </summary>
		public void Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from OnLinePayStatus ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			DBHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Model.OnLinePayStatus GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,orderNo,onLinePayType,payStatus,status,count,remark,addTime from OnLinePayStatus ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			Model.OnLinePayStatus model=new Model.OnLinePayStatus();
			DataSet ds=DBHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.orderNo=ds.Tables[0].Rows[0]["orderNo"].ToString();
				if(ds.Tables[0].Rows[0]["onLinePayType"].ToString()!="")
				{
					model.onLinePayType=int.Parse(ds.Tables[0].Rows[0]["onLinePayType"].ToString());
				}
				if(ds.Tables[0].Rows[0]["payStatus"].ToString()!="")
				{
					model.payStatus=int.Parse(ds.Tables[0].Rows[0]["payStatus"].ToString());
				}
				if(ds.Tables[0].Rows[0]["status"].ToString()!="")
				{
					model.status=int.Parse(ds.Tables[0].Rows[0]["status"].ToString());
				}
				if(ds.Tables[0].Rows[0]["count"].ToString()!="")
				{
					model.count=int.Parse(ds.Tables[0].Rows[0]["count"].ToString());
				}
				model.remark=ds.Tables[0].Rows[0]["remark"].ToString();
				if(ds.Tables[0].Rows[0]["addTime"].ToString()!="")
				{
					model.addTime=DateTime.Parse(ds.Tables[0].Rows[0]["addTime"].ToString());
				}
				return model;
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,orderNo,onLinePayType,payStatus,status,count,remark,addTime ");
			strSql.Append(" FROM OnLinePayStatus ");
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
			strSql.Append(" id,orderNo,onLinePayType,payStatus,status,count,remark,addTime ");
			strSql.Append(" FROM OnLinePayStatus ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
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
			parameters[0].Value = "OnLinePayStatus";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DBHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  成员方法
	}
}

