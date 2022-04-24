<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PcWebThemes.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Themes.PcWebThemes" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %> 
 

<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>当前站点为"<%=CurrentSite.SiteName %>"所使用皮肤为[<%=CurrentSite.PageTheme %>]</h3>
            </div>
            <div class="content">
				
    <input type="button"  class="btn btn-primary" onclick="location.href='<%=GetTempListUrl("") %>'" value="点击进入管理当前站点皮肤模板及样式"/>
            </div>
    </div>
</div>
 
<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader headertips">
                <h3>PC版前端所有皮肤</h3>
            为了安全起见,在这里的删除只是删除数据文件，没有真正删除皮肤刷新数据时将可还原，但如果有需要，请到网站根目录下的themes里删除对应的文件夹，然后刷新当前页面
            </div>
            <div class="content">
				 <XS:ToolBar ID="ucToolBar" runat="server"></XS:ToolBar>
                <XS:GridView ID="gdList" runat="server"   AutoGenerateColumns="false" DataKeyNames="ID">
                              <Columns>
                                                                 
                                   <asp:TemplateField  HeaderText="皮肤目录"  >
                                        <ItemTemplate >                                        
                                            <%#Eval("ThemePath")%><%#Eval("SiteID").ToString() == "0" ? "" : "&nbsp;<font color=red>[使用中,创建站点时不可用，要使用可先复制]<font>"%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField  HeaderText="存放路径"  >
                                        <ItemTemplate >                                        
                                            <%#Eval("FullPath")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                   <asp:BoundField HeaderText="<%$Resources:lang,EBLoginDate %>"   ReadOnly="true" DataField="AddDate" >
                                   </asp:BoundField>
                                    <asp:TemplateField HeaderText="操作">
                                    <ItemTemplate>
                                        
                                        <a href="<%#GetTempListUrl(Eval("ThemePath").ToString()) %>">编辑模板</a>      

                                    <XS:EasyuiDialog ID="wbModify" runat="server" Text="修改" Title="修改" />        
                                     <XS:LinkButton ID="lbDelete"  runat="server" CommandArgument='<%#Eval("id") %>' CommandName="DeleteModel"  Text="删除"></XS:LinkButton>
                                     <XS:LinkButton ID="lbCopy" runat="server" CommandArgument='<%#Eval("id") %>' CommandName="CopyData" confirm="true" Text="复制"></XS:LinkButton>
                                    
                                    </ItemTemplate>
                                </asp:TemplateField>
                                  <asp:TemplateField HeaderText="<input id='chAll' onclick='on_check(this)'  type=checkbox />">
                                <ItemTemplate>
                                    <asp:CheckBox ID="Selector"  runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            </Columns>
             </XS:GridView>
                <XS:PagesContrl ID="pcPage" runat="server">    </XS:PagesContrl>
            </div>
    </div>
</div>
 
 