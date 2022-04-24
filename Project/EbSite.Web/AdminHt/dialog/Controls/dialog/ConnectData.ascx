<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ConnectData.ascx.cs" Inherits="EbSite.Web.AdminHt.dialog.Controls.dialog.ConnectData" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<div class="row">
    <div class="col-sm-12">
        <div class="card-box">
           分类:<XS:ExtensionsCtrls ID="ExtensionsCtrls1"   ModelCtrlID="78740116-ad37-412a-bed3-988fea974d0a" runat="server"/>
            <br/>
                专题:
                <XS:ExtensionsCtrls ID="ExtensionsCtrls2"   ModelCtrlID="d8705cdc-3501-43b3-9cc4-8ba9608d315b" runat="server"/>
             <br/>   
             其他:   
                <XS:DropDownList ID="drpOtherLink" onchange="InserField(this)" AppendDataBoundItems="true" runat="server">
                    <asp:ListItem Text="选择连接" Value=""></asp:ListItem>
                </XS:DropDownList>    
        </div>
    </div>
</div>
 
 
                <script>
                    function InserField(ob) {
                        infield(ob.options[ob.selectedIndex].value);
                    }
                    
                </script>       