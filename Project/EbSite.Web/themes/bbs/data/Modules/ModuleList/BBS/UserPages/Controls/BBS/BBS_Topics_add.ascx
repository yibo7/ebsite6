<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BBS_Topics_add.ascx.cs"
    Inherits="EbSite.Modules.BBS.UserPages.Controls.BBS.BBS_Topics_add" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<link type="text/css" href="/themes/bbs/data/Modules/ModuleList/BBS/DataStore/Attachments/img/CssBbs.css" rel="stylesheet" />
<asp:PlaceHolder ID="phCtrList" runat="server">
    <div id="mainX">
      
        <div id="mainby">
            <div id="main-middle">
                <div class="main-s-top">
                </div>
                <div class="main-s">
                    <div class="main-gg">
                        <span class="gg-bg"></span>发表新主题  <%=GetBkName%> 版块
                    </div>
                    <div class="gg-r">
                    </div>
                </div>
                <div class="main-s-down">
                </div>
                <div class="middle-div">
                    <div>
                        <XS:TextBoxVl ID="TopicTitle" runat="server" Width="500px"></XS:TextBoxVl>标题最多为60个字符.
                      
                    </div>
                    <div style="width: 100%; height: 300px; margin-left: 5px; margin-top: 5px;">
                        <XS:Editor ID="TopicContent" runat="server" EditorTools="简单模式" ExtImg="jpg,JPG,png,PNG,gif,GIF"
                            Width="95%" Height="300" />
                    </div>
                    <%-- <div id="divTP" runat="server">
                <div class="captionBd" style="height: 20px" align="left">
                    编辑帖子观点，让其他网友参与投票发表观点&nbsp;&nbsp;&nbsp;<input type="button" value="发表观点" onclick="zhanKai()" /><XS:CheckBox
                        ID="cb" runat="server" Style="display: none" />
                </div>
                <div style="display: none" id="divNr" align="center">
                    <asp:HiddenField ID="hf" runat="server" />
                    <table>
                        <tr>
                            <td>
                                观点选择:
                            </td>
                            <td>
                                <XS:RadioButtonList ID="gdxz" runat="server">
                                    <asp:ListItem Value="1" Text="单选"></asp:ListItem>
                                    <asp:ListItem Value="2" Text="多选"></asp:ListItem>
                                </XS:RadioButtonList>
                            </td>
                            <td>
                                <input type="button" onclick="addRow()" value="添加一行" /><input type="button" onclick="delRow()"
                                    value="删除一行" />
                                <div style="display: none">
                                    Row index:
                                    <input id="idIndex" />(<a id="idFirst">1</a>~<a id="idLast">1</a>)</div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <table id="idTB" border="0">
                                    <!--注意id，与JS中的要相对应-->
                                    <tr id="idTR">
                                        <td>
                                            观点1:<input type="text" name="txt" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>--%>
                    <div style="text-align: center; margin-top: 5px;">
                        <input id="ipSave"  runat="server" type="button" value="保 存" class="AdminButton" onclick="getValues()"
                            style="width: 70px; height: 35px" />
                        <XS:Button ID="bntSave" runat="server" Text=" 保 存 " Style=" width: 70px;
                            height: 35px;" />
                        <XS:Button ID="btnColseGreyBox" runat="server" Text=" 取 消 " Style="width: 70px; height: 35px" />
                    </div>
                    <%--  <script type="text/javascript">
                /*
                函数名称: Scroll
                Scroll(obj, h, s)
                参数说明:
                obj,[object]  id值或对象.     必需
                h,[height]  展开后的高度.   可选(默认为200px)
                s,[speed]   展开速度,值越小展开速度越慢. 可选(默认为1.2){建议取值为1.1到2.0之间[例如:1.17]}.
                函数返回值:
                true    展开(对象的高度等于展开后的高度)
                false   关闭(对象的高度等于原始高度)
                */
                function Scroll(obj, h, s) {
                    if (obj == undefined) { return false; }
                    var h = h || 0;
                    var s = s || 1.2;
                    var obj = typeof (obj) == "string" ? document.getElementById(obj) : obj;
                    var status = obj.getAttribute("status") == null;
                    var oh = parseInt(obj.offsetHeight);
                    obj.style.height = oh;
                    obj.style.display = "block";
                    obj.style.overflow = "hidden";
                    if (obj.getAttribute("oldHeight") == null) {
                        obj.setAttribute("oldHeight", oh);
                    } else {
                        var oldH = Math.ceil(obj.getAttribute("oldHeight"));
                    }
                    var reSet = function () {
                        if (status) {
                            if (oh < h) {
                                oh = Math.ceil(h - (h - oh) / s);
                                obj.style.height = oh + "px";
                            } else {
                                obj.setAttribute("status", false);
                                window.clearInterval(IntervalId);
                            }
                        } else {
                            obj.style.height = oldH + "px";
                            obj.removeAttribute("status");
                            window.clearInterval(IntervalId);
                        }
                    }
                    var IntervalId = window.setInterval(reSet, 10);
                    return status;
                }
                function zhanKai() {
                    var b = Scroll("<%=divTP.ClientID%>", 400, 1.2);
                    document.getElementById("divNr").style.display = "block";
                    if (b == false) {
                        document.getElementById("<%=cb.ClientID%>").checked = false;
                    } else if (b == true) {
                        document.getElementById("<%=cb.ClientID%>").checked = true;
                    }
                }

                function addRow() {//添加表格的一行
                    if (idTB.rows.length == 14) {
                        return
                    } else {
                        oTR = idTB.insertRow(idTB.rows.length);
                        tmpNum = oTR.rowIndex;
                        kk = tmpNum + 1;
                        oTD = oTR.insertCell(0);
                        //oTD.innerText = "第" + tmpNum + "行"; //在该处添加的HTML代码会原封不动的显示在页面上
                        oTD.innerHTML = "观点" + kk + ":<input type='text' name='txt'>"; //要在该格添加的HTML代码填在这里，因为这里是text，注意不要重名了。
                        idLast.innerText = idTB.rows.length;
                        if (idTB.rows.length > 0)
                            idFirst.innerText = '1';
                        return true;
                    }
                }
                function delRow() {//删除表格的一行
                    if (idTB.rows.length == 1) {
                        return;
                    } else {
                        sIndex = document.getElementById("idIndex").value;
                        if (sIndex == '')
                            sIndex = idTB.rows.length - 1;
                        else
                            sIndex = parseInt(sIndex) - 1;

                        idTB.deleteRow(sIndex);

                        idLast.innerText = idTB.rows.length;
                        if (idTB.rows.length == 0)
                            idFirst.innerText = '0';
                    }
                }

                function getValues() {
                    var ss = "<%=mm%>";
                    if (ss == 0) {
                        var ss = "";
                        var num = document.getElementsByName("txt");
                        for (var i = 0; i < num.length; i++) {
                            if (i < num.length - 1) {
                                ss += num[i].value + ",";
                            } else {
                                ss += num[i].value;
                            }
                        }
                        document.getElementById("<%=hf.ClientID%>").value = ss;
                    }
                    document.getElementById("<%=bntSave.ClientID%>").click();
                }

                function CloseBox() {
                    var jnum = '<%=num%>';
                    if (jnum == 1) {
                        setTimeout("ColseGreyBox()", 1000);
                    }
                }
                CloseBox();

            </script>--%>
                </div>
                <div class="main-lf-down">
                </div>
                <div class="main-lf-down-bg">
                </div>
                <div class="main-lf-down-rr">
                </div>
                <div id="main-down">
                    Copyright &copy;2005 - 2011 Tencent. All Rights Reserved 北京亿博科技 版权所有
                </div>
            </div>
        </div>
</asp:PlaceHolder>
<script>
    window.onLoad = new function () {
    var userid=<%=base.UserID%>;
                if(userid>0)
                {
                }
                else
                {
                  alert("没有登录 请先登录！");
                }
    }
    function getValues() {
        var sTitle=$("#<%=TopicTitle.ClientID%>").val();
        var sContent=$("#<%=TopicContent.ClientID%>").val();
        if ($.trim(sTitle) == "") {
            alert("标题没有添写！");
            $("#<%=TopicTitle.ClientID%>").focus().select();
        }
        if ($.trim(sContent) == "") {
            alert("内容没有添写！");
            $("#<%=TopicContent.ClientID%>").focus().select();
        }
       
          var pram = { "channelId": <%=GetBkId %>, "title": sTitle,"content":sContent};
                    runws("b3eef4b1-6c2c-4528-9e15-ad33716238ce", "IsTopiceAdd", pram, cp_ok);

    }
       function cp_ok(result)
        {
           
           if(result.d=="1")
           {
            alert("发帖成功！");
            //this.location.href='"&request.ServerVariables("HTTP_REFERER")&"';
            history.back();
           }
           else{
           }
           }
</script>
