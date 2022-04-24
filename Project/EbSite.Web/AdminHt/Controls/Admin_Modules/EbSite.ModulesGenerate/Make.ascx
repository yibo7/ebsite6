<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Make.ascx.cs" Inherits="EbSite.ModulesGenerate.Make" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>

<style>
    .WizardStyle{ }
    .WizardStyle table td{ padding-left:5px; height:30px; }
    
    .btn{ color:Red;}
</style>
<script type="text/javascript" language="javascript">

    function checkBoxValidate() {
        var chk1 = document.getElementById("RadDB1");//不显示
        var chk2 = document.getElementById('RadDB2');
        if (chk1.checked) {
            document.getElementById("<%=DbType.ClientID %>").style.display = 'none';
            document.getElementById("<%=HiddenField1.ClientID %>").value = "0";    //不显示   
        }
        else {
            document.getElementById("<%=DbType.ClientID %>").style.display = 'block';
            document.getElementById("<%=HiddenField1.ClientID %>").value = "1";   
        }
        if (chk2.checked) {
            document.getElementById("<%=DbType.ClientID %>").style.display = 'block';
            document.getElementById("<%=HiddenField1.ClientID %>").value = "1";
        }
        else {
            document.getElementById("<%=DbType.ClientID %>").style.display = 'none';
            document.getElementById("<%=HiddenField1.ClientID %>").value = "0";   
        }
    }
    
</script>
<div class="admin_toobar">
    <fieldset>
        <legend>模块项目生成器 </legend>
        <div class="WizardStyle" style=" padding:10px;">
        <asp:Wizard ID="wdMake" StepNextButtonText="下一步"   runat="server" 
                ActiveStepIndex="0" BackColor="#EFF3FB" 
            BorderColor="#B5C7DE" BorderWidth="1px"  Width="800" 
                onfinishbuttonclick="wdMake_FinishButtonClick" 
                onactivestepchanged="wdMake_ActiveStepChanged" 
                onnextbuttonclick="wdMake_NextButtonClick" >
            <SideBarButtonStyle BackColor="#507CD1"   ForeColor="White" />
            <SideBarStyle BackColor="#507CD1" VerticalAlign="Top"  Width="180" />
            <WizardSteps>
                <asp:WizardStep   ID="WizardStep1" runat="server" Title="选择数据库">
                    项目的生成可能比较占用资源，此项工作适合在二次开发环境下使用，如果您的网站正在服务器上运行，我们建议您在本地做个备份来生成<br><br>
                   
                    <input id="RadDB1" type="radio"  value="0" title="本系统数据库"  name="1" onclick="checkBoxValidate();"/> 本系统数据库
                    <input id="RadDB2" type="radio"   checked="checked"  value="1" name="1" onclick="checkBoxValidate();"/>第三方数据库<br>
                    <asp:HiddenField  ID="HiddenField1" runat="server" />
                   <div id="DbType" runat="server" visible="true">
                    请选择数据库类型:<br><br>
                    <XS:DropDownList ID="drpDbType" runat="server" >                            
                        <asp:ListItem Value="SQL2005"  Text="SqlServer2005-2008"></asp:ListItem>
                        <asp:ListItem Value="SQL2000" Text="SqlServer2000"></asp:ListItem>
                        <asp:ListItem Value="OleDb" Text="Access(OleDb)"></asp:ListItem>                                                    
                    </XS:DropDownList>
                    </div>
                </asp:WizardStep>
                <asp:WizardStep ID="WizardStep2" runat="server" Title="设置数据库参数">
                 <table>
                                        <tr id="dbconfigs" runat="server">
                                            <td colspan="2">
                                                <table>
                                                    <tr>
                                                        <td>服务器：</td>
                                                        <td><XS:TextBoxVl  ID="txtServer" Width="120"  runat="server">127.0.0.1</XS:TextBoxVl ></td>
                                                    </tr>
                                                    <tr>
                                                        <td>身份验证：</td>
                                                        <td>
                                                            <XS:DropDownList onchange="OnVlType(this)" ID="drpVlType" runat="server">
                                                                <asp:ListItem Text="Windows 身份验证" Value="0"></asp:ListItem>
                                                                <asp:ListItem Selected="True" Text="Sql Server 身份验证" Value="1"></asp:ListItem>
                                                            </XS:DropDownList>
                                                        </td>
                                                    </tr>
                                                     <tr id="trDBUser">
                                                        <td>登录帐号：</td>
                                                        <td><XS:TextBoxVl  ID="txtDBUser" Width="100" Msg="SqlServer数据的登录帐号"  runat="server">sa</XS:TextBoxVl ></td>
                                                    </tr>
                                                    <tr id="trDBPass">
                                                        <td>密码：</td>
                                                        <td><XS:TextBoxVl  ID="txtDBPass" Width="200" Msg="SqlServer数据的登录密码"  runat="server"></XS:TextBoxVl ></td>
                                                    </tr>
                                                    <tr>
                                                        <td>数据库名称：</td>
                                                        <td>
                                                            <XS:DropDownList ID="drpDataBase" runat="server">
                                                                <asp:ListItem Text="选择数据库" Value=""></asp:ListItem>
                                                            </XS:DropDownList>
                                                            <asp:Button ID="bntConn" runat="server" Text="测试连接" OnClick="bntConn_Click" />
                                                        </td>
                                                    </tr>
                                                    
                                                </table>
                                           
                                            </td>                                          
                                        </tr>
                                        <tr id="dbconfiga"  runat="server">
                                            <td>数据库路径:</td>
                                            <td>
                                                <XS:TextBoxVl  ID="txtDBPath" Width="300" HintInfo="这里请输入Access文件的相对路径,如/db/ebsite.mdb"  runat="server"></XS:TextBoxVl >
                                            </td>
                                        </tr>
                                    </table>
                </asp:WizardStep>
                <asp:WizardStep ID="WizardStep3" runat="server"  Title="选择数据表">
                    请选择数据表:<br><br>
                    <XS:ListBox ID="lbTables" SelectionMode="Multiple" Width="200" Height="300" runat="server"></XS:ListBox>
                </asp:WizardStep>
                <asp:WizardStep ID="WizardStep4" runat="server"  Title="选择字段">
                   
                    <XS:Warning ID="Notes"  Text="这里是您选择要生成模块的表，其中主健必须是【id】！"  runat="server"></XS:Warning>
                    <XS:GridView ID="gdList" Width="500px"  runat="server" AutoGenerateColumns="false" >
                        <Columns>
                            <asp:TemplateField HeaderText="表名称" ItemStyle-CssClass="gvfisrtTD">
                                <ItemTemplate>
                                    <%#Eval("Text")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="字段设置">
                                <ItemTemplate>
                                    <XS:EasyuiDialog ID="wb1" class="btn" runat="server" Href='<%# string.Concat("?t=10&tbn=",Eval("Text"),"&dbn=",drpDataBase.SelectedValue)%>'
                                         IsFull="true" Text="添加字段" Title="选择可添加字段" />   
                                         |
                                    <XS:EasyuiDialog ID="wb2" runat="server" Href='<%# string.Concat("?t=11&tbn=",Eval("Text"),"&dbn=",drpDataBase.SelectedValue)%>'
                                         IsFull="true" Text="列表字段" Title="选择列表字段" />
                                         |
                                    <XS:EasyuiDialog ID="wb3" runat="server" Href='<%# string.Concat("?t=12&tbn=",Eval("Text"),"&dbn=",drpDataBase.SelectedValue)%>'
                                         IsFull="true" Text="查看字段" Title="选择查看字段" />  
                                         |
                                    <XS:EasyuiDialog ID="wb5" runat="server" Href='<%# string.Concat("?t=19&tbn=",Eval("Text"),"&dbn=",drpDataBase.SelectedValue)%>'
                                         IsFull="true" Text="搜索字段" Title="选择查看字段" /> 
                                         |
                                    <XS:EasyuiDialog ID="wb4" runat="server" Href='<%# string.Concat("?t=13&tbn=",Eval("Text"),"&dbn=",drpDataBase.SelectedValue)%>'
                                         IsFull="true" Text="高级搜索字段" Title="选择查看字段" />                                       
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </XS:GridView>
                </asp:WizardStep>
                <asp:WizardStep ID="WizardStep5" runat="server" Title="设置项目参数">
                    <table cellpadding="0" cellspacing="0">                
                    <tr>
                        <td>架构:</td>
                        <td>
                            <XS:DropDownList  ID="droType" runat="server">
                                <asp:ListItem Text="简单三层" Value="S3"></asp:ListItem>
                                <asp:ListItem Text="工厂三层" Value="F3"></asp:ListItem>
                                <asp:ListItem Text="不使用数据库" Value="xml"></asp:ListItem>
                            </XS:DropDownList>
                        </td>
                        <td>
                         </td>
                    </tr>
                    <tr>
                        <td>项目中文名称</td>
                        <td>
                            <XS:TextBoxVl  ID="txtCnTitle" IsAllowNull=false runat="server"></XS:TextBoxVl >
                        </td>
                        <td>
                       
                        </td>
                    </tr>
                    <tr>
                        <td>项目英文名称</td>
                        <td>
                            <XS:TextBoxVl  ID="txtEnTitle" Msg="将以此名称命名项目文件,如EbSite.Modules.Shop中的Modeles" IsAllowNull=false runat="server"></XS:TextBoxVl >
                        </td>
                        <td>
                       
                        </td>
                    </tr>
                    <tr>
                        <td>开发者</td>
                        <td>
                            <XS:TextBoxVl  ID="Author" Msg="开发人，或开发单位" IsAllowNull=false runat="server"></XS:TextBoxVl >
                        </td>
                        <td>
                       
                        </td>
                    </tr>
                    <tr>
                        <td>开发者网站</td>
                        <td>
                            <XS:TextBoxVl  ID="AuthorUrl" Msg="开发人，或开发单位的网站地址"  runat="server"></XS:TextBoxVl >
                        </td>
                        <td>
                       
                        </td>
                    </tr>
                    <tr>
                        <td>版本号</td>
                        <td>
                            <XS:TextBoxVl  ID="Version" Msg="版本号,如 1.0.0"  runat="server">1.0.0</XS:TextBoxVl >
                        </td>
                        <td>
                       
                        </td>
                    </tr>
                    <tr>
                        <td>去掉表前缀</td>
                        <td>
                            <XS:TextBoxVl  ID="txtTabpre" width="50" runat="server"></XS:TextBoxVl >
                        </td>
                        <td>
                       
                        </td>
                    </tr>
                    <tr>
                        <td>vs版本</td>
                        <td>
                            <XS:RadioButtonList ID="rblVS" runat="server">
                                <asp:ListItem Text="vs2008" Value="2008"></asp:ListItem>
                                <asp:ListItem Text="vs2010" Selected="True" Value="2010"></asp:ListItem>
                            </XS:RadioButtonList>                             
                            <asp:CheckBox ID="cbIsMakeAscx" Checked="true" Text="是否同时生成页面文件" runat="server" />
                        </td>
                        <td>
                       
                        </td>
                    </tr>
                    </table>

                </asp:WizardStep>
                 <asp:WizardStep ID="WizardStep6" runat="server" Title="完成">
                    
                </asp:WizardStep>
            </WizardSteps>
        </asp:Wizard>           
           
        </div>
    </fieldset>
</div>
<script>

    function OnVlType(ob)
    {
        var sv = get_selected_value(ob);
        if (sv == 0) {
            $("#trDBUser").hide();
            $("#trDBPass").hide();
        }
        else {
            $("#trDBUser").show();
            $("#trDBPass").show();
        }
    }

</script>