<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ServiceList.ascx.cs" Inherits="EbSite.Modules.CQ.AdminPages.Controls.Service.ServiceList" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<XS:ToolBar ID="ucToolBar" runat="server"></XS:ToolBar>
<div id="PagesMain">

<table class="GridView" cellspacing="0" rules="all" border="1"   style="border-collapse:collapse;">
<XS:Repeater ID="rpList" runat="server" >
    <HeaderTemplate>
        <tr class="GridViewHeader">
			    <th scope="col">ID</th><th scope="col">客服名称</th><th scope="col">状态</th><th scope="col">职位</th><th scope="col">电话</th><th scope="col">手机</th><th scope="col">Email</th><th scope="col">登录帐号</th><th scope="col">用户昵称</th><th scope="col">用户ID</th><th scope="col">是否启用</th>
                <th scope="col">满意率</th>
                <th scope="col">操作</th><th scope="col">选择(<span onclick='on_checkback(PagesMain)'style='cursor:hand;color:#FF0000'>全选</span>)</th>
       </tr>
    </HeaderTemplate>
    <ItemTemplate>
       <tr>
			<td align="center" valign="middle" style="width:50px;">
                  <%#Eval("ID")%>
                </td><td>
                     <%#Eval("ServiceName")%>
                </td><td>
                   <%#IsOnline(Eval("IsOnline"), Eval("ID"))%>
                </td><td>
                    <%#Eval("PostName")%>
                </td><td>
                   <%#Eval("Phone")%>
                </td><td>
                    <%#Eval("Mobile")%>
                </td><td>
                   <%#Eval("Email")%>
                </td><td>
                    <%#Eval("UserName")%>
                </td><td>
                   <%#Eval("UserNiName")%>
                </td><td>
                   <%#Eval("UserID")%>
                </td><td>
                   <%#Eval("IsEabled").ToString().ToLower().Equals("true")?"<span style=\"color:red;\">是</span>":"否"%>
                </td>
                <td>
                   <%#Eval("StarPercent").ToString()%>
                </td>
                <td>               
                
                        <span>
                        <XS:EasyuiDialog ID="wbModify"  Title="修改数据" Text="修改" runat="server"/></span>
                        <span>
                        <XS:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("id") %>'  CommandName="DeleteModel"  Text="删除"></XS:LinkButton>
                        </span>
                        <span>
                        <XS:LinkButton ID="lbCopy" runat="server" CommandArgument='<%#Eval("id") %>' CommandName="CopyModel" Text="复制"></XS:LinkButton>
                        </span>
                       <span>
                        <XS:LinkButton ID="lbOffLine" runat="server" CommandArgument='<%#Eval("id") %>' CommandName="OffLine" Text="置为离线"></XS:LinkButton>
                        </span>
                        <span>
                          <a href="<%=GetUrl %>&t=6&u=<%#Eval("UserID")%>">聊天记录</a> 
                        </span>
                        <span>
                          <a href="<%=GetUrlMsg %>&u=<%#Eval("UserName")%>">留言记录</a> 
                        </span>
                       <asp:HiddenField ID="hfID" Value='<%#Eval("ID")%>' runat="server" />
                
                </td><td>
                   <input name="ebcheckboxname" value="<%#Eval("ID")%>" type="checkbox" />
                </td>
		</tr>
    </ItemTemplate>
</XS:Repeater>
</table>
</div>
<div>
    <XS:PagesContrl ID="pcPage" runat="server" />
</div>