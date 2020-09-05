using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace DAL
{
	/// <summary>
	/// 数据访问类:OrderDetailService
	/// </summary>
	public partial class OrderDetailService
	{
		public OrderDetailService()
		{}
		#region  BasicMethod
        /// <summary>
        /// 查询最新销售订单
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static DataSet GetSaleOrder(int userId)
        {
            string sql = "select max(orderId)as orderId from OrderDetail where productId in(select id from Product where useId = " + userId + ") group by orderId";
            return DBHelperSQL.Query(sql);
        }
        /// <summary>
        /// 更改备货状态
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public static int UpdateInfoTypeByOrderId(int userId,int orderId,int num)
        {
            string sql = "update OrderDetail set infoType = " + num + " where orderId = " + orderId + " and productId in(select id from Product where useId = " + userId + ")";
            return DBHelperSQL.ExecuteSql(sql);
        }
        /// <summary>
        /// 查询最新销售订单
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static DataSet GetSaleOrder(int userId,int status) 
        {
            if (status != 100)
            {
                string sql = "select max(orderId)as orderId from OrderDetail where productId in(select id from Product where useId = " + userId + ") and infoType = " + status + " group by orderId";
                return DBHelperSQL.Query(sql);
            }
            else
            {
                string sql = "select max(orderId)as orderId from OrderDetail where productId in(select id from Product where useId = " + userId + ") group by orderId";
                return DBHelperSQL.Query(sql);
            }
            
        }
        /// <summary>
        /// 获取已购产品种类Quantity
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static int GetProductTypeCount(int userId)
        {
           // DataSet ds = ProductService.GetList("id in(select productId from OrderDetail where orderId in (select id from OrderInfo where addUser = " + user.id + " and status in(1,2,3,4)))");
            string sql = "select count(productId) as productCount from orderdetail where orderId in(select id from OrderInfo where status in(0,1,2,3,4) and addUser = " + userId + ")";
            object obj = DBHelperSQL.GetSingle(sql);
            if(obj != null)
            {
                return Convert.ToInt32(obj);
            }
            return 0;
        }
        /// <summary>
        /// 购买的产品信息
        /// </summary>
        /// <returns></returns>
        public static DataSet GetProduct(int addUser) 
        {
            string sql = "select max(productId) as productId from OrderDetail where orderId in(select id from OrderInfo where addUser = " + addUser + ")  group by productId";
            return DBHelperSQL.Query(sql);
        }
        /// <summary>
        /// 查询订单产品Quantity
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public static int GetProductCount(int orderId) 
        {
            string sql = "select sum(productCount) from OrderDetail where orderId = " + orderId;
            object obj = DBHelperSQL.GetSingle(sql);
            if(obj != null)
            {
                return Convert.ToInt32(obj);
            }
            return 0;
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Model.OrderDetail GetModelByProductId(int productId,int addUser)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,orderId,orderNo,productId,productCount,isActive,activeCode,activeMoney,total,satus,remark,infoType from OrderDetail ");
            strSql.Append(" where productId=@productId and orderId in(select id from OrderInfo where addUser = " + addUser + ") order by id asc");
            SqlParameter[] parameters = {
					new SqlParameter("@productId", SqlDbType.Int,4)
			};
            parameters[0].Value = productId;

            Model.OrderDetail model = new Model.OrderDetail();
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
        /// 获取评价的产品
        /// </summary>
        /// <returns></returns>
        public static DataSet GetAssess(int userId) 
        {
            string sql = "select max(productId) as productId from OrderDetail where orderId in(select id from OrderInfo where addUser = " + userId + ") and satus = 1 group by productId";
            return DBHelperSQL.Query(sql);
        }
        /// <summary>
        /// 更新订单详细付款状态
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public static int UpdatePayStatus(string orderNo)
        {
            string sql = "update OrderDetail set satus = 1 where orderNo = '" + orderNo + "'";
            return DBHelperSQL.ExecuteSql(sql);
        }
        /// <summary>
        /// 更新订单详细状态
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public static int UpdateStatus(int orderId, int status) 
        {
            string sql = "update OrderDetail set satus = " + status + " where orderId = " + orderId;
            return DBHelperSQL.ExecuteSql(sql);
        }
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from OrderDetail");
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
		public static int Add(Model.OrderDetail model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into OrderDetail(");
			strSql.Append("orderId,orderNo,productId,productCount,isActive,activeCode,activeMoney,total,satus,remark,infoType)");
			strSql.Append(" values (");
			strSql.Append("@orderId,@orderNo,@productId,@productCount,@isActive,@activeCode,@activeMoney,@total,@satus,@remark,@infoType)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@orderId", SqlDbType.Int,4),
					new SqlParameter("@orderNo", SqlDbType.VarChar,50),
					new SqlParameter("@productId", SqlDbType.Int,4),
					new SqlParameter("@productCount", SqlDbType.Int,4),
					new SqlParameter("@isActive", SqlDbType.Int,4),
					new SqlParameter("@activeCode", SqlDbType.VarChar,50),
					new SqlParameter("@activeMoney", SqlDbType.Money,8),
					new SqlParameter("@total", SqlDbType.Money,8),
					new SqlParameter("@satus", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.VarChar,50),
					new SqlParameter("@infoType", SqlDbType.Int,4)};
			parameters[0].Value = model.orderId;
			parameters[1].Value = model.orderNo;
			parameters[2].Value = model.productId;
			parameters[3].Value = model.productCount;
			parameters[4].Value = model.isActive;
			parameters[5].Value = model.activeCode;
			parameters[6].Value = model.activeMoney;
			parameters[7].Value = model.total;
			parameters[8].Value = model.satus;
			parameters[9].Value = model.remark;
			parameters[10].Value = model.infoType;

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
		public bool Update(Model.OrderDetail model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update OrderDetail set ");
			strSql.Append("orderId=@orderId,");
			strSql.Append("orderNo=@orderNo,");
			strSql.Append("productId=@productId,");
			strSql.Append("productCount=@productCount,");
			strSql.Append("isActive=@isActive,");
			strSql.Append("activeCode=@activeCode,");
			strSql.Append("activeMoney=@activeMoney,");
			strSql.Append("total=@total,");
			strSql.Append("satus=@satus,");
			strSql.Append("remark=@remark,");
			strSql.Append("infoType=@infoType");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@orderId", SqlDbType.Int,4),
					new SqlParameter("@orderNo", SqlDbType.VarChar,50),
					new SqlParameter("@productId", SqlDbType.Int,4),
					new SqlParameter("@productCount", SqlDbType.Int,4),
					new SqlParameter("@isActive", SqlDbType.Int,4),
					new SqlParameter("@activeCode", SqlDbType.VarChar,50),
					new SqlParameter("@activeMoney", SqlDbType.Money,8),
					new SqlParameter("@total", SqlDbType.Money,8),
					new SqlParameter("@satus", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.VarChar,50),
					new SqlParameter("@infoType", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.orderId;
			parameters[1].Value = model.orderNo;
			parameters[2].Value = model.productId;
			parameters[3].Value = model.productCount;
			parameters[4].Value = model.isActive;
			parameters[5].Value = model.activeCode;
			parameters[6].Value = model.activeMoney;
			parameters[7].Value = model.total;
			parameters[8].Value = model.satus;
			parameters[9].Value = model.remark;
			parameters[10].Value = model.infoType;
			parameters[11].Value = model.id;

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
			strSql.Append("delete from OrderDetail ");
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
			strSql.Append("delete from OrderDetail ");
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
        public static Model.OrderDetail GetModel(int orderId, int productId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,orderId,orderNo,productId,productCount,isActive,activeCode,activeMoney,total,satus,remark,infoType from OrderDetail ");
            strSql.Append(" where orderId=@orderId and productId = " + productId);
            SqlParameter[] parameters = {
					new SqlParameter("@orderId", SqlDbType.Int,4)
			};
            parameters[0].Value = orderId;

            Model.OrderDetail model = new Model.OrderDetail();
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
		/// 得到一个对象实体
		/// </summary>
		public static Model.OrderDetail GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,orderId,orderNo,productId,productCount,isActive,activeCode,activeMoney,total,satus,remark,infoType from OrderDetail ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Model.OrderDetail model=new Model.OrderDetail();
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
		public static Model.OrderDetail DataRowToModel(DataRow row)
		{
			Model.OrderDetail model=new Model.OrderDetail();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["orderId"]!=null && row["orderId"].ToString()!="")
				{
					model.orderId=int.Parse(row["orderId"].ToString());
				}
				if(row["orderNo"]!=null)
				{
					model.orderNo=row["orderNo"].ToString();
				}
				if(row["productId"]!=null && row["productId"].ToString()!="")
				{
					model.productId=int.Parse(row["productId"].ToString());
				}
				if(row["productCount"]!=null && row["productCount"].ToString()!="")
				{
					model.productCount=int.Parse(row["productCount"].ToString());
				}
				if(row["isActive"]!=null && row["isActive"].ToString()!="")
				{
					model.isActive=int.Parse(row["isActive"].ToString());
				}
				if(row["activeCode"]!=null)
				{
					model.activeCode=row["activeCode"].ToString();
				}
				if(row["activeMoney"]!=null && row["activeMoney"].ToString()!="")
				{
					model.activeMoney=double.Parse(row["activeMoney"].ToString());
				}
				if(row["total"]!=null && row["total"].ToString()!="")
				{
					model.total=double.Parse(row["total"].ToString());
				}
				if(row["satus"]!=null && row["satus"].ToString()!="")
				{
					model.satus=int.Parse(row["satus"].ToString());
				}
				if(row["remark"]!=null)
				{
					model.remark=row["remark"].ToString();
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
			strSql.Append("select id,orderId,orderNo,productId,productCount,isActive,activeCode,activeMoney,total,satus,remark,infoType ");
			strSql.Append(" FROM OrderDetail ");
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
		public static DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" id,orderId,orderNo,productId,productCount,isActive,activeCode,activeMoney,total,satus,remark,infoType ");
			strSql.Append(" FROM OrderDetail ");
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
			strSql.Append("select count(1) FROM OrderDetail ");
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
			strSql.Append(")AS Row, T.*  from OrderDetail T ");
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
			parameters[0].Value = "OrderDetail";
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

