<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LayoutPaneAdd.ascx.cs" Inherits="EbSite.Modules.UserBaseInfo.AdminPages.Controls.Splace.LayoutPaneAdd" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>

<asp:PlaceHolder ID="phCtrList" runat="server">
     <div class="row m-t-15">
    <div class="col-sm-12">
        <div class="card-box">
            <h4 class="m-t-0 m-b-20 header-title"><b>添加/修改版式</b></h4>
            <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            版式名称:
                        </td>
                        <td>
                        
                            <XS:TextBoxVl ID="LayoutName" IsAllowNull="false" runat="server"   ></XS:TextBoxVl>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            文件名称:
                        </td>
                        <td>
                            <XS:TextBoxVl ID="FileName" runat="server"    IsAllowNull="false"  ></XS:TextBoxVl>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            上传版式图:
                        </td>
                         <td>
                        <XS:SWFUpload  SaveFolder="ModeleTem" HintInfo="以.jpg为后缀的图片文件" ID="puICOImg" AllowSize="10024" AllowExt="jpg" runat="server"></XS:SWFUpload>
                    </td>
                    </tr>  
                    
                    
                </table>
        </div>
    </div>
</div>
</asp:PlaceHolder>
<div style="text-align: center">
    <XS:Button ID="bntSave" runat="server"  Text=" 保存 " />
</div>
