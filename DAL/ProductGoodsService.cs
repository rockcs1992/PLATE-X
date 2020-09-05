using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace DAL
{
	/// <summary>
	/// 数据访问类:ProductGoodsService
	/// </summary>
	public partial class ProductGoodsService
	{
		public ProductGoodsService()
		{}
		#region  BasicMethod
        /// <summary>
        /// 获取赞数
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static int GetGoods(int num, int id)
        {
            string sql = "";
            if (num == 1)
            {
                sql = "select quantityGoods from ProductGoods where productId = " + id;
            }
            else if (num == 2)
            {
                sql = "select brandGoods from ProductGoods where productId = " + id;
            }
            else if (num == 3)
            {
                sql = "select priceGoods from ProductGoods where productId = " + id;
            }
            else if (num == 4)
            {
                sql = "select setGoods from ProductGoods where productId = " + id;
            }
            else if (num == 5)
            {
                sql = "select beautifulGoods from ProductGoods where productId = " + id;
            }
            else if (num == 6)
            {
                sql = "select otherGoods from ProductGoods where productId = " + id;
            }
            object obj = DBHelperSQL.GetSingle(sql);
            if(obj != null)
            {
                return Convert.ToInt32(obj);
            }
            return 0;
        }
        /// <summary>
        /// 设置赞
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static int SetGoods(int num,int id)
        {
            string sql = "";
            if(num == 1)
            {
                sql = "update ProductGoods set quantityGoods = quantityGoods + 1 where productId = " + id;
            }else if(num == 2)
            {
                sql = "update ProductGoods set brandGoods = brandGoods + 1 where productId = " + id;
            }else if(num == 3)
            {
                sql = "update ProductGoods set priceGoods = priceGoods + 1 where productId = " + id;
            }else if(num == 4)
            {
                sql = "update ProductGoods set setGoods = setGoods + 1 where productId = " + id;
            }else if(num == 5)
            {
                sql = "update ProductGoods set beautifulGoods = beautifulGoods + 1 where productId = " + id;
            }else if(num == 6)
            {
                sql = "update ProductGoods set otherGoods = otherGoods + 1 where productId = " + id;
            }
            return DBHelperSQL.ExecuteSql(sql);
        }
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ProductGoods");
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
		public static int Add(Model.ProductGoods model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ProductGoods(");
			strSql.Append("productId,quantityGoods,brandGoods,priceGoods,setGoods,beautifulGoods,otherGoods,status,remark,infoType)");
			strSql.Append(" values (");
			strSql.Append("@productId,@quantityGoods,@brandGoods,@priceGoods,@setGoods,@beautifulGoods,@otherGoods,@status,@remark,@infoType)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@productId", SqlDbType.Int,4),
					new SqlParameter("@quantityGoods", SqlDbType.Int,4),
					new SqlParameter("@brandGoods", SqlDbType.Int,4),
					new SqlParameter("@priceGoods", SqlDbType.Int,4),
					new SqlParameter("@setGoods", SqlDbType.Int,4),
					new SqlParameter("@beautifulGoods", SqlDbType.Int,4),
					new SqlParameter("@otherGoods", SqlDbType.Int,4),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.VarChar,50),
					new SqlParameter("@infoType", SqlDbType.Int,4)};
			parameters[0].Value = model.productId;
			parameters[1].Value = model.quantityGoods;
			parameters[2].Value = model.brandGoods;
			parameters[3].Value = model.priceGoods;
			parameters[4].Value = model.setGoods;
			parameters[5].Value = model.beautifulGoods;
			parameters[6].Value = model.otherGoods;
			parameters[7].Value = model.status;
			parameters[8].Value = model.remark;
			parameters[9].Value = model.infoType;

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
		public bool Update(Model.ProductGoods model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ProductGoods set ");
			strSql.Append("productId=@productId,");
			strSql.Append("quantityGoods=@quantityGoods,");
			strSql.Append("brandGoods=@brandGoods,");
			strSql.Append("priceGoods=@priceGoods,");
			strSql.Append("setGoods=@setGoods,");
			strSql.Append("beautifulGoods=@beautifulGoods,");
			strSql.Append("otherGoods=@otherGoods,");
			strSql.Append("status=@status,");
			strSql.Append("remark=@remark,");
			strSql.Append("infoType=@infoType");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@productId", SqlDbType.Int,4),
					new SqlParameter("@quantityGoods", SqlDbType.Int,4),
					new SqlParameter("@brandGoods", SqlDbType.Int,4),
					new SqlParameter("@priceGoods", SqlDbType.Int,4),
					new SqlParameter("@setGoods", SqlDbType.Int,4),
					new SqlParameter("@beautifulGoods", SqlDbType.Int,4),
					new SqlParameter("@otherGoods", SqlDbType.Int,4),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.VarChar,50),
					new SqlParameter("@infoType", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.productId;
			parameters[1].Value = model.quantityGoods;
			parameters[2].Value = model.brandGoods;
			parameters[3].Value = model.priceGoods;
			parameters[4].Value = model.setGoods;
			parameters[5].Value = model.beautifulGoods;
			parameters[6].Value = model.otherGoods;
			parameters[7].Value = model.status;
			parameters[8].Value = model.remark;
			parameters[9].Value = model.infoType;
			parameters[10].Value = model.id;

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
			strSql.Append("delete from ProductGoods ");
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
			strSql.Append("delete from ProductGoods ");
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
        public static Model.ProductGoods GetModel(int productId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,productId,quantityGoods,brandGoods,priceGoods,setGoods,beautifulGoods,otherGoods,status,remark,infoType from ProductGoods ");
            strSql.Append(" where productId=@productId");
			SqlParameter[] parameters = {
					new SqlParameter("@productId", SqlDbType.Int,4)
			};
            parameters[0].Value = productId;

			Model.ProductGoods model=new Model.ProductGoods();
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
		public static Model.ProductGoods DataRowToModel(DataRow row)
		{
			Model.ProductGoods model=new Model.ProductGoods();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["productId"]!=null && row["productId"].ToString()!="")
				{
					model.productId=int.Parse(row["productId"].ToString());
				}
				if(row["quantityGoods"]!=null && row["quantityGoods"].ToString()!="")
				{
					model.quantityGoods=int.Parse(row["quantityGoods"].ToString());
				}
				if(row["brandGoods"]!=null && row["brandGoods"].ToString()!="")
				{
					model.brandGoods=int.Parse(row["brandGoods"].ToString());
				}
				if(row["priceGoods"]!=null && row["priceGoods"].ToString()!="")
				{
					model.priceGoods=int.Parse(row["priceGoods"].ToString());
				}
				if(row["setGoods"]!=null && row["setGoods"].ToString()!="")
				{
					model.setGoods=int.Parse(row["setGoods"].ToString());
				}
				if(row["beautifulGoods"]!=null && row["beautifulGoods"].ToString()!="")
				{
					model.beautifulGoods=int.Parse(row["beautifulGoods"].ToString());
				}
				if(row["otherGoods"]!=null && row["otherGoods"].ToString()!="")
				{
					model.otherGoods=int.Parse(row["otherGoods"].ToString());
				}
				if(row["status"]!=null && row["status"].ToString()!="")
				{
					model.status=int.Parse(row["status"].ToString());
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
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,productId,quantityGoods,brandGoods,priceGoods,setGoods,beautifulGoods,otherGoods,status,remark,infoType ");
			strSql.Append(" FROM ProductGoods ");
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
			strSql.Append(" id,productId,quantityGoods,brandGoods,priceGoods,setGoods,beautifulGoods,otherGoods,status,remark,infoType ");
			strSql.Append(" FROM ProductGoods ");
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
			strSql.Append("select count(1) FROM ProductGoods ");
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
			strSql.Append(")AS Row, T.*  from ProductGoods T ");
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
			parameters[0].Value = "ProductGoods";
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

