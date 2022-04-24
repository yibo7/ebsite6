<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MyAskList.ascx.cs" Inherits="EbSite.Modules.Wenda.UserPages.Controls.MWenDaManage.MyAskList" %>
<%@ Import Namespace="EbSite.Modules.Wenda" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>


  <XS:ToolBarMobile ID="ucToolBar" runat="server"></XS:ToolBarMobile>

<div class="data-list">
    <XS:Repeater ID="gdList" runat="server">            
                <ItemTemplate>
                    <div  style="background-color: #ffffff; border: 1px solid #E7E7E7;  margin-bottom: 10px;">
                        <ul>
                    <li> <span class="<%#Equals(Eval("annex21").ToString(),"2")?"c_state2":"c_state1" %> c_state_wd"  ></span> <a  href="<%#EbSite.Base.Host.Instance.MGetContentLink(Eval("ID"),Configs.Instance.Model.GetSiteID) %>"><span style="color: black;" ><%#Eval("newstitle")%></span></a> 
                    <span class="arrow">
                        
                    </span>
                        <br/> <br/>
                         <div style="margin-left: 59px;"> 回答：<%#Eval("Annex11") %> |    <%#DateTime.Parse(Eval("addtime").ToString()).ToString("yyyy-MM-dd")%></div>
                    </li>
                    </ul>
                    </div>
                </ItemTemplate>
    </XS:Repeater>
   
</div>
<div class="btnloadmore">加载更多...</div>
 <XS:PagesContrl ID="pcPage"  PageSize="5" runat="server" />

<script>
    loadpage(".data-list", ".btnloadmore", '.data-list div');
</script>


