using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace DAL
{
	/// <summary>
	/// 数据访问类:CommentService
	/// </summary>
	public partial class CommentService
	{
		public CommentService()
		{}
		#region  BasicMethod
        /// <summary>
        /// 判断记录是否存在
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool Exists(object productId,object id)
        {
            string sql = "select  top 1 * from Comment where productId = " + productId + " and orderId = " + id;
            object obj = DBHelperSQL.GetSingle(sql);
            if(obj != null)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Model.Comment GetModelMobile(object productId,object userId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from Comment ");
            strSql.Append(" where productId=" + productId + " and addUser = " + userId + " and orderId = 0");

            Model.Comment model = new Model.Comment();
            DataSet ds = DBHelperSQL.Query(strSql.ToString());
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
		public static bool Exists(int orderId,int productId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Comment");
            strSql.Append(" where orderId=@orderId and productId = " + productId);
			SqlParameter[] parameters = {
					new SqlParameter("@orderId", SqlDbType.Int,4)
			};
            parameters[0].Value = orderId;

			return DBHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
        public static int Add(Model.Comment model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Comment(");
			strSql.Append("orderId,orderNo,productId,commentType,dataType,fromId,commentInfo,commentDesc,img1Url,img2Url,img3Url,img4Url,status,remark,addTime,addUser,infoType)");
			strSql.Append(" values (");
			strSql.Append("@orderId,@orderNo,@productId,@commentType,@dataType,@fromId,@commentInfo,@commentDesc,@img1Url,@img2Url,@img3Url,@img4Url,@status,@remark,@addTime,@addUser,@infoType)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@orderId", SqlDbType.Int,4),
					new SqlParameter("@orderNo", SqlDbType.VarChar,50),
					new SqlParameter("@productId", SqlDbType.Int,4),
					new SqlParameter("@commentType", SqlDbType.Int,4),
					new SqlParameter("@dataType", SqlDbType.Int,4),
					new SqlParameter("@fromId", SqlDbType.Int,4),
					new SqlParameter("@commentInfo", SqlDbType.VarChar,1500),
					new SqlParameter("@commentDesc", SqlDbType.VarChar,150),
					new SqlParameter("@img1Url", SqlDbType.VarChar,150),
					new SqlParameter("@img2Url", SqlDbType.VarChar,150),
					new SqlParameter("@img3Url", SqlDbType.VarChar,150),
					new SqlParameter("@img4Url", SqlDbType.VarChar,150),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.VarChar,150),
					new SqlParameter("@addTime", SqlDbType.DateTime),
					new SqlParameter("@addUser", SqlDbType.Int,4),
					new SqlParameter("@infoType", SqlDbType.Int,4)};
			parameters[0].Value = model.orderId;
			parameters[1].Value = model.orderNo;
			parameters[2].Value = model.productId;
			parameters[3].Value = model.commentType;
			parameters[4].Value = model.dataType;
			parameters[5].Value = model.fromId;
			parameters[6].Value = model.commentInfo;
			parameters[7].Value = model.commentDesc;
			parameters[8].Value = model.img1Url;
			parameters[9].Value = model.img2Url;
			parameters[10].Value = model.img3Url;
			parameters[11].Value = model.img4Url;
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
        public static bool Update(Model.Comment model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Comment set ");
			strSql.Append("orderId=@orderId,");
			strSql.Append("orderNo=@orderNo,");
			strSql.Append("productId=@productId,");
			strSql.Append("commentType=@commentType,");
			strSql.Append("dataType=@dataType,");
			strSql.Append("fromId=@fromId,");
			strSql.Append("commentInfo=@commentInfo,");
			strSql.Append("commentDesc=@commentDesc,");
			strSql.Append("img1Url=@img1Url,");
			strSql.Append("img2Url=@img2Url,");
			strSql.Append("img3Url=@img3Url,");
			strSql.Append("img4Url=@img4Url,");
			strSql.Append("status=@status,");
			strSql.Append("remark=@remark,");
			strSql.Append("addTime=@addTime,");
			strSql.Append("addUser=@addUser,");
			strSql.Append("infoType=@infoType");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@orderId", SqlDbType.Int,4),
					new SqlParameter("@orderNo", SqlDbType.VarChar,50),
					new SqlParameter("@productId", SqlDbType.Int,4),
					new SqlParameter("@commentType", SqlDbType.Int,4),
					new SqlParameter("@dataType", SqlDbType.Int,4),
					new SqlParameter("@fromId", SqlDbType.Int,4),
					new SqlParameter("@commentInfo", SqlDbType.VarChar,1500),
					new SqlParameter("@commentDesc", SqlDbType.VarChar,150),
					new SqlParameter("@img1Url", SqlDbType.VarChar,150),
					new SqlParameter("@img2Url", SqlDbType.VarChar,150),
					new SqlParameter("@img3Url", SqlDbType.VarChar,150),
					new SqlParameter("@img4Url", SqlDbType.VarChar,150),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.VarChar,150),
					new SqlParameter("@addTime", SqlDbType.DateTime),
					new SqlParameter("@addUser", SqlDbType.Int,4),
					new SqlParameter("@infoType", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.orderId;
			parameters[1].Value = model.orderNo;
			parameters[2].Value = model.productId;
			parameters[3].Value = model.commentType;
			parameters[4].Value = model.dataType;
			parameters[5].Value = model.fromId;
			parameters[6].Value = model.commentInfo;
			parameters[7].Value = model.commentDesc;
			parameters[8].Value = model.img1Url;
			parameters[9].Value = model.img2Url;
			parameters[10].Value = model.img3Url;
			parameters[11].Value = model.img4Url;
			parameters[12].Value = model.status;
			parameters[13].Value = model.remark;
			parameters[14].Value = model.addTime;
			parameters[15].Value = model.addUser;
			parameters[16].Value = model.infoType;
			parameters[17].Value = model.id;

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
			strSql.Append("delete from Comment ");
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
			strSql.Append("delete from Comment ");
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
        public static Model.Comment GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,orderId,orderNo,productId,commentType,dataType,fromId,commentInfo,commentDesc,img1Url,img2Url,img3Url,img4Url,status,remark,addTime,addUser,infoType from Comment ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Model.Comment model=new Model.Comment();
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
        public static Model.Comment DataRowToModel(DataRow row)
		{
			Model.Comment model=new Model.Comment();
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
				if(row["commentType"]!=null && row["commentType"].ToString()!="")
				{
					model.commentType=int.Parse(row["commentType"].ToString());
				}
				if(row["dataType"]!=null && row["dataType"].ToString()!="")
				{
					model.dataType=int.Parse(row["dataType"].ToString());
				}
				if(row["fromId"]!=null && row["fromId"].ToString()!="")
				{
					model.fromId=int.Parse(row["fromId"].ToString());
				}
				if(row["commentInfo"]!=null)
				{
					model.commentInfo=row["commentInfo"].ToString();
				}
				if(row["commentDesc"]!=null)
				{
					model.commentDesc=row["commentDesc"].ToString();
				}
				if(row["img1Url"]!=null)
				{
					model.img1Url=row["img1Url"].ToString();
				}
				if(row["img2Url"]!=null)
				{
					model.img2Url=row["img2Url"].ToString();
				}
				if(row["img3Url"]!=null)
				{
					model.img3Url=row["img3Url"].ToString();
				}
				if(row["img4Url"]!=null)
				{
					model.img4Url=row["img4Url"].ToString();
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
			strSql.Append("select id,orderId,orderNo,productId,commentType,dataType,fromId,commentInfo,commentDesc,img1Url,img2Url,img3Url,img4Url,status,remark,addTime,addUser,infoType ");
			strSql.Append(" FROM Comment ");
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
			strSql.Append(" id,orderId,orderNo,productId,commentType,dataType,fromId,commentInfo,commentDesc,img1Url,img2Url,img3Url,img4Url,status,remark,addTime,addUser,infoType ");
			strSql.Append(" FROM Comment ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder + " desc");
			return DBHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM Comment ");
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
			strSql.Append(")AS Row, T.*  from Comment T ");
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
			parameters[0].Value = "Comment";
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

