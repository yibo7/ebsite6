<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeBehind="WidgetEditor.aspx.cs" Inherits="EbSite.Web.home.WidgetEditor" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
  <title>部件编辑器</title>
  <style type="text/css">
    .thisbody {font: 11px verdana; margin:0; overflow: hidden;background:#ffffff; text-align:left}
   
    #title {background: #F1F1F1; border-bottom: 1px solid silver; padding: 10px}
    label {font-weight: bold}
    #bottom {background: #F1F1F1; border-top: 1px solid silver; padding: 10px; text-align: right}
    .MyPram{ height:460px;overflow: auto; overflow-x: hidden;}
    .MyPram div{  margin:8px;}
  </style>
</head>
<body  class="thisbody" >


  <form id="form1" runat="server">

    <div id="title">
      <label for="<%=txtTitle.ClientID %>">标题</label>&nbsp;&nbsp;&nbsp;
      <XS:TextBoxVl ID="txtTitle" IsAllowNull=false runat="server"></XS:TextBoxVl>
      
    </div>
    <div class="MyPram">
        <div>
            <table cellpadding="0" cellspacing="0">
            <tr>
                <td> 
                    <div runat="server" ID="phEdit" />
                </td>
            </tr>
            <tr>
                <td>       
                    <div >
                        部件皮肤:  <asp:DropDownList ID="drpBoxTheme" 
                            runat="server" onselectedindexchanged="drpBoxTheme_SelectedIndexChanged" />
                    </div>
                    <div runat="server" ID="phColorPram" />
                </td>
            </tr>
        </table> 
        </div>
    </div>

    <div id="bottom">
      <asp:Button runat="server" ID="btnSave" Text="保存" onclick="btnSave_Click" OnClientClick="TipsAutoClose(this,'正在处理...')"   
            style="height: 26px" />
       
    </div>
    
  </form>
  
</body>
</html>
