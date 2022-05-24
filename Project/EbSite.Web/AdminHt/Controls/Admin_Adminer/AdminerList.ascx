<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdminerList.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Adminer.AdminerList" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
 

<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>系统管理员</h3>
            </div>
            <div>
				        
<XS:ToolBar ID="ucToolBar" runat="server"/>
    <XS:GridView ID="gdList" runat="server"  AutoGenerateColumns="false"  runat="server" DataKeyNames="UserName">
    <Columns> 
        
        <asp:BoundField DataField="UserName" HeaderText="<%$Resources:lang,EBUserName %>"  />
         <asp:TemplateField HeaderText="昵称">
                    <ItemTemplate>
                        <%#EbSite.Base.Host.Instance.GetUserNiName(Convert.ToInt32(Eval("UserID").ToString())) %>
                    </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="<%$Resources:lang,EBAdminLock %>">
                    <ItemTemplate>
                        <%#(bool)(EbSite.Core.Utils.ConvertBool(Eval("isLock").ToString())) ? "<font color='red'>是</font>" : "否"%>
                    </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="LastLoginTime"  HeaderText="<%$Resources:lang,EBLastLogin %>" />
       
        <asp:TemplateField HeaderText="<%$Resources:lang,EBUserOperation %>">
                    <ItemTemplate>
                           
                          <XS:EasyuiDialog ID="WinBox2" runat="server" SaveText="保存" IsDialog="true"  Href='<%# string.Concat("?t=6&id=",Eval("UserID"))%>' Text="查看权限" Title="查看权限" />
                          <XS:EasyuiDialog ID="EasyuiDialog1" runat="server" SaveText="保存"  Href='<%# string.Concat("?t=2&uid=",Eval("UserName"))%>' Text="分配角色" Title="分配角色" />                             
                    <XS:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%#Eval("UserName") %>' CommandName="DeleteModel" confirm="true" Text="删除"></XS:LinkButton>
                    </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="<input id='chAll' onclick='on_check(this)'  type=checkbox />">
                    <ItemTemplate>
                        <asp:CheckBox ID="Selector" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
    </Columns>
</XS:GridView>
            </div>
    </div>
</div>