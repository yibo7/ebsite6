<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="IndexManager.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Lucene.IndexManager" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 "> 
                <div class="boxheader">
                    <h3>索引创建配置</h3>
                </div>
        <br />
                <div class="alert alert-success">目前索引只尖对内容表（包括分表，请到：网站管理-内容管理-数据调整-选择分表作为 搜索、排行、专题、标签 的数据源，选择要生成的索引的分表）。</div>

                <table class="table">
                    <tr>
                        <td class="form-inline">
                            <XS:DropDownList AppendDataBoundItems="True" HintInfo="目前不支持自定义字段,其中ID与ClassID默认已经选择,可以直接在前台搜索模板直接调用" ID="drpContentFileds" runat="server">
                                <asp:ListItem Value="" Text="选择字段"></asp:ListItem>
                            </XS:DropDownList>
                             &nbsp;
                            <XS:DropDownList ID="drpSearchType" runat="server">
                                <asp:ListItem Value="1" Text="分词搜索且能存取"></asp:ListItem>
                                <asp:ListItem Value="2" Text="分词搜索但不能存取"></asp:ListItem>
                                <asp:ListItem Value="3" Text="不可搜索但能存取,如Url"></asp:ListItem>
                                <asp:ListItem Value="4" Text="整词搜索且能存取"></asp:ListItem>
                                <asp:ListItem Value="5" Text="整词搜索但不能存取"></asp:ListItem>
                            </XS:DropDownList>
                             &nbsp;
                            <XS:Button ID="bntAddFiled" runat="server" Text="添加字段"
                                OnClick="bntAddFiled_Click" />
                        </td>
                        <td></td>
                    </tr>
                    <tr>

                        <td colspan="2">
                             
                                <XS:GridView ID="gdList" runat="server" AutoGenerateColumns="false" DataKeyNames="ID">
                                    <Columns>
                                        <asp:TemplateField HeaderText="字段名称" ItemStyle-CssClass="gvfisrtTD">
                                            <ItemTemplate>
                                                <%#Eval("FieldName")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="字段类型" DataField="FieldType" />
                                        <asp:BoundField HeaderText="搜索类型" DataField="SearchTypeName" />
                                        <asp:TemplateField HeaderText="操作">
                                            <ItemTemplate>
                                                <XS:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("id") %>' CommandName="DeleteModel" confirm="true" Text="删除"></XS:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </XS:GridView>
                         

                        </td>
                    </tr>

                </table>
                <br />
                <XS:Button ID="bntSave" runat="server" Text="生成所有索引" OnClick="bntSave_Click" />
                <br />
                <asp:Label runat="server" ID="lbTips"></asp:Label> 
                <br />
    </div>
 </div>

<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
            <div class="boxheader">
                <h3>索引搜索字段配置</h3>
             </div> 
        <br />
             <div class="alert alert-success">指定搜索哪个字段，设置多个字段在搜索时目前采用 and 连接方式。</div>
                <table style="width: 100%;">
                    <tr>
                        <td class="form-inline">
                            <XS:DropDownList AppendDataBoundItems="True" ID="drpContentFileds2" runat="server">
                                <asp:ListItem Value="" Text="选择字段"></asp:ListItem>
                            </XS:DropDownList>
                             &nbsp;
                            <XS:Button ID="bntAddFiledForSearch" runat="server" Text="添加字段"
                                OnClick="bntAddFiledForSearch_Click" />
                        </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <div style="margin-top: 20px;">
                                <asp:ListBox ID="lsbSearchFields" SelectionMode="Multiple" Width="220" Height="220" runat="server"></asp:ListBox>
                            </div>

                            <div style="margin-top: 20px;">
                                <XS:Button ID="bntDelSearchField" runat="server" Text="删除所选字段"
                                    OnClick="bntDelSearchField_Click" />
                            </div>
                            <br />
                        </td>
                    </tr>

                </table>
    </div>
 </div>

  
<br />
