using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace DAL
{
	/// <summary>
	/// 数据访问类:ProductImgService
	/// </summary>
	public partial class ProductImgService
	{
		public ProductImgService()
		{}
		#region  BasicMethod
        /// <summary>
        /// 新生成的资讯ID更新Upload的图片信息中的产品ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int UpdateProductId(string ids,int maxId)
        {
            string sql = "update ProductImg set productId = " + maxId + " where id in (" + ids + ")";
            return DBHelperSQL.ExecuteSql(sql);
        }
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ProductImg");
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
		public static int Add(Model.ProductImg model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ProductImg(");
			strSql.Append("productId,imgURL,title,alt,linkurl,status,remark)");
			strSql.Append(" values (");
			strSql.Append("@productId,@imgURL,@title,@alt,@linkurl,@status,@remark)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@productId", SqlDbType.Int,4),
					new SqlParameter("@imgURL", SqlDbType.VarChar,50),
					new SqlParameter("@title", SqlDbType.VarChar,150),
					new SqlParameter("@alt", SqlDbType.VarChar,150),
					new SqlParameter("@linkurl", SqlDbType.VarChar,150),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.VarChar,50)};
			parameters[0].Value = model.productId;
			parameters[1].Value = model.imgURL;
			parameters[2].Value = model.title;
			parameters[3].Value = model.alt;
			parameters[4].Value = model.linkurl;
			parameters[5].Value = model.status;
			parameters[6].Value = model.remark;

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
		public bool Update(Model.ProductImg model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ProductImg set ");
			strSql.Append("productId=@productId,");
			strSql.Append("imgURL=@imgURL,");
			strSql.Append("title=@title,");
			strSql.Append("alt=@alt,");
			strSql.Append("linkurl=@linkurl,");
			strSql.Append("status=@status,");
			strSql.Append("remark=@remark");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@productId", SqlDbType.Int,4),
					new SqlParameter("@imgURL", SqlDbType.VarChar,50),
					new SqlParameter("@title", SqlDbType.VarChar,150),
					new SqlParameter("@alt", SqlDbType.VarChar,150),
					new SqlParameter("@linkurl", SqlDbType.VarChar,150),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.VarChar,50),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.productId;
			parameters[1].Value = model.imgURL;
			parameters[2].Value = model.title;
			parameters[3].Value = model.alt;
			parameters[4].Value = model.linkurl;
			parameters[5].Value = model.status;
			parameters[6].Value = model.remark;
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
        public static int DeleteById(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ProductImg ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            return DBHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
		/// <summary>
		/// Delete一条数据
		/// </summary>
        public static int Delete(int productId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ProductImg ");
            strSql.Append(" where productId=@productId");
			SqlParameter[] parameters = {
					new SqlParameter("@productId", SqlDbType.Int,4)
			};
            parameters[0].Value = productId;

			return DBHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 批量Delete数据
		/// </summary>
		public bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ProductImg ");
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
		public Model.ProductImg GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,productId,imgURL,title,alt,linkurl,status,remark from ProductImg ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Model.ProductImg model=new Model.ProductImg();
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
		public Model.ProductImg DataRowToModel(DataRow row)
		{
			Model.ProductImg model=new Model.ProductImg();
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
				if(row["imgURL"]!=null)
				{
					model.imgURL=row["imgURL"].ToString();
				}
				if(row["title"]!=null)
				{
					model.title=row["title"].ToString();
				}
				if(row["alt"]!=null)
				{
					model.alt=row["alt"].ToString();
				}
				if(row["linkurl"]!=null)
				{
					model.linkurl=row["linkurl"].ToString();
				}
				if(row["status"]!=null && row["status"].ToString()!="")
				{
					model.status=int.Parse(row["status"].ToString());
				}
				if(row["remark"]!=null)
				{
					model.remark=row["remark"].ToString();
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
			strSql.Append("select id,productId,imgURL,title,alt,linkurl,status,remark ");
			strSql.Append(" FROM ProductImg ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
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
			strSql.Append(" id,productId,imgURL,title,alt,linkurl,status,remark ");
			strSql.Append(" FROM ProductImg ");
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
			strSql.Append("select count(1) FROM ProductImg ");
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
			strSql.Append(")AS Row, T.*  from ProductImg T ");
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
			parameters[0].Value = "ProductImg";
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

