using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Model;

namespace DAL
{
	/// <summary>
	/// 数据访问类:Product_ProperValueService
	/// </summary>
	public partial class Product_ProperValueService
	{
		public Product_ProperValueService()
		{}
		#region  BasicMethod
        /// <summary>
        /// 根据产品ID和属性ID获取对象
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="properId"></param>
        /// <returns></returns>
        public static Product_ProperValue GetModel(int productId, int properId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,productId,properValueId,properValueText,properId,parentId from Product_ProperValue ");
            strSql.Append(" where productId=@productId and properId=@properId");
            SqlParameter[] parameters = {
					new SqlParameter("@productId", SqlDbType.Int,4),new SqlParameter("@properId",SqlDbType.Int,4)
			};
            parameters[0].Value = productId;
            parameters[1].Value = properId;
            Model.Product_ProperValue model = new Model.Product_ProperValue();
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
        /// Delete已有的记录插入新的记录
        /// </summary>
        /// <param name="?"></param>
        /// <param name="?"></param>
        /// <param name="?"></param>
        /// <returns></returns>
        public static int Delete(int productId,int parentId,int properId)
        {
            string sql = "delete from Product_ProperValue where productId = " + productId + " and parentId = " + parentId + " and properId = " + properId;
            return DBHelperSQL.ExecuteSql(sql);
        }

		/// <summary>
		/// 是否存在该记录
		/// </summary>
        public static bool Exists(int productId, int properValueId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Product_ProperValue");
            strSql.Append(" where productId=@productId and properValueId=@properValueId");
			SqlParameter[] parameters = {
					new SqlParameter("@productId", SqlDbType.Int,4),new SqlParameter("@properValueId", SqlDbType.Int,4)
			};
            parameters[0].Value = productId;
            parameters[1].Value = properValueId;
			return DBHelperSQL.Exists(strSql.ToString(),parameters);
		}
        

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public static int Add(Model.Product_ProperValue model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Product_ProperValue(");
			strSql.Append("productId,properValueId,properValueText,properId,parentId)");
			strSql.Append(" values (");
			strSql.Append("@productId,@properValueId,@properValueText,@properId,@parentId)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@productId", SqlDbType.Int,4),
					new SqlParameter("@properValueId", SqlDbType.Int,4),
					new SqlParameter("@properValueText", SqlDbType.VarChar,2000),
					new SqlParameter("@properId", SqlDbType.Int,4),
					new SqlParameter("@parentId", SqlDbType.Int,4)};
			parameters[0].Value = model.productId;
			parameters[1].Value = model.properValueId;
			parameters[2].Value = model.properValueText;
			parameters[3].Value = model.properId;
			parameters[4].Value = model.parentId;

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
		public bool Update(Model.Product_ProperValue model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Product_ProperValue set ");
			strSql.Append("productId=@productId,");
			strSql.Append("properValueId=@properValueId,");
			strSql.Append("properValueText=@properValueText,");
			strSql.Append("properId=@properId,");
			strSql.Append("parentId=@parentId");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@productId", SqlDbType.Int,4),
					new SqlParameter("@properValueId", SqlDbType.Int,4),
					new SqlParameter("@properValueText", SqlDbType.VarChar,2000),
					new SqlParameter("@properId", SqlDbType.Int,4),
					new SqlParameter("@parentId", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.productId;
			parameters[1].Value = model.properValueId;
			parameters[2].Value = model.properValueText;
			parameters[3].Value = model.properId;
			parameters[4].Value = model.parentId;
			parameters[5].Value = model.id;

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
        public static bool Delete(int productId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Product_ProperValue ");
            strSql.Append(" where productId=@productId");
			SqlParameter[] parameters = {
					new SqlParameter("@productId", SqlDbType.Int,4)
			};
            parameters[0].Value = productId;

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
			strSql.Append("delete from Product_ProperValue ");
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
		public Model.Product_ProperValue GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,productId,properValueId,properValueText,properId,parentId from Product_ProperValue ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Model.Product_ProperValue model=new Model.Product_ProperValue();
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
		public static Model.Product_ProperValue DataRowToModel(DataRow row)
		{
			Model.Product_ProperValue model=new Model.Product_ProperValue();
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
				if(row["properValueId"]!=null && row["properValueId"].ToString()!="")
				{
					model.properValueId=int.Parse(row["properValueId"].ToString());
				}
				if(row["properValueText"]!=null)
				{
					model.properValueText=row["properValueText"].ToString();
				}
				if(row["properId"]!=null && row["properId"].ToString()!="")
				{
					model.properId=int.Parse(row["properId"].ToString());
				}
				if(row["parentId"]!=null && row["parentId"].ToString()!="")
				{
					model.parentId=int.Parse(row["parentId"].ToString());
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
			strSql.Append("select id,productId,properValueId,properValueText,properId,parentId ");
			strSql.Append(" FROM Product_ProperValue ");
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
			strSql.Append(" id,productId,properValueId,properValueText,properId,parentId ");
			strSql.Append(" FROM Product_ProperValue ");
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
			strSql.Append("select count(1) FROM Product_ProperValue ");
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
			strSql.Append(")AS Row, T.*  from Product_ProperValue T ");
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
			parameters[0].Value = "Product_ProperValue";
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

