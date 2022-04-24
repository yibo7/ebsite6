<%@ Control Language="C#" AutoEventWireup="true"   CodeBehind="--AddClassSimple.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Class.AddClassSimple" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%@ Register Assembly="EbSite.ControlData" TagPrefix="XSD" Namespace="EbSite.ControlData" %>
<div style=" padding-left:10px;">
<XS:CustomTagsBox ID="ctbTag" runat="server"></XS:CustomTagsBox>
<div id="tg1" >
    <table>
   <tr>
                        <td>
                            <%=Resources.lang.EBParentClass%>:
                        </td>
                        <td>
                            <asp:DropDownList ID="drpClassList" AppendDataBoundItems="true" runat="server">
                                <asp:ListItem Text="一级分类" Value="0"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        
                    </tr>                 
        <asp:PlaceHolder ID="phDefaultFileds" runat="server"></asp:PlaceHolder>                    
    </table>
</div>

<div id="tg2">
<XS:Notes ID="Notes3" Text="可以灵活替换关键词,规则 :#Title# 替换分类名称  #SiteName# 替换网站名称,以下可以保留为空"   runat=server></XS:Notes>
    <table> 
     <tr>
                        <td>
                            Seo标题：
                        </td>
                        <td>
                          <XS:TextBox Width="390" runat="server"  ID="SeoTitle"></XS:TextBox>
                          
                        </td>
    </tr> 
    <tr>
                        <td>
                            seo关键词：
                        </td>
                        <td>
                          <XS:TextBox Width="300" Height="50" TextMode="MultiLine"  runat="server"  ID="SeoKeyWord"></XS:TextBox>
                          
                        </td>
    </tr>     
    <tr>
                        <td>
                            Seo描述：
                        </td>
                        <td>
                          <XS:TextBox Width="300" Height="50" TextMode="MultiLine"  runat="server"  ID="SeoDescription"></XS:TextBox>
                          
                        </td>
    </tr>    
    <tr>
                        <td>
                           一页显示数量：
                        </td>
                        <td>
                          <XS:TextBoxVl ValidateType="大于等于0整数包括0" Width="50" runat="server"  ID="PageSize">0</XS:TextBoxVl>
                          
                        </td>
    </tr>                                
        <asp:PlaceHolder ID="phSeoSet" runat="server"></asp:PlaceHolder>      
        <tr>
                        <td>
                            分类静态面页规则：
                        </td>
                        <td>
                            <XS:UcReNameRule ID="rnHtmlName" Width="380"   runat="server" />
                          
                        </td>
                    </tr>
                    <tr>
                        <td>
                            内容静态面页规则：
                        </td>
                        <td>
                            <XS:UcReNameRule ID="rnHtmlContent" Width="380"   runat="server" />
                           
                        </td>
                    </tr>                              
    </table>
</div>

<div id="tg3">

<XS:Notes ID="Notes2" Text="内容模型与内容模板是尖对当前分类下的内容而设置，添加内容时会默认使用此设置,更改分类模型需要重新打开此页面载入模型"   runat=server></XS:Notes>
    <table>
        <tr>
                        <td>
                            列表版式：
                        </td>
                        <td>
                            <XSD:ClassListTem ID="ListTemID"    runat="server" />
                          
                        </td>
        </tr>
         <tr>
                        <td>
                            分类模型：
                        </td>
                        <td>
                            <XSD:ClassModels ID="ClassModelID"   runat="server" />
                          
                        </td>
        </tr>
        <tr>
                        <td>
                            分类模板：
                        </td>
                        <td>
                            <XSD:ClassTemps ID="ClassTemID"  runat="server" />
                          
                        </td>
        </tr>
         <tr>
                        <td>
                            内容模板：
                        </td>
                        <td>
                            <XSD:ContentTemps ID="ContentTemID"    runat="server" />
                          
                        </td>
        </tr>
        <tr>
                        <td>
                            内容模型：
                        </td>
                        <td>
                            <XSD:ContentModels ID="ContentModelID"    runat="server" />
                          
                        </td>
        </tr>

        <asp:PlaceHolder ID="phModuleAndTem" runat="server"></asp:PlaceHolder>
    </table>
  </div>

<div id="tg4">

<XS:Notes ID="Notes1" Text="如果您不希望当前分类有子分类，不要选择'是否可以添加子分类',同理不要选择添加内容"   runat=server></XS:Notes>
    <table>     
        <tr>
                        <td>
                            是否可以添加子分类：
                        </td>
                        <td>
                            <XS:CheckBox runat="server" Checked="true" ID="IsCanAddSub"></XS:CheckBox>
                          
                        </td>
        </tr>   
        <tr>
                        <td>
                            是否可以添加内容：
                        </td>
                        <td>
                            <XS:CheckBox runat="server" Checked="true" ID="IsCanAddContent"></XS:CheckBox>
                          
                        </td>
        </tr>      
     
        <tr>
                        <td>
                            总点击率：
                        </td>
                        <td>
                            <XS:TextBoxVl  Width="50" ValidateType="大于等于0整数包括0" runat="server"  ID="hits">0</XS:TextBoxVl>
                          
                        </td>
        </tr>       
         <tr>
                        <td>
                            天点击率：
                        </td>
                        <td>
                            <XS:TextBoxVl Width="50" ValidateType="大于等于0整数包括0" runat="server"  ID="dayHits">0</XS:TextBoxVl>
                          
                        </td>
        </tr>          
         <tr>
                        <td>
                            本周点击：
                        </td>
                        <td>
                            <XS:TextBoxVl Width="50" ValidateType="大于等于0整数包括0" runat="server"  ID="weekHits">0</XS:TextBoxVl>
                          
                        </td>
        </tr>          
         <tr>
                        <td>
                            本月点击：
                        </td>
                        <td>
                            <XS:TextBoxVl Width="50" ValidateType="大于等于0整数包括0" runat="server"  ID="monthhits">0</XS:TextBoxVl>
                          
                        </td>
        </tr>  
         <tr>
                        <td>
                            内容扩展(模块选择)：
                        </td>
                        <td>
                           <XSD:ModuleList ID="BingModule" runat="server"></XSD:ModuleList>
                          
                        </td>
        </tr>   
         <tr>
                        <td>
                            
                        </td>
                        <td  >
                         注:默认不用选择,内容扩展选项来自所选模块下的ExtContent扩展文件(为.ascx),当eBsite内容表字段不足够使用时
                         可以对当前分类下的内容表扩展保存数据
                        </td>
        </tr>   
        
        
        <tr>
                        <td>
                            外部连接：
                        </td>
                        <td>
                            <XS:TextBox  runat="server" Width="380"  ID="OutLike"></XS:TextBox>
                          
                        </td>
        </tr>  
                                         
        <asp:PlaceHolder ID="phOrtherFileds" runat="server"></asp:PlaceHolder>     
         <tr>
                        <td colspan="2" style="text-align:center; height:50px;">
                            <asp:CheckBox ID="cbIsContinu"   Text="操作完毕是否返回列表" runat="server" />
                        </td>
                    </tr>                               
    </table>
</div>
<div id="tg5">
    <XS:Notes ID="Notes7" Text="方便子添加子分类默认使用此配置，特别是在子分类很多的情况下，不用一个一个来设置,其中[子分类添加名字]'可修改成您想要的名字，如把[添加子分类]改成[添加歌手]"   runat=server></XS:Notes>
    <table>        
         <tr>
                        <td>
                            子分类添加名字：
                        </td>
                        <td>
                            <XS:TextBox runat="server" ID="SubClassAddName"></XS:TextBox>
                          
                        </td>
        </tr>    

         <tr>
                        <td>
                            子分类模型：
                        </td>
                        <td>
                            <XSD:ClassModels ID="SubClassModelID"  runat="server" />
                          
                        </td>
        </tr>    
        <tr>
                        <td>
                            子分类内容模型：
                        </td>
                        <td>
                            <XSD:ContentModels ID="SubClassTemID"    runat="server" />
                          
                        </td>
        </tr>      
 
         <tr>
                        <td>
                            子分类是否可添加子分类：
                        </td>
                        <td>
                              <XS:CheckBox ID="SubIsCanAddSub"   runat="server" />
                        </td>
        </tr>   
         <tr>
                        <td>
                            子类是否可以添加内容：
                        </td>
                        <td>
                            <XS:CheckBox ID="SubIsCanAddContent"   runat="server" />
                        </td>
        </tr>                       
        <asp:PlaceHolder ID="phSubClassSet" runat="server"></asp:PlaceHolder>   
         <tr>
                        <td style=" display:none" colspan="2">
                            <XS:CheckBox ID="cbConfigsToSub" Visible="false" Text="是否将配置传递给下级分类" runat="server" />
                        </td>
                   </tr>                                 
    </table>
</div>
  <asp:Literal ID="llTagEnd" runat="server"></asp:Literal>

</div>

<div style=" text-align:center; padding:10px;">
 <XS:Button ID="bntSave" Text=" <%$Resources:lang,EBSave%> " runat="server" ValidationGroup="savedata" />
</div>

