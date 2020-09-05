using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace DAL
{
	/// <summary>
	/// 数据访问类:ProductPKService
	/// </summary>
	public partial class ProductPKService
	{
		public ProductPKService()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ProductPK");
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
		public int Add(Model.ProductPK model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ProductPK(");
			strSql.Append("productId,quantiyCount,brandCount,priceCount,configCount,appearanceCount,otherCount)");
			strSql.Append(" values (");
			strSql.Append("@productId,@quantiyCount,@brandCount,@priceCount,@configCount,@appearanceCount,@otherCount)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@productId", SqlDbType.Int,4),
					new SqlParameter("@quantiyCount", SqlDbType.Int,4),
					new SqlParameter("@brandCount", SqlDbType.Int,4),
					new SqlParameter("@priceCount", SqlDbType.Int,4),
					new SqlParameter("@configCount", SqlDbType.Int,4),
					new SqlParameter("@appearanceCount", SqlDbType.Int,4),
					new SqlParameter("@otherCount", SqlDbType.Int,4)};
			parameters[0].Value = model.productId;
			parameters[1].Value = model.quantiyCount;
			parameters[2].Value = model.brandCount;
			parameters[3].Value = model.priceCount;
			parameters[4].Value = model.configCount;
			parameters[5].Value = model.appearanceCount;
			parameters[6].Value = model.otherCount;

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
		public bool Update(Model.ProductPK model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ProductPK set ");
			strSql.Append("productId=@productId,");
			strSql.Append("quantiyCount=@quantiyCount,");
			strSql.Append("brandCount=@brandCount,");
			strSql.Append("priceCount=@priceCount,");
			strSql.Append("configCount=@configCount,");
			strSql.Append("appearanceCount=@appearanceCount,");
			strSql.Append("otherCount=@otherCount");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@productId", SqlDbType.Int,4),
					new SqlParameter("@quantiyCount", SqlDbType.Int,4),
					new SqlParameter("@brandCount", SqlDbType.Int,4),
					new SqlParameter("@priceCount", SqlDbType.Int,4),
					new SqlParameter("@configCount", SqlDbType.Int,4),
					new SqlParameter("@appearanceCount", SqlDbType.Int,4),
					new SqlParameter("@otherCount", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.productId;
			parameters[1].Value = model.quantiyCount;
			parameters[2].Value = model.brandCount;
			parameters[3].Value = model.priceCount;
			parameters[4].Value = model.configCount;
			parameters[5].Value = model.appearanceCount;
			parameters[6].Value = model.otherCount;
			parameters[7].Value = model.id;

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
			strSql.Append("delete from ProductPK ");
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
			strSql.Append("delete from ProductPK ");
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
		public Model.ProductPK GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,productId,quantiyCount,brandCount,priceCount,configCount,appearanceCount,otherCount from ProductPK ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Model.ProductPK model=new Model.ProductPK();
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
		public Model.ProductPK DataRowToModel(DataRow row)
		{
			Model.ProductPK model=new Model.ProductPK();
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
				if(row["quantiyCount"]!=null && row["quantiyCount"].ToString()!="")
				{
					model.quantiyCount=int.Parse(row["quantiyCount"].ToString());
				}
				if(row["brandCount"]!=null && row["brandCount"].ToString()!="")
				{
					model.brandCount=int.Parse(row["brandCount"].ToString());
				}
				if(row["priceCount"]!=null && row["priceCount"].ToString()!="")
				{
					model.priceCount=int.Parse(row["priceCount"].ToString());
				}
				if(row["configCount"]!=null && row["configCount"].ToString()!="")
				{
					model.configCount=int.Parse(row["configCount"].ToString());
				}
				if(row["appearanceCount"]!=null && row["appearanceCount"].ToString()!="")
				{
					model.appearanceCount=int.Parse(row["appearanceCount"].ToString());
				}
				if(row["otherCount"]!=null && row["otherCount"].ToString()!="")
				{
					model.otherCount=int.Parse(row["otherCount"].ToString());
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
			strSql.Append("select id,productId,quantiyCount,brandCount,priceCount,configCount,appearanceCount,otherCount ");
			strSql.Append(" FROM ProductPK ");
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
			strSql.Append(" id,productId,quantiyCount,brandCount,priceCount,configCount,appearanceCount,otherCount ");
			strSql.Append(" FROM ProductPK ");
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
			strSql.Append("select count(1) FROM ProductPK ");
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
			strSql.Append(")AS Row, T.*  from ProductPK T ");
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
			parameters[0].Value = "ProductPK";
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

