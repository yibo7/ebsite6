<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="List.ascx.cs" Inherits="EbSite.Modules.UserBaseInfo.UserPages.Controls.MFavorite.List" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>

   <div class="w-navigator">
                <a><img onclick="OpenSearch('ebSearch')" src="/images/search.png"/></a> <b>|</b>
                <a><img onclick="on_checkback(ebcontent)" src="/images/check.png"/></a> <b>|</b>
                <a><img onclick="on_checkback(ebcontent)" src="/images/add.png"/></a> <b>|</b>
                <a><img onclick="on_checkback(ebcontent)" src="/images/edit.png"/></a> <b>|</b>
                <a><img src="/images/delete.png"/></a>
                <span onclick="SubMenusClick()" >更多&#9660</span>
               
       </div>
       
        
      <div id="ebSearch" class="w-home-search" style="margin:5px;display: none;" >
           <input type="submit" value=" 搜 索 " alog-alias="search">
            <div class="input">
                <div class="ui-input-mask" style="height: 45px;">
                    <input name="k" type="text" autocomplete="off" autocorrect="off" maxlength="100"
                        placeholder="请描述您的问题…" style="position: absolute; top: 0px; left: 0px; width: auto;
                        right: 40px;">
                    <div class="ui-quickdelete-button" style="height: 20px; width: 20px; top: 13px; right: 10px;">
                    </div>
                </div>
            </div>
    </div>

<ul class="data-list">
    <XS:Repeater ID="gdList" runat="server">            
                <ItemTemplate>
                    <li><input value="<%#Eval("id")%>" type="checkbox"/> <a href="<%#Eval("LinkUrl")%>"><span ><%#Eval("Title")%></span></a> 
                    <span class="arrow">
                        
                    </span>
                    </li>
                </ItemTemplate>
    </XS:Repeater>
    <div class="btnloadmore">加载更多...</div>
</ul>
<div>
    <XS:PagesContrl ID="pcPage" runat="server" />
</div>
<div style="height: 100px;" id="ebSubMenus">
    <div >查看</div>
    <div >分享</div>
</div>

<script>m_dialog('ebSubMenus', '300', '200');</script>