<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LimitRole.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Modules.LimitRole" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %> 
<div class="row m-t-15">
    <div class="col-sm-12">
        <div class="card-box">
            <h4 class="m-t-0 m-b-20 header-title"><b>请注意当前给<span style=" color:red"> <%=Name %></span> 选择权限</b></h4>
            <div id="PagesMain" class="table-responsive" >
                
                <XS:GridView ID="gdList" runat="server" AutoGenerateColumns="false" DataKeyNames="LimitID" >
                    <Columns>
                        
                         <asp:TemplateField HeaderText="权限ID" ItemStyle-CssClass="gvfisrtTD">
                             <ItemTemplate>
                                <%#Eval("LimitID")%>
                            </ItemTemplate>       
                        </asp:TemplateField>       
                                
                        <asp:TemplateField HeaderText="权限名称" ItemStyle-CssClass="gvfisrtTD">
                          
                           
                            <ItemTemplate>
                                <%#Eval("LimitName")%>
                            </ItemTemplate>
                        </asp:TemplateField>                 
                        <asp:TemplateField HeaderText="<input id='chAll' onclick='on_check(this)'  type=checkbox />">
                            <ItemTemplate>
                                <asp:CheckBox ID="Selector" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
           
                    </Columns>
                </XS:GridView>
                 <div style="text-align: center; padding-top:10px;display: none">
                    <XS:Button ID="bntSave" OnClick="bntSave_Click" runat="server" Text=" <%$Resources:lang,EBSave%> " />&nbsp;&nbsp;
        
                </div>
            </div>
        </div>
    </div>
</div>
 <script>
     function SaveFrame() {
         $("#<%=bntSave.ClientID%>").click();
     }
 </script>