<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TemList.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Ctrtem.TemList" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
 

<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>管理部件模板</h3>
            </div>
            <div class="content">
				<XS:ToolBar ID="ucToolBar" runat="server"/>
                <XS:GridView ID="gdList" runat="server" AutoGenerateColumns="false" DataKeyNames="ID">
                             
                              <Columns>                             
                                                                                                    
                                   <asp:BoundField HeaderText="模板名称" DataField="Title" />
                                   <asp:TemplateField HeaderText="模板类别">
                                         <ItemTemplate> 
                                              <asp:DropDownList Enabled="false" runat="server" 
                                                DataTextField="title" DataValueField="id"  DataSourceID ="objdsClass"
                                                ID="drBoxClass3" 
                                                SelectedValue='<%# Bind("classid") %>'>
                                        </asp:DropDownList>
                                         </ItemTemplate>
                                   </asp:TemplateField> 
                                   <asp:TemplateField HeaderText="路径">
                                         <ItemTemplate> 
                                         <%#EbSite.BLL.Ctrtem.TemListInstace.TemBll(GetSiteID).GetTemPath(new Guid(Eval("id").ToString()))%>
                                     </ItemTemplate>
                                   </asp:TemplateField>   
                                   <asp:BoundField HeaderText="添加日期" DataField="AddDate" />  
                                     <asp:TemplateField HeaderText="操作">
                                         <ItemTemplate>       
                                                 <XS:EasyuiDialog ID="wbModify" runat="server" Text="修改" Title="修改" />                    
                                                         <XS:LinkButton ID="lbCopy" runat="server" CommandArgument='<%#Eval("id") %>' CommandName="CopyData"
                        confirm="true" Text="复制"></XS:LinkButton>
                                                 <XS:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("id") %>' CommandName="DeleteModel" Text="删除"></XS:LinkButton>         
                                         </ItemTemplate>
                                   </asp:TemplateField>     
                                 
                            </Columns>
                            
                          </XS:GridView>
                
<asp:ObjectDataSource ID="objdsClass" runat="server" 
    SelectMethod="FillCtrTemClasss" TypeName="EbSite.BLL.Ctrtem.TemClass"></asp:ObjectDataSource>
            </div>
    </div>
</div>

<script>

    function OnTemTpChange(ob) { 
        var ttp = get_selected_value(ob);
        location.href = "<% =GetUrl%>&ttp=" + ttp;
    }

</script>