<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="InitTabWidgets.ascx.cs"
    Inherits="EbSite.Modules.UserBaseInfo.AdminPages.Controls.Splace.InitTabWidgets" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>

<asp:PlaceHolder ID="phCtrList" runat="server">
   <div class="row">
    <div class="col-sm-12">
        <div class="card-box">
           <div>
                <div>
                    部件名称
                    <XS:DropDownList ID="DropWidgets" runat="server">
                    </XS:DropDownList>
                </div>
                <div style="margin-top: 5px;">
                    部件布局
                    <XS:TextBoxVl ID="LayoutPane" IsAllowNull="false" runat="server" width="255" ValidationGroup="A">
                    </XS:TextBoxVl>
                </div>
                <div style="margin-top: 5px;">
                    <asp:Button ID="bntAddOne" runat="server" Text=" 添 加 " ValidationGroup="A"  /></div>
            </div>
            <br />
            <br />
            <div>
                <XS:GridView ID="gvData" runat="server" DataKeyNames="id" AutoGenerateColumns="False"
                    EnableViewState="true" IsShowSWPages="false"  onrowcommand="gvData_RowCommand"  
                    Width="1000">
                    <columns>           
                                <%--   <asp:BoundField HeaderText="id" DataField="id"  />         --%>        
                                   <asp:BoundField HeaderText="部件ID" DataField="WidgetsID"   />
                                  
                                    <asp:BoundField HeaderText="部件名称" DataField="WidgetsName" />
                                    <asp:BoundField HeaderText="部件布局" DataField="LayoutPane" />                                  
                                     <asp:TemplateField HeaderText="操作">
                                         <ItemTemplate>       
                                                   <%-- <XS:LinkButton  ID="LinkButton2" CommandArgument='<%#Eval("id") %>' CommandName="modifymodel" Text="修改" confirm="false" runat="server"></XS:LinkButton>
                                                   --%> <XS:LinkButton  ID="LinkButton1" CommandArgument='<%#Eval("id") %>' CommandName="deletemodel" Text="删除" runat="server"></XS:LinkButton>
                                    
                                         </ItemTemplate>
                                   </asp:TemplateField>     
                                 
                            </columns>
                </XS:GridView>
            </div>
        </div>
    </div>
</div>
</asp:PlaceHolder>

