<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SpiderList.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Spider.SpiderList" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
 
<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
            <div class="boxheader">
                <h3>蜘蛛管理</h3>
            </div>
            <div class="content">
				 <XS:ToolBar ID="ucToolBar" runat="server"></XS:ToolBar> 
                <XS:GridView ID="gdList" runat="server"   AutoGenerateColumns="false" DataKeyNames="ID">
                              <Columns>
                                   <asp:TemplateField HeaderText="搜索引擎名称" ItemStyle-CssClass="gvfisrtTD" >
                                         <ItemTemplate>
                                            <%#Eval("SpiderCnName")%>    
                                         </ItemTemplate>
                                   </asp:TemplateField>
                                   <asp:BoundField HeaderText="蜘蛛标识"   ReadOnly="true" DataField="SpiderEnName" />
                                   
                                  <asp:TemplateField HeaderText="操作">
                                    <ItemTemplate>
                                       
                                             <div class="spiderdiv" spiderid="<%#Eval("id") %>">
                                                来访：
                                                <span>今天(<font color="#ff0000">...</font>)</span>
                                                <span>昨天(<font color="#ff0000">...</font>)</span>
                                                <span>前7天(<font color="#ff0000">...</font>)</span>
                                                <span>前30天(<font color="#ff0000">...</font>)</span>
                                            </div> 
                                       
                                    
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField  >
                                        <ItemTemplate >                                        
                                            <XS:EasyuiDialog ID="wbModify"  Title="修改数据" Text="修改" runat="server"/> 
                                    <XS:LinkButton ID="lbDelete"  runat="server" CommandArgument='<%#Eval("id") %>' CommandName="DeleteModel"  Text="删除"></XS:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField> 
                               <asp:TemplateField ItemStyle-Width="30" HeaderText="<input id='chAll' onclick='on_check(this)'  type=checkbox />">
                                        <ItemTemplate >                                        
                                            <asp:CheckBox ID="Selector"   runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField> 
                            </Columns>
             </XS:GridView>
            </div>
    </div>
</div>

<script>
    $(function() {
        $(".spiderdiv").each(function(i) {
            var spd = $(this).attr("spiderid");
            var fonts = $(this).find("span font");
            runadminws("GetSpiderCount", { spid: spd }, function (msg) {
                $(fonts[0]).text(msg.d.d);
                $(fonts[1]).text(msg.d.l);
                $(fonts[2]).text(msg.d.w);
                $(fonts[3]).text(msg.d.m);
            });

        });


    });
</script>