<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="bbsconfigs_show.ascx.cs" Inherits="EbSite.Modules.BBS.AdminPages.Controls.BBSmanagement.bbsconfigs_show" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<asp:PlaceHolder ID="phCtrList" runat="server">
    <div class="admin_toobar">
        <fieldset>
            <legend>板块描述查看</legend>
            <div>
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            版块名称：
                        </td>
                        <td>
                            <%=Model.ChannelName%>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            版标：
                        </td>
                        <td>
                            <img alt="" src="<%=Model.ChannelImageUrl%>" onerror="this.src='../DataStore/Attachments/images/noimg.gif';"/>
                        </td>
                    </tr>                    
                     <tr>
                        <td>
                            排序：
                        </td>
                        <td>
                            <%=Model.OrderFlag%>
                        </td>
                    </tr>
                     <tr>
                        <td>
                            版块描述：
                        </td>
                        <td>
                            <%=Model.ChannelDescription%>
                        </td>
                    </tr>                  
                </table>
            </div>
        </fieldset>
    </div>
</asp:PlaceHolder>
