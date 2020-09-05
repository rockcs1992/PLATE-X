﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="shopInfo_edit.aspx.cs" Inherits="CommonBussiness.shopInfo_edit" %>
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
        </style>

    <script type="text/javascript" src="js/jquery-1.8.3.js"></script>
    <script type="text/javascript" src="js/js.js"></script>
    <script type="text/javascript" src="js/js_menu.js"></script>

    
    <script type="text/javascript" src="js/jquery-1.11.3.min.js"></script>
    <script type="text/javascript" src="js/js_new.js"></script>
<script  src="My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="js/user.js" type="text/javascript"></script>
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
                            
                            <li class="li_cur"><a href="my_person.html" class="aa"><i>My Business Center</i><span></span></a></li>
                            <li><a href="saleOrder_0.html" class="aa"><i>New Orders</i><span></span></a></li>
                            <li><a href="saleOrder_1.html" class="aa"><i>Complete Orders</i><span></span></a></li>
                             <li><a href="saleOrder_100.html" class="aa"><i>Manage My Orders</i><span></span></a></li>
                              <li><a href="shoper_product.html" class="aa"><i>Manage My Items</i><span></span></a></li>
                            <li><a href="orders_0.html" class="aa"><i> My Items</i><span></span></a></li>
                            <li><a href="my_shop.html" class="aa"><i>Past Orders</i><span></span></a></li>
                            <li><a href="/exit.html" class="aa"><i>Log Out</i><span></span></a></li>
                        </ul>
                    </div>
                    <div class="my_yuanX">
                      <div class="my_person">
                        <div class="my_balance_t">
                          <h2>My Business Center</h2>
                        </div>
                          <div class="my_person_l">
                            <dl>
                              <dt><s id="headImgId"><img id="preview" src="<%=ViewState["headImg"] %>" alt="" /></s>
                              <span></span></dt>
                              <dd><input type="button" value="Upload Logo" onclick="document.getElementById('filepic').click();" class="file_style" /> 
                              <asp:FileUpload ID="filepic" runat="server" onchange="showImage(this,'headImgId');" style="display:none;" />  
                              </dd>
                            </dl>
                            <asp:HiddenField ID="hidImg" runat="server" />
                          </div>
                          <div class="my_person_r">
                            <dl class="sex">
                              <dt>I am a</dt>
                              <dd>
                                <ul class="_sex">
                                  <%=ViewState["sex"] %>
                                </ul>
                              </dd>
                            </dl>
                            <dl class="pet_name">
                              <dt>Phone</dt>
                              <dd><input type="text" id="mobile" value="<%=ViewState["mobile"] %>" readonly="readonly" /></dd>
                            </dl>
                            <dl class="pet_name">
                              <dt>First Name</dt>
                              <dd><input type="text" id="realname" value="<%=ViewState["realname"] %>" /></dd>
                            </dl>
                            
                            <dl class="pet_name">
                              <dt>Last Name</dt>
                              <dd><input type="text" id="surname" value="<%=ViewState["surname"] %>" /></dd>
                            </dl>
                            
                            <input type="hidden" id="sexValue" value="<%=ViewState["sexValue"] %>" />
                           <dl class="pet_name">
                              <dt>Item Name</dt>
                              <dd><input type="text" id="shopName" value="<%=ViewState["shopName"] %>" /></dd>                              
                            </dl>
                            <dl class="pet_name">
                              <dt>Street 1</dt>
                              <dd><input type="text" id="street" value="<%=ViewState["street"] %>"/></dd>
                            </dl>   
                            <dl class="pet_name">
                              <dt>Street 2</dt>
                              <dd><input type="text" id="street2" value="<%=ViewState["street2"] %>"/></dd>
                            </dl>    
                            <dl class="pet_name">
                              <dt>City</dt>
                              <dd><input type="text" id="city" value="<%=ViewState["city"] %>" /></dd>
                            </dl>  
                            <dl class="pet_name">
                              <dt>State</dt>
                              <dd><input type="text" id="province" value="<%=ViewState["province"] %>" /></dd>
                            </dl>       
                            <dl class="pet_name">
                              <dt>Email</dt>
                              <dd><input type="text" id="email" value="<%=ViewState["email"] %>" /></dd>
                            </dl>
                            <dl class="pet_name">
                              <dt>Introduction</dt>
                              <dd><input type="text" id="remark" value="<%=ViewState["remark"] %>" /></dd>
                            </dl>                  
                            <div class="safty_btn" onclick="return saveBaseShop();">Save</div>
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
