using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Model;
namespace DAL
{
	/// <summary>
	/// 数据访问类AdminUserService。
	/// </summary>
	public class AdminUserService
	{
		public AdminUserService()
		{}
		#region  成员方法
        /// <summary>
        /// 启用或停用管理员
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int UseAdmin(int id,int status)
        {
            string sql = "";
            if (status == 1)
            {
                sql = "update AdminUser set status = 2 where id = " + id;
            }
            else
            {
                sql = "update AdminUser set status = 1 where id = " + id;
            }

            return DBHelperSQL.ExecuteSql(sql);
        }
		/// <summary>
		/// 是否存在该记录
		/// </summary>
        public static bool Exists(AdminUser item)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from AdminUser");
            strSql.Append(" where username=@username ");
			SqlParameter[] parameters = {
					new SqlParameter("@username", SqlDbType.VarChar,40)};
			parameters[0].Value = item.username;

			return DBHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public static int Add(Model.AdminUser model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into AdminUser(");
			strSql.Append("username,password,md5Pass,realName,roleId,status,remark)");
			strSql.Append(" values (");
			strSql.Append("@username,@password,@md5Pass,@realName,@roleId,@status,@remark)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@username", SqlDbType.VarChar,50),
					new SqlParameter("@password", SqlDbType.VarChar,50),
					new SqlParameter("@md5Pass", SqlDbType.VarChar,50),
					new SqlParameter("@realName", SqlDbType.VarChar,50),
					new SqlParameter("@roleId", SqlDbType.Int,4),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.VarChar,50)};
			parameters[0].Value = model.username;
			parameters[1].Value = model.password;
			parameters[2].Value = model.md5Pass;
			parameters[3].Value = model.realName;
			parameters[4].Value = model.roleId;
			parameters[5].Value = model.status;
			parameters[6].Value = model.remark;

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
		public static int Update(Model.AdminUser model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update AdminUser set ");
			strSql.Append("username=@username,");
			strSql.Append("password=@password,");
			strSql.Append("md5Pass=@md5Pass,");
			strSql.Append("realName=@realName,");
			strSql.Append("roleId=@roleId,");
			strSql.Append("status=@status,");
			strSql.Append("remark=@remark");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@username", SqlDbType.VarChar,50),
					new SqlParameter("@password", SqlDbType.VarChar,50),
					new SqlParameter("@md5Pass", SqlDbType.VarChar,50),
					new SqlParameter("@realName", SqlDbType.VarChar,50),
					new SqlParameter("@roleId", SqlDbType.Int,4),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.VarChar,50)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.username;
			parameters[2].Value = model.password;
			parameters[3].Value = model.md5Pass;
			parameters[4].Value = model.realName;
			parameters[5].Value = model.roleId;
			parameters[6].Value = model.status;
			parameters[7].Value = model.remark;

			return DBHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// Delete一条数据
		/// </summary>
		public static int Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from AdminUser ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			return DBHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Model.AdminUser GetModel(string name,string pass)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,username,password,md5Pass,realName,roleId,status,remark from AdminUser ");
            strSql.Append(" where username = '" + name + "' and password = '" + pass + "'");
            
            Model.AdminUser model = new Model.AdminUser();
            DataSet ds = DBHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                model.username = ds.Tables[0].Rows[0]["username"].ToString();
                model.password = ds.Tables[0].Rows[0]["password"].ToString();
                model.md5Pass = ds.Tables[0].Rows[0]["md5Pass"].ToString();
                model.realName = ds.Tables[0].Rows[0]["realName"].ToString();
                if (ds.Tables[0].Rows[0]["roleId"].ToString() != "")
                {
                    model.roleId = int.Parse(ds.Tables[0].Rows[0]["roleId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["status"].ToString() != "")
                {
                    model.status = int.Parse(ds.Tables[0].Rows[0]["status"].ToString());
                }
                model.remark = ds.Tables[0].Rows[0]["remark"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public static Model.AdminUser GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,username,password,md5Pass,realName,roleId,status,remark from AdminUser ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			Model.AdminUser model=new Model.AdminUser();
			DataSet ds=DBHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.username=ds.Tables[0].Rows[0]["username"].ToString();
				model.password=ds.Tables[0].Rows[0]["password"].ToString();
				model.md5Pass=ds.Tables[0].Rows[0]["md5Pass"].ToString();
				model.realName=ds.Tables[0].Rows[0]["realName"].ToString();
				if(ds.Tables[0].Rows[0]["roleId"].ToString()!="")
				{
					model.roleId=int.Parse(ds.Tables[0].Rows[0]["roleId"].ToString());
				}
				if(ds.Tables[0].Rows[0]["status"].ToString()!="")
				{
					model.status=int.Parse(ds.Tables[0].Rows[0]["status"].ToString());
				}
				model.remark=ds.Tables[0].Rows[0]["remark"].ToString();
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
		public static DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,username,password,md5Pass,realName,roleId,status,remark ");
			strSql.Append(" FROM AdminUser ");
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
			strSql.Append(" id,username,password,md5Pass,realName,roleId,status,remark ");
			strSql.Append(" FROM AdminUser ");
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
			parameters[0].Value = "AdminUser";
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

