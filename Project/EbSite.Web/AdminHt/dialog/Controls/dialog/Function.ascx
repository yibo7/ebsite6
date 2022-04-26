<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Function.ascx.cs" Inherits="EbSite.Web.AdminHt.dialog.Controls.dialog.Function" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<div class="row">
    <div class="col-sm-12">
        <div class="card-box">
            <div class="table-responsive">
          <table class="table table-hover">
            <XS:Repeater ID="RepFunction" runat="server">
                <HeaderTemplate>
                    <tr class="GridViewHeader">
                        <th scope="col">
                            显示名称
                        </th>
                        <th scope="col">
                            模板调用方式
                        </th>
                      
                        <th scope="col">
                            操作
                        </th>
                    </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <%#Eval("Title")%>
                        </td>
                        <td>
                            <%#Eval("GetCode")%>
                        </td>
                       
                        <td>
                            <a href="#" name='<%#Eval("GetCode")%>'
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
 
