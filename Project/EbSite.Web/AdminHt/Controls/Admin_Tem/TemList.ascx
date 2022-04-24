<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TemList.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Tem.TemList" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
 
<div class="alert alert-info">使用说明书:首页模板请在系统配置里设置，请在分类，内容，专题创建或修改时设置相应的模板,请在添加用户组或修改用户组时设置相关的用户主页，用户母板，用户面板模板，注册与登录模板通过ID来调用,在以上情况不设置时将调用默认模板</div>

<div class="row">
    <div class="col-sm-12">
        <div class="card-box">
            <h4 class="m-t-0 m-b-20 header-title"><b>您当前编辑的模板来自皮肤<font color="red">[<%=CurrentThemeName %>]</font></b></h4>
            
<XS:ToolBar ID="ucToolBar" runat="server"/>

<div class="table-responsive" id="PagesMain">
    
    <XS:GridView ID="gdList" runat="server" AutoGenerateColumns="false" DataKeyNames="ID">
                             
                              <Columns>                            
                                                                    
                                   <asp:BoundField HeaderText="ID" DataField="id" /> 
                                   <asp:TemplateField HeaderText="<%$Resources:lang,EBTmeplateName %>">
                                    <ItemTemplate>
                                        <%#Eval("TemName")%>
                                    </ItemTemplate>
                                   </asp:TemplateField>       
                                   <asp:TemplateField HeaderText="<%$Resources:lang,EBAppType %>">
                                        <ItemTemplate>
                                            <asp:Label ID="TemType" runat="server" Text='<%#GetTemClass(Eval("TemType")) %>'></asp:Label>
                                        </ItemTemplate>
                                   </asp:TemplateField>
                                   <asp:BoundField HeaderText="<%$Resources:lang,EBPath %>" DataField="TemFullPath" /> 
                                   <asp:TemplateField HeaderText="<%$Resources:lang,EBOperation %>">
                                         <ItemTemplate>
                                                
                                                <a target="_blank" href="<%#GetEditUrl(Eval("id")) %>">编辑模板</a>
                                                <XS:EasyuiDialog ID="wbModify" runat="server" Text="修改" Title="修改" />                    
                                                <XS:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("id") %>' CommandName="DeleteModel" Visible='<%#Eval("IsNoSysTem")%>'
                                                    confirm="true" Text="删除"></XS:LinkButton>
                                                     <XS:LinkButton ID="lbCopy" runat="server" CommandArgument='<%#Eval("id") %>' CommandName="CopyClass"
                        confirm="true" Text="复制"></XS:LinkButton>
                                         </ItemTemplate>
                                   </asp:TemplateField>  
                                      
                                   <asp:TemplateField HeaderText="<input id='chAll' onclick='on_check(this)'  type=checkbox />">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="Selector" Visible='<%#Eval("IsNoSysTem")%>' runat="server" />
                                    </ItemTemplate>
                                   </asp:TemplateField>
                            </Columns>
    </XS:GridView>
</div>
        </div>
    </div>
</div>

<div    style=" text-align:center;margin:10px;" >
   
<XS:Button ID="btnInit" runat="server" Text="还没有模板数据，点这里可以初始化" 
    onclick="btnInit_Click" />
    
<XS:Button ID="btnResetThemeName" runat="server" Visible="false" Text="非当前皮肤的模板数据" 
    onclick="btnResetThemeName_Click" />

</div>

<script>

    function OnTemClassChange(ob) {
        
        var tc = get_selected_value(ob);
        location.href = "<%=GetTabUrl %>&tc=" + tc+"&t=<%=PageType %>";
    }

</script>