<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Configs.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Lucene.Configs" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
 
<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
            <div class="boxheader">
                <h3>分词测试</h3>
                <div>                    
                采用搜索插件:<asp:Literal ID="llSearchPlugin" runat="server"></asp:Literal>
                </div>
            </div>
            <div class="content">
                
				<div>
                    输入需要分词的内容：
                </div>
            <div>
                <asp:TextBox Width="100%" Height="300" TextMode="MultiLine" ID="txtContent" runat="server"></asp:TextBox>
            </div>
            <br />
            <div>
                过滤字数：
                <asp:TextBox Width="50" ID="txtNum" runat="server">0</asp:TextBox>(0表示不过滤,输入3表示分词的字数大于等于3)
            </div>
            <br />
            <div>
                返回词数：
                <asp:TextBox Width="50" ID="txtTop" runat="server">0</asp:TextBox>(0表示返回所有分词)
            </div>
            <br />
            <div>

                <XS:Button ID="bntSave" runat="server" Text="测试分词" />
            </div>
            <br />
            <br />
            <div>
                结果：
            </div>
            <br />
            <br />
            <div>
                <asp:Literal ID="llRz" runat="server"></asp:Literal>
            </div>
            </div>
    </div>
</div>