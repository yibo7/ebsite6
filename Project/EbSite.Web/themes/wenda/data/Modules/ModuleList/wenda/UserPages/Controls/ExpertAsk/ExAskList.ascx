<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ExAskList.ascx.cs" Inherits="EbSite.Modules.Wenda.UserPages.Controls.ExpertAsk.ExAskList" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>


<div id="PagesMain">
    <div class="gdList_title">
        <XS:ToolBar ID="ucToolBar" runat="server"></XS:ToolBar>    
    </div>
    <div class="gdList_title">
        
        <div style="width:50px;">序号</div>
        <div style="width:400px;">问题标题</div>
        <div style="width:100px;">提问时间</div>
        <div style="width:50px;">状态</div>
        <div style="width:100px;">回答时间</div>
        <div style="width:50px;">操作</div>
    </div>
            <XS:Repeater ID="gdList" runat="server">
                <ItemTemplate>
                    <div class="gdListContent">
                        <div style="width:50px;">
                            <%# (this.pcPage.PageIndex-1) * this.pcPage.PageSize + Container.ItemIndex + 1%>
                           
                        </div>
                        <div style="width:400px;">
                            <%# (Eval("title")).ToString().Length >= 30 ? (Eval("title")).ToString().PadRight(30).Substring(0, 30) + "..." : (Eval("title")).ToString()%>
                        </div>
                        <div style="width:100px;"> <%#string.Format("{0:g}",Eval("OpTime"))%></div>
                        <div style="width:50px;"><%#Equals( Eval("State").ToString(),"0")?" 未回答":"已回答"%></div>
                        <div style="width:100px;"><%#string.Format("{0:g}",Eval("AskDate"))%></div>
                        <div style="width:50px;"><%#GetAskAress(Eval("qid").ToString(),Eval("State").ToString()) %>
                           
                        </div>
                     </div>
                </ItemTemplate>
            </XS:Repeater>
             <div class="gdListContent" id="divMsg" runat="server">
                <div style="width:100%; text-align:center;"><asp:Literal ID="litNoMsg" runat="server" Text="暂 无 数 据 !"></asp:Literal></div>
            </div>
</div>
<div>
    <XS:PagesContrl ID="pcPage" runat="server" CssClass="goodPage"  />
</div>


