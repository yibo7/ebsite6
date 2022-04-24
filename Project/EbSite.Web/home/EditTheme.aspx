<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditTheme.aspx.cs" Inherits="EbSite.Web.home.EditTheme"  ValidateRequest="false"%>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
   <XS:CustomTagsBox ID="ctbTag" runat="server"></XS:CustomTagsBox>
        <div id="tg1" >
            <XS:TextBox ID="txtCSS" TextMode="MultiLine" Width="700" Height="400" runat="server"></XS:TextBox>
        </div>
        <div id="tg2" >
            <XS:Notes ID="Notes7" Text="您没有编写模板的权限，不过您可以查看此模板杰编辑样表"   runat=server></XS:Notes>
            <asp:TextBox    ID="txtMaster" TextMode="MultiLine" Width="700" Height="400" runat="server"></asp:TextBox>
        </div>
  <asp:Literal ID="llTagEnd" runat="server"></asp:Literal>
  <br />
  <div> 
       <span style=" float:left"> 
       <div>
            皮肤名称： <XS:TextBoxVl ID="txtThemeName"  IsAllowNull="false" ValidateType="不作验证" Width="150" runat="server" /></span>
      
          验证码： <XS:TextBox ID="txtSafeCoder" runat="server" Width="80" CanBeNull="必填" ></XS:TextBox>
           <asp:Image ID="ImageCheck" runat="server" onClick="this.src+=Math.random()" style="cursor:pointer;" ImageUrl="/ValidateCode.ashx?"  ToolTip="图片看不清？点击重新得到验证码,不区分大小写!红色数字,黑色字母!"></asp:Image>
       </div>
       <div>
       
        <XS:Button ID="bntSave" OnClick="btnSave_Click" runat="server" Text=" 保 存 "  OnClientClick="TipsAutoClose(this,'正在处理...')"  />
        &nbsp;&nbsp;&nbsp;
        <XS:Button ID="bntSaveApp" OnClick="btnSaveApp_Click" runat="server" Text=" 保存并应用 "  OnClientClick="TipsAutoClose(this,'正在处理...')"  />
       
       </div>
      
  </div>

    </form>
</body>
</html>
