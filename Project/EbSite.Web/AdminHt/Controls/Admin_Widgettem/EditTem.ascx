<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditTem.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Ctrtem.EditTem" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<div class="admin_toobar">
    <fieldset>
        <legend>编辑模板</legend>
        <div >     
            <div style="height:30px; margin-top:10px;">
                 插件部件:
                <XS:DropDownList ID="drWebPartList" onchange="InserField(this)" AppendDataBoundItems="true" runat="server">
                    <asp:ListItem Text="选择部件" Value=""></asp:ListItem>
                </XS:DropDownList>
            </div> 
            
              <XS:CodeMirror ID="txtTem" Codemode="Aspx" Width="100%" Height="500" runat="server"/>
        </div>
    </fieldset>
    
</div>
<div style="text-align:center">
    <XS:Button ID="bntSave" Text="保存模板" runat="server" />
</div>

<script>
    
    function InserField(ob)
    {   
        InserFieldToBox(ob,"<%=txtTem.ClientID %>");
    }
</script>