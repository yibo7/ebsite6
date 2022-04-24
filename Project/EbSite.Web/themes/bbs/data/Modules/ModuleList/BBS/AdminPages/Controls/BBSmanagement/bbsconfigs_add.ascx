<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="bbsconfigs_add.ascx.cs" Inherits="EbSite.Modules.BBS.AdminPages.Controls.BBSmanagement.bbsconfigs_add" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<asp:PlaceHolder ID="phCtrList" runat="server">
    <div class="admin_toobar">
        <fieldset>
            <legend>添加/修改版块</legend>
            <div>
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            版块名称：
                        </td>
                        <td>
                            <XS:TextBoxVl  ID="ChannelName" runat="server" IsAllowNull="false"></XS:TextBoxVl >
                        </td>
                    </tr>
                    <tr>
                        <td>
                            版标：
                        </td>
                        <td>
                             <XS:SWFUploadMore ID="txUp" runat="server" AllowSize="50" AllowExt="jpg,png,gif"/><font style="color:Red">文件大小不能超过50k</font>
                        </td>
                    </tr>
                    <tr>
                    <td>
                    </td>
                        <td>
                        <div id="divImg" runat="server">
                        <img id="imgTu" height="180" width="250" runat="server" alt="" onerror="this.src='../DataStore/Attachments/images/noimg.gif';"/>
                        </div>                        
                        </td>
                    </tr>
                   <%--  <tr>
                        <td>
                            排序：
                        </td>
                        <td>
                            <XS:TextBoxVl  ID="OrderFlag" runat="server" IsAllowNull="false" ValidateType=整数></XS:TextBoxVl >
                        </td>
                    </tr>--%>
                       <tr>
                        <td>
                           父类：
                        </td>
                        <td>
                          <XS:DropDownList ID="drpPatentID" AppendDataBoundItems=true runat="server">
                                <asp:ListItem Value="0" Selected="True">根目录</asp:ListItem>
                            </XS:DropDownList>  
                        </td>
                    </tr>
                     <tr>
                        <td>
                            版块描述：
                        </td>
                        <td>
                            <XS:TextBoxVl  TextMode="MultiLine" ID="ChannelDescription" runat="server" Width="300px" Height="100px"></XS:TextBoxVl >
                        </td>
                    </tr>                  
                </table>
            </div>
        </fieldset>
    </div>
</asp:PlaceHolder>
<div style="text-align: center">
    <XS:Button ID="bntSave" runat="server" Text=" 保 存 " />
    <XS:Button ID="btnColseGreyBox" runat="server" Text=" 取 消 " />
</div>
<script>
    window.onload = LoadImg;
    var num = 0;

    function LoadImg() {
        num = setInterval('ShowImg()', 2000);
    }
    function ShowImg() {
        var ddl = document.getElementById("<%=txUp.ID%>_drpFiles");
        var optionsArray = ddl.options;
        if (optionsArray.length > 0) {
            var index = ddl.selectedIndex;
            var FielsPath = ddl.options[index].value;
            document.getElementById("<%=imgTu.ID%>").src = FielsPath;
            document.getElementById("<%=divImg.ID%>").style.display = "block";
        }
    }
  
</script>