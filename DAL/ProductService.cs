using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace DAL
{
	/// <summary>
	/// 数据访问类:ProductService
	/// </summary>
	public partial class ProductService
	{
		public ProductService()
		{}
		#region  BasicMethod
        /// 获得数据列表
        /// </summary>
        public static DataSet GetListCommitDesc(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  Max(p.id) as id,max(listImgUrl) as listImgUrl,max(proName) as proName,max(unit1) as unit1,max(price1) as price1,max(stopTypeName) as stopTypeName from Product p left join Comment c on p.id=c.productId where " + strWhere + " group by p.id order by count(c.id) desc");
           
            return DBHelperSQL.Query(strSql.ToString());
        }
        /// 获得数据列表
        /// </summary>
        public static DataSet GetListCommitAsc(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  Max(p.id) as id,max(listImgUrl) as listImgUrl,max(proName) as proName,max(unit1) as unit1,max(price1) as price1,max(stopTypeName) as stopTypeName from Product p left join Comment c on p.id=c.productId where " + strWhere + " group by p.id order by count(c.id) asc");

            return DBHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 更新推荐
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public static int UpdateTj(int id,int status) 
        {
            string sql = "update Product set status = " + status + " where id = " + id;
            return DBHelperSQL.ExecuteSql(sql);
        }

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public static bool Exists(string proName)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Product");
			strSql.Append(" where proName=@proName");
			SqlParameter[] parameters = {
					new SqlParameter("@proName", SqlDbType.VarChar,154)
			};
			parameters[0].Value = proName;

			return DBHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public static int Add(Model.Product model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Product(");
			strSql.Append("proName,proNameEn,productType,productTypeName,proType,proTypeName,oneId,twoId,threeId,fourId,listImgUrl,detailImg1,detailImg2,detailImg3,detailImg4,creditImg1,creditImg2,creditImg3,creditImg4,fromImg,otherImg,fromId,fromName,fromDesc,brandId,brandName,varietyId,varietyName,relieveId,relieveName,cookId,cookName,useId,useName,unit1,price1,unit2,price2,unit3,price3,unit4,price4,advantage,saveInfo,rankingType,rankingTypeName,ranking,listeTime,proGrade,proGradeName,proMaterial,proMaterialName,speed,stopType,stopTypeName,proContent,proDesc,ImgDesc,propertyDesc,labelInfo,assessCount,shareCount,viewsCount,author,isTj,isHot,isNew,goodCount,badCount,status,remark,addTime,addUser,addUserName,saveCount,infoType)");
			strSql.Append(" values (");
			strSql.Append("@proName,@proNameEn,@productType,@productTypeName,@proType,@proTypeName,@oneId,@twoId,@threeId,@fourId,@listImgUrl,@detailImg1,@detailImg2,@detailImg3,@detailImg4,@creditImg1,@creditImg2,@creditImg3,@creditImg4,@fromImg,@otherImg,@fromId,@fromName,@fromDesc,@brandId,@brandName,@varietyId,@varietyName,@relieveId,@relieveName,@cookId,@cookName,@useId,@useName,@unit1,@price1,@unit2,@price2,@unit3,@price3,@unit4,@price4,@advantage,@saveInfo,@rankingType,@rankingTypeName,@ranking,@listeTime,@proGrade,@proGradeName,@proMaterial,@proMaterialName,@speed,@stopType,@stopTypeName,@proContent,@proDesc,@ImgDesc,@propertyDesc,@labelInfo,@assessCount,@shareCount,@viewsCount,@author,@isTj,@isHot,@isNew,@goodCount,@badCount,@status,@remark,@addTime,@addUser,@addUserName,@saveCount,@infoType)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@proName", SqlDbType.VarChar,150),
					new SqlParameter("@proNameEn", SqlDbType.VarChar,150),
					new SqlParameter("@productType", SqlDbType.Int,4),
					new SqlParameter("@productTypeName", SqlDbType.VarChar,50),
					new SqlParameter("@proType", SqlDbType.Int,4),
					new SqlParameter("@proTypeName", SqlDbType.VarChar,150),
					new SqlParameter("@oneId", SqlDbType.Int,4),
					new SqlParameter("@twoId", SqlDbType.Int,4),
					new SqlParameter("@threeId", SqlDbType.Int,4),
					new SqlParameter("@fourId", SqlDbType.Int,4),
					new SqlParameter("@listImgUrl", SqlDbType.VarChar,150),
					new SqlParameter("@detailImg1", SqlDbType.VarChar,150),
					new SqlParameter("@detailImg2", SqlDbType.VarChar,150),
					new SqlParameter("@detailImg3", SqlDbType.VarChar,150),
					new SqlParameter("@detailImg4", SqlDbType.VarChar,150),
					new SqlParameter("@creditImg1", SqlDbType.VarChar,150),
					new SqlParameter("@creditImg2", SqlDbType.VarChar,150),
					new SqlParameter("@creditImg3", SqlDbType.VarChar,150),
					new SqlParameter("@creditImg4", SqlDbType.VarChar,150),
					new SqlParameter("@fromImg", SqlDbType.VarChar,150),
					new SqlParameter("@otherImg", SqlDbType.VarChar,150),
					new SqlParameter("@fromId", SqlDbType.Int,4),
					new SqlParameter("@fromName", SqlDbType.VarChar,150),
					new SqlParameter("@fromDesc", SqlDbType.VarChar,1500),
					new SqlParameter("@brandId", SqlDbType.Int,4),
					new SqlParameter("@brandName", SqlDbType.VarChar,150),
					new SqlParameter("@varietyId", SqlDbType.Int,4),
					new SqlParameter("@varietyName", SqlDbType.VarChar,150),
					new SqlParameter("@relieveId", SqlDbType.Int,4),
					new SqlParameter("@relieveName", SqlDbType.VarChar,150),
					new SqlParameter("@cookId", SqlDbType.Int,4),
					new SqlParameter("@cookName", SqlDbType.VarChar,150),
					new SqlParameter("@useId", SqlDbType.Int,4),
					new SqlParameter("@useName", SqlDbType.VarChar,150),
					new SqlParameter("@unit1", SqlDbType.VarChar,150),
					new SqlParameter("@price1", SqlDbType.Money,8),
					new SqlParameter("@unit2", SqlDbType.VarChar,150),
					new SqlParameter("@price2", SqlDbType.Money,8),
					new SqlParameter("@unit3", SqlDbType.VarChar,150),
					new SqlParameter("@price3", SqlDbType.Money,8),
					new SqlParameter("@unit4", SqlDbType.VarChar,150),
					new SqlParameter("@price4", SqlDbType.Money,8),
					new SqlParameter("@advantage", SqlDbType.VarChar,1500),
					new SqlParameter("@saveInfo", SqlDbType.VarChar,1500),
					new SqlParameter("@rankingType", SqlDbType.Int,4),
					new SqlParameter("@rankingTypeName", SqlDbType.VarChar,50),
					new SqlParameter("@ranking", SqlDbType.Int,4),
					new SqlParameter("@listeTime", SqlDbType.DateTime),
					new SqlParameter("@proGrade", SqlDbType.Int,4),
					new SqlParameter("@proGradeName", SqlDbType.VarChar,50),
					new SqlParameter("@proMaterial", SqlDbType.Int,4),
					new SqlParameter("@proMaterialName", SqlDbType.VarChar,150),
					new SqlParameter("@speed", SqlDbType.Int,4),
					new SqlParameter("@stopType", SqlDbType.Int,4),
					new SqlParameter("@stopTypeName", SqlDbType.VarChar,150),
					new SqlParameter("@proContent", SqlDbType.NText),
					new SqlParameter("@proDesc", SqlDbType.VarChar,1500),
					new SqlParameter("@ImgDesc", SqlDbType.NText),
					new SqlParameter("@propertyDesc", SqlDbType.VarChar,1500),
					new SqlParameter("@labelInfo", SqlDbType.VarChar,150),
					new SqlParameter("@assessCount", SqlDbType.Int,4),
					new SqlParameter("@shareCount", SqlDbType.Int,4),
					new SqlParameter("@viewsCount", SqlDbType.Int,4),
					new SqlParameter("@author", SqlDbType.VarChar,50),
					new SqlParameter("@isTj", SqlDbType.Int,4),
					new SqlParameter("@isHot", SqlDbType.Int,4),
					new SqlParameter("@isNew", SqlDbType.Int,4),
					new SqlParameter("@goodCount", SqlDbType.Int,4),
					new SqlParameter("@badCount", SqlDbType.Int,4),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.VarChar,150),
					new SqlParameter("@addTime", SqlDbType.DateTime),
					new SqlParameter("@addUser", SqlDbType.Int,4),
					new SqlParameter("@addUserName", SqlDbType.VarChar,50),
					new SqlParameter("@saveCount", SqlDbType.Int,4),
					new SqlParameter("@infoType", SqlDbType.Int,4)};
			parameters[0].Value = model.proName;
			parameters[1].Value = model.proNameEn;
			parameters[2].Value = model.productType;
			parameters[3].Value = model.productTypeName;
			parameters[4].Value = model.proType;
			parameters[5].Value = model.proTypeName;
			parameters[6].Value = model.oneId;
			parameters[7].Value = model.twoId;
			parameters[8].Value = model.threeId;
			parameters[9].Value = model.fourId;
			parameters[10].Value = model.listImgUrl;
			parameters[11].Value = model.detailImg1;
			parameters[12].Value = model.detailImg2;
			parameters[13].Value = model.detailImg3;
			parameters[14].Value = model.detailImg4;
			parameters[15].Value = model.creditImg1;
			parameters[16].Value = model.creditImg2;
			parameters[17].Value = model.creditImg3;
			parameters[18].Value = model.creditImg4;
			parameters[19].Value = model.fromImg;
			parameters[20].Value = model.otherImg;
			parameters[21].Value = model.fromId;
			parameters[22].Value = model.fromName;
			parameters[23].Value = model.fromDesc;
			parameters[24].Value = model.brandId;
			parameters[25].Value = model.brandName;
			parameters[26].Value = model.varietyId;
			parameters[27].Value = model.varietyName;
			parameters[28].Value = model.relieveId;
			parameters[29].Value = model.relieveName;
			parameters[30].Value = model.cookId;
			parameters[31].Value = model.cookName;
			parameters[32].Value = model.useId;
			parameters[33].Value = model.useName;
			parameters[34].Value = model.unit1;
			parameters[35].Value = model.price1;
			parameters[36].Value = model.unit2;
			parameters[37].Value = model.price2;
			parameters[38].Value = model.unit3;
			parameters[39].Value = model.price3;
			parameters[40].Value = model.unit4;
			parameters[41].Value = model.price4;
			parameters[42].Value = model.advantage;
			parameters[43].Value = model.saveInfo;
			parameters[44].Value = model.rankingType;
			parameters[45].Value = model.rankingTypeName;
			parameters[46].Value = model.ranking;
			parameters[47].Value = model.listeTime;
			parameters[48].Value = model.proGrade;
			parameters[49].Value = model.proGradeName;
			parameters[50].Value = model.proMaterial;
			parameters[51].Value = model.proMaterialName;
			parameters[52].Value = model.speed;
			parameters[53].Value = model.stopType;
			parameters[54].Value = model.stopTypeName;
			parameters[55].Value = model.proContent;
			parameters[56].Value = model.proDesc;
			parameters[57].Value = model.ImgDesc;
			parameters[58].Value = model.propertyDesc;
			parameters[59].Value = model.labelInfo;
			parameters[60].Value = model.assessCount;
			parameters[61].Value = model.shareCount;
			parameters[62].Value = model.viewsCount;
			parameters[63].Value = model.author;
			parameters[64].Value = model.isTj;
			parameters[65].Value = model.isHot;
			parameters[66].Value = model.isNew;
			parameters[67].Value = model.goodCount;
			parameters[68].Value = model.badCount;
			parameters[69].Value = model.status;
			parameters[70].Value = model.remark;
			parameters[71].Value = model.addTime;
			parameters[72].Value = model.addUser;
			parameters[73].Value = model.addUserName;
			parameters[74].Value = model.saveCount;
			parameters[75].Value = model.infoType;

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
		public static bool Update(Model.Product model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Product set ");
			strSql.Append("proName=@proName,");
			strSql.Append("proNameEn=@proNameEn,");
			strSql.Append("productType=@productType,");
			strSql.Append("productTypeName=@productTypeName,");
			strSql.Append("proType=@proType,");
			strSql.Append("proTypeName=@proTypeName,");
			strSql.Append("oneId=@oneId,");
			strSql.Append("twoId=@twoId,");
			strSql.Append("threeId=@threeId,");
			strSql.Append("fourId=@fourId,");
			strSql.Append("listImgUrl=@listImgUrl,");
			strSql.Append("detailImg1=@detailImg1,");
			strSql.Append("detailImg2=@detailImg2,");
			strSql.Append("detailImg3=@detailImg3,");
			strSql.Append("detailImg4=@detailImg4,");
			strSql.Append("creditImg1=@creditImg1,");
			strSql.Append("creditImg2=@creditImg2,");
			strSql.Append("creditImg3=@creditImg3,");
			strSql.Append("creditImg4=@creditImg4,");
			strSql.Append("fromImg=@fromImg,");
			strSql.Append("otherImg=@otherImg,");
			strSql.Append("fromId=@fromId,");
			strSql.Append("fromName=@fromName,");
			strSql.Append("fromDesc=@fromDesc,");
			strSql.Append("brandId=@brandId,");
			strSql.Append("brandName=@brandName,");
			strSql.Append("varietyId=@varietyId,");
			strSql.Append("varietyName=@varietyName,");
			strSql.Append("relieveId=@relieveId,");
			strSql.Append("relieveName=@relieveName,");
			strSql.Append("cookId=@cookId,");
			strSql.Append("cookName=@cookName,");
			strSql.Append("useId=@useId,");
			strSql.Append("useName=@useName,");
			strSql.Append("unit1=@unit1,");
			strSql.Append("price1=@price1,");
			strSql.Append("unit2=@unit2,");
			strSql.Append("price2=@price2,");
			strSql.Append("unit3=@unit3,");
			strSql.Append("price3=@price3,");
			strSql.Append("unit4=@unit4,");
			strSql.Append("price4=@price4,");
			strSql.Append("advantage=@advantage,");
			strSql.Append("saveInfo=@saveInfo,");
			strSql.Append("rankingType=@rankingType,");
			strSql.Append("rankingTypeName=@rankingTypeName,");
			strSql.Append("ranking=@ranking,");
			strSql.Append("listeTime=@listeTime,");
			strSql.Append("proGrade=@proGrade,");
			strSql.Append("proGradeName=@proGradeName,");
			strSql.Append("proMaterial=@proMaterial,");
			strSql.Append("proMaterialName=@proMaterialName,");
			strSql.Append("speed=@speed,");
			strSql.Append("stopType=@stopType,");
			strSql.Append("stopTypeName=@stopTypeName,");
			strSql.Append("proContent=@proContent,");
			strSql.Append("proDesc=@proDesc,");
			strSql.Append("ImgDesc=@ImgDesc,");
			strSql.Append("propertyDesc=@propertyDesc,");
			strSql.Append("labelInfo=@labelInfo,");
			strSql.Append("assessCount=@assessCount,");
			strSql.Append("shareCount=@shareCount,");
			strSql.Append("viewsCount=@viewsCount,");
			strSql.Append("author=@author,");
			strSql.Append("isTj=@isTj,");
			strSql.Append("isHot=@isHot,");
			strSql.Append("isNew=@isNew,");
			strSql.Append("goodCount=@goodCount,");
			strSql.Append("badCount=@badCount,");
			strSql.Append("status=@status,");
			strSql.Append("remark=@remark,");
			strSql.Append("addTime=@addTime,");
			strSql.Append("addUser=@addUser,");
			strSql.Append("addUserName=@addUserName,");
			strSql.Append("saveCount=@saveCount,");
			strSql.Append("infoType=@infoType");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@proName", SqlDbType.VarChar,150),
					new SqlParameter("@proNameEn", SqlDbType.VarChar,150),
					new SqlParameter("@productType", SqlDbType.Int,4),
					new SqlParameter("@productTypeName", SqlDbType.VarChar,50),
					new SqlParameter("@proType", SqlDbType.Int,4),
					new SqlParameter("@proTypeName", SqlDbType.VarChar,150),
					new SqlParameter("@oneId", SqlDbType.Int,4),
					new SqlParameter("@twoId", SqlDbType.Int,4),
					new SqlParameter("@threeId", SqlDbType.Int,4),
					new SqlParameter("@fourId", SqlDbType.Int,4),
					new SqlParameter("@listImgUrl", SqlDbType.VarChar,150),
					new SqlParameter("@detailImg1", SqlDbType.VarChar,150),
					new SqlParameter("@detailImg2", SqlDbType.VarChar,150),
					new SqlParameter("@detailImg3", SqlDbType.VarChar,150),
					new SqlParameter("@detailImg4", SqlDbType.VarChar,150),
					new SqlParameter("@creditImg1", SqlDbType.VarChar,150),
					new SqlParameter("@creditImg2", SqlDbType.VarChar,150),
					new SqlParameter("@creditImg3", SqlDbType.VarChar,150),
					new SqlParameter("@creditImg4", SqlDbType.VarChar,150),
					new SqlParameter("@fromImg", SqlDbType.VarChar,150),
					new SqlParameter("@otherImg", SqlDbType.VarChar,150),
					new SqlParameter("@fromId", SqlDbType.Int,4),
					new SqlParameter("@fromName", SqlDbType.VarChar,150),
					new SqlParameter("@fromDesc", SqlDbType.VarChar,1500),
					new SqlParameter("@brandId", SqlDbType.Int,4),
					new SqlParameter("@brandName", SqlDbType.VarChar,150),
					new SqlParameter("@varietyId", SqlDbType.Int,4),
					new SqlParameter("@varietyName", SqlDbType.VarChar,150),
					new SqlParameter("@relieveId", SqlDbType.Int,4),
					new SqlParameter("@relieveName", SqlDbType.VarChar,150),
					new SqlParameter("@cookId", SqlDbType.Int,4),
					new SqlParameter("@cookName", SqlDbType.VarChar,150),
					new SqlParameter("@useId", SqlDbType.Int,4),
					new SqlParameter("@useName", SqlDbType.VarChar,150),
					new SqlParameter("@unit1", SqlDbType.VarChar,150),
					new SqlParameter("@price1", SqlDbType.Money,8),
					new SqlParameter("@unit2", SqlDbType.VarChar,150),
					new SqlParameter("@price2", SqlDbType.Money,8),
					new SqlParameter("@unit3", SqlDbType.VarChar,150),
					new SqlParameter("@price3", SqlDbType.Money,8),
					new SqlParameter("@unit4", SqlDbType.VarChar,150),
					new SqlParameter("@price4", SqlDbType.Money,8),
					new SqlParameter("@advantage", SqlDbType.VarChar,1500),
					new SqlParameter("@saveInfo", SqlDbType.VarChar,1500),
					new SqlParameter("@rankingType", SqlDbType.Int,4),
					new SqlParameter("@rankingTypeName", SqlDbType.VarChar,50),
					new SqlParameter("@ranking", SqlDbType.Int,4),
					new SqlParameter("@listeTime", SqlDbType.DateTime),
					new SqlParameter("@proGrade", SqlDbType.Int,4),
					new SqlParameter("@proGradeName", SqlDbType.VarChar,50),
					new SqlParameter("@proMaterial", SqlDbType.Int,4),
					new SqlParameter("@proMaterialName", SqlDbType.VarChar,150),
					new SqlParameter("@speed", SqlDbType.Int,4),
					new SqlParameter("@stopType", SqlDbType.Int,4),
					new SqlParameter("@stopTypeName", SqlDbType.VarChar,150),
					new SqlParameter("@proContent", SqlDbType.NText),
					new SqlParameter("@proDesc", SqlDbType.VarChar,1500),
					new SqlParameter("@ImgDesc", SqlDbType.NText),
					new SqlParameter("@propertyDesc", SqlDbType.VarChar,1500),
					new SqlParameter("@labelInfo", SqlDbType.VarChar,150),
					new SqlParameter("@assessCount", SqlDbType.Int,4),
					new SqlParameter("@shareCount", SqlDbType.Int,4),
					new SqlParameter("@viewsCount", SqlDbType.Int,4),
					new SqlParameter("@author", SqlDbType.VarChar,50),
					new SqlParameter("@isTj", SqlDbType.Int,4),
					new SqlParameter("@isHot", SqlDbType.Int,4),
					new SqlParameter("@isNew", SqlDbType.Int,4),
					new SqlParameter("@goodCount", SqlDbType.Int,4),
					new SqlParameter("@badCount", SqlDbType.Int,4),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.VarChar,150),
					new SqlParameter("@addTime", SqlDbType.DateTime),
					new SqlParameter("@addUser", SqlDbType.Int,4),
					new SqlParameter("@addUserName", SqlDbType.VarChar,50),
					new SqlParameter("@saveCount", SqlDbType.Int,4),
					new SqlParameter("@infoType", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.proName;
			parameters[1].Value = model.proNameEn;
			parameters[2].Value = model.productType;
			parameters[3].Value = model.productTypeName;
			parameters[4].Value = model.proType;
			parameters[5].Value = model.proTypeName;
			parameters[6].Value = model.oneId;
			parameters[7].Value = model.twoId;
			parameters[8].Value = model.threeId;
			parameters[9].Value = model.fourId;
			parameters[10].Value = model.listImgUrl;
			parameters[11].Value = model.detailImg1;
			parameters[12].Value = model.detailImg2;
			parameters[13].Value = model.detailImg3;
			parameters[14].Value = model.detailImg4;
			parameters[15].Value = model.creditImg1;
			parameters[16].Value = model.creditImg2;
			parameters[17].Value = model.creditImg3;
			parameters[18].Value = model.creditImg4;
			parameters[19].Value = model.fromImg;
			parameters[20].Value = model.otherImg;
			parameters[21].Value = model.fromId;
			parameters[22].Value = model.fromName;
			parameters[23].Value = model.fromDesc;
			parameters[24].Value = model.brandId;
			parameters[25].Value = model.brandName;
			parameters[26].Value = model.varietyId;
			parameters[27].Value = model.varietyName;
			parameters[28].Value = model.relieveId;
			parameters[29].Value = model.relieveName;
			parameters[30].Value = model.cookId;
			parameters[31].Value = model.cookName;
			parameters[32].Value = model.useId;
			parameters[33].Value = model.useName;
			parameters[34].Value = model.unit1;
			parameters[35].Value = model.price1;
			parameters[36].Value = model.unit2;
			parameters[37].Value = model.price2;
			parameters[38].Value = model.unit3;
			parameters[39].Value = model.price3;
			parameters[40].Value = model.unit4;
			parameters[41].Value = model.price4;
			parameters[42].Value = model.advantage;
			parameters[43].Value = model.saveInfo;
			parameters[44].Value = model.rankingType;
			parameters[45].Value = model.rankingTypeName;
			parameters[46].Value = model.ranking;
			parameters[47].Value = model.listeTime;
			parameters[48].Value = model.proGrade;
			parameters[49].Value = model.proGradeName;
			parameters[50].Value = model.proMaterial;
			parameters[51].Value = model.proMaterialName;
			parameters[52].Value = model.speed;
			parameters[53].Value = model.stopType;
			parameters[54].Value = model.stopTypeName;
			parameters[55].Value = model.proContent;
			parameters[56].Value = model.proDesc;
			parameters[57].Value = model.ImgDesc;
			parameters[58].Value = model.propertyDesc;
			parameters[59].Value = model.labelInfo;
			parameters[60].Value = model.assessCount;
			parameters[61].Value = model.shareCount;
			parameters[62].Value = model.viewsCount;
			parameters[63].Value = model.author;
			parameters[64].Value = model.isTj;
			parameters[65].Value = model.isHot;
			parameters[66].Value = model.isNew;
			parameters[67].Value = model.goodCount;
			parameters[68].Value = model.badCount;
			parameters[69].Value = model.status;
			parameters[70].Value = model.remark;
			parameters[71].Value = model.addTime;
			parameters[72].Value = model.addUser;
			parameters[73].Value = model.addUserName;
			parameters[74].Value = model.saveCount;
			parameters[75].Value = model.infoType;
			parameters[76].Value = model.id;

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
			strSql.Append("delete from Product ");
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
		public static bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Product ");
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
		public static Model.Product GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,proName,proNameEn,productType,productTypeName,proType,proTypeName,oneId,twoId,threeId,fourId,listImgUrl,detailImg1,detailImg2,detailImg3,detailImg4,creditImg1,creditImg2,creditImg3,creditImg4,fromImg,otherImg,fromId,fromName,fromDesc,brandId,brandName,varietyId,varietyName,relieveId,relieveName,cookId,cookName,useId,useName,unit1,price1,unit2,price2,unit3,price3,unit4,price4,advantage,saveInfo,rankingType,rankingTypeName,ranking,listeTime,proGrade,proGradeName,proMaterial,proMaterialName,speed,stopType,stopTypeName,proContent,proDesc,ImgDesc,propertyDesc,labelInfo,assessCount,shareCount,viewsCount,author,isTj,isHot,isNew,goodCount,badCount,status,remark,addTime,addUser,addUserName,saveCount,infoType from Product ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Model.Product model=new Model.Product();
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
		public static Model.Product DataRowToModel(DataRow row)
		{
			Model.Product model=new Model.Product();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["proName"]!=null)
				{
					model.proName=row["proName"].ToString();
				}
				if(row["proNameEn"]!=null)
				{
					model.proNameEn=row["proNameEn"].ToString();
				}
				if(row["productType"]!=null && row["productType"].ToString()!="")
				{
					model.productType=int.Parse(row["productType"].ToString());
				}
				if(row["productTypeName"]!=null)
				{
					model.productTypeName=row["productTypeName"].ToString();
				}
				if(row["proType"]!=null && row["proType"].ToString()!="")
				{
					model.proType=int.Parse(row["proType"].ToString());
				}
				if(row["proTypeName"]!=null)
				{
					model.proTypeName=row["proTypeName"].ToString();
				}
				if(row["oneId"]!=null && row["oneId"].ToString()!="")
				{
					model.oneId=int.Parse(row["oneId"].ToString());
				}
				if(row["twoId"]!=null && row["twoId"].ToString()!="")
				{
					model.twoId=int.Parse(row["twoId"].ToString());
				}
				if(row["threeId"]!=null && row["threeId"].ToString()!="")
				{
					model.threeId=int.Parse(row["threeId"].ToString());
				}
				if(row["fourId"]!=null && row["fourId"].ToString()!="")
				{
					model.fourId=int.Parse(row["fourId"].ToString());
				}
				if(row["listImgUrl"]!=null)
				{
					model.listImgUrl=row["listImgUrl"].ToString();
				}
				if(row["detailImg1"]!=null)
				{
					model.detailImg1=row["detailImg1"].ToString();
				}
				if(row["detailImg2"]!=null)
				{
					model.detailImg2=row["detailImg2"].ToString();
				}
				if(row["detailImg3"]!=null)
				{
					model.detailImg3=row["detailImg3"].ToString();
				}
				if(row["detailImg4"]!=null)
				{
					model.detailImg4=row["detailImg4"].ToString();
				}
				if(row["creditImg1"]!=null)
				{
					model.creditImg1=row["creditImg1"].ToString();
				}
				if(row["creditImg2"]!=null)
				{
					model.creditImg2=row["creditImg2"].ToString();
				}
				if(row["creditImg3"]!=null)
				{
					model.creditImg3=row["creditImg3"].ToString();
				}
				if(row["creditImg4"]!=null)
				{
					model.creditImg4=row["creditImg4"].ToString();
				}
				if(row["fromImg"]!=null)
				{
					model.fromImg=row["fromImg"].ToString();
				}
				if(row["otherImg"]!=null)
				{
					model.otherImg=row["otherImg"].ToString();
				}
				if(row["fromId"]!=null && row["fromId"].ToString()!="")
				{
					model.fromId=int.Parse(row["fromId"].ToString());
				}
				if(row["fromName"]!=null)
				{
					model.fromName=row["fromName"].ToString();
				}
				if(row["fromDesc"]!=null)
				{
					model.fromDesc=row["fromDesc"].ToString();
				}
				if(row["brandId"]!=null && row["brandId"].ToString()!="")
				{
					model.brandId=int.Parse(row["brandId"].ToString());
				}
				if(row["brandName"]!=null)
				{
					model.brandName=row["brandName"].ToString();
				}
				if(row["varietyId"]!=null && row["varietyId"].ToString()!="")
				{
					model.varietyId=int.Parse(row["varietyId"].ToString());
				}
				if(row["varietyName"]!=null)
				{
					model.varietyName=row["varietyName"].ToString();
				}
				if(row["relieveId"]!=null && row["relieveId"].ToString()!="")
				{
					model.relieveId=int.Parse(row["relieveId"].ToString());
				}
				if(row["relieveName"]!=null)
				{
					model.relieveName=row["relieveName"].ToString();
				}
				if(row["cookId"]!=null && row["cookId"].ToString()!="")
				{
					model.cookId=int.Parse(row["cookId"].ToString());
				}
				if(row["cookName"]!=null)
				{
					model.cookName=row["cookName"].ToString();
				}
				if(row["useId"]!=null && row["useId"].ToString()!="")
				{
					model.useId=int.Parse(row["useId"].ToString());
				}
				if(row["useName"]!=null)
				{
					model.useName=row["useName"].ToString();
				}
				if(row["unit1"]!=null)
				{
					model.unit1=row["unit1"].ToString();
				}
				if(row["price1"]!=null && row["price1"].ToString()!="")
				{
					model.price1=double.Parse(row["price1"].ToString());
				}
				if(row["unit2"]!=null)
				{
					model.unit2=row["unit2"].ToString();
				}
				if(row["price2"]!=null && row["price2"].ToString()!="")
				{
					model.price2=double.Parse(row["price2"].ToString());
				}
				if(row["unit3"]!=null)
				{
					model.unit3=row["unit3"].ToString();
				}
				if(row["price3"]!=null && row["price3"].ToString()!="")
				{
					model.price3=double.Parse(row["price3"].ToString());
				}
				if(row["unit4"]!=null)
				{
					model.unit4=row["unit4"].ToString();
				}
				if(row["price4"]!=null && row["price4"].ToString()!="")
				{
					model.price4=double.Parse(row["price4"].ToString());
				}
				if(row["advantage"]!=null)
				{
					model.advantage=row["advantage"].ToString();
				}
				if(row["saveInfo"]!=null)
				{
					model.saveInfo=row["saveInfo"].ToString();
				}
				if(row["rankingType"]!=null && row["rankingType"].ToString()!="")
				{
					model.rankingType=int.Parse(row["rankingType"].ToString());
				}
				if(row["rankingTypeName"]!=null)
				{
					model.rankingTypeName=row["rankingTypeName"].ToString();
				}
				if(row["ranking"]!=null && row["ranking"].ToString()!="")
				{
					model.ranking=int.Parse(row["ranking"].ToString());
				}
				if(row["listeTime"]!=null && row["listeTime"].ToString()!="")
				{
					model.listeTime=DateTime.Parse(row["listeTime"].ToString());
				}
				if(row["proGrade"]!=null && row["proGrade"].ToString()!="")
				{
					model.proGrade=int.Parse(row["proGrade"].ToString());
				}
				if(row["proGradeName"]!=null)
				{
					model.proGradeName=row["proGradeName"].ToString();
				}
				if(row["proMaterial"]!=null && row["proMaterial"].ToString()!="")
				{
					model.proMaterial=int.Parse(row["proMaterial"].ToString());
				}
				if(row["proMaterialName"]!=null)
				{
					model.proMaterialName=row["proMaterialName"].ToString();
				}
				if(row["speed"]!=null && row["speed"].ToString()!="")
				{
					model.speed=int.Parse(row["speed"].ToString());
				}
				if(row["stopType"]!=null && row["stopType"].ToString()!="")
				{
					model.stopType=int.Parse(row["stopType"].ToString());
				}
				if(row["stopTypeName"]!=null)
				{
					model.stopTypeName=row["stopTypeName"].ToString();
				}
				if(row["proContent"]!=null)
				{
					model.proContent=row["proContent"].ToString();
				}
				if(row["proDesc"]!=null)
				{
					model.proDesc=row["proDesc"].ToString();
				}
				if(row["ImgDesc"]!=null)
				{
					model.ImgDesc=row["ImgDesc"].ToString();
				}
				if(row["propertyDesc"]!=null)
				{
					model.propertyDesc=row["propertyDesc"].ToString();
				}
				if(row["labelInfo"]!=null)
				{
					model.labelInfo=row["labelInfo"].ToString();
				}
				if(row["assessCount"]!=null && row["assessCount"].ToString()!="")
				{
					model.assessCount=int.Parse(row["assessCount"].ToString());
				}
				if(row["shareCount"]!=null && row["shareCount"].ToString()!="")
				{
					model.shareCount=int.Parse(row["shareCount"].ToString());
				}
				if(row["viewsCount"]!=null && row["viewsCount"].ToString()!="")
				{
					model.viewsCount=int.Parse(row["viewsCount"].ToString());
				}
				if(row["author"]!=null)
				{
					model.author=row["author"].ToString();
				}
				if(row["isTj"]!=null && row["isTj"].ToString()!="")
				{
					model.isTj=int.Parse(row["isTj"].ToString());
				}
				if(row["isHot"]!=null && row["isHot"].ToString()!="")
				{
					model.isHot=int.Parse(row["isHot"].ToString());
				}
				if(row["isNew"]!=null && row["isNew"].ToString()!="")
				{
					model.isNew=int.Parse(row["isNew"].ToString());
				}
				if(row["goodCount"]!=null && row["goodCount"].ToString()!="")
				{
					model.goodCount=int.Parse(row["goodCount"].ToString());
				}
				if(row["badCount"]!=null && row["badCount"].ToString()!="")
				{
					model.badCount=int.Parse(row["badCount"].ToString());
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
				if(row["addUserName"]!=null)
				{
					model.addUserName=row["addUserName"].ToString();
				}
				if(row["saveCount"]!=null && row["saveCount"].ToString()!="")
				{
					model.saveCount=int.Parse(row["saveCount"].ToString());
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
			strSql.Append("select id,proName,proNameEn,productType,productTypeName,proType,proTypeName,oneId,twoId,threeId,fourId,listImgUrl,detailImg1,detailImg2,detailImg3,detailImg4,creditImg1,creditImg2,creditImg3,creditImg4,fromImg,otherImg,fromId,fromName,fromDesc,brandId,brandName,varietyId,varietyName,relieveId,relieveName,cookId,cookName,useId,useName,unit1,price1,unit2,price2,unit3,price3,unit4,price4,advantage,saveInfo,rankingType,rankingTypeName,ranking,listeTime,proGrade,proGradeName,proMaterial,proMaterialName,speed,stopType,stopTypeName,proContent,proDesc,ImgDesc,propertyDesc,labelInfo,assessCount,shareCount,viewsCount,author,isTj,isHot,isNew,goodCount,badCount,status,remark,addTime,addUser,addUserName,saveCount,infoType ");
			strSql.Append(" FROM Product ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
            strSql.Append(" order by id desc");
			return DBHelperSQL.Query(strSql.ToString());
		}
        /// 获得数据列表
        /// </summary>
        public static DataSet GetListCommit(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,proName,proNameEn,productType,productTypeName,proType,proTypeName,oneId,twoId,threeId,fourId,listImgUrl,detailImg1,detailImg2,detailImg3,detailImg4,creditImg1,creditImg2,creditImg3,creditImg4,fromImg,otherImg,fromId,fromName,fromDesc,brandId,brandName,varietyId,varietyName,relieveId,relieveName,cookId,cookName,useId,useName,unit1,price1,unit2,price2,unit3,price3,unit4,price4,advantage,saveInfo,rankingType,rankingTypeName,ranking,listeTime,proGrade,proGradeName,proMaterial,proMaterialName,speed,stopType,stopTypeName,proContent,proDesc,ImgDesc,propertyDesc,labelInfo,assessCount,shareCount,viewsCount,author,isTj,isHot,isNew,goodCount,badCount,status,remark,addTime,addUser,addUserName,saveCount,infoType ");
            strSql.Append(" FROM Product ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DBHelperSQL.Query(strSql.ToString());
        }
        /// 获得数据列表
        /// </summary>
        public static DataSet GetListPrice(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,proName,proNameEn,productType,productTypeName,proType,proTypeName,oneId,twoId,threeId,fourId,listImgUrl,detailImg1,detailImg2,detailImg3,detailImg4,creditImg1,creditImg2,creditImg3,creditImg4,fromImg,otherImg,fromId,fromName,fromDesc,brandId,brandName,varietyId,varietyName,relieveId,relieveName,cookId,cookName,useId,useName,unit1,price1,unit2,price2,unit3,price3,unit4,price4,advantage,saveInfo,rankingType,rankingTypeName,ranking,listeTime,proGrade,proGradeName,proMaterial,proMaterialName,speed,stopType,stopTypeName,proContent,proDesc,ImgDesc,propertyDesc,labelInfo,assessCount,shareCount,viewsCount,author,isTj,isHot,isNew,goodCount,badCount,status,remark,addTime,addUser,addUserName,saveCount,infoType ");
            strSql.Append(" FROM Product ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
			strSql.Append(" id,proName,proNameEn,productType,productTypeName,proType,proTypeName,oneId,twoId,threeId,fourId,listImgUrl,detailImg1,detailImg2,detailImg3,detailImg4,creditImg1,creditImg2,creditImg3,creditImg4,fromImg,otherImg,fromId,fromName,fromDesc,brandId,brandName,varietyId,varietyName,relieveId,relieveName,cookId,cookName,useId,useName,unit1,price1,unit2,price2,unit3,price3,unit4,price4,advantage,saveInfo,rankingType,rankingTypeName,ranking,listeTime,proGrade,proGradeName,proMaterial,proMaterialName,speed,stopType,stopTypeName,proContent,proDesc,ImgDesc,propertyDesc,labelInfo,assessCount,shareCount,viewsCount,author,isTj,isHot,isNew,goodCount,badCount,status,remark,addTime,addUser,addUserName,saveCount,infoType ");
			strSql.Append(" FROM Product ");
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
			strSql.Append("select count(1) FROM Product ");
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
			strSql.Append(")AS Row, T.*  from Product T ");
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
			parameters[0].Value = "Product";
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

