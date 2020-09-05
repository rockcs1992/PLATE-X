<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="invite.aspx.cs" Inherits="CommonBussiness.invite" %>

<%@ Register src="top.ascx" tagname="top" tagprefix="uc1" %>
<%@ Register src="bottom.ascx" tagname="bottom" tagprefix="uc2" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8"/>
       <title><%= ViewState["title"] %></title>
    <meta name="keywords" content="<%= ViewState["keyword"] %>" />
    <meta name="description" content="<%= ViewState["miaoshu"] %>" /> 


    <meta name="renderer" content="webkit">

    <meta name="viewport" content="width=device-width">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <meta name="format-detection" content="telephone=no">
    <meta http-equiv="X-UA-Compatible" content="IE=Edge;chrome=1"/>
    <link rel="stylesheet" type="text/css" href="css/index.css"/>
    <link rel="stylesheet" type="text/css" href="css/list.css"/>
    <link rel="stylesheet" type="text/css" href="css/project.css"/>
    <link rel="stylesheet" href="css/pygments.css"/>
    <link rel="stylesheet" href="css/easyzoom.css"/>
    <script type="text/javascript" src="js/jquery-1.8.3.js"></script>
    <script type="text/javascript" src="js/js.js"></script>
    <script type="text/javascript" src="js/js_menu.js"></script>
    <script type="text/javascript" src="js/jquery-1.11.2.min.js"></script>
    <script type="text/javascript" src="js/easyzoom.js"></script>
    <!--
    EasyZoom by Matt Hinchliffe <http://maketea.co.uk>
    Find out more at GitHub <http://github.com/i-like-robots/EasyZoom>
    -->
    <script type="text/javascript">
        /*project_list*/
        $(function () {
            var h = $("html,body").height();
            $('.renz').height(h);
        });
    </script>
    <script src="js/order.js" type="text/javascript"></script>
    <style type="text/css">
      .sdCloseBtn {
    position: absolute;
    right: -68px;
    top: 0;
    width: 68px;
    height: 68px;
    background: #e00025 url(../images/dialog_close.png) no-repeat center center;
}
/*招聘页开始*/
.joinBody{width: 1000px; margin: 37px auto 0; background: #ffffff; }
.joWrap{ }
.joList{margin: 0 0 8px; border-bottom: 1px dotted #848484; padding: 10px 40px 58px; }
.joList.noBottomBorder{border-bottom: none; }
.joName{padding: 0 0 10px; color: #000000; font-size: 18px; line-height: 28px; font-weight: bold;}
.joContent{line-height: 24px; color: #535353; }
.jocTitle{line-height: 28px; color: #000000; font-size: 14px; }
.jocIntro{padding: 0px 0 0px; }
.joSendBtn{display: block; position: relative; margin: 6px 0 0; width: 122px; height: 34px; overflow: hidden; line-height: 34px; text-align: center; }
.josbLink,
.josbHover{position: absolute; top: 0; left: 0; width: 122px; height: 34px; background: url(../images/join_btn.png) no-repeat center top; }
.josbLink{z-index: 1; background-position: center top; color: #3f3f3f; }
/*.joSendBtn:hover .josbLink{display: none; }*/
.josbHover{z-index: 0; background-position: center bottom; color: #ffffff; }
p{ line-height:28px;}


.catwTip {
    color: #cf0000;
}

/*body{overflow: hidden; }*/
.joinDialog{position: fixed; z-index: 1001; left: 50%; top: -606px; width: 1000px; height: 565px; box-shadow: 5px 5px 5px rgba(0,0,0,0.3), -5px -5px 5px rgba(0,0,0,0.3); margin: -303px 0 0 -500px; background: #ffffff; }
.jfWrap{width: 420px; margin: 0 auto; padding: 53px 0 0; }
.jfWrap input,
.jfWrap textarea{border: 1px solid #989898; font-size: 14px; line-height: 38px; }
.jfWrap input{height: 38px; }
.jfiName{padding: 0 0 18px; }
.jfiName input{width: 380px; padding: 0 4px; }
.jfiSex{padding: 0 0 18px; }
.jfiSex input{width: 177px; margin: 0 17px 0 0; padding: 0 4px; }
.jfiPosi{padding: 0 0 18px; }
.jfiPosi input{width: 177px; margin: 0 17px 0 0; padding: 0 4px; }
.jfIntro{padding: 0 0 18px; }
.jfIntro textarea{width: 381px; height: 178px; padding: 0 4px; line-height: 24px; }
.jfBtn .jfSubmit,
.jfBtn .jfCancel{position: relative; float: left; width: 186px; height: 41px; margin: 0 19px 0 0; }
.jfBtn input{position: absolute; width: 186px; height: 41px; border: none; background: url(../images/join_form.png) no-repeat center bottom;}
.jfBtn .jfBtnLink{z-index: 9; background-position: center bottom; }
.jfBtn .jfBtnHover{z-index: 0; background-position: center top; color: #ffffff; }
/*.jfBtn .jfSubmit:hover .jfBtnLink,
.jfBtn .jfCancel:hover .jfBtnLink{display: none; }
.jfBtn .jfSubmit:hover .jfBtnHover,
.jfBtn .jfCancel:hover .jfBtnHover{display: block; }*/
/*招聘页结束*/
    </style>
    	<script type="text/javascript" src="js/TweenMax.min.js"></script>
	<script type="text/javascript" src="js/page.js"></script>
</head>
<body>
<form id="form1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<div class="returnTop2"><img src="images/icon/returnTop.png" height="50" width="50" alt="" /></div>
<div class="returnTop"><img src="images/icon/returnTop.png" height="50" width="50" alt="" /></div>
<!--head-->

<uc1:top ID="top1" runat="server" />
<!--project-->
<div class="returnTop"><img src="images/icon/returnTop.png" height="50" width="50" alt=""/></div>
<div class="proList_bg">   
    
    <div class="QC_main wrap" id="NUMOne">       
        <h1 style="text-align:center; font-weight:bold; font-size:36px; margin:20px;">We are hiring</h1>    
        <div class="header_bg"></div>
	    <div class="joinBody">
		    <ul id="joWrap" class="joWrap">
                <asp:Repeater ID="repInfo" runat="server">
                    <ItemTemplate>
                        <li class="joList">
				            <h4 class="joName" style="display:inline-block;"><%#Eval("inviteName") %></h4><h4 style=" display:inline-block;font-weight: bold;font-size: 18px;margin-left: 10%;"><%#Eval("inviteType") %> digits</h4>
				            <h4 class="joId" style="display:none;"><%#Eval("id") %></h4>
                            <dl class="joContent">
					            <dt class="jocTitle">Requirements：</dt>
					            <dd clas="jocIntro">
                                <%#Eval("inviteInfo") %>
                                </dd>
				            </dl>
				            <dl class="joContent">
					            <dt class="jocTitle">Job description：</dt>
					            <dd class="jocIntro">
                                <%#Eval("inviteDesc") %>
                                </dd>
				            </dl>
				            <a class="joSendBtn" href="javascript:void(0);" data-name="<%#Eval("inviteName") %>">
					            <span class="josbLink"> Apply </span>
					            <span class="josbHover"> Apply </span>
				            </a>
			            </li>
                    </ItemTemplate>
                </asp:Repeater>
		    </ul>
	    </div>
	    <div id="joinDialog" class="joinDialog">
		    <a class="sdCloseBtn" href="javascript:void(0);"></a>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
			    <div class="jfWrap"><span class='catwTip' style="font-weight:bold;font-size: 16px;"><%=ViewState["errorInfo"] %></span>
				    <div class="jfiName">
                        <asp:TextBox ID="txtName" runat="server" placeholder="Enter name"></asp:TextBox></div>
				    <div class="jfiSex">
                        <asp:TextBox ID="txtMobile" runat="server" placeholder="Enter mobile" ></asp:TextBox>
                        <asp:TextBox ID="txtQQ" runat="server" placeholder="QQ" ></asp:TextBox>
                        </div>
				    <div class="jfiPosi"><asp:TextBox ID="txtInviteName" runat="server" placeholder="" CssClass="jobNameInput" ></asp:TextBox>
                    <asp:TextBox ID="txtWorkYears" runat="server" placeholder="Dedication to work"></asp:TextBox>
                    </div>
				    <div class="jfIntro">
                    <asp:TextBox ID="txtSelInfo" runat="server" TextMode="MultiLine" placeholder="introduce oneself to"></asp:TextBox>
                   </div>
				    <div id="jfBtn" class="jfBtn">
                    <span class="jfSubmit">
                         <asp:Button ID="Button1" runat="server" Text="Apply" CssClass="jfBtnLink" 
                            onclick="Button1_Click" />
                            <asp:Button ID="Button2" runat="server" Text="Apply" CssClass="jfBtnHover" 
                            onclick="Button1_Click" />						
					    </span>
					    <span class="jfCancel">
						    <input class="jfBtnLink" type="button" value="Cancel" />
						    <input class="jfBtnHover" type="button" value="Cancel" />
					    </span><br />
                         
                     </div>
			    </div>	
                <asp:HiddenField ID="hidInviteId" runat="server" />
            </ContentTemplate>
            </asp:UpdatePanel>
	    </div>
	    <div id="mask" class="mask"></div>
    </div>
    
</div>


<!--foot-->
 <uc2:bottom ID="bottom1" runat="server" />

<img src="images/icon/list_a.png" alt="" class="renz_close"/>
<img src="images/list_3.jpg" alt="" class="yx_renz2"/>
<img src="images/icon/list_a.png" alt="" class="renz_close2"/>
<div class="show_bg" style="display:none;background-color:#000;opacity:0.4;position:absolute;width:100%;top:0;left:0;z-index:9999;"></div>

<script type="text/javascript">
    var h = $('html,body').height() - 120;
    $('.show_bg').height(h);
</script>
<script type="text/javascript">
    // Instantiate EasyZoom plugin
    var $easyzoom = $('.easyzoom').easyZoom();

    // Get the instance API
    //    var api = $easyzoom.data('easyZoom');
    //    $('.yx_renz').hover(
    //            function(){
    //                var top=$('body').scrollTop();
    //                $(window).scroll(function(){ //滚动时，固定页面滚动条到页顶的高度，使其不滚动
    //                    $('body').scrollTop(top);
    //                });
    //            },function(){
    //                $(window).off('scroll');	//鼠标移开后，解除固定
    //            });

    
</script>
</form>
</body>
</html>

