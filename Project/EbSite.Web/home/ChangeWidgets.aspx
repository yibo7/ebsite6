<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangeWidgets.aspx.cs" Inherits="EbSite.Web.home.ChangeWidgets" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="background: #ffffff">
    <form id="form1" runat="server">
  

<XS:Notes ID="Notes7" Text="选择要添加的部件，然后点保存,一个页面不能超过20个部件"   runat=server></XS:Notes>
<br/>

<style>
    .allwidget { width:100%; vertical-align:top;}
	.allwidget ul { list-style-type: none; margin: 0; padding: 0; margin-bottom: 10px; }
	.allwidget li { margin: 5px; padding: 5px; width: 150px; float:left  }
	.fRightDelete{ float:right; margin-top:-15px; cursor:pointer;}
	</style>
    <div class="allwidget">
     <asp:Repeater ID="rpWidgets" runat="server"  >
                <ItemTemplate>        
                    <li   class="ui-state-highlight">
                       <span class="fLeft">
                       <%#Eval("WidgetName")%>
                       </span> 
                         <span class="fRight">
                            <input id="<%#Eval("id")%>" type="checkbox" />
                         </span>
                    </li>
                </ItemTemplate>
            </asp:Repeater>
</div>
<br/>
<div>
 <input type="button"  value=" 保 存  "  onclick="SaveWidgets()"   class="AdminButton" />
</div>

    </form>
    <script>
        function SaveWidgets() {
          
             var AddIDs = [];
            $(".allwidget").find("input[type=checkbox]").each(
		    function (i) {
                if (this.checked) {
		            AddIDs.push(this.id);
		        }
               
		    }
		    );
            var tid = <%=CurrentTabID %>;
            var Url = SiteConfigs.UrlIISPath + "home/ajaxget/WidgetPosChange.ashx?tid="+tid+"&addid=" + AddIDs.join(",")+"&time="+Math.random();
                run_ajax_async(Url, "", SaveWidgetsCom);
            
        }
        function SaveWidgetsCom(msg) {
            if(msg=="ok") {
                RefeshParent();
            }
            else {
                alert("保存失败！");
            }
        }
    </script>
</body>
</html>
