<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ManageMemberGroup.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Member.ManageMemberGroup" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
 

<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
            <div class="boxheader">
                <h3>管理会员组</h3> 
            </div>
            <div class="eb-content">
                 <XS:ToolBar ID="ucToolBar" runat="server"/>
				<XS:GridView ID="gdList" runat="server" AutoGenerateColumns="false" DataKeyNames="id">
                    <Columns>
                         <asp:BoundField DataField="id"   ItemStyle-Width="70" HeaderText="<%$Resources:lang,
                        EBGroupId%>"  />
       
                        <asp:BoundField DataField="GroupName" HeaderText="<%$Resources:lang,
                        EBUserGroupName%>"  />
       
        
                        <asp:TemplateField HeaderText="<%$Resources:lang,EBOperation%>">
                                    <ItemTemplate>
                                    <a class="AdminLinkButton" href="?mpid=7d99f35a-fd5e-4f1d-a8c5-cd31579547a3&msid=d4119787-bbb8-49a8-819d-77c18836be13&rid=<%#Eval("id") %>">查看会员</a>
                                    <XS:EasyuiDialog ID="wbModify" SaveText="" runat="server" Text="修改" Title="修改" />
                                    <XS:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("id") %>' CommandName="DeleteModel"
                                        confirm="true" Text="删除"></XS:LinkButton>
                                    </ItemTemplate>
                   
                        </asp:TemplateField>        
                      <%--  <asp:TemplateField HeaderText="<%$Resources:lang,EBSelect%>">
                                    <ItemTemplate>
                                        <asp:Literal ID="RadioButtonMarkup" runat="server"></asp:Literal>
                                    </ItemTemplate>
                        </asp:TemplateField>--%>
                        <asp:TemplateField HeaderText="<%$Resources:lang,EBFlag%>">
                                    <ItemTemplate>
                                        <%#EbSite.BLL.User.UserGroupProfile.GroupIDEncode(Eval("id").ToString())%>
                                    </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="30" HeaderText="<input id='chAll' onclick='on_check(this)'  type=checkbox />">
                                <ItemTemplate >                                        
                                    <asp:CheckBox ID="Selector" runat="server" />
                                </ItemTemplate>
                        </asp:TemplateField>   
                    </Columns>
    
                </XS:GridView>
            </div>
    </div>
</div>