<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="edit.ascx.cs" Inherits="EbSite.Widgets.BannerPic.edit" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>

添加幻灯片:<br>
图片路径:
<XS:SWFUpload  SaveFolder="ModeleTem" HintInfo="文件以jpg,gif,png为后缀" ID="txtPath" AllowSize="10024" AllowExt="jpg,gif,png" runat="server"></XS:SWFUpload>
<br>
连接地址:<XS:TextBox ID="txtUrl" Width="300"  runat="server"></XS:TextBox><br /><br />
文字说明:<XS:TextBox ID="txtTitle" Width="300"  runat="server"></XS:TextBox><br /><br />
<asp:Button ID="bntAddOne" runat="server" Text=" 添 加 " 
    onclick="bntAddOne_Click" />
 <br /><br />
<div>
    <XS:GridView ID="gvData" runat="server"                            
                                    DataKeyNames="id"                                                                   
                                  AutoGenerateColumns="False" 
                                  EnableViewState="true"
                                   IsShowSWPages="false"    
                                   onrowcommand="gvData_RowCommand"  
                                    Width="600"                 
                            >                             
                              <Columns>                            
                                   <asp:BoundField HeaderText="图片路径" DataField="flashpath" />
                                    <asp:BoundField HeaderText="连接地址" DataField="url" />      
                                    <asp:BoundField HeaderText="标题" DataField="title" />                             
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
<div style=" padding-top:15px;">

宽度:<XS:TextBox ID="txtWidth" Width="50"  runat="server"></XS:TextBox>
&nbsp;&nbsp;
高度:<XS:TextBox ID="txtHeith" Width="50"  runat="server"></XS:TextBox>
    &nbsp;&nbsp;
速度:<XS:TextBox ID="txtSpeed" Width="50"  runat="server"></XS:TextBox>
</div>

