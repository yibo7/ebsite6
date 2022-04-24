<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="edit.ascx.cs" Inherits="EbSite.Widgets.ClassListMore.edit" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>

选择要显示的分类:<br><br>自动适应分类ID<asp:CheckBox AutoPostBack="true" ID="IsAptID" runat="server" 
    oncheckedchanged="IsAptID_CheckedChanged" />
<br><br>
<asp:ListBox ID="cblClass" Height="200" SelectionMode="Multiple"  runat="server">    
</asp:ListBox>
<br />
 或指定分类ID:<XS:TextBox HintInfo="超过500个分类时，不能列表出来，只能指定子分类ID" ID="txtIDs" Width="100" runat="server"></XS:TextBox>(多个ID用逗号分开)
         
<br /><br />
调用类别:<XS:DropDownList ID="drpType" runat="server">
            <asp:ListItem Value="1" Text="最新数据列表"></asp:ListItem>
            <asp:ListItem Value="2" Text="推荐数据列表"></asp:ListItem>
            <asp:ListItem Value="3" Text="总点击率排行"></asp:ListItem>
            <asp:ListItem Value="4" Text="本周点击率排行"></asp:ListItem>
            <asp:ListItem Value="5" Text="收藏率排行"></asp:ListItem>
         </XS:DropDownList>
         <br /><br />
多列表自定义模板(分类):
<XS:ExtensionsCtrls ID="drpTemMoreList"   ModelCtrlID="71579f18-a40c-42fb-aa8c-73ee820ad3f3" runat="server"/>
         <br /><br />
         <div style=" background:#ccc; margin:10px;" onclick="oncheckcontentmodel(this)" >       
                <asp:RadioButtonList  ID="rbListSubClassOrContent"  RepeatColumns="2" runat="server">
                    <asp:ListItem Text="获取分类下的内容" Selected="True" Value="0"></asp:ListItem>
                    <asp:ListItem Text="获取分类下的子分类" Value="1"></asp:ListItem>
                </asp:RadioButtonList>  
           </div>        
     
    <div id="mcontent" >
            <br />
         数据列表模式:
        <XS:DropDownList ID="drpListModel" runat="server">
                    <asp:ListItem Value="1" Text="只列表标题"></asp:ListItem>
                    <asp:ListItem Value="2" Text="左栏图片右栏标题"></asp:ListItem>
                    <asp:ListItem Value="3" Text="左栏标题右栏图片"></asp:ListItem>
         </XS:DropDownList>
         <br /><br />
         <div></div>
是否显示序号:<asp:CheckBox ID="cbIsShowNum" runat="server" /><br /><br />
是否调用子分类下的数据:<asp:CheckBox ID="cbIsGetSub" runat="server" />

                                    
(可以为空)
<br /><br />
标题列表自定义模板（内容）:
<XS:ExtensionsCtrls ID="drpTemTitle"   ModelCtrlID="e878b3c7-6edc-466a-95da-61cb910cec68" runat="server"/>
                                    
(可以为空)
<br /><br />
图片列表自定义模板（内容）:
<XS:ExtensionsCtrls ID="drpTemImg"   ModelCtrlID="e878b3c7-6edc-466a-95da-61cb910cec68" runat="server"/>
(可以为空)
<br /><br />
标题列表条数:<XS:TextBox ID="txtCountTitle" CanBeNull="必填" RequiredFieldType="数据校验" Width="50" runat="server">12</XS:TextBox>
<br /><br />
图片列表条数:<XS:TextBox ID="txtCountImg" CanBeNull="必填" RequiredFieldType="数据校验" Width="50" runat="server">3</XS:TextBox>

<br><br />
使用说明:<br>
 如果您想更改数据展示方式,请自定义数据模板,自定义模板这里使用相对路径,<br />
 如你上传一个数据模板在网站根目录下,<br />
 名为test.ascx,输入/test.ascx即可,<br />
 制作模板时可调用字段(具体意义查看模型):
         id;
         smallpic;
         newstitle;
         titlestyle;
         classid;
         hits;
         isgood;
         contentinfo;
         dayhits;
         weekhits;
         monthhits;
         lasthitstime<br />
         tagids;
         userid;
         orderid;
         htmlname;
         contenttemid;
         contenthtmlnamerule;
         markismakehtml;
         iscomment;
         addtime;
         username;
         annex1;<br />
         annex2;
         annex3;
         annex4;
         annex5;
         annex6;
         annex7;
         annex8;
         annex9;
         annex10;
         ClassName;
    </div>

      <div id="msubclass" style=" display:none;" >
        
自定义分类模板:
<XS:ExtensionsCtrls ID="drpTemSubClass"   ModelCtrlID="71579f18-a40c-42fb-aa8c-73ee820ad3f3" runat="server"/>
<br /><br />
调用条数：
<XS:TextBox ID="txtCountSubClass" CanBeNull="必填"  Width="50" runat="server">12</XS:TextBox>
<br /><br />
排放方式:<XS:DropDownList ID="drpOrderBySubClass" runat="server">
            <asp:ListItem Value="z" Text="按排序ID排序"></asp:ListItem>
            <asp:ListItem Value="n" Text="最新数据列表"></asp:ListItem>
            <asp:ListItem Value="a" Text="总点击率排行"></asp:ListItem>
            <asp:ListItem Value="d" Text="今天点击率排行"></asp:ListItem>
            <asp:ListItem Value="w" Text="本周点击率排行"></asp:ListItem>
            <asp:ListItem Value="m" Text="本月点击率排行"></asp:ListItem>
         </XS:DropDownList>

      </div>

  <br>  
         <script>
             function oncheckcontentmodel(ob) {

                 $(ob).find("input[type=radio]").each(
		        function (i) {
		            if (this.checked) {
		                if (this.value == "1") {
		                    $("#msubclass").show();
		                    $("#mcontent").hide();
		                }
		                else {
		                    $("#mcontent").show();
		                    $("#msubclass").hide();
		                }
		            }
		        }
		        );
            }
         </script>