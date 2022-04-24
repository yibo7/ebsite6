<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="edit.ascx.cs" Inherits="EbSite.Widgets.SpecialContent.edit" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
 <table id="tbSetConfigs" >
                    <tr>
                        <td >调用记录条数:</td>
                        <td >
                             <XS:TextBoxVl   ID="txtCount"    ValidateType="匹配正整数" IsAllowNull="False" runat="server"></XS:TextBoxVl>                         
                        </td>
                     </tr>
                        <tr>
                        <td >数据类型:</td>
                        <td >
                            
                        <XS:DropDownList ID="drpDataType"     runat="server">
                            <asp:ListItem Value="0">全部</asp:ListItem>
                            <asp:ListItem Value="1">推荐</asp:ListItem>
                            <asp:ListItem Value="2">有图片</asp:ListItem>
                            <asp:ListItem Value="3">有标签</asp:ListItem>
                        </XS:DropDownList>     
                                     
                        </td>
                     </tr>
                     <tr>
                        <td >排序方式:</td>
                        <td >
                            
                        <XS:DropDownList ID="drpOrderType"     runat="server">
                            <asp:ListItem Value="0">最新</asp:ListItem>
                            <asp:ListItem Value="1">最老</asp:ListItem>
                            <asp:ListItem Value="2">访问最多</asp:ListItem>
                            <asp:ListItem Value="3">今日访问最多</asp:ListItem>
                             <asp:ListItem Value="4">本周访问最多</asp:ListItem>
                             <asp:ListItem Value="5">本月访问最多</asp:ListItem>
                             <asp:ListItem Value="6">评论最多</asp:ListItem>
                             <asp:ListItem Value="7">收藏最多</asp:ListItem>
                           <%-- <asp:ListItem Value="8">随机</asp:ListItem>--%>
                        </XS:DropDownList>     
                                    
                        </td>
                     </tr>
                      <tr>
                        <td >数据模板:</td>
                        <td > 
                                     
                        <XS:ExtensionsCtrls ID="drpTemMoreList"   ModelCtrlID="e878b3c7-6edc-466a-95da-61cb910cec68" runat="server"/>
                                     
                        </td>
                     </tr> 
                 </table>
 


