<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HtmlConfigs.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Configs.HtmlConfigs" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>修改静态页生成配置</h3>
            </div>
            <div class="content">
				<table>   
            <tr>              
                <td >
                    <%=Resources.lang.EBGeneratSpeed%>：             
                </td>
                <td>
                    <XS:TextBox ID="txtCreateSleep" RequiredFieldType="数据校验" runat="server" Width="50"></XS:TextBox>
                </td>
                
           </tr>
           
           <tr>     
                <td>
                    <%=Resources.lang.EBDftNOfTPg%>：        
                    </td>
                <td>
                    <XS:TextBox ID="txtDefualtName" runat="server" Width="80px"></XS:TextBox>
                    为空时表示不启用默认文档，否则将此名称连接在静态页面命名规则后面
                </td>
           </tr>
             
             <tr>
                <td>
                   <%=Resources.lang.EBTagListPath%>：         
                </td>
                <td>
                    <XS:TextBox ID="txtTagList" runat="server" Width="242px"></XS:TextBox>
                    
                </td>
                </tr>
             <tr>
                <td>
                    <%=Resources.lang.EBTagSearchPath%>：           
                </td>
                <td class="form-inline">
                    <XS:TextBox ID="txtTagSearch" HintInfo="支持{#KeyID#}与{#TitleSpell#}替换" runat="server" Width="242px"></XS:TextBox>
                    
                     &nbsp;&nbsp;
                    <XS:Button ID="btnTagSearchUpdateRule" runat="server" Text="更新到现在有数据" onclick="btnTagSearchUpdateRule_Click" />
                    <XS:Button ID="btnTagSearchMakeName" runat="server" Text="重新生成页面名称" ToolTip="如果数据量大很点资源"
                        onclick="btnTagSearchMakeName_Click"  />   
                        
                </td> 
             </tr>
             <tr>
                <td>
                   <%=Resources.lang.EBSptPage%>：         
                </td>
                <td>
                    <XS:TextBox ID="txtPageSplit" HintInfo="页码分隔符,如填写A，那么分页显示为A1,A2,A3..." runat="server" Width="50px"></XS:TextBox>
                    
                </td>
                </tr>
              <tr>
                 <td>
                   <%=Resources.lang.EBCateRule%>：            
                </td>
                <td class="form-inline">
                    <XS:UcReNameRule Width="350" ID="rnrClass" runat="server" />
                    &nbsp;&nbsp;
                    <%--<XS:Button ID="bntUpdateClassRule" runat="server" Text="更新到现在有数据" onclick="bntUpdateClassRule_Click" />--%>
                    <XS:Button ID="bntReMakeHtmlNameClass" runat="server" Text="重新生成页面名称" ToolTip="如果数据量大很点资源" onclick="bntReMakeHtmlNameClass_Click"  />   
                
                </td>              
           </tr>
            <tr>
                 <td>
                    <%=Resources.lang.EBCtntPgRule%>：
                 </td>
                <td class="form-inline">
                    <XS:UcReNameRule Width="350" ID="rnrContent" runat="server" />
                    &nbsp;&nbsp;
                    <%--<XS:Button ID="bntUpdateContentRule" runat="server"  Text="更新到现在有数据" onclick="bntUpdateContentRule_Click" />--%>    
                    <XS:Button ID="bntReMakeHtmlNameContent" runat="server" Text="重新生成页面名称" ToolTip="如果数据量大很点资源"
                        onclick="bntReMakeHtmlNameContent_Click"  />    
                </td>              
           </tr>
            <tr>
                 <td>
                    <%=Resources.lang.EBSpPgRule%>：
                 </td>
                <td class="form-inline">
                    <XS:UcReNameRule Width="350" ID="rnrSpecial" runat="server" />
                    &nbsp;&nbsp;
                    <XS:Button ID="bntUpdateSpecial" runat="server"  Text="更新到现在有数据" onclick="bntUpdateSpecial_Click" />    
                    <XS:Button ID="bntReMakeHtmlNameSpecial" runat="server" Text="重新生成页面名称" ToolTip="如果数据量大很点资源"
                        onclick="bntReMakeHtmlNameSpecial_Click"  />    
                </td>              
           </tr>
            <tr>
                <td colspan="2" style="padding: 10px;">
                     
                </td>
           </tr>   
           <tr >              
                <td >
                   
                    自动静态页面过期时间：          
                </td>
                <td class="form-inline">
                    <XS:TextBox ID="txtTimeSpan" runat="server" RequiredFieldType="数据校验" HintInfo="自动静态生成时判断页面过期的时间间隔，为0时不做判断" Width="50px"></XS:TextBox>
                    <XS:DropDownList ID="drpTimeSpanModel" runat="server">
                        <asp:ListItem Text="天" Value="0"></asp:ListItem>
                        <asp:ListItem Text="小时" Value="1"></asp:ListItem>
                        <asp:ListItem Text="分钟" Value="2"></asp:ListItem>
                    </XS:DropDownList>
                </td>
                
           </tr>
           
              
           <tr>
                <td colspan="2" style="text-align: center; padding-top:20px;">
                    
                     <XS:Button ID="bntSave" runat="server" Text="<%$Resources:lang,EBSaveConfig%>"  />

                </td>
           </tr>           
    </table>
            </div>
    </div>
</div>

 