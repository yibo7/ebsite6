<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="List.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Quartz.List" %>
<%@ Import Namespace="EbSite.BLL.GetLink" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
 

<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>计划任务(作业调度)管理</h3>
            </div>
            <div class="content">
				
                <XS:ToolBar ID="ucToolBar" runat="server"></XS:ToolBar>
                <XS:GridView ID="gdList" runat="server"   AutoGenerateColumns="false" DataKeyNames="id">
                              <Columns>
                                
                                   <asp:TemplateField HeaderText="任务名称"   >
                                         <ItemTemplate>
                                             <span title="任务Id:<%#Eval("id")%>"><%#Eval("TaskName")%></span>
                                         </ItemTemplate>
                                   </asp:TemplateField>
                             
                                    <asp:TemplateField   HeaderText="程序集或URL">
                                        <ItemTemplate >                                        
                                            <%#Eval("AssemblyName")%>
                                        </ItemTemplate>
                                    </asp:TemplateField> 
                                    
                                    <asp:TemplateField   HeaderText="状态">
                                        <ItemTemplate >                                        
                                         <%#Equals(Eval("Status"),0)?"<font color=#ff0000>已停止</font>":"运行中"%>
                                        </ItemTemplate>
                                    </asp:TemplateField> 
                                  <asp:TemplateField   HeaderText="最后执行时间">
                                        <ItemTemplate >                                        
                                         <%#Eval("RecentRunTime")%>
                                        </ItemTemplate>
                                    </asp:TemplateField> 
                                  
                                  <asp:TemplateField   HeaderText="备注">
                                        <ItemTemplate >
                                         <%#Eval("Remark")%>
                                        </ItemTemplate>
                                    </asp:TemplateField> 
                                  
                                   
                                  <asp:TemplateField HeaderText="操作">
                                    <ItemTemplate>
                                    <XS:EasyuiDialog ID="wbModify" LinkOnly="True"  Title="修改数据" Text="修改" runat="server"/> 
                                    <XS:LinkButton ID="lbCopy" runat="server" CommandArgument='<%#Eval("id") %>' CommandName="copy" Text="复制"></XS:LinkButton>
                                    <XS:LinkButton ID="lbDelete" Visible='<%#Eval("IsNoSys") %>' runat="server" CommandArgument='<%#Eval("id") %>' CommandName="DeleteModel"  Text="删除"></XS:LinkButton>
                                    
                                    <XS:LinkButton ID="lbstop"  runat="server" CommandArgument='<%#Eval("id") %>' confirm="True"   CommandName="stop"  Text='<%#Equals(Eval("Status"),1)?"停止任务":"开启任务" %>'></XS:LinkButton> 
                                    <a href='?t=2&id=<%#Eval("id") %>'>查看</a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                               <asp:TemplateField ItemStyle-Width="30" HeaderText="<input id='chAll' onclick='on_check(this)'  type=checkbox />">
                                        <ItemTemplate >                                        
                                            <asp:CheckBox Visible='<%#Eval("IsNoSys") %>' ID="Selector"  runat="server" />
                                        </ItemTemplate>
                               </asp:TemplateField> 
                            </Columns>
             </XS:GridView>
            </div>
    </div>
</div>