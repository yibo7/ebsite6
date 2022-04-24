<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LayoutPanne.aspx.cs" Inherits="EbSite.Web.home.LayoutPanne" %>

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
        float:left; margin:10px;
     }
     .ThemesList img
    {
        cursor:pointer;
     }
     .themeimg{border:0px solid #ffffff;}
     .themeimgsel{ border:2px solid #ff0000;}
</style>
<body style="background: #ffffff">
    <form id="form1" runat="server">
      <div class="ThemesList">
    <ul>
    <asp:Repeater ID="rpLayouts"  runat="server"  >
            <ItemTemplate> 
               <li>
                    <div onclick="SelectItem(this)" path="<%#Eval("FileName")%>" id="<%#Eval("id")%>" class="themeimg">
                    <img  src="<%# GetLayoutPath(Eval("FileName"))%>"  onerror=this.onerror='';this.src='../images/nopic.gif'; width="60" height="50"   />      
                    </div>
                    <div><%#Eval("LayoutName")%></div>
                    
                </li>
            </ItemTemplate>
        </asp:Repeater>
     </ul>
    </div>
    <br/>
    <div>
        <XS:Button ID="btnSave" OnClick="btnSave_Click" runat="server"  OnClientClick="TipsAutoClose(this,'正在处理...')"  Text=" 保存所选版式 " />
        <asp:HiddenField ID="txtLayoutName" runat="server" />
    </div>
    </form>

    <script>

        function SelectItem(obTheme) {
            var ThemeID = obTheme.id;
            var ThemePath = $(obTheme).attr("path");
            $("#<%=txtLayoutName.ClientID %>").val(ThemePath);

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
