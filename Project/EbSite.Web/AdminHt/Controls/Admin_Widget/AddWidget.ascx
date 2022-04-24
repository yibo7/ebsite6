<%@ Control Language="C#" AutoEventWireup="true"  CodeBehind="AddWidget.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Widgets.AddWidget" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<link rel=stylesheet href="<%=IISPath%>js/codemirror/lib/codemirror.css">
<script src="<%=IISPath%>js/codemirror/lib/codemirror.js"></script>
<script src="<%=IISPath%>js/codemirror/xml.js"></script>
<script src="<%=IISPath%>js/codemirror/javascript.js"></script>
<script src="<%=IISPath%>js/codemirror/css.js"></script>
<script src="<%=IISPath%>js/codemirror/htmlmixed.js"></script>
<style>
  .CodeMirror { height: auto; border: 1px solid #ddd; }
  .CodeMirror pre { padding-left: 7px; line-height: 1.25; }
  td{ padding: 5px;}
</style>
  

<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader headertips">
                <h3>部件设置</h3>
             
            </div>
            <div class="content">
				<table><tr>
                        <td>
                            部件类型：
                        </td>
                        <td>
                            <span id="wgType" ><%=sWidgetTypeName %></span>
                        </td>
                    </tr>   
                    <tr>
                        <td>
                            部件名称：
                        </td>
                        <td>
                            <XS:TextBoxVl ID="txtTitle" IsAllowNull="False" runat="server"></XS:TextBoxVl>
                        </td>
                    </tr>  
                    
                    
                       <tr>
                        <td>
                            部件归类:
                        </td>
                        <td>
                            <asp:DropDownList ID="drpClass" AppendDataBoundItems="true" runat="server">
                                <asp:ListItem Text="全部" Value=""></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        
                    </tr>                       
                        
                          
                     <tr>
                        <td>
                            
                        </td>
                        <td>
                            <div runat="server" ID="phEdit" />
                        </td>
                    </tr>
                     
                </table>

                
 <XS:Button ID="bntSave" Text="  保   存   " runat="server" />                       
                            <span class="btn btn-default" onclick="history.back()">返回</span>
            </div>
    </div>
</div>       
<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader headertips">
                <h3>调用代码</h3>
            将此代码复制到模板中的相应位置
            </div>
            <div class="content">
				 <XS:TextBox ID="txtCode" Width="650"    runat="server"></XS:TextBox>
            </div>
    </div>
</div>
<script>
    var editor = CodeMirror.fromTextArea(document.getElementById("<%=txtCode.ClientID%>"), {
      lineNumbers: true,
      mode: "text/html"
    });
     
    </script>
         