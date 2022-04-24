<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="seltempfields.aspx.cs" Inherits="EbSite.Web.AdminHt.dialog.seltempfileds" %>

<asp:Content ID="Content1"  ContentPlaceHolderID="ctphBody"  Runat="Server">
        <asp:PlaceHolder   id="phBodyControls" runat="server"></asp:PlaceHolder>
        <script>
            function infield(msg) { 
                parent.InserField(msg);
                 
            }
            
</script>
</asp:Content>
