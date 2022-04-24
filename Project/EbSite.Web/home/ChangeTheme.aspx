<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangeTheme.aspx.cs" Inherits="EbSite.Web.home.ChangeTheme" %>

<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<style>
    .ThemesList{ width:100%}
    .ThemesList li
    {
        float:left; margin:10px; width:80px; height:80px;
     
     }
     .ThemesList img
    {
        cursor:pointer;
     }
     .themeimg{border:0px solid #ffffff;}
     .themeimgsel{ border:2px solid #ff0000;}
</style>

<body style="background: #ffffff" >
    <form id="form1" runat="server">
    <div class="ui-state-default">
      选择分类:  <asp:DropDownList ID="drpClass" runat="server" />

      名称:<asp:TextBox ID="txtClassName" runat="server" />
        <asp:Button ID="btnSearch" OnClick="btnSearch_Click" runat="server" Text=" 搜 索 " />
    </div>
  <div class="ThemesList">
    <ul>
        <asp:Repeater ID="rpThemes" runat="server"  >
            <ItemTemplate> 
                <li>
                    
                    <img path="<%#Eval("ThemePath")%>" onclick="SelectItem(this)" id="<%#Eval("id")%>" class="themeimg" src="<%#Eval("ImgUrl")%>"  onerror=this.onerror='';this.src='../images/nopic.gif'; width="60" height="50"   />      
                   
                    <div><%#Eval("ThemeName")%></div>
                    
                </li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>
  </div>
  <div>  
  <XS:PagesContrl ID="pcPage"  Linktype="Aspx" runat="server" />
  </div>
  
    <div style=" clear:both; width:100%; text-align:center;">
        <XS:Button ID="btnSave" OnClick="btnSave_Click" runat="server"  OnClientClick="TipsAutoClose(this,'正在处理...')"  Text=" 保存所选皮肤 " />
        <asp:HiddenField ID="txtSelItemID" runat="server" />
        <asp:HiddenField ID="txtSelItemPath" runat="server" />
    </div>
    </form>

    <script>

        function SelectItem(obTheme) {
            var ThemeID = obTheme.id;
            var ThemePath = $(obTheme).attr("path");
            $("#<%=txtSelItemID.ClientID %>").val(ThemeID);
            $("#<%=txtSelItemPath.ClientID %>").val(ThemePath);
            
            $(".ThemesList").find(".themeimg,.themeimgsel").each(
		    function (i) {
		        
		        if (this.id == ThemeID) {
		            $(this).attr("class", "themeimgsel");
		        }
		        else {
		            $(this).attr("class", "themeimg");
		           
		        }
		    }
		    );
        }
        
    </script>
</body>
</html>
