using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace DAL
{
	/// <summary>
	/// ���ݷ�����:CartTempService
	/// </summary>
	public partial class CartTempService
	{
		public CartTempService()
		{}
		#region  BasicMethod
        /// <summary>
        /// Delete�û�������
        /// </summary>
        public static bool DeleteByUserIdRightNow(int userId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from CartTemp ");
            strSql.Append(" where addUser = " + userId);
            int rows = DBHelperSQL.ExecuteSql(strSql.ToString());
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
        /// ����һ������
        /// </summary>
        public static bool UpdateNewPC(int id, int productCount, string remark,int status)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CartTemp set ");
            strSql.Append("productCount=@productCount,remark = '" + remark + "',status = " + status);
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@productCount", SqlDbType.Int,4)};
            parameters[0].Value = id;
            parameters[1].Value = productCount;

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
        /// Delete�û�������
        /// </summary>
        public static bool ExistsSelProduct(int userId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 * from CartTemp ");
            strSql.Append(" where addUser = " + userId + " and sel = 1");
            int rows = DBHelperSQL.Query(strSql.ToString()).Tables[0].Rows.Count;
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
        /// ����ѡ��״̬
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int UpdateSel(int productId, int status,int userId) 
        {
            string sql = "update CartTemp set sel = " + status + " where addUser = " + userId + " and productId = " + productId;
            return DBHelperSQL.ExecuteSql(sql);
        }
        /// <summary>
        /// ���ﳵ����Quantity
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static int UpdateCart(Model.CartTemp item) 
        {
            string sql = "update CartTemp set productCount = " + item.productCount + ",remark = '" + item.remark + "' where id = " + item.id;
            return DBHelperSQL.ExecuteSql(sql);
        }
        /// <summary>
        /// ��ȡ���ﳵ��ƷQuantity
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static int GetProductCount(object userId)
        {
            string sql = "select sum(productCount) as productCount from CartTemp where addUser = " + userId;
            object obj = DBHelperSQL.GetSingle(sql);
            if(obj != null)
            {
                return Convert.ToInt32(obj);
            }
            return 0;
        }
        /// <summary>
        /// Delete�û�������
        /// </summary>
        public static bool DeleteByUserId(int userId, int productId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from CartTemp ");
            strSql.Append(" where addUser = " + userId + " and sel = 1");
            int rows = DBHelperSQL.ExecuteSql(strSql.ToString());
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
        /// �õ�һ������ʵ��
        /// </summary>
        public static Model.CartTemp GetModel(int addUser, int productId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from CartTemp ");
            strSql.Append(" where addUser=@addUser and productId = " + productId);
            SqlParameter[] parameters = {
					new SqlParameter("@addUser", SqlDbType.Int,4)
			};
            parameters[0].Value = addUser;

            Model.CartTemp model = new Model.CartTemp();
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
		/// �Ƿ���ڸü�¼
		/// </summary>
		public static bool Exists(int productId,int addUser)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from CartTemp");
            strSql.Append(" where productId=@productId and addUser = " + addUser);
			SqlParameter[] parameters = {
					new SqlParameter("@productId", SqlDbType.Int,4)
			};
            parameters[0].Value = productId;

			return DBHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// ����һ������
		/// </summary>
        public static int Add(Model.CartTemp model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into CartTemp(");
			strSql.Append("productId,productCount,addUser,status,remark,sel)");
			strSql.Append(" values (");
			strSql.Append("@productId,@productCount,@addUser,@status,@remark," + model.sel + ")");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@productId", SqlDbType.Int,4),
					new SqlParameter("@productCount", SqlDbType.Int,4),
					new SqlParameter("@addUser", SqlDbType.Int,4),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.VarChar,50)};
			parameters[0].Value = model.productId;
			parameters[1].Value = model.productCount;
			parameters[2].Value = model.addUser;
			parameters[3].Value = model.status;
			parameters[4].Value = model.remark;

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
		/// ����һ������
		/// </summary>
        public static bool Update(int id, int productCount,string remark)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update CartTemp set ");
            strSql.Append("productCount=productCount + @productCount,remark = '" + remark + "'");
            strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@productCount", SqlDbType.Int,4)};
            parameters[0].Value = id;
            parameters[1].Value = productCount;

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
        /// Delete�û�������
        /// </summary>
        public static bool DeleteByUserId(int userId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from CartTemp ");
            strSql.Append(" where addUser = " + userId + " and sel = 1");
            int rows = DBHelperSQL.ExecuteSql(strSql.ToString());
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
        /// Deleteһ������
        /// </summary>
        public static bool Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from CartTemp ");
            strSql.Append(" where id = " + id);
            int rows = DBHelperSQL.ExecuteSql(strSql.ToString());
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
		/// Deleteһ������
		/// </summary>
        public static bool Delete(int userId,int pid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from CartTemp ");
            strSql.Append(" where productId=@productId and addUser = " + userId);
			SqlParameter[] parameters = {
					new SqlParameter("@productId", SqlDbType.Int,4)
			};
			parameters[0].Value = pid;

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
		/// ����Delete����
		/// </summary>
        public static bool DeleteList(string idlist)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from CartTemp ");
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
        /// �õ�һ������ʵ��
        /// </summary>
        public static Model.CartTemp GetModelByProductId(int userId, int productId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from CartTemp ");
            strSql.Append(" where productId=@productId and addUser = " + userId);
            SqlParameter[] parameters = {
					new SqlParameter("@productId", SqlDbType.Int,4)
			};
            parameters[0].Value = productId;

            Model.CartTemp model = new Model.CartTemp();
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
		/// �õ�һ������ʵ��
		/// </summary>
        public static Model.CartTemp GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 * from CartTemp ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Model.CartTemp model=new Model.CartTemp();
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
		/// �õ�һ������ʵ��
		/// </summary>
        public static Model.CartTemp DataRowToModel(DataRow row)
		{
			Model.CartTemp model=new Model.CartTemp();
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
				if(row["productCount"]!=null && row["productCount"].ToString()!="")
				{
					model.productCount=int.Parse(row["productCount"].ToString());
				}
				if(row["addUser"]!=null && row["addUser"].ToString()!="")
				{
					model.addUser=int.Parse(row["addUser"].ToString());
				}
				if(row["status"]!=null && row["status"].ToString()!="")
				{
					model.status=int.Parse(row["status"].ToString());
				}
				if(row["remark"]!=null)
				{
					model.remark=row["remark"].ToString();
				}
                if (row["sel"] != null && row["sel"].ToString() != "")
                {
                    model.sel = int.Parse(row["sel"].ToString());
                }
			}
			return model;
		}

		/// <summary>
		/// ��������б�
		/// </summary>
        public static DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM CartTemp ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DBHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// ���ǰ��������
		/// </summary>
        public static DataSet GetList(int Top, string strWhere, string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" * ");
			strSql.Append(" FROM CartTemp ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DBHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// ��ȡ��¼����
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM CartTemp ");
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
		/// ��ҳ��ȡ�����б�
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
			strSql.Append(")AS Row, T.*  from CartTemp T ");
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
		/// ��ҳ��ȡ�����б�
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
			parameters[0].Value = "CartTemp";
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

