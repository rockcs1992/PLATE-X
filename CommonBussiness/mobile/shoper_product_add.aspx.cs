using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using DAL;
using System.Text;
using System.Net;
using System.IO;
using Aliyun.Acs.Core.Profile;
using Aliyun.Acs.Core;
using Aliyun.Acs.Dysmsapi.Model.V20170525;

using Aliyun.Acs.Core.Exceptions;
using System.Data;

namespace CommonBussiness.mobile
{
    public partial class shoper_product_add : System.Web.UI.Page
    {
        protected int id = CRequest.GetInt("id",0);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                KeyWordBind();

                //产品I am a
                DataSet ds = ProductTypeService.GetList("parentId = 0");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    this.ddlProductType.DataSource = ds;
                    ddlProductType.DataTextField = "typeName";
                    ddlProductType.DataValueField = "id";
                    ddlProductType.DataBind();
                }
                ddlProductType.Items.Insert(0, new ListItem("Category", "0"));

                ViewState["imgUrl"] = "images/product_default.png";
                UserInfo user = Session["user"] as UserInfo;
                if (user != null)
                {
                    if(id != 0)
                    {
                        this.hidId.Value = id.ToString();
                        ViewState["id"] = id;
                        Product p = ProductService.GetModel(id);
                        if(p != null)
                        {
                            ViewState["modItem"] = p;
                            if(p.listImgUrl != "")
                            {
                                ViewState["imgUrl"] = p.listImgUrl;
                            }
                            proname.Text = p.proName;
                            ddlProductType.SelectedValue = p.productType.ToString();
                            storeCount.Text = p.proType.ToString();
                            unit1.Text = p.unit1;
                            price1.Text = p.price1.ToString("0.00");
                            infoDesc.Text = p.advantage;
                        }
                    }

                    
                }
                else
                {
                    Response.Redirect("login.html");
                }
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
        /// Upload图片
        /// </summary>
        private string UploadImg(string imgstr)
        {
            string path = "";
            try
            {
                var imgData = imgstr.Replace("data:image/png;base64,", "").Replace("data:image/jpg;base64,", "").Replace("data:image/jpeg;base64,", "");
                //过滤特殊字符即可   
                string dummyData = imgData.Trim().Replace("%", "").Replace(",", "").Replace(" ", "+");
                if (dummyData.Length % 4 > 0)
                {
                    dummyData = dummyData.PadRight(dummyData.Length + 4 - dummyData.Length % 4, '=');
                }
                byte[] imageBytes = Convert.FromBase64String(dummyData);
                //读入MemoryStream对象  
                MemoryStream memoryStream = new MemoryStream(imageBytes, 0, imageBytes.Length);
                memoryStream.Write(imageBytes, 0, imageBytes.Length);
                //二进制转成图片Save  
                System.Drawing.Image image = System.Drawing.Image.FromStream(memoryStream);
                path = Global_Upload.ShoperResImgPath + DateTime.Now.ToString("yyyyMMddHHmmssff") + ".jpg";
                if (!Directory.Exists(Server.MapPath(Global_Upload.ShoperResImgPath)))//判断目录是否存在
                {
                    Directory.CreateDirectory(Server.MapPath(Global_Upload.ShoperResImgPath));//创建目录
                }
                image.Save(Server.MapPath(path));

            }
            catch (Exception je)
            {
                Response.Write(je.Message);
            }
            return path;
        }

        /// <summary>
        /// Save信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            UserInfo user = Session["user"] as UserInfo;
            if (user == null)
            {
                return;
            }
            Product item = new Product();
            if (this.hidId.Value != "")
            {
                if (ViewState["modItem"] != null)
                {
                    item = ViewState["modItem"] as Product;
                    if (item != null)
                    {
                        item.proName = proname.Text.Trim();
                        item.productType = Convert.ToInt32(ddlProductType.SelectedValue);
                        item.productTypeName = ddlProductType.SelectedItem.Text;
                        item.proType = 0;
                        if (storeCount.Text.Trim() != "")
                        {
                            if (RegExp.IsNumeric(storeCount.Text.Trim()))
                            {
                                item.proType = Convert.ToInt32(storeCount.Text.Trim());
                            }
                        }
                        item.oneId = Convert.ToInt32(ddlProductType.SelectedValue);
                        item.listImgUrl = "";
                        if (this.hidImg.Value != "" && this.hidImg.Value.IndexOf("data") != -1)
                        {
                            item.listImgUrl = UploadImg(hidImg.Value);
                        }
                        item.unit1 = unit1.Text.Trim();
                        item.price1 = 0;
                        if (price1.Text.Trim() != "")
                        {
                            item.price1 = Convert.ToDouble(price1.Text.Trim());
                        }
                        item.advantage = infoDesc.Text.Trim();
                        if (ProductService.Update(item))
                        {
                            ScriptManager.RegisterStartupScript(btnAdd, GetType(), "", "alert('Saved succesfully');location.href='shoper_product.html'", true);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(btnAdd, GetType(), "", "alert('Failed to save');", true);
                        }
                    }
                }
            }
            else
            {
                #region 新增
                item.proName = proname.Text.Trim();
               
                item.proNameEn = "";
                item.productType = Convert.ToInt32(ddlProductType.SelectedValue);
                item.productTypeName = ddlProductType.SelectedItem.Text;

                item.proType = 0;
                if (storeCount.Text.Trim() != "")
                {
                    if (RegExp.IsNumeric(storeCount.Text.Trim()))
                    {
                        item.proType = Convert.ToInt32(storeCount.Text.Trim());
                    }
                }
                item.proTypeName = "";

                item.oneId = Convert.ToInt32(ddlProductType.SelectedValue);
                item.twoId = 0;
                item.threeId = 0;
                item.fourId = 0;
                if (item.twoId != 0)
                {
                    item.productType = item.twoId;
                }
                if (item.threeId != 0)
                {
                    item.productType = item.threeId;
                }


                item.listImgUrl = "";
                if(this.hidImg.Value != "")
                {
                    item.listImgUrl = UploadImg(hidImg.Value);
                }
                item.detailImg1 = "";
                item.detailImg2 = "";
                item.detailImg3 = "";
                item.detailImg4 = "";

                item.creditImg1 = "";
                item.creditImg2 = "";
                item.creditImg3 = "";
                item.creditImg4 = "";

                item.fromImg = "";
                item.otherImg = "";
                item.fromId = 0;
                item.fromName = "";
                item.fromDesc = "";
                item.brandId = 0;
                item.brandName = "";

                item.varietyId = 0;
                item.varietyName = "";

                item.relieveId = 0;
                item.relieveName = "";
                item.cookId = 0;
                item.cookName = "";
                item.useId = user.id;
                item.useName = "";
                
                item.unit1 = unit1.Text.Trim();
                item.price1 = 0;
                if (price1.Text.Trim() != "")
                {
                    item.price1 = Convert.ToDouble(price1.Text.Trim());
                }
                item.unit2 = "";
                item.price2 = 0;
                item.unit3 = "";
                item.price3 = 0;
                item.unit4 = "";
                item.price4 = 0;

                item.advantage = infoDesc.Text.Trim();
                
                item.saveInfo = "";// saveInfo.Text.Trim();

                item.rankingType = 0;
                item.rankingTypeName = "";

                item.ranking = 0;

                item.listeTime = DateTime.Now;

                item.proGrade = 0;
                item.proGradeName = "";
                item.proMaterial = 0;
                item.proMaterialName = "";
                item.speed = 0;
                
                item.stopType = 0;
                item.stopTypeName = "";

                item.proContent = "";

                item.proDesc = "";
                item.ImgDesc = "";
                item.propertyDesc = "";

                item.labelInfo = "";
                item.remark = "";

                item.assessCount = 0;
                item.shareCount = 0;
                item.viewsCount = 0;


                item.author = "";
                item.isTj = 0;
                item.isHot = 0;
                item.isNew = 0;
                item.goodCount = 0;
                item.badCount = 0;
                item.status = 0;

                item.infoType = 0;
                item.addTime = DateTime.Now;
                item.addUser = user.id;
                item.addUserName = user.username;
                int maxId = ProductService.Add(item);
                if (maxId > 0)
                {
                    ScriptManager.RegisterStartupScript(btnAdd, GetType(), "", "alert('Saved succesfully');location.href='shoper_product.html'", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btnAdd, GetType(), "", "alert('Failed to save');", true);
                }
                #endregion
            }
        }
    }
}