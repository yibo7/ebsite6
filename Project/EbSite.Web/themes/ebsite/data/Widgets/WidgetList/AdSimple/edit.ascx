<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="edit.ascx.cs" Inherits="EbSite.Widgets.Simple.edit" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>

<asp:RadioButtonList ID="rblLinkType"  RepeatColumns="2" AutoPostBack="True" EnableViewState="True"
      RepeatDirection="Vertical" runat="server" OnSelectedIndexChanged="rblLinkType_SelectedIndexChanged">
   <asp:ListItem Selected="True" Value="0">图片连接</asp:ListItem>
   <asp:ListItem  Value="1">文字连接</asp:ListItem>
</asp:RadioButtonList>
列表模板:<XS:DropDownList ID="drCustomTem"   AppendDataBoundItems="true" runat="server">
                    <asp:ListItem Text="默认模板" Value=""></asp:ListItem></XS:DropDownList>
<br/><br/>
<asp:PlaceHolder ID="phImg" runat="server">
图片路径:
<XS:UploadImg  SaveFolder="ModeleTem" HintInfo="文件以jpg,gif,png为后缀" ID="txtImg" AllowSize="10024" Width="300" AllowExt="jpg,gif,png" runat="server"></XS:UploadImg>
</asp:PlaceHolder>
 
<asp:PlaceHolder ID="phTitle" runat="server">
连接文本:<XS:TextBox ID="txtTitle" Width="300" runat="server"></XS:TextBox>
    </asp:PlaceHolder>
<br><br>
连接地址:<br>
<XS:TextBox ID="txtUrl" Width="300"  runat="server"></XS:TextBox><br /><br>
简介:<br>
<XS:TextBox ID="txtInfo" Width="500" Height="200" TextMode="MultiLine"  runat="server"></XS:TextBox>
<br /><br>
备注1:<br>
<XS:TextBox ID="txtPram1" Width="500" Height="100" TextMode="MultiLine"   runat="server"></XS:TextBox>
<br /><br>
备注2:<br>
<XS:TextBox ID="txtPram2" Width="500" Height="100" TextMode="MultiLine"  runat="server"></XS:TextBox>
<br><br>
<asp:Button ID="bntAddOne" runat="server"  Text="   添  加   " onclick="bntAddOne_Click" />
 <br /> <br>
<div>
    <XS:GridView ID="gvData" runat="server"                            
                                    DataKeyNames="id"                                                                   
                                  AutoGenerateColumns="False" 
                                  EnableViewState="true"
                                   IsShowSWPages="false"    
                                   onrowcommand="gvData_RowCommand"  
                                    Width="800"                 
                            >                             
                              <Columns>                            
                                   
                                    <asp:TemplateField HeaderText="图片">
                                         <ItemTemplate>       
                                                <img height="60" src="<%#Eval("imgpth") %>"/>
                                         </ItemTemplate>
                                   </asp:TemplateField>  
                                  <asp:BoundField HeaderText="连接文本" DataField="txttitle" />     
                                    <asp:BoundField HeaderText="连接地址" DataField="url" />                                  
                                     <asp:TemplateField HeaderText="操作">
                                         <ItemTemplate>       
                                                    <XS:LinkButton  ID="LinkButton2" CommandArgument='<%#Eval("id") %>' CommandName="modifymodel" Text="修改" confirm="false" runat="server"></XS:LinkButton>
                                                    <XS:LinkButton  ID="LinkButton1" CommandArgument='<%#Eval("id") %>' CommandName="deletemodel" Text="删除" runat="server"></XS:LinkButton>
                                    
                                         </ItemTemplate>
                                   </asp:TemplateField>     
                                 
                            </Columns>                           
                            
</XS:GridView>
</div>
<br />
<asp:PlaceHolder ID="phImgWH" runat="server">
<div style=" padding-top:15px;">

宽度:<XS:TextBox ID="txtWidth" Width="50"  runat="server"></XS:TextBox>
&nbsp;&nbsp;
高度:<XS:TextBox ID="txtHeith" Width="50"  runat="server"></XS:TextBox>
</div>
</asp:PlaceHolder>
<br /><br />
模板绑定字段说明:<br />
图片地址:imgpth<br />
链接地址:url<br />
链接标题:txttitle<br />
简介:Info<br />
备注1:Pram1<br />
备注2:Pram2

