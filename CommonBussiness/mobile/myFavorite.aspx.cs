﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using System.Data;
using DAL;

namespace CommonBussiness.mobile
{
    public partial class myFavorite : System.Web.UI.Page
    {
        protected int shopType = CRequest.GetInt("shopType", 0);
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                KeyWordBind();

                if (shopType != 0)
                {
                    if(shopType == 1)
                    {
                        ViewState["shopTypeName"] = "Restaurant";
                    }
                    else if (shopType == 2)
                    {
                        ViewState["shopTypeName"] = "Store";
                    }
                    else
                    {
                        ViewState["shopTypeName"] = "商家";
                    }
                    ViewState["shopType"] = shopType;
                }
                BindData();
                //UserInfo user = Session["user"] as UserInfo;
                //if (user == null)
                //{
                    
                //}
                
            }
        }
        #region###页面标题、关键字和描述信息
        /// <summary>
        /// 页面标题、关键字和描述信息
        /// </summary>
        private void KeyWordBind()
        {
            string url = Request.Url.ToString().Replace("aspx", "html");

            KeyWordInfo km = KeyWordInfoService.GetModel(url);
            if (km != null)
            {
                ViewState["title"] = km.title;
                ViewState["keyword"] = km.keyword;
                ViewState["miaoshu"] = km.description;
            }
            else
            {
                ViewState["title"] = BaseConfigService.GetById(9);
                ViewState["keyword"] = BaseConfigService.GetById(23);
                ViewState["miaoshu"] = BaseConfigService.GetById(13);
            }
        }
        #endregion
        /// <summary>
        /// 获取购物车中产品的Quantity
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        protected string GetProductCount(object id)
        {
            UserInfo user = Session["user"] as UserInfo;
            if (user == null)
            {
                List<CartTemp> cartlist = Session["nologinCart"] as List<CartTemp>;
                if (cartlist != null)
                {
                    if (cartlist.Count > 0)
                    {
                        foreach (CartTemp ct in cartlist)
                        {
                            if (ct.productId == Convert.ToInt32(id))
                            {
                                return ct.productCount.ToString();
                            }
                        }
                    }
                }
            }
            else
            {
                Session["nologinCart"] = null;
                CartTemp item = CartTempService.GetModelByProductId(user.id, Convert.ToInt32(id));
                if (item != null)
                {
                    return item.productCount.ToString();
                }
            }
            return "";
        }
        /// <summary>
        /// 获取类
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        protected string GetNumClass(object productId)
        {
            string str = GetProductCount(productId);
            if (str != "")
            {
                return "num";
            }
            return "num hideNum";

        }
        /// <summary>
        /// 移动端列表图片
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        protected string GetMobileImg(object productId)
        {
            ProductImgMobile item = ProductImgMobileService.GetModelByProductId(Convert.ToInt32(productId));
            if (item != null)
            {
                return item.imgUrl;
            }
            return "";
        }
        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindData()
        {
            UserInfo user = Session["user"] as UserInfo;
            if (user != null)
            {
                if(ViewState["shopType"] != null)
                {
                    DataSet ds = UserInfoService.GetList("shopType = " + ViewState["shopType"] + " and infoType = 2 and id in(select objId from UserFavoriteInfo where addUser = " + user.id + ")");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        repInfo.DataSource = ds;
                        repInfo.DataBind();
                    }
                    else
                    {
                        this.noList.Visible = true;
                    }
                }
                
            }
            else
            {
                Response.Redirect("login.html");
            }
        }
    }
}