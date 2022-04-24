<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="widget.ascx.cs" Inherits="EbSite.Widgets.CustomSearch.widget" %>

<form id="<%=FormID %>" action="<%=action %>" method="<%=method %>" onSubmit="return <%=onSubmit %>" target=<%=target %>  >
<asp:Repeater ID="rpData" runat="server"  >
  <ItemTemplate>            
        <%#Eval("Title")%>:<%#Eval("Control")%><br>
  </ItemTemplate>
</asp:Repeater> 
<div>
  
    <input type="hidden" id="cid" name="cid" value="<%=DataID %>" />
    <input type="<%=SubMitType %>"    <%=SubMitTextOrImgUrl %> />  
</div>

</form>