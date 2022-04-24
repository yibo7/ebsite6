<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="edit.ascx.cs" Inherits="EbSite.Modules.Shop.Widgets.MobileFlash.edit" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>


 标题:<XS:TextBoxVl ID="txtTitle" Width="300"    runat="server"></XS:TextBoxVl><br />
图片路径:<XS:SWFUpload SaveFolder="ModeleTem" HintInfo="文件以jpg,gif,png为后缀" ID="txtPath"
    AllowSize="10024" AllowExt="jpg,gif,png" runat="server"></XS:SWFUpload> 320*148
<br>
连接地址:<XS:TextBoxVl ID="txtUrl" Width="300"    runat="server"></XS:TextBoxVl><br />
<br />
<asp:Button ID="bntAddOne" runat="server" Text=" 添 加 "    OnClick="bntAddOne_Click" />
<br />
<br />
<div>
    <div class="gdList_title" style="width: 900px;">
        <div style="width: 200px;">
            名称</div>
        <div style="width: 400px;">
            图片地址
        </div>
        <div style="width: 150px;">
            连接</div>
        <div style="width: 100px;">
            操作
        </div>
    </div>
    <XS:Repeater ID="rpList" runat="server" OnItemCommand="gdList_ItemCommand">
        <itemtemplate>
            <div class="gdListContent">
                <div style="width: 200px;">
                    <%#Eval("name") %></div>
                <div style="width: 400px;">
                    <%#Eval("picurl") %></div>
                <div style="width: 150px;">
                    <%#Eval("url") %></div>  
                <div  style="width:150px;">
                        <XS:LinkButton ID="lbEdit" runat="server" CommandArgument='<%#Eval("id") %>'   CommandName="EditModel"  Text="删除">
                            <img title="编辑" src="<%=IISPath %>images/edit.gif" />
                        </XS:LinkButton>
                       <XS:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("id") %>' OnClientClick="javascript:return confirm('您确定要删除该项么?')"  CommandName="DeleteModel"  Text="删除">
                            <img title="删除内容" src="<%=IISPath %>images/delete.gif" />
                        </XS:LinkButton>
                </div>
            </div>
        </itemtemplate>
    </XS:Repeater>
</div>
<br />
