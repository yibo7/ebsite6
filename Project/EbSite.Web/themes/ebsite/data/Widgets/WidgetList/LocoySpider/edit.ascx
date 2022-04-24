<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="edit.ascx.cs" Inherits="EbSite.Widgets.LocoySpider.edit" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
选择要采集的字段（不需要采集的字段不用选择，但可以保留一个默认值）:<br>
<div style=" width:800px; ">
     <table id="tbContent">
                 <tr>
                        <td>
                            要入库的分类:
                        </td>
                        <td>
                           <XS:DropDownList ID="drpClass" AppendDataBoundItems="true" AutoPostBack="true" runat="server" 
                                onselectedindexchanged="drpClass_SelectedIndexChanged"></XS:DropDownList>
         或指定分类ID:<XS:TextBox HintInfo="超过500个分类时，不能列表出来，只能指定分类ID" ID="txtIDs" Width="50" runat="server"></XS:TextBox>
                            <asp:Button ID="bntInitModel" runat="server" Text="加载模型" 
                                onclick="bntInitModel_Click" />
                        </td>
                        
                    </tr>
                    
                <asp:PlaceHolder ID="phCustomControls" runat="server"></asp:PlaceHolder>
                  
                    
                   <tr>
                        <td>
                            内容静态面页规则：
                        </td>
                        <td>
                            <XS:UcReNameRule ID="rnHtmlContent" Width="300"   runat="server" />
                           
                        </td>
                    </tr>
                    <tr>
                        <td style="color:Red" colspan="2">
                            注:具体使用方法，请在部件'预览'里查看
                        </td>
                    </tr>
                </table>
</div>
<script>
    var aColumns = [<%=Columns %>];
    if(aColumns.length>0)
    {
           
           $(tbContent).find("input[@type='checkbox']").each(		
		        function(i)
		        {
		            for(var j=0;j<aColumns.length;j++)
		            {
		                var vl = aColumns[j];
		                if(this.value==vl)this.checked = true;
		            }
			        
		        }
		        );
        
    }
</script>