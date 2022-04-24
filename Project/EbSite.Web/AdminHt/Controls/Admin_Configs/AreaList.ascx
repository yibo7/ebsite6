<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AreaList.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Configs.AreaList" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
 
<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>区域配置</h3>
            地区数据是一种常用的数据，这里设置好后，方便在其他模块开发时调用，也可直接调用扩展控件AreaLis
            </div>
            <div class="content">
				<div id="PagesMain">
    <asp:Panel ID="PaneArea" runat="server">
        
        <div style="color: red;  font-size: 16px; margin-top: 10px;">
            您还没有初始化数据，请点击初始化按钮。
             <XS:Button ID="btnAddArea"  runat="server" Text="初始化"  OnClientClick="OpenTipsToCenter('','正在导入数据,请稍等..',200,100)" OnClick="btnAddArea_Click" />
            
        </div>

    </asp:Panel>
    
     <asp:Panel ID="PanelComplete" runat="server">
    <table cellpadding="0" cellspacing="0" width="100%" align="center" style="margin: 20px 0 0 0;
        padding: 10px; border-top: 1px #dddddd solid">
        <tr>
            <td style="border-right: 1px #dddddd solid; background: #f1f1f1">
                <b>国家（一级地区）</b><br />
                <asp:ListBox ID="Area_1" runat="server" Width="150px" Height="300px" OnSelectedIndexChanged="Area_1_SelectedIndexChanged"
                    AutoPostBack="true"></asp:ListBox>
            </td>
            <td style="border-right: 1px #dddddd solid; background: #f9f9f9">
                <b>省份（二级地区）</b><br />
                <asp:ListBox ID="Area_2" runat="server" Width="150px" Height="300px" OnSelectedIndexChanged="Area_2_SelectedIndexChanged"
                    AutoPostBack="true"></asp:ListBox>
            </td>
            <td style="border-right: 1px #dddddd solid; background: #f1f1f1">
                <b>城市（三级地区）</b><br />
                <asp:ListBox ID="Area_3" runat="server" Width="150px" Height="300px" OnSelectedIndexChanged="Area_3_SelectedIndexChanged"
                    AutoPostBack="true"></asp:ListBox>
            </td>
            <td style="border-right: 1px #dddddd solid; background: #f9f9f9">
                <b>区/县（四级地区）</b><br />
                <asp:ListBox ID="Area_4" runat="server" Width="150px" Height="300px" OnSelectedIndexChanged="Area_4_SelectedIndexChanged"
                    AutoPostBack="true"></asp:ListBox>
            </td>
            <td style="border-right: 1px #eeeeee solid">
                <XS:Button ID="btnEdit" runat="server" Text="编辑" CausesValidation="false" OnClick="btnEdit_Click"
                    Enabled="false" /><br />
                <br />
                <br />
                <XS:Button ID="btnDelete" runat="server" Text="删除" OnClick="btnDelete_Click" OnClientClick="return confirm('该操作不可恢复，您确定要删除吗？')" />
            </td>
        </tr>
        <tr>
            <td colspan="5" align="center" style="border-top: 1px #dddddd solid">
                <span style="display: none;">
                    <asp:HiddenField ID="NowLevelID" runat="server" Value="1" />
                    父ID：<asp:Label ID="HeadID" runat="server" Text="0"></asp:Label></span>
                <asp:Label ID="LevelID" runat="server" Text="1" Visible="false" />
                <asp:Label ID="lblName" runat="server" Text="地区名称："></asp:Label>
                <XS:TextBoxVl ID="txtName" ValidationGroup="Tb" IsAllowNull="false" MsgErr="不能为空"
                    runat="server" Width="95px"></XS:TextBoxVl>
                &nbsp;<asp:CheckBox ID="IsFirst" runat="server" Text="是否为一级地区" Height="17px" />
                <XS:Button ID="btnAddSubmit" ValidationGroup="Tb" runat="server" Text="确定" OnClick="btnAddSubmit_Click" />
                <XS:Button ID="btnEditSubmit" runat="server" Text="更新" Visible="false" OnClick="btnEditSubmit_Click" />
                <XS:Button ID="btnReset" ValidationGroup="Tb" runat="server" Text="重置" OnClick="btnReset_Click" />
                &nbsp;
            </td>
        </tr>
        
    </table>
         <br />
    </asp:Panel>
</div>
            </div>
    </div>
</div>
 
<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>批量添加</h3>
            </div>
            <div class="content">
                请用","分开 如：石家庄，邢台
				 <XS:TextBoxVl ID="AllAreaNames"  onkeydown="javascript:this.value=this.value.replace('，',',')" ValidationGroup="TbA" IsAllowNull="false" TextMode="MultiLine"
                    MsgErr="不能为空" runat="server" Width="600px" Height="100px"></XS:TextBoxVl>
                <br />
                <XS:Button ID="ButAll" ValidationGroup="TbA" runat="server" Text="批量添加" OnClick="ButAll_Click" />
            </div>
    </div>
</div>
