using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Model;

namespace DAL
{
	/// <summary>
	/// 数据访问类:UserInfoService
	/// </summary>
	public partial class UserInfoService
	{
		public UserInfoService()
		{}
		#region  BasicMethod


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Model.UserInfo GetModel(string mobile)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from UserInfo ");
            strSql.Append(" where mobile=@mobile");
            SqlParameter[] parameters = {
					new SqlParameter("@mobile", SqlDbType.VarChar,154)
			};
            parameters[0].Value = mobile;

            Model.UserInfo model = new Model.UserInfo();
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
        /// 设置新Password
        /// </summary>
        /// <param name="mobile"></param>
        /// <param name="pass"></param>
        /// <param name="md5Pass"></param>
        /// <returns></returns>
        public static int SetNewPass(string mobile,string pass,string md5Pass) 
        {
            string sql = "update UserInfo set password = '" + pass + "',md5Pass = '" + md5Pass + "' where mobile = '" + mobile + "'";
            return DBHelperSQL.ExecuteSql(sql);
        }

        /// <summary>
        /// 更新支付Password
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static int UpdatePayPass(UserInfo user) 
        {
            string sql = "update UserInfo set telephone = '" + user.telephone + "' where id = " + user.id;
            return DBHelperSQL.ExecuteSql(sql);
        }
        /// <summary>
        /// 绑定邮箱
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public static int BindEmail(object userId,object email) 
        {
            string sql = "update UserInfo set isBindEmail = 1,email = '" + email + "' where id = " + userId;
            return DBHelperSQL.ExecuteSql(sql);
        }
        /// <summary>
        /// Delete二维码
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static int DelErWeiCode(UserInfo user) 
        {
            string sql = "update UserInfo set badCount = 0,imgUrl = '' where id = " + user.id;
            return DBHelperSQL.ExecuteSql(sql);
        }
        /// <summary>
        /// 更新找回Password信息
        /// </summary>
        /// <param name="username"></param>
        /// <param name="email"></param>
        /// <param name="md5UserName"></param>
        /// <param name="md5Email"></param>
        /// <returns></returns>
        public static int UpdateActive(string username,string email,string md5UserName,string md5Email) 
        {
            string sql = "update UserInfo set mobileCode = '" + md5UserName + "',activeCode = '" + md5Email +"' where username = '" + username + "' and email = '" + email + "'";
            return DBHelperSQL.ExecuteSql(sql);
        }
        /// <summary>
        /// 更新付款状态
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static int UpdatePayStatus(UserInfo user)
        {
            string sql = "update UserInfo set badCount = " + user.badcount + " where id = " + user.id;
             return DBHelperSQL.ExecuteSql(sql);
        }
        /// <summary>
        /// 更新会员I am a
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static int UpdateInfoType(UserInfo user) 
        {
            string sql = "update UserInfo set infoType = " + user.infoType + ",comName = '" + user.comName + "',address = '" + user.address + "',mainbrand = '" + user.mainbrand + "' where id = " + user.id;
            return DBHelperSQL.ExecuteSql(sql);
        }
        /// <summary>
        /// 更新浏览次数
        /// </summary>
        /// <param name="comId"></param>
        /// <returns></returns>
        public static int UpdateViews(int comId) 
        {
            string sql = "update UserInfo set viewsCount = viewsCount + 1 where id = " + comId;
            return DBHelperSQL.ExecuteSql(sql);
        }
        /// <summary>
        /// 获取浏览次数
        /// </summary>
        /// <param name="comId"></param>
        /// <returns></returns>
        public static int GetViews(int comId)
        {
            string sql = "select viewsCount from UserInfo where id = " + comId;
            object obj = DBHelperSQL.GetSingle(sql);
            if(obj != null)
            {
                return Convert.ToInt32(obj);
            }
            return 0;
        }
        /// <summary>
        /// 更新公司Item Name信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static int UpdateComName(UserInfo user) 
        {
            string sql = "update UserInfo set comName = '" + user.comName + "' where id = " + user.id;
            return DBHelperSQL.ExecuteSql(sql);
        }
        /// <summary>
        /// 更新Phone号
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static int UpdateMobile(UserInfo user) 
        {
            string sql = "update UserInfo set isBindMobile = 1,mobile = '" + user.mobile + "' where id = " + user.id;
            return DBHelperSQL.ExecuteSql(sql);
        }
        /// <summary>
        /// 更新email 和mobile
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static int UpdateEmailAndMobile(UserInfo user) 
        {
            string sql = "update UserInfo set mobile = '" + user.mobile + "',mainBrand = '" + user.mainbrand + "',email = '" + user.email + "' where id = " + user.id;
            return DBHelperSQL.ExecuteSql(sql);
        }
        /// <summary>
        /// 找回Password更新新的Password
        /// </summary>
        /// <param name="password"></param>
        /// <param name="md5Pass"></param>
        /// <param name="mobileCode"></param>
        /// <param name="activeCode"></param>
        /// <returns></returns>
        public static int UpdatePassword(string password,string md5Pass, string mobileCode,string activeCode)
        {
            string sql = "update UserInfo set password = '" + password + "',md5Pass = '" + md5Pass + "' where mobileCode = '" + mobileCode + "' and activeCode = '" + activeCode + "'";
            return DBHelperSQL.ExecuteSql(sql);
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static string GetUserName(string username, string email)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select username from UserInfo");
            strSql.Append(" where (username=@username or mobile=@mobile) and email=@email");
            SqlParameter[] parameters = {
					new SqlParameter("@username", SqlDbType.VarChar,54),new SqlParameter("@email", SqlDbType.VarChar,54)
			};
            parameters[0].Value = username;
            parameters[1].Value = email;
            object obj = DBHelperSQL.GetSingle(strSql.ToString(), parameters);
            if(obj != null)
            {
                return obj.ToString();
            }
            return "";
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool Exists(string username,string email)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from UserInfo");
            strSql.Append(" where (username=@username or mobile=@mobile) and email=@email");
            SqlParameter[] parameters = {
					new SqlParameter("@username", SqlDbType.VarChar,54),new SqlParameter("@email", SqlDbType.VarChar,54)
			};
            parameters[0].Value = username;
            parameters[1].Value = email;
            return DBHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 激活账户
        /// </summary>
        /// <param name="mobileCode"></param>
        /// <param name="activeCode"></param>
        /// <returns></returns>
        public static int UpdateActive(string mobileCode, string activeCode) 
        {
            string sql = "update UserInfo set goodCount = 1 where mobileCode = '" + mobileCode + "' and activeCode = '" + activeCode + "'";
            return DBHelperSQL.ExecuteSql(sql);
        }
        /// <summary>
        /// 更新二维码
        /// </summary>
        /// <param name="id"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public static int UpdateErWeiCode(int id,string url) 
        {
            string sql = "update UserInfo set shopingTime = '" + url + "' where id = " + id;
            return DBHelperSQL.ExecuteSql(sql);
        }
        /// <summary>
        /// 更新登陆信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static int UpdateLoginTime(UserInfo user)
        {
            string sql = "update UserInfo set loginTime = '" + user.logintime + "',loginIP = '" + user.loginip + "' where id = " + user.id;
            return DBHelperSQL.ExecuteSql(sql);
        }
        /// <summary>
        /// 成员信息编辑更新所属公司信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static int UpdateMemComInfo(UserInfo user)
        {
            string sql = "update UserInfo set username = '" + user.username + "',password = '" + user.password + "',md5Pass = '" + user.md5Pass + "',comName = '" + user.comName + "',address = '" + user.address + "' where id = " + user.id;
            return DBHelperSQL.ExecuteSql(sql);
        }
        /// <summary>
        /// 更新用户状态
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public static int CheckUser(int id, int status)
        {
            string sql = "update UserInfo set assessCount = " + status + " where id = " + id;
            return DBHelperSQL.ExecuteSql(sql);
        }

        /// <summary>
        /// 催乳师验证信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static int CreditUser(int id,int type) 
        {
            string sql = "";
            if(type == 1)
            {
                sql = "update UserInfo set isBindWeiBo = 1 where id = " + id;
            }
            if(type == 2)
            {
                sql = "update UserInfo set isBindWeiXin = 1 where id = " + id;
            }
            return DBHelperSQL.ExecuteSql(sql);

        }

        /// <summary>
        /// 更新真实姓名
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="realName"></param>
        /// <returns></returns>
        public static int UpdateRealName(int userId,string realName) 
        {
            string sql = "update UserInfo set relName = '" + realName + "' where id = " + userId;
            return DBHelperSQL.ExecuteSql(sql);
        }

        /// <summary>
        /// 平台类登陆
        /// </summary>
        /// <param name="openId"></param>
        /// <param name="accessToken"></param>
        /// <param name="infoType"></param>
        /// <returns></returns>
        public static UserInfo GetModel(string loginname, string password)
        {
            string sql = "select * from UserInfo where mobile = '" + loginname + "' and md5Pass = '" + password + "'";
            Model.UserInfo model = new Model.UserInfo();
            DataSet ds = DBHelperSQL.Query(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            return null;
        }



        /// <summary>
        /// 头像信息更新
        /// </summary>
        /// <param name="model"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public static int UpdateImg(Model.UserInfo model,int num)
        {
            if(num == 1)
            {
                string sql = "update UserInfo set shopingTime = '" + model.shopingtime + "' where id = " + model.id;
                return DBHelperSQL.ExecuteSql(sql);
            }
            else if (num == 2)
            {
                string sql = "update UserInfo set mainbrand = '" + model.mainbrand + "' where id = " + model.id;
                return DBHelperSQL.ExecuteSql(sql);
            }
            else if (num == 3)
            {
                string sql = "update UserInfo set mobileCode = '" + model.mobileCode + "' where id = " + model.id;
                return DBHelperSQL.ExecuteSql(sql);
            }
            else if (num == 4)
            {
                string sql = "update UserInfo set activeCode = '" + model.activeCode + "' where id = " + model.id;
                return DBHelperSQL.ExecuteSql(sql);
            }
            else if (num == 5)
            {
                string sql = "update UserInfo set imgUrl = '" + model.imgUrl + "' where id = " + model.id;
                return DBHelperSQL.ExecuteSql(sql);
            }
            else if (num == 6)
            {
                string sql = "update UserInfo set remark = '" + model.remark + "' where id = " + model.id;
                return DBHelperSQL.ExecuteSql(sql);
            }
            else if (num == 10)
            {
                string sql = "update UserInfo set zipCode = '" + model.zipCode + "' where id = " + model.id;
                return DBHelperSQL.ExecuteSql(sql);
            }
            else if (num == 11)
            {
                string sql = "update UserInfo set qq = '" + model.qq + "' where id = " + model.id;
                return DBHelperSQL.ExecuteSql(sql);
            }
            else if (num == 12)
            {
                string sql = "update UserInfo set weixin = '" + model.weixin + "' where id = " + model.id;
                return DBHelperSQL.ExecuteSql(sql);
            }
            else if (num == 13)
            {
                string sql = "update UserInfo set weibo = '" + model.weibo + "' where id = " + model.id;
                return DBHelperSQL.ExecuteSql(sql);
            }
            return 0;
        }
        /// <summary>
        /// 更新普通用户信息
        /// </summary>
        /// <returns></returns>
        public static int UpdateCommonInfo(Model.UserInfo model) 
        {
            string sql = "update UserInfo set pid=" + model.pid + ",cid = " + model.cid + ", comName = '" + model.comName + "',mobile = '" + model.mobile + "',mainBrand = '" + model.mainbrand + "',email = '" + model.email + "',address = '" + model.address + "',regionId = " + model.regionId + " where id = " + model.id;
            return DBHelperSQL.ExecuteSql(sql);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static int UpdateShopInfo(Model.UserInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update UserInfo set ");
            
            strSql.Append("username=@username,");
            strSql.Append("relName=@relName,");

            strSql.Append("comName=@comName,");

            strSql.Append("imgUrl=@imgUrl,");
     
            strSql.Append("remark=@remark,");

            strSql.Append("mobileCode=@mobileCode,");

            strSql.Append("activeCode=@activeCode,");
            strSql.Append("mainbrand=@mainbrand,");

            strSql.Append("email=@email,shopType=" + model.shopType + ",weibo = '" + model.weibo + "'");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
                   new SqlParameter("@username", SqlDbType.VarChar,150),
                   new SqlParameter("@relName", SqlDbType.VarChar,150),	
							
					new SqlParameter("@comName", SqlDbType.VarChar,150),
                    new SqlParameter("@imgUrl", SqlDbType.VarChar,150),						
					
					new SqlParameter("@remark", SqlDbType.VarChar,1500),
					
					new SqlParameter("@mobileCode", SqlDbType.VarChar,550),
					new SqlParameter("@activeCode", SqlDbType.VarChar,550),
                    new SqlParameter("@mainbrand", SqlDbType.VarChar,1500),	

				new SqlParameter("@email", SqlDbType.VarChar,150),

					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.username;
            parameters[1].Value = model.relName;
            parameters[2].Value = model.comName;
            parameters[3].Value = model.imgUrl;

            parameters[4].Value = model.remark;

            parameters[5].Value = model.mobileCode;
            parameters[6].Value = model.activeCode;
            parameters[7].Value = model.mainbrand;

            parameters[8].Value = model.email;
            parameters[9].Value = model.id;
            return DBHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            
        }

        /// <summary>
        /// 更新昵称信息
        /// </summary>
        /// <param name="user"></param>
        /// <param name="relName"></param>
        /// <returns></returns>
        public static int UpdateNiCheng(UserInfo user,string relName) 
        {
            string sql = "update UserInfo set relName = '" + relName + "' where bodyCode = '" + user.bodyCode + "' and comName = '" + user.comName + "' and infoType = 2";
            return DBHelperSQL.ExecuteSql(sql);
        }

        /// <summary>
        /// 更新评论次数
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int UpdateassessCount(int id)
        {
            string sql = "update UserInfo set assessCount = assessCount + 1 where id = " + id;
            return DBHelperSQL.ExecuteSql(sql);
        }
        /// <summary>
        /// 发布该产品的经销商总数
        /// </summary>
        /// <param name="p1"></param>
        /// <returns></returns>
        public static int GetCount_Product(Product p1)
        {
            string sql = "select count(id) from UserInfo where id in(select addUser from Product where productType = " + p1.productType + " and proType = " + p1.proType + " and rankingType = " + p1.rankingType + " and proGradeName = '" + p1.proGradeName + "')";
            object obj = DBHelperSQL.GetSingle(sql);
            if(obj != null)
            {
                return Convert.ToInt32(obj);
            }
            return 0;
        }
        /// <summary>
        /// 更新用户推荐状态
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public static int UpdateTj(int id, int status)
        {
            string sql = "update UserInfo set isBindWeiXin = " + status + " where id = " + id;
            return DBHelperSQL.ExecuteSql(sql);
        }
        /// <summary>
        /// 更新用户状态
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public static int UpdateStatus(int id,int status)
        {
            string sql = "update UserInfo set status = " + status + " where id = " + id;
            return DBHelperSQL.ExecuteSql(sql);
        }
        /// <summary>
        /// qq登陆授权
        /// </summary>
        /// <param name="openId"></param>
        /// <param name="accessToken"></param>
        /// <param name="infoType"></param>
        /// <returns></returns>
        public static UserInfo GetModel(string openId,string accessToken,int infoType) 
        {
            string sql = "select * from UserInfo where bodyCode = '" + openId + "' and comName = '" + accessToken + "' and infoType = " + infoType;
            Model.UserInfo model = new Model.UserInfo();
            DataSet ds = DBHelperSQL.Query(sql);
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
        /// 会员中心更新信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static int UpdateCenterInfo(UserInfo user) 
        {
            string sql = "update UserInfo set weibo='" + user.weibo + "',remark = '" + user.remark + "',mainBrand = '" + user.mainbrand + "',assessCount = " + user.assesscount + ",mobile = '" + user.mobile + "',email = '" + user.email + "' where id = " + user.id;
            return DBHelperSQL.ExecuteSql(sql);
        }
        /// <summary>
        /// 修改用户Password
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static int ModPass(UserInfo item)
        {
            string sql = "update UserInfo set password = '" + item.password + "',md5Pass = '" + item.md5Pass + "' where id = " + item.id;
            return DBHelperSQL.ExecuteSql(sql);
        }
        /// <summary>
        /// 更新个人基本信息
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static int UpdateInfoShop(UserInfo item)
        {
            string sql = "update UserInfo set weibo = '" + item.weibo + "',remark='" + item.remark + "',email='" + item.email + "',imgUrl='" + item.imgUrl + "',mobileCode = '" + item.mobileCode + "',activeCode = '" + item.activeCode + "',comName = '" + item.comName + "',shopType = " + item.shopType + ",relName = '" + item.relName + "',username = '" + item.username + "',mainBrand ='" + item.mainbrand + "' where id = " + item.id;
            return DBHelperSQL.ExecuteSql(sql);
        }
        /// <summary>
        /// 更新个人基本信息
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static int UpdateInfo(UserInfo item) 
        {
            string sql = "update UserInfo set address = '" + item.address + "',imgUrl='" + item.imgUrl + "',mobileCode = '" + item.mobileCode + "',activeCode = '" + item.activeCode + "',shopingtime = '" + item.shopingtime + "',sharecount = " + item.sharecount + ",relName = '" + item.relName + "',username = '" + item.username + "',mainBrand ='" + item.mainbrand + "' where id = " + item.id;
            return DBHelperSQL.ExecuteSql(sql);
        }
        /// <summary>
        /// 获取Username
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static string GetUserName(int userId)
        {
            string sql = "select username from UserInfo where id = " + userId;
            object obj = DBHelperSQL.GetSingle(sql);
            if(obj != null)
            {
                return obj.ToString();
            }
            return "";
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistsMobileMod(string mobile,int userId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from UserInfo");
            strSql.Append(" where mobile=@mobile and id <> " + userId);
            SqlParameter[] parameters = {
					new SqlParameter("@mobile", SqlDbType.VarChar,54)
			};
            parameters[0].Value = mobile;

            return DBHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistsMobile(string mobile)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from UserInfo");
            strSql.Append(" where mobile=@mobile");
            SqlParameter[] parameters = {
					new SqlParameter("@mobile", SqlDbType.VarChar,54)
			};
            parameters[0].Value = mobile;

            return DBHelperSQL.Exists(strSql.ToString(), parameters);
        }
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public static bool Exists(string username)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from UserInfo");
            strSql.Append(" where mobile = '" + username + "'");
			SqlParameter[] parameters = {
					new SqlParameter("@username", SqlDbType.VarChar,54)
			};
            parameters[0].Value = username;

			return DBHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public static int Add(Model.UserInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into UserInfo(");
            strSql.Append("username,mobile,isBindMobile,email,isBindEmail,password,md5Pass,relName,bodyCode,comName,pid,cid,regionId,address,zipCode,qq,weixin,isBindWeiXin,weibo,isBindWeiBo,shopType,shopTypeName,imgUrl,comInfo,remark,status,addTime,mobileCode,activeCode,infoType,shopingTime,mainBrand,assessCount,shareCount,productType,goodCount,badCount,viewsCount,loginTime,loginIP)");
			strSql.Append(" values (");
            strSql.Append("@username,@mobile,@isBindMobile,@email,@isBindEmail,@password,@md5Pass,@relName,@bodyCode,@comName,@pid,@cid,@regionId,@address,@zipCode,@qq,@weixin,@isBindWeiXin,@weibo,@isBindWeiBo,@shopType,@shopTypeName,@imgUrl,@comInfo,@remark,@status,@addTime,@mobileCode,@activeCode,@infoType,@shopingTime,@mainBrand,@assessCount,@shareCount,@productType,@goodCount,@badCount,@viewsCount,@loginTime,@loginIP)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@username", SqlDbType.VarChar,150),
					new SqlParameter("@mobile", SqlDbType.VarChar,150),
					new SqlParameter("@isBindMobile", SqlDbType.Int,4),
					new SqlParameter("@email", SqlDbType.VarChar,150),
					new SqlParameter("@isBindEmail", SqlDbType.Int,4),
					new SqlParameter("@password", SqlDbType.VarChar,150),
					new SqlParameter("@md5Pass", SqlDbType.VarChar,150),
					new SqlParameter("@relName", SqlDbType.VarChar,150),
					new SqlParameter("@bodyCode", SqlDbType.VarChar,150),
					new SqlParameter("@comName", SqlDbType.VarChar,150),
					new SqlParameter("@pid", SqlDbType.Int,4),
					new SqlParameter("@cid", SqlDbType.Int,4),
					new SqlParameter("@regionId", SqlDbType.Int,4),
					new SqlParameter("@address", SqlDbType.VarChar,150),
					new SqlParameter("@zipCode", SqlDbType.VarChar,150),
					new SqlParameter("@qq", SqlDbType.VarChar,150),
					new SqlParameter("@weixin", SqlDbType.VarChar,150),
					new SqlParameter("@isBindWeiXin", SqlDbType.Int,4),
					new SqlParameter("@weibo", SqlDbType.VarChar,150),
					new SqlParameter("@isBindWeiBo", SqlDbType.Int,4),
					new SqlParameter("@shopType", SqlDbType.Int,4),
					new SqlParameter("@shopTypeName", SqlDbType.VarChar,150),
					new SqlParameter("@imgUrl", SqlDbType.VarChar,150),
					new SqlParameter("@comInfo", SqlDbType.NText),
					new SqlParameter("@remark", SqlDbType.VarChar,1500),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@addTime", SqlDbType.DateTime),
					new SqlParameter("@mobileCode", SqlDbType.VarChar,150),
					new SqlParameter("@activeCode", SqlDbType.VarChar,150),
					new SqlParameter("@infoType", SqlDbType.Int,4),
                                        		new SqlParameter("@shopingTime", SqlDbType.VarChar,54),
                                        		new SqlParameter("@mainBrand", SqlDbType.VarChar,154),
                                        		new SqlParameter("@assessCount", SqlDbType.Int,4),
                                        		new SqlParameter("@shareCount", SqlDbType.Int,4),
                                        		new SqlParameter("@productType", SqlDbType.Int,4),
                                        		new SqlParameter("@goodCount", SqlDbType.Int,4),
                                        		new SqlParameter("@badCount", SqlDbType.Int,4),
                                        		new SqlParameter("@viewsCount", SqlDbType.Int,4),new SqlParameter("@loginTime", SqlDbType.DateTime),new SqlParameter("@loginIP", SqlDbType.VarChar,54)};
			parameters[0].Value = model.username;
			parameters[1].Value = model.mobile;
			parameters[2].Value = model.isBindMobile;
			parameters[3].Value = model.email;
			parameters[4].Value = model.isBindEmail;
			parameters[5].Value = model.password;
			parameters[6].Value = model.md5Pass;
			parameters[7].Value = model.relName;
			parameters[8].Value = model.bodyCode;
			parameters[9].Value = model.comName;
			parameters[10].Value = model.pid;
			parameters[11].Value = model.cid;
			parameters[12].Value = model.regionId;
			parameters[13].Value = model.address;
			parameters[14].Value = model.zipCode;
			parameters[15].Value = model.qq;
			parameters[16].Value = model.weixin;
			parameters[17].Value = model.isBindWeiXin;
			parameters[18].Value = model.weibo;
			parameters[19].Value = model.isBindWeiBo;
			parameters[20].Value = model.shopType;
			parameters[21].Value = model.shopTypeName;
			parameters[22].Value = model.imgUrl;
			parameters[23].Value = model.comInfo;
			parameters[24].Value = model.remark;
			parameters[25].Value = model.status;
			parameters[26].Value = model.addTime;
			parameters[27].Value = model.mobileCode;
			parameters[28].Value = model.activeCode;
			parameters[29].Value = model.infoType;


            parameters[30].Value = model.shopingtime;
            parameters[31].Value = model.mainbrand;
            parameters[32].Value = model.assesscount;
            parameters[33].Value = model.sharecount;
            parameters[34].Value = model.producttype;
            parameters[35].Value = model.goodcount;
            parameters[36].Value = model.badcount;
            parameters[37].Value = model.viewscountd;
            parameters[38].Value = model.logintime;
            parameters[39].Value = model.loginip;
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
		public bool Update(Model.UserInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update UserInfo set ");
			strSql.Append("username=@username,");
			strSql.Append("mobile=@mobile,");
			strSql.Append("isBindMobile=@isBindMobile,");
			strSql.Append("email=@email,");
			strSql.Append("isBindEmail=@isBindEmail,");
			strSql.Append("password=@password,");
			strSql.Append("md5Pass=@md5Pass,");
			strSql.Append("relName=@relName,");
			strSql.Append("bodyCode=@bodyCode,");
			strSql.Append("comName=@comName,");
			strSql.Append("pid=@pid,");
			strSql.Append("cid=@cid,");
			strSql.Append("regionId=@regionId,");
			strSql.Append("address=@address,");
			strSql.Append("zipCode=@zipCode,");
			strSql.Append("qq=@qq,");
			strSql.Append("weixin=@weixin,");
			strSql.Append("isBindWeiXin=@isBindWeiXin,");
			strSql.Append("weibo=@weibo,");
			strSql.Append("isBindWeiBo=@isBindWeiBo,");
			strSql.Append("shopType=@shopType,");
			strSql.Append("shopTypeName=@shopTypeName,");
			strSql.Append("imgUrl=@imgUrl,");
			strSql.Append("comInfo=@comInfo,");
			strSql.Append("remark=@remark,");
			strSql.Append("status=@status,");
			strSql.Append("addTime=@addTime,");
			strSql.Append("mobileCode=@mobileCode,");
			strSql.Append("activeCode=@activeCode,");
			strSql.Append("infoType=@infoType");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@username", SqlDbType.VarChar,150),
					new SqlParameter("@mobile", SqlDbType.VarChar,150),
					new SqlParameter("@isBindMobile", SqlDbType.Int,4),
					new SqlParameter("@email", SqlDbType.VarChar,150),
					new SqlParameter("@isBindEmail", SqlDbType.Int,4),
					new SqlParameter("@password", SqlDbType.VarChar,150),
					new SqlParameter("@md5Pass", SqlDbType.VarChar,150),
					new SqlParameter("@relName", SqlDbType.VarChar,150),
					new SqlParameter("@bodyCode", SqlDbType.VarChar,150),
					new SqlParameter("@comName", SqlDbType.VarChar,150),
					new SqlParameter("@pid", SqlDbType.Int,4),
					new SqlParameter("@cid", SqlDbType.Int,4),
					new SqlParameter("@regionId", SqlDbType.Int,4),
					new SqlParameter("@address", SqlDbType.VarChar,150),
					new SqlParameter("@zipCode", SqlDbType.VarChar,150),
					new SqlParameter("@qq", SqlDbType.VarChar,150),
					new SqlParameter("@weixin", SqlDbType.VarChar,150),
					new SqlParameter("@isBindWeiXin", SqlDbType.Int,4),
					new SqlParameter("@weibo", SqlDbType.VarChar,150),
					new SqlParameter("@isBindWeiBo", SqlDbType.Int,4),
					new SqlParameter("@shopType", SqlDbType.Int,4),
					new SqlParameter("@shopTypeName", SqlDbType.VarChar,150),
					new SqlParameter("@imgUrl", SqlDbType.VarChar,150),
					new SqlParameter("@comInfo", SqlDbType.NText),
					new SqlParameter("@remark", SqlDbType.VarChar,150),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@addTime", SqlDbType.DateTime),
					new SqlParameter("@mobileCode", SqlDbType.VarChar,150),
					new SqlParameter("@activeCode", SqlDbType.VarChar,150),
					new SqlParameter("@infoType", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.username;
			parameters[1].Value = model.mobile;
			parameters[2].Value = model.isBindMobile;
			parameters[3].Value = model.email;
			parameters[4].Value = model.isBindEmail;
			parameters[5].Value = model.password;
			parameters[6].Value = model.md5Pass;
			parameters[7].Value = model.relName;
			parameters[8].Value = model.bodyCode;
			parameters[9].Value = model.comName;
			parameters[10].Value = model.pid;
			parameters[11].Value = model.cid;
			parameters[12].Value = model.regionId;
			parameters[13].Value = model.address;
			parameters[14].Value = model.zipCode;
			parameters[15].Value = model.qq;
			parameters[16].Value = model.weixin;
			parameters[17].Value = model.isBindWeiXin;
			parameters[18].Value = model.weibo;
			parameters[19].Value = model.isBindWeiBo;
			parameters[20].Value = model.shopType;
			parameters[21].Value = model.shopTypeName;
			parameters[22].Value = model.imgUrl;
			parameters[23].Value = model.comInfo;
			parameters[24].Value = model.remark;
			parameters[25].Value = model.status;
			parameters[26].Value = model.addTime;
			parameters[27].Value = model.mobileCode;
			parameters[28].Value = model.activeCode;
			parameters[29].Value = model.infoType;
			parameters[30].Value = model.id;

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
		public static int Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from UserInfo ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			return DBHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 批量Delete数据
		/// </summary>
		public bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from UserInfo ");
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
		public static Model.UserInfo GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 * from UserInfo ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Model.UserInfo model=new Model.UserInfo();
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
		public static Model.UserInfo DataRowToModel(DataRow row)
		{
			Model.UserInfo model=new Model.UserInfo();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["username"]!=null)
				{
					model.username=row["username"].ToString();
				}
				if(row["mobile"]!=null)
				{
					model.mobile=row["mobile"].ToString();
				}
				if(row["isBindMobile"]!=null && row["isBindMobile"].ToString()!="")
				{
					model.isBindMobile=int.Parse(row["isBindMobile"].ToString());
				}
				if(row["email"]!=null)
				{
					model.email=row["email"].ToString();
				}
				if(row["isBindEmail"]!=null && row["isBindEmail"].ToString()!="")
				{
					model.isBindEmail=int.Parse(row["isBindEmail"].ToString());
				}
				if(row["password"]!=null)
				{
					model.password=row["password"].ToString();
				}
				if(row["md5Pass"]!=null)
				{
					model.md5Pass=row["md5Pass"].ToString();
				}
                if (row["telephone"] != null)
                {
                    model.telephone = row["telephone"].ToString();
                }

				if(row["relName"]!=null)
				{
					model.relName=row["relName"].ToString();
				}
				if(row["bodyCode"]!=null)
				{
					model.bodyCode=row["bodyCode"].ToString();
				}
				if(row["comName"]!=null)
				{
					model.comName=row["comName"].ToString();
				}
				if(row["pid"]!=null && row["pid"].ToString()!="")
				{
					model.pid=int.Parse(row["pid"].ToString());
				}
				if(row["cid"]!=null && row["cid"].ToString()!="")
				{
					model.cid=int.Parse(row["cid"].ToString());
				}
				if(row["regionId"]!=null && row["regionId"].ToString()!="")
				{
					model.regionId=int.Parse(row["regionId"].ToString());
				}
				if(row["address"]!=null)
				{
					model.address=row["address"].ToString();
				}
				if(row["zipCode"]!=null)
				{
					model.zipCode=row["zipCode"].ToString();
				}
				if(row["qq"]!=null)
				{
					model.qq=row["qq"].ToString();
				}
				if(row["weixin"]!=null)
				{
					model.weixin=row["weixin"].ToString();
				}
				if(row["isBindWeiXin"]!=null && row["isBindWeiXin"].ToString()!="")
				{
					model.isBindWeiXin=int.Parse(row["isBindWeiXin"].ToString());
				}
				if(row["weibo"]!=null)
				{
					model.weibo=row["weibo"].ToString();
				}
				if(row["isBindWeiBo"]!=null && row["isBindWeiBo"].ToString()!="")
				{
					model.isBindWeiBo=int.Parse(row["isBindWeiBo"].ToString());
				}
				if(row["shopType"]!=null && row["shopType"].ToString()!="")
				{
					model.shopType=int.Parse(row["shopType"].ToString());
				}
				if(row["shopTypeName"]!=null)
				{
					model.shopTypeName=row["shopTypeName"].ToString();
				}
				if(row["imgUrl"]!=null)
				{
					model.imgUrl=row["imgUrl"].ToString();
				}
				if(row["comInfo"]!=null)
				{
					model.comInfo=row["comInfo"].ToString();
				}
				if(row["remark"]!=null)
				{
					model.remark=row["remark"].ToString();
				}
				if(row["status"]!=null && row["status"].ToString()!="")
				{
					model.status=int.Parse(row["status"].ToString());
				}
				if(row["addTime"]!=null && row["addTime"].ToString()!="")
				{
					model.addTime=DateTime.Parse(row["addTime"].ToString());
				}
				if(row["mobileCode"]!=null)
				{
					model.mobileCode=row["mobileCode"].ToString();
				}
				if(row["activeCode"]!=null)
				{
					model.activeCode=row["activeCode"].ToString();
				}
				if(row["infoType"]!=null && row["infoType"].ToString()!="")
				{
					model.infoType=int.Parse(row["infoType"].ToString());
				}
                model.shopingtime = row["shopingTime"].ToString();
                model.mainbrand = row["mainbrand"].ToString();
                
                if (row["assessCount"] != null && row["assessCount"].ToString() != "")
                {
                    model.assesscount = int.Parse(row["assessCount"].ToString());
                }


                if (row["shareCount"] != null && row["shareCount"].ToString() != "")
                {
                    model.sharecount = int.Parse(row["shareCount"].ToString());
                }
                if (row["productType"] != null && row["productType"].ToString() != "")
                {
                    model.producttype = int.Parse(row["productType"].ToString());
                }
                if (row["goodCount"] != null && row["goodCount"].ToString() != "")
                {
                    model.goodcount = int.Parse(row["goodCount"].ToString());
                }


                if (row["badCount"] != null && row["badCount"].ToString() != "")
                {
                    model.badcount = int.Parse(row["badCount"].ToString());
                }
                if (row["viewsCount"] != null && row["viewsCount"].ToString() != "")
                {
                    model.viewscountd = int.Parse(row["viewsCount"].ToString());
                }


                model.loginip = row["loginip"].ToString();
                if (row["logintime"] != null && row["logintime"].ToString() != "")
                {
                    model.logintime = DateTime.Parse(row["logintime"].ToString());
                }
                model.relName = row["relName"].ToString();
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
			strSql.Append(" FROM UserInfo ");
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
			strSql.Append(" * ");
			strSql.Append(" FROM UserInfo ");
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
			strSql.Append("select count(1) FROM UserInfo ");
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
			strSql.Append(")AS Row, T.*  from UserInfo T ");
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
			parameters[0].Value = "UserInfo";
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

