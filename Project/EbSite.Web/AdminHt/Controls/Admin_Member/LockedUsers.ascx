<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LockedUsers.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Member.LockedUsers" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
 

<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>锁定用户管理</h3>
            </div>
            <div class="content">
                  <XS:ToolBar ID="ucToolBar" runat="server"/>
				    <XS:GridView ID="gdList" runat="server" AutoGenerateColumns="false" DataKeyNames="UserName">
    <Columns>        
        
        <asp:BoundField DataField="UserName" HeaderText="用户名"  />
         <asp:BoundField DataField="emailAddress" HeaderText="Email"  />
        <asp:BoundField DataField="LastLockoutDate" HeaderText="最后锁定日期"  />
        <asp:BoundField DataField="LastLoginDate" HeaderText="最后登录日期"  />
        <asp:TemplateField HeaderText="操作">
                    <ItemTemplate>                          
                          <XS:LinkButton  ID="lbDelete" CommandArgument='<%#Eval("UserName") %>' CommandName="deleteuser" Text="删除" runat="server"></XS:LinkButton>
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