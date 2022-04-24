<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Edit.ascx.cs" Inherits="EbSite.ExtensionsCtrls.TextBox.Edit" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>

文本框类型:
<XS:DropDownList ID="drpBoxType" runat="server">
    <asp:ListItem Value="0" Text="单行文本框"></asp:ListItem>
    <asp:ListItem Value="1" Text="多行文本框"></asp:ListItem>
</XS:DropDownList><br><br>
文本框的高:
<XS:TextBox ID="txtHeight" Width="50" runat="server"></XS:TextBox><br><br>
文本框的宽:
<XS:TextBox ID="txtWidth" Width="50" runat="server"></XS:TextBox><br><br>
是否可为空: <XS:DropDownList runat="server"    ID="drpCanNull">
                <asp:ListItem Text="可为空" Value="可为空"></asp:ListItem>
                <asp:ListItem Text="必填" Value="必填"></asp:ListItem>
            </XS:DropDownList> <br><br>
值的验证类型:<XS:DropDownList runat="server"    ID="drpRequiredFieldType">
                                                    <asp:ListItem Value="0" Text="不作验证" ></asp:ListItem>
                                                    <asp:ListItem Value="1" Text="金额" ></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="电子邮箱email" ></asp:ListItem>
                                                    <asp:ListItem Value="3" Text="手机号" ></asp:ListItem>
                                                    <asp:ListItem Value="4" Text="QQ号" ></asp:ListItem>
                                                    <asp:ListItem Value="5" Text="网址Url" ></asp:ListItem>
                                                    <asp:ListItem Value="6" Text="正整数" ></asp:ListItem>
                                                    <asp:ListItem Value="7" Text="IP地址" ></asp:ListItem>
                                                    <asp:ListItem Value="8" Text="身份证" ></asp:ListItem>
                                                    <asp:ListItem Value="9" Text="邮政编码" ></asp:ListItem>
                                                    <asp:ListItem Value="10" Text="电话号码加区号" ></asp:ListItem>                                                    
                                                    <asp:ListItem Value="11" Text="账号字母开头数字下划线" ></asp:ListItem>
                                                    <asp:ListItem Value="12" Text="匹配正整数" ></asp:ListItem>
                                                    <asp:ListItem Value="13" Text="负整数" ></asp:ListItem>
                                                    <asp:ListItem Value="14" Text="整数" ></asp:ListItem>
                                                    <asp:ListItem Value="15" Text="大于等于0整数包括0" ></asp:ListItem>
                                                    <asp:ListItem Value="16" Text="小于等于0整数包括0" ></asp:ListItem>
                                                    <asp:ListItem Value="17" Text="匹配正浮点数" ></asp:ListItem>
                                                    <asp:ListItem Value="18" Text="匹配负浮点数" ></asp:ListItem>
                                                    <asp:ListItem Value="19" Text="匹配由26个英文字母组成的字符串" ></asp:ListItem>
                                                    <asp:ListItem Value="20" Text="匹配由26个英文字母的大写组成的字符串" ></asp:ListItem>
                                                    <asp:ListItem Value="21" Text="匹配由26个英文字母的小写组成的字符串" ></asp:ListItem>
                                                    <asp:ListItem Value="22" Text="匹配由数字和26个英文字母组成的字符串" ></asp:ListItem>
                                                    <asp:ListItem Value="23" Text="匹配由数字26个英文字母或者下划线组成的字符串" ></asp:ListItem>
                                                    <asp:ListItem Value="24" Text="日期格式为yyyy-mm-dd" ></asp:ListItem>
                                                    <asp:ListItem Value="25" Text="禁止输入特殊字符" ></asp:ListItem>
                                                    
                                               </XS:DropDownList>
                                               <br>
                                               默认值:
<XS:TextBox ID="txtDefaultValue" Width="300" runat="server"></XS:TextBox>
