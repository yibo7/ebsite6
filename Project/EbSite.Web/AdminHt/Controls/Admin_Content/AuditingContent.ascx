<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AuditingContent.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Content.AuditingContent" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
 <div class="container-fluid mt10">
	<div class="row-fluid"> 
        <ul id="tagModels" class="nav nav-tabs">
    <asp:Repeater ID="repWebModel" runat="server">
        <ItemTemplate>
            
            <li class="nav-item" >
                        <a class="<%#Equals(Guid.Parse(Eval("id").ToString()),ModelID)?"active":"" %> nav-link" href="<%#GetUrl %>&modelid=<%#Eval("id") %>">
                            <span class="visible-xs"><i class="fa fa-cube"></i></span>
                            <span data-toggle="tooltip" title="[表:<%#Equals(Eval("tablename"),null) ? "默认表" : Eval("tablename")%>]" class="hidden-xs"><%#Eval("ModelName")%></span>

                        </a>
                    </li>

        </ItemTemplate>
</asp:Repeater>
 </ul>
        <div class="tab-content cbrowbox-tab">
            <div id="tg1" class="tab-pane active">
                <XS:ToolBar ID="ucToolBar" runat="server"></XS:ToolBar>
                <div class="table-responsive" id="PagesMain">
    <XS:GridView ID="gdList" runat="server" AutoGenerateColumns="false" DataKeyNames="ID">
                             
                              <Columns>                                                      
                                                         
                                   <asp:BoundField HeaderText="标题名称" DataField="newstitle" />
                                   <asp:BoundField HeaderText="分类名称" DataField="classname" /> 
                                   <asp:BoundField HeaderText="发布人" DataField="UserNiName" />
                                   <asp:BoundField HeaderText="添加时间" DataField="AddTime" />  
                                   <asp:BoundField HeaderText="内容ID" DataField="id" />             
                                     <asp:TemplateField HeaderText="查看效果">
                                         <ItemTemplate>       
                                          <a href='<%#EbSite.BLL.GetLink.LinkContent.Instance.GetAspxInstance(GetSiteID).GetContentLink(Eval("id"),Eval("htmlname"),Eval("classid"),0)%>'target="_blank">预览</a>                         
                                         
                                         </ItemTemplate>
                                   </asp:TemplateField>     
                                  <asp:BoundField HeaderText="内容ID" DataField="id" />             
                                     <asp:TemplateField HeaderText="操作">
                                         <ItemTemplate>       
                                           <XS:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("id") %>' CommandName="DeleteModel"     confirm="true" Text="删除">
                                              <img title="删除内容" src="<%=IISPath %>images/delete.gif" />
                                          </XS:LinkButton>
                                            <a href='<%#string.Format("?t=4&id={0}&&modelid={1}",Eval("id"),ModelID)%>'>
                                                    <img title="编辑" src="<%=IISPath %>images/edit.gif" />
                                                    </a>
                                         
                                         </ItemTemplate>
                                   </asp:TemplateField>     
                                 <asp:TemplateField ItemStyle-Width="30" HeaderText="<input id='chAll' onclick='on_check(this)'  type=checkbox />">
                                        <ItemTemplate >                                        
                                            <asp:CheckBox ID="Selector"  runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                            </Columns>
                            
</XS:GridView> 
                </div>
                <div class="text-right">
                  <XS:PagesContrl ID="pcPage" Linktype="Aspx" runat="server" />
                </div>
                
            </div>
        </div>
    </div>
</div> 
<script>
    $(function () {
        var objTags = $("#tagModels li");
        if (objTags.length == 1) {
            objTags.remove();
        }

    });
</script>