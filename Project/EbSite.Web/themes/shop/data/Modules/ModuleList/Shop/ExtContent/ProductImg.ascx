<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductImg.ascx.cs"
    Inherits="EbSite.Modules.Shop.ExtContent.ProductImg" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>

<div >
   
    <div >
      <table cellpadding="0" cellspacing="0">
        <tr>
            <td>
                 <p class="Pa_198 clearfix">
                    图片应小于120k，jpg,gif,jpeg,png或bmp格式。建议为750x750像素</p>

                    <XS:SWFUploadMore Width="350" ID="GoodsImgs" OnUploadComplete="UploadComplete" AddBtnName="设为封面" runat="server" IsMakeSmallImg="true"  AllowExt="jpg,gif,png" AllowSize="2024"  />
            </td>
            <td valign="top">
                
                <div style=" margin-top:65px; border:1px solid #ccc; background-color:#E3E3E3; padding:5px; margin-left:10px; ">
                    <img id="imgsmallimg" runat="server"  width="120" height="120" />
                </div>
                <div style=" text-align:center; margin-top:10px;">封面图</div>
            </td>
        </tr>
      </table>
        
    </div>
</div>
<asp:HiddenField ID="hiSmallimg" runat="server" />
<script>
    //
    function AddBtnName(rowvalueid) {
        var obValue = $("#"+rowvalueid);
        var bigImgUrl = obValue.attr("newname");        
        var smallUrl = <%=GoodsImgs.GetBatchObID() %>.GetMiddlemgFileName(bigImgUrl);
        $("#<%=imgsmallimg.ClientID %>").attr("src",smallUrl);
        $("#<%=hiSmallimg.ClientID %>").val(smallUrl);
    }
    
    function UploadComplete(ob)
    {
        var sSmallImgUrl =  $("#<%=hiSmallimg.ClientID %>").val();
        if($.trim(sSmallImgUrl)=="")
        {
            var bigImg =  <%=GoodsImgs.GetBatchObID() %>.GetValueInputByRowIndex(1);
            var smallUrl = <%=GoodsImgs.GetBatchObID() %>.GetMiddlemgFileName(bigImg);//GetSmallImgFileName
            $("#<%=imgsmallimg.ClientID %>").attr("src",smallUrl);
            $("#<%=hiSmallimg.ClientID %>").val(smallUrl);
        }
    }
</script>