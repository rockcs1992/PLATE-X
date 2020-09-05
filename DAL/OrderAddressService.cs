using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace DAL
{
	/// <summary>
	/// 数据访问类:OrderAddressService
	/// </summary>
	public partial class OrderAddressService
	{
		public OrderAddressService()
		{}
		#region  BasicMethod
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Model.OrderAddress GetModelByOrderId(int orderId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,orderId,orderNo,relName,mobile,tel,qq,weixin,zipcode,pid,pName,cid,cName,regionId,regionName,address,addressDetail,labelName,otherName,status,remark,addTime,addUser,infoType from OrderAddress ");
            strSql.Append(" where orderId=@orderId");
            SqlParameter[] parameters = {
					new SqlParameter("@orderId", SqlDbType.Int,4)
			};
            parameters[0].Value = orderId;

            Model.OrderAddress model = new Model.OrderAddress();
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
		public static bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from OrderAddress");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			return DBHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
        public static int Add(Model.OrderAddress model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into OrderAddress(");
			strSql.Append("orderId,orderNo,relName,mobile,tel,qq,weixin,zipcode,pid,pName,cid,cName,regionId,regionName,address,addressDetail,labelName,otherName,status,remark,addTime,addUser,infoType)");
			strSql.Append(" values (");
			strSql.Append("@orderId,@orderNo,@relName,@mobile,@tel,@qq,@weixin,@zipcode,@pid,@pName,@cid,@cName,@regionId,@regionName,@address,@addressDetail,@labelName,@otherName,@status,@remark,@addTime,@addUser,@infoType)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@orderId", SqlDbType.Int,4),
					new SqlParameter("@orderNo", SqlDbType.VarChar,50),
					new SqlParameter("@relName", SqlDbType.VarChar,50),
					new SqlParameter("@mobile", SqlDbType.VarChar,50),
					new SqlParameter("@tel", SqlDbType.VarChar,50),
					new SqlParameter("@qq", SqlDbType.VarChar,50),
					new SqlParameter("@weixin", SqlDbType.VarChar,50),
					new SqlParameter("@zipcode", SqlDbType.VarChar,50),
					new SqlParameter("@pid", SqlDbType.Int,4),
					new SqlParameter("@pName", SqlDbType.VarChar,150),
					new SqlParameter("@cid", SqlDbType.Int,4),
					new SqlParameter("@cName", SqlDbType.VarChar,150),
					new SqlParameter("@regionId", SqlDbType.Int,4),
					new SqlParameter("@regionName", SqlDbType.VarChar,150),
					new SqlParameter("@address", SqlDbType.VarChar,150),
					new SqlParameter("@addressDetail", SqlDbType.VarChar,150),
					new SqlParameter("@labelName", SqlDbType.VarChar,150),
					new SqlParameter("@otherName", SqlDbType.VarChar,150),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.VarChar,150),
					new SqlParameter("@addTime", SqlDbType.DateTime),
					new SqlParameter("@addUser", SqlDbType.Int,4),
					new SqlParameter("@infoType", SqlDbType.Int,4)};
			parameters[0].Value = model.orderId;
			parameters[1].Value = model.orderNo;
			parameters[2].Value = model.relName;
			parameters[3].Value = model.mobile;
			parameters[4].Value = model.tel;
			parameters[5].Value = model.qq;
			parameters[6].Value = model.weixin;
			parameters[7].Value = model.zipcode;
			parameters[8].Value = model.pid;
			parameters[9].Value = model.pName;
			parameters[10].Value = model.cid;
			parameters[11].Value = model.cName;
			parameters[12].Value = model.regionId;
			parameters[13].Value = model.regionName;
			parameters[14].Value = model.address;
			parameters[15].Value = model.addressDetail;
			parameters[16].Value = model.labelName;
			parameters[17].Value = model.otherName;
			parameters[18].Value = model.status;
			parameters[19].Value = model.remark;
			parameters[20].Value = model.addTime;
			parameters[21].Value = model.addUser;
			parameters[22].Value = model.infoType;

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
        public static bool Update(Model.OrderAddress model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update OrderAddress set ");
			strSql.Append("orderId=@orderId,");
			strSql.Append("orderNo=@orderNo,");
			strSql.Append("relName=@relName,");
			strSql.Append("mobile=@mobile,");
			strSql.Append("tel=@tel,");
			strSql.Append("qq=@qq,");
			strSql.Append("weixin=@weixin,");
			strSql.Append("zipcode=@zipcode,");
			strSql.Append("pid=@pid,");
			strSql.Append("pName=@pName,");
			strSql.Append("cid=@cid,");
			strSql.Append("cName=@cName,");
			strSql.Append("regionId=@regionId,");
			strSql.Append("regionName=@regionName,");
			strSql.Append("address=@address,");
			strSql.Append("addressDetail=@addressDetail,");
			strSql.Append("labelName=@labelName,");
			strSql.Append("otherName=@otherName,");
			strSql.Append("status=@status,");
			strSql.Append("remark=@remark,");
			strSql.Append("addTime=@addTime,");
			strSql.Append("addUser=@addUser,");
			strSql.Append("infoType=@infoType");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@orderId", SqlDbType.Int,4),
					new SqlParameter("@orderNo", SqlDbType.VarChar,50),
					new SqlParameter("@relName", SqlDbType.VarChar,50),
					new SqlParameter("@mobile", SqlDbType.VarChar,50),
					new SqlParameter("@tel", SqlDbType.VarChar,50),
					new SqlParameter("@qq", SqlDbType.VarChar,50),
					new SqlParameter("@weixin", SqlDbType.VarChar,50),
					new SqlParameter("@zipcode", SqlDbType.VarChar,50),
					new SqlParameter("@pid", SqlDbType.Int,4),
					new SqlParameter("@pName", SqlDbType.VarChar,150),
					new SqlParameter("@cid", SqlDbType.Int,4),
					new SqlParameter("@cName", SqlDbType.VarChar,150),
					new SqlParameter("@regionId", SqlDbType.Int,4),
					new SqlParameter("@regionName", SqlDbType.VarChar,150),
					new SqlParameter("@address", SqlDbType.VarChar,150),
					new SqlParameter("@addressDetail", SqlDbType.VarChar,150),
					new SqlParameter("@labelName", SqlDbType.VarChar,150),
					new SqlParameter("@otherName", SqlDbType.VarChar,150),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.VarChar,150),
					new SqlParameter("@addTime", SqlDbType.DateTime),
					new SqlParameter("@addUser", SqlDbType.Int,4),
					new SqlParameter("@infoType", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.orderId;
			parameters[1].Value = model.orderNo;
			parameters[2].Value = model.relName;
			parameters[3].Value = model.mobile;
			parameters[4].Value = model.tel;
			parameters[5].Value = model.qq;
			parameters[6].Value = model.weixin;
			parameters[7].Value = model.zipcode;
			parameters[8].Value = model.pid;
			parameters[9].Value = model.pName;
			parameters[10].Value = model.cid;
			parameters[11].Value = model.cName;
			parameters[12].Value = model.regionId;
			parameters[13].Value = model.regionName;
			parameters[14].Value = model.address;
			parameters[15].Value = model.addressDetail;
			parameters[16].Value = model.labelName;
			parameters[17].Value = model.otherName;
			parameters[18].Value = model.status;
			parameters[19].Value = model.remark;
			parameters[20].Value = model.addTime;
			parameters[21].Value = model.addUser;
			parameters[22].Value = model.infoType;
			parameters[23].Value = model.id;

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
			strSql.Append("delete from OrderAddress ");
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
			strSql.Append("delete from OrderAddress ");
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
        public static Model.OrderAddress GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,orderId,orderNo,relName,mobile,tel,qq,weixin,zipcode,pid,pName,cid,cName,regionId,regionName,address,addressDetail,labelName,otherName,status,remark,addTime,addUser,infoType from OrderAddress ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Model.OrderAddress model=new Model.OrderAddress();
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
        public static Model.OrderAddress DataRowToModel(DataRow row)
		{
			Model.OrderAddress model=new Model.OrderAddress();
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
				if(row["relName"]!=null)
				{
					model.relName=row["relName"].ToString();
				}
				if(row["mobile"]!=null)
				{
					model.mobile=row["mobile"].ToString();
				}
				if(row["tel"]!=null)
				{
					model.tel=row["tel"].ToString();
				}
				if(row["qq"]!=null)
				{
					model.qq=row["qq"].ToString();
				}
				if(row["weixin"]!=null)
				{
					model.weixin=row["weixin"].ToString();
				}
				if(row["zipcode"]!=null)
				{
					model.zipcode=row["zipcode"].ToString();
				}
				if(row["pid"]!=null && row["pid"].ToString()!="")
				{
					model.pid=int.Parse(row["pid"].ToString());
				}
				if(row["pName"]!=null)
				{
					model.pName=row["pName"].ToString();
				}
				if(row["cid"]!=null && row["cid"].ToString()!="")
				{
					model.cid=int.Parse(row["cid"].ToString());
				}
				if(row["cName"]!=null)
				{
					model.cName=row["cName"].ToString();
				}
				if(row["regionId"]!=null && row["regionId"].ToString()!="")
				{
					model.regionId=int.Parse(row["regionId"].ToString());
				}
				if(row["regionName"]!=null)
				{
					model.regionName=row["regionName"].ToString();
				}
				if(row["address"]!=null)
				{
					model.address=row["address"].ToString();
				}
				if(row["addressDetail"]!=null)
				{
					model.addressDetail=row["addressDetail"].ToString();
				}
				if(row["labelName"]!=null)
				{
					model.labelName=row["labelName"].ToString();
				}
				if(row["otherName"]!=null)
				{
					model.otherName=row["otherName"].ToString();
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
			strSql.Append("select id,orderId,orderNo,relName,mobile,tel,qq,weixin,zipcode,pid,pName,cid,cName,regionId,regionName,address,addressDetail,labelName,otherName,status,remark,addTime,addUser,infoType ");
			strSql.Append(" FROM OrderAddress ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
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
			strSql.Append(" id,orderId,orderNo,relName,mobile,tel,qq,weixin,zipcode,pid,pName,cid,cName,regionId,regionName,address,addressDetail,labelName,otherName,status,remark,addTime,addUser,infoType ");
			strSql.Append(" FROM OrderAddress ");
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
			strSql.Append("select count(1) FROM OrderAddress ");
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
			strSql.Append(")AS Row, T.*  from OrderAddress T ");
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
			parameters[0].Value = "OrderAddress";
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

