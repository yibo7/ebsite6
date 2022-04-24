<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="edit.ascx.cs" Inherits="EbSite.Widgets.JsonList.edit" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
 <table id="tbSetConfigs" >
                    <tr>
                        <td >Json源地址:</td>
                        <td >
                             <XS:TextBoxVl Width="500"  ID="txtJsonUrl"   IsAllowNull="False" runat="server"></XS:TextBoxVl>                         
                        </td>
                     </tr>
                        <tr>
                        <td >请求编码:</td>
                        <td >
                            
                        <XS:DropDownList ID="drpEndc"     runat="server">
                            <asp:ListItem Value="0">UTF-8</asp:ListItem>
                            <asp:ListItem Value="1">GB2312</asp:ListItem> 
                        </XS:DropDownList>     
                                     
                        </td>
                     </tr>
                     <tr>
                        <td >请求方式:</td>
                        <td >
                            
                        <XS:DropDownList ID="drpPostGet"     runat="server">
                            <asp:ListItem Value="GET">GET</asp:ListItem>
                            <asp:ListItem Value="POST">POST</asp:ListItem> 
                        </XS:DropDownList>     
                                     
                        </td>
                     </tr>
                      <tr>
                        <td >数据模板:</td>
                        <td > 
                       <XS:ExtensionsCtrls ID="drpTem"   ModelCtrlID="bdec2947-cc6b-4e9a-abf2-56cb7d77387e" runat="server"/>          
                        </td>
                     </tr> 
                 </table>

<div style="margin-top: 50px; " >
    参数传入方法:<br/>
    如果你要静态传入参数，可以直接给控件的Pram属性赋值，动态传入要在Page_Load里完成，所以麻烦点,<br>
    如果你要动态传入参数，此部件使用到通用参数Pram,你可以在调用模板里传入参数，方法是这样，给部件起一个ID,如 wdTest,参考如下代码:
    
    <XS:TextBox ID="txtDeMo" ReadOnly="True" Width="800" TextMode="MultiLine" Height="300"    runat="server">
        
    </XS:TextBox>

</div>
 

<script>
     CodeMirror.fromTextArea(document.getElementById("<%=txtDeMo.ClientID%>"), {
      lineNumbers: true,
      mode: "text/html"
    });
     
    </script>

