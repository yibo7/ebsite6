<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Commonly.ascx.cs" Inherits="EbSite.Web.AdminHt.dialog.Controls.dialog.Commonly" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<div class="row">
    <div class="col-sm-12">
        <div class="card-box">
            <div class="table-responsive">
          <table class="table table-hover" >
            <XS:Repeater ID="RepCommon" runat="server">
                <HeaderTemplate>
                    <tr >
                        <th scope="col">
                            名称
                        </th>
                        <th scope="col">
                            代码
                        </th>
                      
                        <th scope="col">
                            操作
                        </th>
                    </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <%#Eval("Text")%>
                        </td>
                        <td>
                            <%#Eval("Value")%>
                        </td>
                      
                        <td>
                            <a href="#" name='<%#Eval("Value")%>'
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

