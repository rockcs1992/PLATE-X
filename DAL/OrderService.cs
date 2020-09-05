using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace DAL
{
	/// <summary>
	/// 数据访问类:OrderService
	/// </summary>
	public partial class OrderService
	{
		public OrderService()
		{}
		#region  BasicMethod
        /// <summary>
        /// 获取指定状态下的订单Quantity
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public static int GetCount(int userId,int status) 
        {
            string sql = "";
            if (status != 100)
            {
                sql = "select count(*) from OrderInfo where status = " + status + " and addUser = " + userId;
            }
            else
            {
                sql = "select count(*) from OrderInfo where addUser = " + userId + " and status not in(100,150)";
            }
            object obj = DBHelperSQL.GetSingle(sql);
            if(obj != null)
            {
                return Convert.ToInt32(obj);
            }
            return 0;
        }
        /// <summary>
        /// 更新订单的二维码
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static int UpdateCodeUrl(Model.OrderInfo item)
        {
            string sql = "update OrderInfo set pName = '" + item.PName + "' where id = " + item.id;
            return DBHelperSQL.ExecuteSql(sql);
        }
        /// <summary>
        /// 更新Order ID
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public static int UpdateOrderNo(int orderId, string orderNo, string orderDesc)
        {
            string sql = "update OrderInfo set orderNo = '" + orderNo + "',orderDesc='" + orderDesc + "' where id = " + orderId;
            return DBHelperSQL.ExecuteSql(sql);
        }
        /// <summary>
        /// 更新Order ID
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public static int UpdateOrderNo(int orderId,string orderNo) 
        {
            string sql = "update OrderInfo set orderNo = '" + orderNo + "' where id = " + orderId;
            return DBHelperSQL.ExecuteSql(sql);
        }
        /// <summary>
        /// 支付成功更新付款状态和订单状态
        /// </summary>
        /// <param name="orderNo"></param>
        /// <param name="status"></param>
        /// <param name="payStatus"></param>
        /// <returns></returns>
        public static int UpdateStatus(string orderNo, int status, int payStatus, int payType)
        {
            if (payStatus == 1)
            {
                string sql = "update OrderInfo set status = " + status + ",payStatus = " + payStatus + ",payTime = '" + DateTime.Now + "',payType = " + payType + " where orderNo = '" + orderNo + "'";
                return DBHelperSQL.ExecuteSql(sql);

            }
            else
            {
                string sql = "update OrderInfo set status = " + status + ",payStatus = " + payStatus + " where orderNo = '" + orderNo + "'";
                return DBHelperSQL.ExecuteSql(sql);

            }

        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Model.OrderInfo GetModel(string orderNo)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from OrderInfo ");
            strSql.Append(" where orderNo=@orderNo");
            SqlParameter[] parameters = {
					new SqlParameter("@orderNo", SqlDbType.VarChar,154)
			};
            parameters[0].Value = orderNo;

            Model.OrderInfo model = new Model.OrderInfo();
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
        /// 在线付款更新订单付款状态
        /// </summary>
        /// <param name="orderNo"></param>
        /// <returns></returns>
        public static int UpdatePayStatus(string orderNo)
        {
            string sql = "update OrderInfo set status = 1 where orderNo = '" + orderNo + "'";
            return DBHelperSQL.ExecuteSql(sql);
        }
        /// <summary>
        /// 更新送货状态
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public static int UpdateStatus(int id,int status)
        {
            string sql = "update OrderInfo set status = " + status + " where id = " + id;
            return DBHelperSQL.ExecuteSql(sql);
        }
        /// <summary>
        /// 更新订单金额
        /// </summary>
        public static bool UpdateOrderTotal(Model.OrderInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update OrderInfo set ");

            strSql.Append("proTotal=@proTotal,");
            strSql.Append("orderTotal=@orderTotal,");
            strSql.Append("orderDesc=@orderDesc,");
            strSql.Append("recieveUser=@recieveUser,");

            strSql.Append("pid=@pid,");
            strSql.Append("PName=@PName,");
            strSql.Append("cid=@cid,");
            strSql.Append("CName=@CName,");
            strSql.Append("regionId=@regionId,");
            strSql.Append("ReginName=@ReginName,");
            strSql.Append("address=@address,");

            strSql.Append("mobile=@mobile,");
            strSql.Append("tel=@tel");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@proTotal", SqlDbType.Money,8),
					new SqlParameter("@orderTotal", SqlDbType.Money,8),
					new SqlParameter("@orderDesc", SqlDbType.VarChar,150),
					new SqlParameter("@recieveUser", SqlDbType.VarChar,50),

					new SqlParameter("@pid", SqlDbType.Int,4),
					new SqlParameter("@PName", SqlDbType.VarChar,50),
					new SqlParameter("@cid", SqlDbType.Int,4),
					new SqlParameter("@CName", SqlDbType.VarChar,50),
					new SqlParameter("@regionId", SqlDbType.Int,4),
					new SqlParameter("@ReginName", SqlDbType.VarChar,50),
					new SqlParameter("@address", SqlDbType.VarChar,150),

					new SqlParameter("@mobile", SqlDbType.VarChar,20),
					new SqlParameter("@tel", SqlDbType.VarChar,20),

					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.proTotal;
            parameters[1].Value = model.orderTotal;
            parameters[2].Value = model.orderDesc;
            parameters[3].Value = model.recieveUser;

            parameters[4].Value = model.pid;
            parameters[5].Value = model.PName;
            parameters[6].Value = model.cid;
            parameters[7].Value = model.CName;
            parameters[8].Value = model.regionId;
            parameters[9].Value = model.ReginName;
            parameters[10].Value = model.address;

            parameters[11].Value = model.mobile;
            parameters[12].Value = model.tel;

            parameters[13].Value = model.id;

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
        /// 月订单Quantity
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static int GetMonthCount(int userId)
        {
            string sql = "select count(id) from OrderInfo where addUser = " + userId + " and addTime >= '" + DateTime.Now.AddDays(-30) +"'";
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
            strSql.Append("select count(1) from OrderInfo");
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
		public static int Add(Model.OrderInfo model)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("insert into OrderInfo(");
            strSql.Append("orderNo,orderName,proTotal,sendTotal,orderTotal,orderDesc,remark,recieveUser,pid,PName,cid,CName,regionId,ReginName,address,mobile,tel,status,addTime,infoType,addUser)");
			strSql.Append(" values (");
            strSql.Append("@orderNo,@orderName,@proTotal,@sendTotal,@orderTotal,@orderDesc,@remark,@recieveUser,@pid,@PName,@cid,@CName,@regionId,@ReginName,@address,@mobile,@tel,@status,@addTime,@infoType,@addUser)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@orderNo", SqlDbType.VarChar,50),
					new SqlParameter("@orderName", SqlDbType.VarChar,100),
					new SqlParameter("@proTotal", SqlDbType.Money,8),
					new SqlParameter("@sendTotal", SqlDbType.Money,8),
					new SqlParameter("@orderTotal", SqlDbType.Money,8),
					new SqlParameter("@orderDesc", SqlDbType.VarChar,150),
					new SqlParameter("@remark", SqlDbType.VarChar,150),
					new SqlParameter("@recieveUser", SqlDbType.VarChar,50),
					new SqlParameter("@pid", SqlDbType.Int,4),
					new SqlParameter("@PName", SqlDbType.VarChar,50),
					new SqlParameter("@cid", SqlDbType.Int,4),
					new SqlParameter("@CName", SqlDbType.VarChar,50),
					new SqlParameter("@regionId", SqlDbType.Int,4),
					new SqlParameter("@ReginName", SqlDbType.VarChar,50),
					new SqlParameter("@address", SqlDbType.VarChar,150),
					new SqlParameter("@mobile", SqlDbType.VarChar,20),
					new SqlParameter("@tel", SqlDbType.VarChar,20),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@addTime", SqlDbType.DateTime),
					new SqlParameter("@infoType", SqlDbType.Int,4),new SqlParameter("@addUser",SqlDbType.Int,4)};
			parameters[0].Value = model.orderNo;
			parameters[1].Value = model.orderName;
			parameters[2].Value = model.proTotal;
			parameters[3].Value = model.sendTotal;
			parameters[4].Value = model.orderTotal;
			parameters[5].Value = model.orderDesc;
			parameters[6].Value = model.remark;
			parameters[7].Value = model.recieveUser;
			parameters[8].Value = model.pid;
			parameters[9].Value = model.PName;
			parameters[10].Value = model.cid;
			parameters[11].Value = model.CName;
			parameters[12].Value = model.regionId;
			parameters[13].Value = model.ReginName;
			parameters[14].Value = model.address;
			parameters[15].Value = model.mobile;
			parameters[16].Value = model.tel;
			parameters[17].Value = model.status;
			parameters[18].Value = model.addTime;
			parameters[19].Value = model.infoType;
            parameters[20].Value = model.addUser;
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
		public bool Update(Model.OrderInfo model)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("update OrderInfo set ");
			strSql.Append("orderNo=@orderNo,");
			strSql.Append("orderName=@orderName,");
			strSql.Append("proTotal=@proTotal,");
			strSql.Append("sendTotal=@sendTotal,");
			strSql.Append("orderTotal=@orderTotal,");
			strSql.Append("orderDesc=@orderDesc,");
			strSql.Append("remark=@remark,");
			strSql.Append("recieveUser=@recieveUser,");
			strSql.Append("pid=@pid,");
			strSql.Append("PName=@PName,");
			strSql.Append("cid=@cid,");
			strSql.Append("CName=@CName,");
			strSql.Append("regionId=@regionId,");
			strSql.Append("ReginName=@ReginName,");
			strSql.Append("address=@address,");
			strSql.Append("mobile=@mobile,");
			strSql.Append("tel=@tel,");
			strSql.Append("status=@status,");
			strSql.Append("addTime=@addTime,");
			strSql.Append("infoType=@infoType");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@orderNo", SqlDbType.VarChar,50),
					new SqlParameter("@orderName", SqlDbType.VarChar,100),
					new SqlParameter("@proTotal", SqlDbType.Money,8),
					new SqlParameter("@sendTotal", SqlDbType.Money,8),
					new SqlParameter("@orderTotal", SqlDbType.Money,8),
					new SqlParameter("@orderDesc", SqlDbType.VarChar,150),
					new SqlParameter("@remark", SqlDbType.VarChar,150),
					new SqlParameter("@recieveUser", SqlDbType.VarChar,50),
					new SqlParameter("@pid", SqlDbType.Int,4),
					new SqlParameter("@PName", SqlDbType.VarChar,50),
					new SqlParameter("@cid", SqlDbType.Int,4),
					new SqlParameter("@CName", SqlDbType.VarChar,50),
					new SqlParameter("@regionId", SqlDbType.Int,4),
					new SqlParameter("@ReginName", SqlDbType.VarChar,50),
					new SqlParameter("@address", SqlDbType.VarChar,150),
					new SqlParameter("@mobile", SqlDbType.VarChar,20),
					new SqlParameter("@tel", SqlDbType.VarChar,20),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@addTime", SqlDbType.DateTime),
					new SqlParameter("@infoType", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.orderNo;
			parameters[1].Value = model.orderName;
			parameters[2].Value = model.proTotal;
			parameters[3].Value = model.sendTotal;
			parameters[4].Value = model.orderTotal;
			parameters[5].Value = model.orderDesc;
			parameters[6].Value = model.remark;
			parameters[7].Value = model.recieveUser;
			parameters[8].Value = model.pid;
			parameters[9].Value = model.PName;
			parameters[10].Value = model.cid;
			parameters[11].Value = model.CName;
			parameters[12].Value = model.regionId;
			parameters[13].Value = model.ReginName;
			parameters[14].Value = model.address;
			parameters[15].Value = model.mobile;
			parameters[16].Value = model.tel;
			parameters[17].Value = model.status;
			parameters[18].Value = model.addTime;
			parameters[19].Value = model.infoType;
			parameters[20].Value = model.id;

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
		public bool Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("delete from OrderInfo ");
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
            strSql.Append("delete from OrderInfo ");
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
		public static Model.OrderInfo GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 * from OrderInfo ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Model.OrderInfo model=new Model.OrderInfo();
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
		public static Model.OrderInfo DataRowToModel(DataRow row)
		{
			Model.OrderInfo model=new Model.OrderInfo();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["orderNo"]!=null)
				{
					model.orderNo=row["orderNo"].ToString();
				}
				if(row["orderName"]!=null)
				{
					model.orderName=row["orderName"].ToString();
				}
				if(row["proTotal"]!=null && row["proTotal"].ToString()!="")
				{
					model.proTotal=double.Parse(row["proTotal"].ToString());
				}
				if(row["sendTotal"]!=null && row["sendTotal"].ToString()!="")
				{
					model.sendTotal=double.Parse(row["sendTotal"].ToString());
				}
				if(row["orderTotal"]!=null && row["orderTotal"].ToString()!="")
				{
					model.orderTotal=double.Parse(row["orderTotal"].ToString());
				}
				if(row["orderDesc"]!=null)
				{
					model.orderDesc=row["orderDesc"].ToString();
				}
				if(row["remark"]!=null)
				{
					model.remark=row["remark"].ToString();
				}
				if(row["recieveUser"]!=null)
				{
					model.recieveUser=row["recieveUser"].ToString();
				}
				if(row["pid"]!=null && row["pid"].ToString()!="")
				{
					model.pid=int.Parse(row["pid"].ToString());
				}
				if(row["PName"]!=null)
				{
					model.PName=row["PName"].ToString();
				}
				if(row["cid"]!=null && row["cid"].ToString()!="")
				{
					model.cid=int.Parse(row["cid"].ToString());
				}
				if(row["CName"]!=null)
				{
					model.CName=row["CName"].ToString();
				}
				if(row["regionId"]!=null && row["regionId"].ToString()!="")
				{
					model.regionId=int.Parse(row["regionId"].ToString());
				}
				if(row["ReginName"]!=null)
				{
					model.ReginName=row["ReginName"].ToString();
				}
				if(row["address"]!=null)
				{
					model.address=row["address"].ToString();
				}
				if(row["mobile"]!=null)
				{
					model.mobile=row["mobile"].ToString();
				}
				if(row["tel"]!=null)
				{
					model.tel=row["tel"].ToString();
				}
				if(row["status"]!=null && row["status"].ToString()!="")
				{
					model.status=int.Parse(row["status"].ToString());
				}
				if(row["addTime"]!=null && row["addTime"].ToString()!="")
				{
					model.addTime=DateTime.Parse(row["addTime"].ToString());
				}
				if(row["infoType"]!=null && row["infoType"].ToString()!="")
				{
					model.infoType=int.Parse(row["infoType"].ToString());
				}
                if (row["addUser"] != null && row["addUser"].ToString() != "")
                {
                    model.addUser = int.Parse(row["addUser"].ToString());
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
            strSql.Append(" FROM OrderInfo ");
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
            strSql.Append(" FROM OrderInfo ");
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
            strSql.Append("select count(1) FROM OrderInfo ");
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
            strSql.Append(")AS Row, T.*  from OrderInfo T ");
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
			parameters[0].Value = "Order";
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

