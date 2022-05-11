<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddTem.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Ctrtem.AddTem" %>
<%@ Register Assembly="EbSite.Web" Namespace="EbSite.Web.WebCore.PublicControl" TagPrefix="EB" %>
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
</style>
 

<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>添加编辑部件模板</h3>
            </div>
            <div class="eb-content">
				 <table>
                <tr>
                    <td>
                        模板名称:
                    </td>
                    <td>
                        <XS:TextBox ID="txtTemName" HintInfo="模板名称" runat="server"></XS:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        模板类别:
                    </td>
                    <td>
                        <div style="float: left;">
                            <XS:DropDownList ID="drpTemClass" AppendDataBoundItems="true" runat="server">
                            </XS:DropDownList>
                        </div>
                        <%--<div id="DModel" style="float: left;">
                            <asp:DropDownList ID="drpModelContent" AppendDataBoundItems="true" runat="server"
                             Visible="false" AutoPostBack="True" OnSelectedIndexChanged="drpModelContent_SelectedIndexChanged">
                           
                            </asp:DropDownList>
                            <asp:DropDownList ID="drpModelClass" AppendDataBoundItems="true" runat="server" Visible="false"
                            AutoPostBack="True" OnSelectedIndexChanged="drpModelClass_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:DropDownList ID="drpModelUser" AppendDataBoundItems="true" runat="server" Visible="false"
                            AutoPostBack="True" OnSelectedIndexChanged="drpModelUser_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>--%>
                    </td>
                </tr>
                
                <tr>
                    <td>
                       
                    </td>
                    <td >
                        <%--<div style="margin-top: 10px; padding-bottom: 10px;">
                            <span style="color: Red">注:分类字段与内容字段分别给出默认值，如果您为某个模型设计模板，请参模型来调用 </span>
                            <br />
                            <span id="spClassColumns" runat="server">插入分类字段:
                                <XS:DropDownList ID="drpClassColumns" onchange="InserField(this)" runat="server">
                                    <asp:ListItem Text="选择字段" Value=""></asp:ListItem>
                                </XS:DropDownList>
                            </span><span id="spContentColumns" runat="server">插入内容字段:
                                <XS:DropDownList ID="drpContentColumns" onchange="InserField(this)" runat="server">
                                    <asp:ListItem Text="选择字段" Value=""></asp:ListItem>
                                </XS:DropDownList>
                            </span><span id="spSpecial" runat="server">插入专题字段:
                                <XS:DropDownList ID="drpSpecial" onchange="InserField(this)" runat="server">
                                    <asp:ListItem Text="选择字段" Value=""></asp:ListItem>
                                </XS:DropDownList>
                            </span>
                        </div>
                        <div>
                            公共函数库:<EB:TemMethod ID="drpPublicMethod" runat="server" />
                        </div> --%>
                      
                        
                   </td>
                </tr>
                <tr>
                    <td colspan="2" >
                        <b>模板内容</b> 数据调用格式:<span id="spDataGetF"></span>
                    </td>
                </tr>
                 <tr>
                    <td colspan="2" >
                         <asp:TextBox ID="txtTem"    TextMode="MultiLine" runat="server"/>
                    </td>
                </tr>
                
            </table>
            </div>
    </div>
</div>
<div class="text-center mt10">
    <XS:Button ID="bntSave" Text="保存模板" runat="server" />  <input onclick="history.go(-1)" class="btn btn-default" type="button" value="返回"/>
</div>
 
<script>
    $("#spDataGetF").text('<' + '%# Eval("字段名称")%>');
    function InserField(ob) {
        InserFieldToBox(ob, "<%=txtTem.ClientID %>");
    }
        var editor = CodeMirror.fromTextArea(document.getElementById("<%=txtTem.ClientID%>"), {
      lineNumbers: true,
      mode: "text/html"
    });
</script>

<style>td{ padding: 5px;}</style>