<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="InclueCode.ascx.cs" Inherits="EbSite.Web.AdminHt.dialog.Controls.dialog.InclueCode" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<div class="row">
    <div class="col-sm-12">
        <div class="card-box">
            <div class="table-responsive">
          <table class="table" >
            <XS:Repeater ID="RepInclude" runat="server">
                <HeaderTemplate>
                    <tr class="GridViewHeader">
                        <th scope="col">
                            文件名称
                        </th>
                        <th scope="col">
                            路径
                        </th>
                        <th scope="col">
                            操作
                        </th>
                    </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <%#Eval("TemName")%>
                        </td>
                        <td>
                          <%#Eval("TemPath")%>
                        </td>
                       
                        <td>
                            <a href="#" name=' <%# string.Format("<!--#include file=\"{0}\" -->", Eval("TemPath"))%>'
                                onclick="infield(name)">插入 </a>
                        </td>
                    </tr>
                </ItemTemplate>
            </XS:Repeater>
        </table>
                </div>
        </div>
    </div>
</div>
 
