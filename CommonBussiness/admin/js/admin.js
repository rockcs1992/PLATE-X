///
//资讯二级分类
function getTwoNewsType(id, name, obj) {
    if (obj.checked) {
        document.getElementById("txtTwo").value = name;
        document.getElementById("hidTwo").value = id;
    }
}

//资讯一级分类
function getOneNewsType(id, name,obj) {
    if (obj.checked) {
        document.getElementById("txtOne").value = name;     
        document.getElementById("hidOne").value = id;
    }
}

function overGoOnRemark(id, remark, lastStatus) {
    document.getElementById("wfullbg").style.display = "block";
    document.getElementById("layer").style.display = "block";
    document.getElementById("txtGoOnInfo").value = remark;
    document.getElementById("hidAdminId").value = id;
    document.getElementById("isGoOn").value = lastStatus;
}

function overCustomerDiv(id,relName,mobile,tel,qq,email,comName,comSite,canKao1,canKao2,canKao3,remark,lastStatus) {
    document.getElementById("wfullbg").style.display = "block";
    document.getElementById("layer").style.display = "block";

    document.getElementById("txtRealName").value = relName;
    document.getElementById("txtMobile").value = mobile;
    document.getElementById("txtTel").value = tel;
    document.getElementById("txtQQ").value = qq;

    document.getElementById("txtEmail").value = email;
    document.getElementById("txtComName").value = comName;
    document.getElementById("txtComSite").value = comSite;

    document.getElementById("txtCanKaoSite1").value = canKao1;
    document.getElementById("txtCanKaoSite2").value = canKao2;
    document.getElementById("txtCanKaoSite3").value = canKao3;
    document.getElementById("txtRemark").value = remark;

    document.getElementById("hidAdminId").value = id;
    document.getElementById("isGoOn").value = lastStatus;

}

///直接优惠输入验证
function checkYouHuiInput() {
    var youhui = document.getElementById("txtYouHui").value;
    if (youhui.length == 0) {
        alert('请输入优惠金额');
        return false;
    }
    if (isNaN(youhui)) {
        alert('优惠金额输入错误');
        return false;
    }
  }
 ///成员编辑输入认证
function checkMemEdit() {
    var txtMemName = document.getElementById("txtMemName").value;
    var txtMobile = document.getElementById("txtMobile").value;
    var txtBodyCode = document.getElementById("txtBodyCode").value;
    var ddlProvince = document.getElementById("ddlProvince").value;
    var ddlCity = document.getElementById("ddlCity").value;
    var ddlPeronsalType = document.getElementById("ddlPeronsalType").value;  
    if (txtMemName.length == 0 || txtMobile.length == 0 || txtBodyCode.length == 0) {
        alert('各项不能为空');
        return false;
    }
    if (ddlCity == "0" || ddlProvince == "0") {
        alert('请选择省市信息');
        return false;
    }
    if (ddlPeronsalType == "0") {
        alert('请选择户口类别');
        return false;
    }
    
 }

///保存更改后的促销金额
function updateCuXiao(id,shenhe,status) {
    var cxValue = document.getElementById("cx_" + id).value;
    var fromTime = document.getElementById("cxfrom_" + id).value;
    var endTime = document.getElementById("cxend_" + id).value;

    if (cxValue == "" || cxValue == "0" || isNaN(cxValue)) {
        alert('促销金额输入错误');
        return;
    }
    $.ajax({
        url: "/JsData/admin.aspx?action=UpdateCuXiaoValue&id=" + id + "&cxValue=" + cxValue + "&tfrom=" + escape(fromTime) + "&tend=" + escape(endTime) + "&time=" + new Date().getTime() + "",
        type: 'GET',
        success: function (msg) {
            if ($.trim(msg) == "success") {
                alert('修改成功');
                $("#cx_" + id).hide();
                $("#save_" + id).hide();
                $("#cxfrom_" + id).hide();
                $("#cxend_" + id).hide();
                $("#cxDate_" + id).html(fromTime + "至" + endTime);
                $("#cxprice_" + id).html(cxValue);
                $("#edit_" + id).show();
                var date = new Date();
                var now = "";
                if ((date.getMonth() + 1) < 10) {
                    now = date.getFullYear() + "-0"; //读英文就行了
                } else {
                    now = date.getFullYear() + "-"; //读英文就行了
                }
                if (date.getDate() < 10) {
                    now = now + (date.getMonth() + 1) + "-0"; //取月的时候取的是当前月-1如果想取当前月+1就可以了
                } else {
                    now = now + (date.getMonth() + 1) + "-"; //取月的时候取的是当前月-1如果想取当前月+1就可以了
                }
                now = now + date.getDate();
                //                alert(now + "\n" + endTime);
                //                alert(now > endTime);
                if (now > endTime) {
                    $("#statusInfo_" + id).html('已过期');
                } else {
                    if (shenhe == 1) {
                        $("#statusInfo_" + id).html('未进行');
                    } else {
                        if (status == 3) {
                            $("#statusInfo_" + id).html('暂停');
                        } else {
                            $("#statusInfo_" + id).html('促销中');
                        }
                    }
                }
            }
            else {
                alert('修改失败');
                $("#cx_" + id).hide();
                $("#save_" + id).hide();
                $("#cxfrom_" + id).hide();
                $("#cxend_" + id).hide();
                $("#cxDate_" + id).html(fromTime + "至" + endTime);
                $("#cxprice_" + id).html(cxValue);
                $("#edit_" + id).show();
            }

        }
    });
 }

///显示更改促销金额控件
 function showUpdateCuXiao(id) {   
    $("#cx_" + id).show();
    $("#save_" + id).show();
    $("#cxfrom_" + id).show();
    $("#cxend_" + id).show();
    $("#cxDate_" + id).html("");
    $("#cxprice_" + id).html("");
    $("#edit_" + id).hide();

  }


///添加资讯信息验证
function checkNewsInput() {
    var ddlOne = document.getElementById("ddlOne").value;
    var ddlTwo = document.getElementById("ddlTwo").value;
    var title = document.getElementById("txtTitle").value;
    var pageName = document.getElementById("txtZhaiYao").value;
    //var releaseTime = document.getElementById("txtReleaseTime").value; 
  
    if (ddlOne == "0" && ddlTwo == "0") {
        alert('请选择分类');
        return false;
    }
    if (title.length == 0 || (pageName.length == 0 && ddlOne != 22)) {
        alert('标题、内容和发布时间以及摘要信息不能为空！');
        return false;
    }
}
//地标信息
function getAddressInfo(id, name, obj) {
    if (obj.checked) {
        document.getElementById("txtSite").value = name;
        document.getElementById("hidSite").value = id.toString();
    }
}
//地铁站信息
function getStationInfo(id, name, obj) {
    if (obj.checked) {
        document.getElementById("txtSation").value = name;
        document.getElementById("hidStation").value = id.toString();
    }
}

//地铁线
function getSubwayInfo(id,pid,cid,name,obj) {
    if (obj.checked) {
        if (pid == 1 || pid == 2 || pid == 3 || pid == 4) {
            document.getElementById("ddlProvince").value = pid;
        } else {
            document.getElementById("ddlCity").value = cid;
        }
        document.getElementById("txtSubway").value = name;
        document.getElementById("hidSubway").value = id.toString();
    }
}
//一级分类
function getOneMenuInfo(id, name, obj) {
    if (obj.checked) {
        document.getElementById("txtOne").value = name;
        document.getElementById("hidOne").value = id;
    }
}
//一级分类
function getOneInfo(id,name,charInfo,obj) {
    if (obj.checked) {
        document.getElementById("txtOne").value = name;
        document.getElementById("txtChar").value = charInfo;
        document.getElementById("hidOne").value = id;
    }
}
//市级分类
function getCityInfo(id, name, cCh, obj) {
    if (obj.checked) {
        document.getElementById("txtCharCity").value = cCh;
        document.getElementById("txtTwo").value = name;
        document.getElementById("hidTwo").value = id;
    }
}

//商圈分类
function getRegionInfo(id, name, cCh, obj) {
    if (obj.checked) {
        document.getElementById("txtC").value = cCh;
        document.getElementById("txtRegion").value = name;
        document.getElementById("hidRegion").value = id;
    }
}
//二级分类
function getTwoInfo(id, name, obj,url) {
    if (obj.checked) {
        document.getElementById("txtURL").value = url;
        document.getElementById("txtTwo").value = name;
        document.getElementById("hidTwo").value = id;
    }
}

//添加管理员验证
function checkAdminLoginInput() {
    var name = document.getElementById("txtUserName").value;
    var pass = document.getElementById("txtPassWord").value;
    if (name.length == 0 || pass.length == 0) {
        alert('各项不能为空!');
        return false;
    }
 }
 ///回复信息验证
 function saveReply() {
     document.getElementById("wfullbg").style.display = "none";
    var content = $("#replyContent").val();
    if (content.length == 0) {
        alert('回复内容不能为空！');
        return;
    }
    var id = document.getElementById("selId").value;
    $.ajax({
        url: "/JsData/common.aspx?action=SaveReply&id=" + id + "&content=" + escape(content) + "&time=" + new Date().getTime() + "",
        type: 'GET',
        success: function (msg) {
            if ($.trim(msg) == "success") {
                alert('回复成功');
                $("#replyContent").val("");
                $("#selId").val("");                
                $("#layer").hide();
                location.href = '/admin/message.aspx';
            }
            else {
                alert('回复失败');
                $("#replyContent").val("");
                $("#selId").val("");  
                $("#layer").hide();
                location.href = '/admin/message.aspx';
            }

        }
    });
}

//添加管理员验证
function checkAdminInput() {
    var name = document.getElementById("txtUserName").value;
    var realName = document.getElementById("txtRealName").value;
    var pass1 = document.getElementById("txtPass").value;
    var pass2 = document.getElementById("txtPassAgain").value;
    if (name.length == 0 || realName.length == 0 || pass1.length == 0 || pass2.length == 0) {
        alert('各项不能为空');
        return false;
    }
    if(pass1.length < 6) {
        alert('密码不能少于6位');
        return false;
    }      
    if (pass1 != pass2) {
        alert('两次密码输入不一致');
        return false;    
    }

 }

//修改连接信息
 function saveModLink() {
     document.getElementById("wfullbg").style.display = "none";
     place = document.getElementById("place").value;
     name = document.getElementById("name").value;
    title = document.getElementById("title").value ;
    path = document.getElementById("url").value ;
    id = document.getElementById("hidLinkId").value;
    if (name.length == 0 || path.length == 0) {
        alert('名称和连接路径不能为空');
        return;
    }
    $.ajax({
        url: "/JsData/common.aspx?action=ModLink&id=" + id + "&place=" + place + "&name=" + escape(name) + "&title=" + escape(title) + "&path=" + escape(path) + "&time=" + new Date().getTime() + "",
        type: 'GET',
        success: function (msg) {
            if ($.trim(msg) == "success") {
                alert('修改成功');
                $("#name").val("");
                $("#title").val("");
                $("#url").val("");
                $("#hidLinkId").val("");
                $("#layer").hide();
                location.href = '/admin/link.aspx';
            }
            else {
                alert('修改失败');
                $("#name").val("");
                $("#title").val("");
                $("#url").val("");
                $("#hidLinkId").val("");
                $("#layer").hide();
                location.href = '/admin/link.aspx';
            }
            
        }
    });
 }

// 设置左侧菜单当前显示
 function dis_cont(url, id, roleId,count) {
    if(roleId != 2 && (url == "manager.aspx" || url == "infoType.aspx"))
    {
        alert('无操作权限');
        return;
    }
	document.getElementById("iframeid").src=url;

	 //count 是子菜单总数
	for (var i = 1; i <= count; i++) {
	    var curid = document.getElementById("m_" + i); //获取当前ID值
		if(i==id){
		curid.className="curstyle";	
		}else{			
		curid.className="";
		}
	}
}
//-------------------------弹窗--------

function overMoreMesDiv(num) {
    
    //获取选中的id
    $("#eamil").html("您共选择了" + num + "条记录");
    document.getElementById("layer").style.display = "block";
    $("#msgContent").hide();
}


//留言信息管理页面
function overMessageDiv(id, username, email, content) {
    document.getElementById("wfullbg").style.display = "block";
    document.getElementById("layer").style.display = "block";
    $("#realName").html(username);
    $("#eamil").html(email);
    $("#msgContent").html(content);
    $("#selId").val(id);
    $.ajax({
        url: "/JsData/common.aspx?action=UpdateMessageStatus&id=" + id + "&time=" + new Date().getTime() + "",
        type: 'GET',
        success: function (msg) {            
        }
    });

}
//管理员管理页面
function showAdminDiv() {
    document.getElementById("wfullbg").style.display = "block";
    document.getElementById("layer").style.display = "block";
    document.getElementById("hidAdminId").value = "";
}
function overAdminDiv(id, username, pass, realName, roleId) {
    document.getElementById("wfullbg").style.display = "block";
    document.getElementById("layer").style.display = "block";
    document.getElementById("txtUserName").value = username;
    document.getElementById("txtRealName").value = realName;
    document.getElementById("txtPass").value = pass;
    document.getElementById("txtPassAgain").value = pass;
    document.getElementById("hidAdminId").value = id;
    document.getElementById("ddlRole").value = roleId;

}
//关键字信息页面
function overKeyWordDiv() {
    document.getElementById("layer").style.display = "block";
    document.getElementById("wfullbg").style.display = "block";
}
//公告页面
function overGongGaoDiv(id, title, url, content) {

    document.getElementById("layer").style.display = "block";
    document.getElementById("wfullbg").style.display = "block";
    document.getElementById("name").value = name;
    document.getElementById("title").value = title;
    document.getElementById("url").value = url;
    var sel = document.getElementById("place");
    var len = sel.length;
    for (var i = 0; i < len; i++) {
        if (sel.options[i].value == place) {
            sel.options[i].selected = true;
            break;
        }
    }
    document.getElementById("hidLinkId").value = id;

}
//友情链接页面
function overDiv(place,id, name, title, url) {
    
    document.getElementById("layer").style.display = "block";
    document.getElementById("wfullbg").style.display = "block";
    document.getElementById("name").value = name;
    document.getElementById("title").value = title;
    document.getElementById("url").value = url;
    var sel =  document.getElementById("place");
    var len = sel.length;
    for (var i = 0; i < len; i++) {      
        if (sel.options[i].value == place) {            
            sel.options[i].selected = true; 
            break;  
        }
    }
    document.getElementById("hidLinkId").value = id;

}

    //隐藏div
function hideOver(){
    document.getElementById("layer").style.display = "none";
    document.getElementById("wfullbg").style.display = "none";
}
//用户评价
function overComment() {
    document.getElementById("layer").style.display = "block";
    document.getElementById("wfullbg").style.display = "block";
}
//停缴弹窗显示
function overTingJiao() {
    document.getElementById("layer").style.display = "block";
    document.getElementById("wfullbg").style.display = "block";
}
//停缴弹窗隐藏
function hideTingJiao() {
    document.getElementById("layer").style.display = "none";
    document.getElementById("wfullbg").style.display = "none";
}
//用户心语
function xinyuShow() {
    document.getElementById("tianjia").style.display = "block";
    document.getElementById("wfullbg").style.display = "block";
}
function xinyuHide() {
    document.getElementById("tianjia").style.display = "none";
    document.getElementById("wfullbg").style.display = "none";
}
//进度查询弹窗显示
function processShow() {
    document.getElementById("layerProcess").style.display = "block";
    document.getElementById("wfullbg").style.display = "block";
}
//进度查询弹窗隐藏
function processHide() {
    document.getElementById("layerProcess").style.display = "none";
    document.getElementById("wfullbg").style.display = "none";
}
//用户详情弹窗显示
function userDetailShow() {
    document.getElementById("layer").style.display = "block";
    document.getElementById("wfullbg").style.display = "block";
}
//用户详情弹窗隐藏
function userDetailHide() {
    document.getElementById("layer").style.display = "none";
    document.getElementById("wfullbg").style.display = "none";
}
//添加系统消息弹窗显示
function sysmShow() {
    document.getElementById("sys_add").style.display = "block";
    document.getElementById("wfullbg").style.display = "block";
}
//添加系统消息弹窗隐藏
function sysmHide() {
    document.getElementById("sys_add").style.display = "none";
    document.getElementById("wfullbg").style.display = "none";
}
//添加系统消息弹窗显示
function noticeShow() {
    document.getElementById("notice").style.display = "block";
    document.getElementById("wfullbg").style.display = "block";
}
//添加系统消息弹窗隐藏
function noticeHide() {
    document.getElementById("notice").style.display = "none";
    document.getElementById("wfullbg").style.display = "none";
}
//发票弹窗显示
function inShow() {
    document.getElementById("invoice").style.display = "block";
    document.getElementById("wfullbg").style.display = "block";
}
//发票弹窗隐藏
function inHide() {
    document.getElementById("invoice").style.display = "none";
    document.getElementById("wfullbg").style.display = "none";
}
//子会员户口补差弹窗显示
function memSonShow() {
    document.getElementById("memSon").style.display = "block";
    document.getElementById("wfullbg").style.display = "block";
}
//子会员户口补差弹窗隐藏
function memSonHide() {
    document.getElementById("memSon").style.display = "none";
    document.getElementById("wfullbg").style.display = "none";
}