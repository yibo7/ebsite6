<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MemberList.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Member.MemberList" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
 


<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>管理会员</h3>
            </div>
            <div class="eb-content">
                 <XS:ToolBar ID="ucToolBar" runat="server"/>
				<XS:GridView ID="gdList" runat="server" AutoGenerateColumns="false" DataKeyNames="UserName">
    <Columns>        
        
        <asp:BoundField DataField="UserName" HeaderText="用户名"  />
        <asp:BoundField DataField="ID" HeaderText="用户ID"  />
        <asp:BoundField DataField="NiName" HeaderText="昵称"  />        
        <asp:TemplateField HeaderText="是否管理员">
                    <ItemTemplate>
                        <%#(Eval("ManagerID").ToString()=="0")?"否":"是"%>
                    </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="CreateDate" HeaderText="注册日期"  />
        
        <asp:TemplateField HeaderText="操作">
                    <ItemTemplate>        
                          <a class="AdminLinkButton" href="?t=12&id=<%#Eval("id") %>">详细</a>                  
                          <XS:EasyuiDialog ID="EasyuiDialog1" IsDialog="true" runat="server" Width="500" Height="300" Href='<%# string.Concat("?t=3&u=",Eval("UserName"))%>' Text="分配会员组" SaveText="保存用户组"  Title="分配会员组" />
                          <XS:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("UserName") %>' CommandName="DeleteModel"
                        confirm="true" Text="删除"></XS:LinkButton>
                        <XS:EasyuiDialog ID="EasyuiDialog2" runat="server" Href='<%# string.Concat("?t=13&u=",Eval("UserName"))%>' Text="修改密码" Title="修改密码" />
                    </ItemTemplate>
        </asp:TemplateField>     
        <asp:TemplateField HeaderText="<input id='chAll' onclick='on_check(this)'  type=checkbox />">
                <ItemTemplate>
                    <asp:CheckBox ID="Selector" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>   
    </Columns>
</XS:GridView>
                
<XS:PagesContrl ID="pcPage"  Linktype="Aspx" runat="server" />
            </div>
    </div>
</div>

<script>

    function OnRoleChange(ob) {

        var rid = get_selected_value(ob);
        location.href = "<% =GetUrl%>&rid=" + rid;

    }
</script>
