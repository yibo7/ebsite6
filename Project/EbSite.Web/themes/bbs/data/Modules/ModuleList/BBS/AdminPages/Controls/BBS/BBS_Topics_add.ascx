<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BBS_Topics_add.ascx.cs"
    Inherits="EbSite.Modules.BBS.AdminPages.Controls.BBS.BBS_Topics_add" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<asp:PlaceHolder ID="phCtrList" runat="server">
    <div class="admin_toobar">
        <fieldset>
            <div>
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            主题：
                        </td>
                        <td>
                            <XS:TextBoxVl  ID="TopicTitle" runat="server" IsAllowNull="false" Width="500px"></XS:TextBoxVl >
                        </td>
                        <td>
                            <XS:CheckBox ID="cbBTJC" runat="server" Text="标题加粗" />
                        </td>
                        <td>
                            <XS:CheckBox ID="cbBTBS" runat="server" Text="标题变色" />
                        </td>
                        <td>
                      
                            <XS:ColorPicker ID="cpYS" Width="50" runat="server" />
                        </td>
                    </tr>
                   
                    <tr>
                        <td>
                            内容：
                        </td>
                        <td style="width: 600px; height: 300px" colspan="4">
                            <XS:Editor ID="TopicContent" runat="server"  EditorTools="全功能模式" ExtImg="jpg,JPG,png,PNG,gif,GIF" Width="600" Height="300"/>
                        </td>
                    </tr>
                </table>
            </div>
        </fieldset>
    </div>
</asp:PlaceHolder>
<div id="divTP" runat="server">
    <div class="captionBd" style="height: 20px" align="left">
        编辑帖子观点，让其他网友参与投票发表观点&nbsp;&nbsp;&nbsp;<input type="button" value="发表观点" onclick="zhanKai()" /><XS:CheckBox ID="cb" runat="server" style="display:none"/>
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
                    <div style="display:none">Row index: <input id="idIndex"/>(<a id="idFirst">1</a>~<a id="idLast">1</a>)</div>                 
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
</div>
<div style="text-align: center">
<input id="fsd" value="保 存" class="AdminButton" onclick="getValues()" style="width:50px;height:25px"/>
    <XS:Button ID="bntSave" runat="server" Text=" 保 存 " style="display:none;width:50px;height:25px"/>
    <XS:Button ID="btnColseGreyBox" runat="server" Text=" 取 消 " style="width:50px;height:25px"/>
</div>
<script type="text/javascript">
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
        if (b==false) {
            document.getElementById("<%=cb.ClientID%>").checked = false;
        } else if (b==true) {
            document.getElementById("<%=cb.ClientID%>").checked =true;
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
            sIndex =document.getElementById("idIndex").value;
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
        if(jnum==1) {
            setTimeout("ColseGreyBox()", 1000);            
        }
    }
    CloseBox();

</script>
