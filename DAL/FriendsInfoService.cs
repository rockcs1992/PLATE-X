using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace DAL
{
	/// <summary>
	/// 数据访问类FriendsInfoService。
	/// </summary>
	public class FriendsInfoService
	{
		public FriendsInfoService()
		{}
		#region  成员方法
        /// <summary>
        /// 根据图片路径获取URL
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static string GetUrl(string src) 
        {
            string sql = "select linkurl from FriendsInfo where img1path = '" + src + "'";
            object obj = DBHelperSQL.GetSingle(sql);
            if(obj != null)
            {
                return obj.ToString();
            }
            return "";
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static DataSet GetModelByModelId(int status)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,title,alt,img1path,img2Path,linkurl,orderNum,status,addTime,addUser,infoType from FriendsInfo ");
            strSql.Append(" where status=@status order by orderNum desc");
            SqlParameter[] parameters = {
					new SqlParameter("@status", SqlDbType.Int,4)};
            parameters[0].Value = status;

            Model.FriendsInfo model = new Model.FriendsInfo();
            return DBHelperSQL.Query(strSql.ToString(), parameters);
           
        }

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from FriendsInfo");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			return DBHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public static int Add(Model.FriendsInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into FriendsInfo(");
			strSql.Append("title,alt,img1path,img2Path,linkurl,orderNum,status,addTime,addUser,infoType)");
			strSql.Append(" values (");
			strSql.Append("@title,@alt,@img1path,@img2Path,@linkurl,@orderNum,@status,@addTime,@addUser,@infoType)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.VarChar,50),
					new SqlParameter("@alt", SqlDbType.VarChar,50),
					new SqlParameter("@img1path", SqlDbType.VarChar,50),
					new SqlParameter("@img2Path", SqlDbType.VarChar,50),
					new SqlParameter("@linkurl", SqlDbType.VarChar,150),
					new SqlParameter("@orderNum", SqlDbType.Int,4),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@addTime", SqlDbType.DateTime),
					new SqlParameter("@addUser", SqlDbType.Int,4),
					new SqlParameter("@infoType", SqlDbType.Int,4)};
			parameters[0].Value = model.title;
			parameters[1].Value = model.alt;
			parameters[2].Value = model.img1path;
			parameters[3].Value = model.img2Path;
			parameters[4].Value = model.linkurl;
			parameters[5].Value = model.orderNum;
			parameters[6].Value = model.status;
			parameters[7].Value = model.addTime;
			parameters[8].Value = model.addUser;
			parameters[9].Value = model.infoType;

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
		public static int Update(Model.FriendsInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update FriendsInfo set ");
			strSql.Append("title=@title,");
			strSql.Append("alt=@alt,");
			strSql.Append("img1path=@img1path,");
			strSql.Append("img2Path=@img2Path,");
			strSql.Append("linkurl=@linkurl,");
			strSql.Append("orderNum=@orderNum,");
			strSql.Append("status=@status");			
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@title", SqlDbType.VarChar,50),
					new SqlParameter("@alt", SqlDbType.VarChar,50),
					new SqlParameter("@img1path", SqlDbType.VarChar,50),
					new SqlParameter("@img2Path", SqlDbType.VarChar,50),
					new SqlParameter("@linkurl", SqlDbType.VarChar,150),
					new SqlParameter("@orderNum", SqlDbType.Int,4),
					new SqlParameter("@status", SqlDbType.Int,4)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.title;
			parameters[2].Value = model.alt;
			parameters[3].Value = model.img1path;
			parameters[4].Value = model.img2Path;
			parameters[5].Value = model.linkurl;
			parameters[6].Value = model.orderNum;
			parameters[7].Value = model.status;

			return DBHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// Delete一条数据
		/// </summary>
		public static int Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from FriendsInfo ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			return DBHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Model.FriendsInfo GetModelByStatus(int status)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,title,alt,img1path,img2Path,linkurl,orderNum,status,addTime,addUser,infoType from FriendsInfo ");
            strSql.Append(" where status=@status order by id desc");
            SqlParameter[] parameters = {
					new SqlParameter("@status", SqlDbType.Int,4)};
            parameters[0].Value = status;

            Model.FriendsInfo model = new Model.FriendsInfo();
            DataSet ds = DBHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                model.title = ds.Tables[0].Rows[0]["title"].ToString();
                model.alt = ds.Tables[0].Rows[0]["alt"].ToString();
                model.img1path = ds.Tables[0].Rows[0]["img1path"].ToString();
                model.img2Path = ds.Tables[0].Rows[0]["img2Path"].ToString();
                model.linkurl = ds.Tables[0].Rows[0]["linkurl"].ToString();
                if (ds.Tables[0].Rows[0]["orderNum"].ToString() != "")
                {
                    model.orderNum = int.Parse(ds.Tables[0].Rows[0]["orderNum"].ToString());
                }
                if (ds.Tables[0].Rows[0]["status"].ToString() != "")
                {
                    model.status = int.Parse(ds.Tables[0].Rows[0]["status"].ToString());
                }
                if (ds.Tables[0].Rows[0]["addTime"].ToString() != "")
                {
                    model.addTime = DateTime.Parse(ds.Tables[0].Rows[0]["addTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["addUser"].ToString() != "")
                {
                    model.addUser = int.Parse(ds.Tables[0].Rows[0]["addUser"].ToString());
                }
                if (ds.Tables[0].Rows[0]["infoType"].ToString() != "")
                {
                    model.infoType = int.Parse(ds.Tables[0].Rows[0]["infoType"].ToString());
                }
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
		public static Model.FriendsInfo GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,title,alt,img1path,img2Path,linkurl,orderNum,status,addTime,addUser,infoType from FriendsInfo ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			Model.FriendsInfo model=new Model.FriendsInfo();
			DataSet ds=DBHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.title=ds.Tables[0].Rows[0]["title"].ToString();
				model.alt=ds.Tables[0].Rows[0]["alt"].ToString();
				model.img1path=ds.Tables[0].Rows[0]["img1path"].ToString();
				model.img2Path=ds.Tables[0].Rows[0]["img2Path"].ToString();
				model.linkurl=ds.Tables[0].Rows[0]["linkurl"].ToString();
				if(ds.Tables[0].Rows[0]["orderNum"].ToString()!="")
				{
					model.orderNum=int.Parse(ds.Tables[0].Rows[0]["orderNum"].ToString());
				}
				if(ds.Tables[0].Rows[0]["status"].ToString()!="")
				{
					model.status=int.Parse(ds.Tables[0].Rows[0]["status"].ToString());
				}
				if(ds.Tables[0].Rows[0]["addTime"].ToString()!="")
				{
					model.addTime=DateTime.Parse(ds.Tables[0].Rows[0]["addTime"].ToString());
				}
				if(ds.Tables[0].Rows[0]["addUser"].ToString()!="")
				{
					model.addUser=int.Parse(ds.Tables[0].Rows[0]["addUser"].ToString());
				}
				if(ds.Tables[0].Rows[0]["infoType"].ToString()!="")
				{
					model.infoType=int.Parse(ds.Tables[0].Rows[0]["infoType"].ToString());
				}
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
			strSql.Append("select id,title,alt,img1path,img2Path,linkurl,orderNum,status,addTime,addUser,infoType ");
			strSql.Append(" FROM FriendsInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
            strSql.Append(" order by id asc");
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
			strSql.Append(" id,title,alt,img1path,img2Path,linkurl,orderNum,status,addTime,addUser,infoType ");
			strSql.Append(" FROM FriendsInfo ");
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
			parameters[0].Value = "FriendsInfo";
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

