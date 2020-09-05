using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DAL;
using Model;
using System.IO;
using System.Text;
using System.Net;
using System.Collections;

namespace CommonBussiness.admin
{
    public partial class addProduct : System.Web.UI.Page
    {
        static public ArrayList hif = new ArrayList(); // 保存文件列表
        public int filesUploaded = 0; // 上传文件的数量
        int userId = CRequest.GetInt("userId", 0);
        int id = CRequest.GetInt("id",0);
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (Session["loginUser"] == null)
                {
                    Response.Redirect("/admin/login.aspx");
                    return;
                }
                if (userId != 0)
                {
                    ViewState["userId"] = userId;
                }
                LoadOneCate();
                if(id != 0)
                {
                    LoadModelInfo();
                }
            }
        }

        /// <summary>
        /// 获取对象
        /// </summary>
        private void LoadModelInfo()
        {
            Product item = ProductService.GetModel(id);
            if(item != null)
            {
                txtTjOrder.Text = item.speed.ToString();
                txtStoreCount.Text = item.proType.ToString();
                txtMobileGood.Text = item.stopTypeName;
                ddlRelieve.SelectedValue = item.relieveId.ToString();
                ddlCook.SelectedValue = item.cookId.ToString();
                this.content2.Value = item.advantage;

                lblImgUrl.Text = item.listImgUrl;
                Label1.Text = item.detailImg1;
               
                txtFrom.Text = item.fromName;

                ddlOne.SelectedValue = item.oneId.ToString();

                txtProductName.Text = item.proName;
                content1.Value = item.proContent;
                content3.Value = item.ImgDesc;
                ddlTwo.Items.Clear();
                DataSet ds = ProductTypeService.GetList("parentId = " + ddlOne.SelectedValue);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddlTwo.DataSource = ds;
                    ddlTwo.DataTextField = "typeName";
                    ddlTwo.DataValueField = "id";
                    ddlTwo.DataBind();
                }
                ddlTwo.Items.Insert(0, new ListItem("请选择", "0"));
                ddlTwo.SelectedValue = item.twoId.ToString();

                ddlThree.Items.Clear();
                ds = ProductTypeService.GetList("parentId = " + ddlTwo.SelectedValue);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddlThree.DataSource = ds;
                    ddlThree.DataTextField = "typeName";
                    ddlThree.DataValueField = "id";
                    ddlThree.DataBind();
                }
                this.ddlThree.Items.Insert(0, new ListItem("请选择", "0"));
                ddlThree.SelectedValue = item.threeId.ToString();

                ddlVariety.SelectedValue = item.varietyId.ToString();
prodesc.Text = item.proDesc;
                unit1.Text = item.unit1;
                price1.Text = item.price1.ToString("0.00");

                ViewState["userId"] = item.useId;
            }
            
        }

        /// <summary>
        /// 身份证正面预览
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbUploadPhoto_Click(object sender, EventArgs e)
        {
            fileUpload(1);
        }

        //从控件上传文件
        public void fileUpload(int num)
        {
            string spic = "";
            if (num == 1)
            {
                if (filepic.PostedFile != null && filepic.PostedFile.FileName != "")
                {
                    if (!Directory.Exists(Server.MapPath(Global_Upload.ProductImgPath)))//判断目录是否存在
                    {
                        Directory.CreateDirectory(Server.MapPath(Global_Upload.ProductImgPath));//创建目录
                    }
                    spic = DoClass.UploadFile(filepic.PostedFile, Global_Upload.Imgsize, Global_Upload.ImgType, Global_Upload.ProductImgPath);

                    if (spic == "-1")
                    {
                        return;
                    }
                    else if (spic == "0")
                    {
                        return;
                    }
                    else
                    {
                        ViewState["img1Name"] = spic;
                        spic = Global_Upload.ProductImgPath + spic;
                        ViewState["productImg1"] = spic;
                        this.lblImgUrl.Text = spic;
                    }
                }
            }
        }

        /// <summary>
        /// 加载信息
        /// </summary>
        private void LoadOneCate() 
        {
            //产品类型
            DataSet ds = ProductTypeService.GetList("parentId = 0");
            if(ds.Tables[0].Rows.Count > 0)
            {
                this.ddlOne.DataSource = ds;
                ddlOne.DataTextField = "typeName";
                ddlOne.DataValueField = "id";
                ddlOne.DataBind();
            }
            ddlOne.Items.Insert(0, new ListItem("请选择", "0"));
            this.ddlTwo.Items.Insert(0, new ListItem("请选择", "0"));
            this.ddlThree.Items.Insert(0, new ListItem("请选择", "0"));

            ds = TypeInfoService.GetList("infoType = 1");
            if(ds.Tables[0].Rows.Count > 0)
            {
                ddlVariety.DataSource = ds;
                ddlVariety.DataTextField = "typeName";
                ddlVariety.DataValueField = "id";
                ddlVariety.DataBind();
            }
            ddlVariety.Items.Insert(0,new ListItem("请选择","0"));

            ds = TypeInfoService.GetList("infoType = 2");
            if (ds.Tables[0].Rows.Count > 0)
            {
                this.ddlRelieve.DataSource = ds;
                ddlRelieve.DataTextField = "typeName";
                ddlRelieve.DataValueField = "id";
                ddlRelieve.DataBind();
            }
            ddlRelieve.Items.Insert(0, new ListItem("请选择", "0"));


            ds = TypeInfoService.GetList("infoType = 3");
            if (ds.Tables[0].Rows.Count > 0)
            {
                this.ddlCook.DataSource = ds;
                ddlCook.DataTextField = "typeName";
                ddlCook.DataValueField = "id";
                ddlCook.DataBind();
            }
            ddlCook.Items.Insert(0, new ListItem("请选择", "0"));



        }
        /// <summary>
        /// 添加产品
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRelease_Click(object sender, EventArgs e)
        {
            string spic = "";
            #region 列表图片
            if (filepic.PostedFile != null && filepic.PostedFile.FileName != "")
            {
                if (!Directory.Exists(Server.MapPath(Global_Upload.ProductImgPath)))//判断目录是否存在
                {
                    Directory.CreateDirectory(Server.MapPath(Global_Upload.ProductImgPath));//创建目录
                }
                spic = DoClass.UploadFile(filepic.PostedFile, Global_Upload.Imgsize, Global_Upload.ImgType, Global_Upload.ProductImgPath);

                if (spic == "-1")
                {
                    return;
                }
                else if (spic == "0")
                {
                    return;
                }
                else
                {
                    //ViewState["img1Name"] = spic;
                    spic = Global_Upload.ProductImgPath + spic;
                    this.lblImgUrl.Text = spic;
                }
            }
            #endregion

            #region 产品详细图片1
            if (FileUpload1.PostedFile != null && FileUpload1.PostedFile.FileName != "")
            {
                if (!Directory.Exists(Server.MapPath(Global_Upload.ProductImgPath)))//判断目录是否存在
                {
                    Directory.CreateDirectory(Server.MapPath(Global_Upload.ProductImgPath));//创建目录
                }
                spic = DoClass.UploadFile(FileUpload1.PostedFile, Global_Upload.Imgsize, Global_Upload.ImgType, Global_Upload.ProductImgPath);

                if (spic == "-1")
                {
                    return;
                }
                else if (spic == "0")
                {
                    return;
                }
                else
                {
                    //ViewState["img1Name"] = spic;
                    spic = Global_Upload.ProductImgPath + spic;
                    this.Label1.Text = spic;
                }
            }
            #endregion
            
            #region 验证输入
            if (Session["loginUser"] == null)
            {
                Jscript.AlertAndRedirect("请登录", "/admin/login.aspx");
                return;
            }
           
            string productName = txtProductName.Text.Trim();
            
            if(productName.Length == 0)
            {
                lblError.Text = "产品名称不能为空";
                return;
            }
            if (this.lblImgUrl.Text.Trim().Length == 0)
            {
                lblError.Text = "请上传产品列表图片";
                return;
            }
            #endregion
            Product item = new Product();
            item.proName = productName;
            item.advantage = content2.Value.Trim();
            item.proNameEn = "";
            item.productType = Convert.ToInt32(ddlOne.SelectedValue);
            item.productTypeName = ddlOne.SelectedItem.Text;

            item.proType = 0;
            if(txtStoreCount.Text.Trim() != "")
            {
                if(RegExp.IsNumeric(txtStoreCount.Text.Trim()))
                {
                    item.proType = Convert.ToInt32(txtStoreCount.Text.Trim());
                }
            }
            item.proTypeName = "";

            item.oneId = Convert.ToInt32(ddlOne.SelectedValue);
            item.twoId = Convert.ToInt32(ddlTwo.SelectedValue);
            item.threeId = Convert.ToInt32(ddlThree.SelectedValue);
            item.fourId = 0;
            if(item.twoId != 0)
            {
                item.productType = item.twoId;
            }
            if(item.threeId != 0)
            {
                item.productType = item.threeId;
            }


            item.listImgUrl = lblImgUrl.Text;
            item.detailImg1 = Label1.Text;
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
            item.fromName = txtFrom.Text.Trim();
            item.fromDesc = "";
            item.brandId = 0;
            item.brandName = "";

            item.varietyId = Convert.ToInt32(ddlVariety.SelectedValue);
            item.varietyName = ddlVariety.SelectedItem.Text ;

            item.relieveId = Convert.ToInt32(ddlRelieve.SelectedValue);
            item.relieveName = ddlRelieve.SelectedItem.Text;
            item.cookId = Convert.ToInt32(ddlCook.SelectedValue);
            item.cookName = ddlCook.SelectedItem.Text;
            item.useId = 0;            
            item.useName = "";
            if (ViewState["userId"] != null)
            {
                item.useId = Convert.ToInt32(ViewState["userId"]);
            }
            item.unit1 = unit1.Text.Trim() ;
            item.price1 = 0;
            if(price1.Text.Trim() != "")
            {
                item.price1 = Convert.ToDouble(price1.Text.Trim());
            }
            item.unit2 = unit2.Text.Trim();
            item.price2 = 0;
            if (price2.Text.Trim() != "")
            {
                item.price2 = Convert.ToDouble(price2.Text.Trim());
            }
            item.unit3 = unit3.Text.Trim();
            item.price3 = 0;
            if (price3.Text.Trim() != "")
            {
                item.price3 = Convert.ToDouble(price3.Text.Trim());
            }
            item.unit4 = unit4.Text.Trim();
            item.price4 = 0;
            if (price4.Text.Trim() != "")
            {
                item.price4 = Convert.ToDouble(price4.Text.Trim());
            }

            item.advantage = content2.Value.Trim();// advantage.Text.Trim();
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
            if (txtTjOrder.Text.Trim() != "")
            {
                if(RegExp.IsNumeric(txtTjOrder.Text.Trim()))
                {
                    item.speed = Convert.ToInt32(txtTjOrder.Text.Trim());
                }
            }
            item.stopType = 0;
            item.stopTypeName = txtMobileGood.Text.Trim();

            item.proContent = content1.Value.Trim();

            item.proDesc = prodesc.Text.Trim();
            item.ImgDesc = content3.Value.Trim();
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
            item.addUser = 0;
            item.addUserName = "";
            AdminUser admin = Session["loginUser"] as AdminUser;
            if(admin != null)
            {
                item.author = admin.username;
                item.addUserName = admin.realName;
                item.addUser = admin.id;
            }
            if (id != 0)
            {
                #region 修改
                item.id = id;
                ViewState["maxId"] = id;

                if (ProductService.Update(item))
                {
                    ScriptManager.RegisterStartupScript(this.btnRelease, GetType(), "", "alert('保存成功');location.href='productList.aspx?userId=" + ViewState["userId"] + "';", true);
                }
                
                #endregion
            }
            else
            {
                #region 添加
                int maxId = ProductService.Add(item);
                if (maxId > 0)
                {
                    ScriptManager.RegisterStartupScript(this.btnRelease, GetType(), "", "alert('保存成功');location.href='productList.aspx?userId=" + ViewState["userId"] + "';", true);
                }
                else
                {
                    lblError.Text = "保存失败";
                }
                #endregion
            }
            
        }
        /// <summary>
        /// 一级下拉时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlOne_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlTwo.Items.Clear();
            DataSet ds = ProductTypeService.GetList("parentId = " + ddlOne.SelectedValue);
            if(ds.Tables[0].Rows.Count > 0)
            {
                ddlTwo.DataSource = ds;
                ddlTwo.DataTextField = "typeName";
                ddlTwo.DataValueField = "id";
                ddlTwo.DataBind();
            }
            ddlTwo.Items.Insert(0,new ListItem("请选择","0"));
        }
        /// <summary>
        /// 二级下拉
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlTwo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlThree.Items.Clear();
            DataSet ds = ProductTypeService.GetList("parentId = " + ddlTwo.SelectedValue);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlThree.DataSource = ds;
                ddlThree.DataTextField = "typeName";
                ddlThree.DataValueField = "id";
                ddlThree.DataBind();
            }
            this.ddlThree.Items.Insert(0, new ListItem("请选择", "0"));
        }
    }
}