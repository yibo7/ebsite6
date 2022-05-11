<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VisitSum.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Spider.VisitSum" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
 
<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div>
                <h3>受访频率</h3>
            </div>
            <div class="eb-content">
				<XS:ToolBar ID="ucToolBar" runat="server"></XS:ToolBar> 
                <XS:GridView ID="gdList" runat="server"   AutoGenerateColumns="false" DataKeyNames="ID">
                              <Columns>
                                   <asp:TemplateField HeaderText="访问地址">
                                         <ItemTemplate>
                                            <a href="<%#Eval("Text")%>" target="_blank"><%#Eval("Text")%></a>
                                         </ItemTemplate>
                                   </asp:TemplateField>
                                   <asp:BoundField HeaderText="受访次数"    DataField="Value" /> 
                                  
                            </Columns>
             </XS:GridView>
            </div>
    </div>
</div>