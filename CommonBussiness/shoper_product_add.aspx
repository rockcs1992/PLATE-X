<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="shoper_product_add.aspx.cs" Inherits="CommonBussiness.shoper_product_add" %>
<%@ Register src="top.ascx" tagname="top" tagprefix="uc1" %>
<%@ Register src="bottom.ascx" tagname="bottom" tagprefix="uc2" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8" />
      <title><%= ViewState["title"] %></title>
    <meta name="keywords" content="<%= ViewState["keyword"] %>" />
    <meta name="description" content="<%= ViewState["miaoshu"] %>" /> 

    <meta name="renderer" content="webkit">

    <meta name="viewport" content="width=device-width">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <meta name="format-detection" content="telephone=no">
    <link rel="stylesheet" type="text/css" href="css/index.css" />
    <link rel="stylesheet" type="text/css" href="css/lanmu.css" />
    <link rel="stylesheet" type="text/css" href="css/jiesuan.css" />
        <link rel="stylesheet" type="text/css" href="css/jquery.datetimepicker.css" />

        <style type="text/css">
            .my_person_r .safty_btn{ margin:40px 160px;}
            .my_person_r dd select{ margin:0px; width:90px;}
            .my_person_r dt{ width:150px;    margin-right: 10px;
    text-align: right;}
            .my_person_r .safty_btn{}
        </style>

    <script type="text/javascript" src="js/jquery-1.8.3.js"></script>
    <script type="text/javascript" src="js/js.js"></script>
    <script type="text/javascript" src="js/js_menu.js"></script>

    
    <script type="text/javascript" src="js/jquery-1.11.3.min.js"></script>
    <script type="text/javascript" src="js/js_new.js"></script>
    <script src="js/user.js" type="text/javascript"></script>
<script  src="My97DatePicker/WdatePicker.js" type="text/javascript"></script>

</head>
<body style="position:static;">
<form id="form1" runat="server">
<div class="returnTop2"><img src="images/icon/returnTop.png" height="50" width="50" alt="" /></div>
<div class="returnTop"><img src="images/icon/returnTop.png" height="50" width="50" alt="" /></div>
    <!--head-->
    <uc1:top ID="top1" runat="server" />
    <!--orders-->
    <div class="blank_bg">
        <div class="overf">
            <div class="order wrap">
                <div class="orders">
                    <div class="orders_l">
                        <ul>
                            <li class="title"><i>My Plate-X</i></li>
                            
                            <li><a href="my_person.html" class="aa"><i>My Business Center</i><span></span></a></li>
                            <li><a href="saleOrder_0.html" class="aa"><i>New Orders</i><span></span></a></li>
                            <li><a href="saleOrder_1.html" class="aa"><i>Complete Orders</i><span></span></a></li>
                             <li><a href="saleOrder_100.html" class="aa"><i>Manage My Orders</i><span></span></a></li>
                              <li class="li_cur"><a href="shoper_product.html" class="aa"><i>Manage My Items</i><span></span></a></li>
                            <li><a href="orders_0.html" class="aa"><i> My Items</i><span></span></a></li>
                            <li><a href="my_shop.html" class="aa"><i>Past Orders</i><span></span></a></li>
                            <li><a href="/exit.html" class="aa"><i>Log Out</i><span></span></a></li>
                        </ul>
                    </div>
                    <div class="my_yuanX" style="min-height:800px;">
                      <div class="my_person">
                        <div class="my_balance_t">
                          <h2>Add Item</h2>
                        </div>
                          <div class="my_person_l">
                            <dl>
                              <dt><s id="headImgId"><img id="preview" src="<%=ViewState["headImg"] %>" style=" border:1px #ddd solid; border-radius:0;"/></s>
                              <span onclick="document.getElementById('filepic').click();" style="background:none;"></span></dt>
                              <dd><input type="button" value="Picture" onclick="document.getElementById('filepic').click();" class="file_style" /> 
                              <asp:FileUpload ID="filepic" runat="server" onchange="showImage(this,'headImgId');" style="display:none;" />  
                              </dd>
                            </dl>
                            <asp:HiddenField ID="hidImg" runat="server" />
                          </div>
                          <div class="my_person_r">
                            <dl class="pet_name">
                              <dt>Category</dt>
                              <dd>
                              <asp:DropDownList ID="ddlProductType" runat="server" style="width: 335px;height: 43px">
                                </asp:DropDownList>
                              </dd>
                            </dl>
                            <dl class="pet_name">
                              <dt>Item Name</dt>
                              <dd><asp:TextBox ID="proname" runat="server" CssClass="tel" placeholder=""  autocomplete="off"></asp:TextBox></dd>
                            </dl>
                            <dl class="pet_name">
                              <dt>Amount in Stock</dt>
                              <dd><asp:TextBox ID="storeCount" runat="server" CssClass="tel" placeholder="" autocomplete="off"></asp:TextBox></dd>
                            </dl>
                            <dl class="pet_name">
                              <dt>Unit</dt>
                              <dd><asp:TextBox ID="unit1" runat="server" CssClass="tel" placeholder="" autocomplete="off"></asp:TextBox></dd>
                            </dl>

                           <dl class="pet_name">
                              <dt>Price</dt>
                              <dd><asp:TextBox ID="price1" runat="server" CssClass="tel" placeholder="" autocomplete="off"></asp:TextBox></dd>                              
                            </dl>
                            <dl class="pet_name">
                              <dt>More About this Item</dt>
                              <dd><asp:TextBox ID="infoDesc" runat="server" CssClass="tel" placeholder="" TextMode="MultiLine" Height="300px" style=" border:1px solid #c3c8cc; width:335px;padding: 10px;" autocomplete="off"></asp:TextBox></dd>
                            </dl> 
                            <dl class="pet_name">
                              <dt></dt>
                              <dd style="float:none;"><div class="safty_btn" style="margin-top: 275px;" onclick="return saveProduct();">Save</div></dd>                              
                            </dl>
                              <asp:HiddenField ID="hidId" runat="server" /> 
                          </div>
                          
                      </div>
                    </div>
                </div>
            </div>
        </div>
    </div> 
    <uc2:bottom ID="bottom1" runat="server" />
    </form>
</body>
</html>
<script type="text/javascript">
    function showImage(file, id) {
        var ext = file.value.toLowerCase().split('.').splice(-1);
        var div = document.getElementById(id);
        if (file.files && file.files[0]) {
            div.innerHTML = "<img id='img_" + id + "' class='photo' >";
            var img = document.getElementById("img_" + id);
            img.onload = function () {
                img.width = "100";
                img.height = "100";
            }
            var reader = new FileReader();
            reader.onload = function (evt) {
                img.src = evt.target.result;
                document.getElementById("hidImg").value = img.src;
            }
            reader.readAsDataURL(file.files[0]);
        }
        else { //兼容IE

        }
    }
</script>
