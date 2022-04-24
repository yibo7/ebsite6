<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VoteList.ascx.cs" Inherits="EbSite.Modules.BBS.AdminPages.Controls.Vote.VoteList" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
        <div id="PagesMain">
            <XS:GridView ID="gdList" runat="server" AutoGenerateColumns="False" 
                DataKeyNames="ID" ondatabound="gdList_DataBound">
                <Columns>
                    <asp:TemplateField HeaderText="投票主题">
                        <ItemTemplate>
                            <%#Eval("title")%></a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="选择类型">
                        <ItemTemplate>
                            <%#Eval("xuanze")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                      <asp:TemplateField HeaderText="当前状态">
                        <ItemTemplate>
                            <asp:Label ID="lbtype" runat="server" Text='<%#Eval("type")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>                     
                    <asp:TemplateField HeaderText="操作">
                        <ItemTemplate>
                            <XS:EasyuiDialog ID="WinBox8" runat="server" Href='<%# string.Concat("Vote.aspx?&t=5&mid="+ModuleID,"&id=",Eval("id"))%>'
                                 Text="参加投票" Title="参加投票" /> 
                                <asp:Label ID="lbtp" runat="server" Text='<a href="#" onclick="show()">参加投票</a>'></asp:Label>                          
                        </ItemTemplate>
                    </asp:TemplateField>                  
                </Columns>
            </XS:GridView>

        </div>
        <div>
            <XS:PagesContrl ID="pcPage" runat="server" />
        </div>
        <script>
            function show() {
                alert("投票已结束!");
            }
        </script>